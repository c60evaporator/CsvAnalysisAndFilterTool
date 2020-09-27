using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAnalysisAndFilterTool
{
    class AdditionalClassList
    {
    }

    //グローバル変数
    public static class GlobalVar
    {
        //数値、日時と判定するための必要割合（空欄を除く）
        public static double valueJudgeRatio = 0.9;

        //DateTimeの最小値（"DateTime.MinValue"だとSQLServerで読み込めないため）
        public static DateTime MinDateTime = DateTime.Parse("1900/1/1 0:00:00");
    }
}
