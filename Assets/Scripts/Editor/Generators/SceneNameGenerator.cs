using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class SceneNameGenerator : GeneratorBase
{
    private const string SOURCE_TEMPLATE =@"
#AUTHOR_COMMENT#

public enum SceneNames
{
#ENUM_SCENE_NAME#
}

public class #FILE_NAME#
{
    public static string GetSceneName(SceneNames sceneNames)
    {
        string ret = """";
        switch (sceneNames)
        {
#RETURN_SCENE_NAME#
        }
        return ret;
    }
}
";
    protected override string Code(string generatorFileName)
    {
        StringBuilder sb = new StringBuilder(SOURCE_TEMPLATE);
        sb.Replace("#AUTHOR_COMMENT#", AuthorComment(generatorFileName));
        sb.Replace("#ENUM_SCENE_NAME#", EnumSceneName());
        sb.Replace("#FILE_NAME#", FileName());
        sb.Replace("#RETURN_SCENE_NAME#", ReturnSceneName());
        return sb.ToString();
    }
    protected override string FileName()
    {
        return "SceneName";
    }

    private string EnumSceneName()
    {
        StringBuilder sb = new StringBuilder();
        foreach(var scene in EditorBuildSettings.scenes)
        {
            
            sb.AppendLine(Tab(1) + GetSceneName(scene) + ",");
            
        }
        return sb.ToString();
    }
    private string ReturnSceneName()
    {
        StringBuilder sb = new StringBuilder();
        foreach(var scene in EditorBuildSettings.scenes)
        {
            sb.AppendLine(Tab(3) + "case SceneNames." + GetSceneName(scene) + ":");
            sb.AppendLine(Tab(4) + "ret = \"" + GetSceneName(scene) + "\";");
            sb.AppendLine(Tab(4) + "break;");
        }
        return sb.ToString();
    }
    private string GetSceneName(EditorBuildSettingsScene scene)
    {
        return Path.GetFileNameWithoutExtension(scene.path);
    }
}
