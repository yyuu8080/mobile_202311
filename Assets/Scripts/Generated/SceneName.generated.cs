
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// これは自動生成されたコードです。直接の編集は禁止です。
// 生成元のコードは、SceneNameGenerator.cs です。
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

public enum SceneNames
{
    Top,

}

public class SceneName
{
    public static string GetSceneName(SceneNames sceneNames)
    {
        string ret = "";
        switch (sceneNames)
        {
            case SceneNames.Top:
                ret = "Top";
                break;

        }
        return ret;
    }
}
