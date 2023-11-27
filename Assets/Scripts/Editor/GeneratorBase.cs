using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public abstract class GeneratorBase
{
    // 出力するコードのクラス名（拡張子なし）を記載
    protected abstract string FileName();
    // 出力するコードの中身を記載
    protected abstract string Code(string generatorFileName);
    // 自動実行に含めるか
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
// これは自動生成されたコードです。直接の編集は禁止です。
// 生成元のコードは、" + generatorFileName + @".cs です。
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
        return ret;
    }
    protected string Tab(int repeartCount)
    {
        return string.Concat(Enumerable.Repeat("    ", repeartCount));
    }
}
