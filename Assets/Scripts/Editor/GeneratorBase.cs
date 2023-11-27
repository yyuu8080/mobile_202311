using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public abstract class GeneratorBase
{
    // �o�͂���R�[�h�̃N���X���i�g���q�Ȃ��j���L��
    protected abstract string FileName();
    // �o�͂���R�[�h�̒��g���L��
    protected abstract string Code(string generatorFileName);
    // �������s�Ɋ܂߂邩
    public bool includeAutoGenerate = true;

    public void Generate(string generatorFileName, string generatedDirPath)
    {
        using (StreamWriter writer = new StreamWriter(generatedDirPath + "/" + FileName() + ".generated.cs"))
        {
            writer.Write(Code(generatorFileName));
        }
    }
    protected virtual string AuthorComment(string generatorFileName)
    {
        var ret = @"// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// ����͎����������ꂽ�R�[�h�ł��B���ڂ̕ҏW�͋֎~�ł��B
// �������̃R�[�h�́A" + generatorFileName + @".cs �ł��B
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
        return ret;
    }
    protected string Tab(int repeartCount)
    {
        return string.Concat(Enumerable.Repeat("    ", repeartCount));
    }
}
