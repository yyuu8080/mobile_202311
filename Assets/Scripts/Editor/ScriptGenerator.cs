using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class ScriptGenerator
{
    [MenuItem("Tool/GenerateScript")]
    public static void Generate()
    {
        // Assets/Scripts/Editor/Generators 以下のファイル名を取得
        // for ファイル名をクラスに変換して、Generate実行

        // Generatorファイルの一覧を取得
        string generatorsDirPath = Application.dataPath + "/Scripts/Editor/Generators";
        string[] filePaths = Directory.GetFiles(generatorsDirPath, "*.cs", SearchOption.AllDirectories);

        // 生成
        string generatedDirPath = Application.dataPath + "/Scripts/Generated";
        foreach(string filePath in filePaths)
        {
            // ファイル名から、クラスに変換
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            Type masterType = Type.GetType(fileName);
            GeneratorBase generatorBase = (GeneratorBase)Activator.CreateInstance(masterType);
            if (generatorBase.includeAutoGenerate)
            {
                generatorBase.Generate(fileName, generatedDirPath);
            }
        }

        // ファイル生成したので、Unityのアセットデータベースを更新
        AssetDatabase.Refresh();
    }
}
