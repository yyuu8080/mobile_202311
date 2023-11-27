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
        // Assets/Scripts/Editor/Generators �ȉ��̃t�@�C�������擾
        // for �t�@�C�������N���X�ɕϊ����āAGenerate���s

        // Generator�t�@�C���̈ꗗ���擾
        string generatorsDirPath = Application.dataPath + "/Scripts/Editor/Generators";
        string[] filePaths = Directory.GetFiles(generatorsDirPath, "*.cs", SearchOption.AllDirectories);

        // ����
        string generatedDirPath = Application.dataPath + "/Scripts/Generated";
        foreach(string filePath in filePaths)
        {
            // �t�@�C��������A�N���X�ɕϊ�
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            Type masterType = Type.GetType(fileName);
            GeneratorBase generatorBase = (GeneratorBase)Activator.CreateInstance(masterType);
            if (generatorBase.includeAutoGenerate)
            {
                generatorBase.Generate(fileName, generatedDirPath);
            }
        }

        // �t�@�C�����������̂ŁAUnity�̃A�Z�b�g�f�[�^�x�[�X���X�V
        AssetDatabase.Refresh();
    }
}
