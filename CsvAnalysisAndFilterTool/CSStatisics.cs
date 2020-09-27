using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvAnalysisAndFilterTool
{
    class CSStatistics
    {
        /// <summary>
        /// 分散の計算
        /// </summary>
        /// <param name="values">計算したい配列</param>
        /// <returns></returns>
        public static double CalcVariance(List<double> values)
        {
            //配列の要素数が0のとき、0を返す
            if (values.Count == 0) return 0.0;

            double mean = 0.0;//平均
            double sum2 = 0.0;//自乗和

            //平均値を算出
            mean = values.Sum() / values.Count;

            //自乗和を算出
            foreach (double value in values)
            {
                sum2 += value * value;
            }

            //分散 = 自乗和 / 要素数 - 平均値^2
            double variance = sum2 / values.Count - mean * mean;

            return variance;
        }

        /// <summary>
        /// 標準偏差の計算
        /// </summary>
        /// <param name="values">計算したい配列</param>
        /// <returns></returns>
        public static double CalcStdev(List<double> values)
        {
            double stdev = Math.Sqrt(CalcVariance(values));//分散の平方根
            return stdev;
        }
    }
}