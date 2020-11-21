using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace CsvAnalysisAndFilterTool
{
    class CsvAnalysisAndFilter
    {
        //クラス内変数
        private List<string> NULL_STR_LIST = new List<string>() { "", "null", "nan" };
        private double _allowStrRatio;//文字列許容率（文字列の割合がこの割合を超えなければ数値判定する）
        public string _readCSVPath;//読み込んだ元CSVのパス
        private bool _firstHeaderFlg;//1行目がヘッダーかどうかを表すフラグ
        private int _nRow;//行数
        private int[] _intCount;//整数の数
        private int[] _zeroCount;//0の数
        private int[] _oneCount;//1の数
        private int[] _longCount;//64bit整数の数
        private int[] _doubleCount;//小数の数
        private int[] _DateTimeCount;//日時の数
        private int[] _BooleanCount;//Booleanの数
        private int[] _nullCount;//nullの数
        private bool[] _allSameFlg;//全て同一値かどうかを表すフラグ
        private List<List<int>> _intValueList;//整数データのみ保持したリスト(数値以外はint.MaxValueとして保持)
        private List<List<long>> _longValueList;//64bit整数データのみ保持したリスト(数値以外はlong.MaxValueとして保持)
        private List<List<double>> _doubleValueList;//小数データのみ保持したリスト(数値以外はint.MaxValueとして保持)
        private List<List<DateTime>> _datetimeValueList;//時間データのみ保持したリスト(数値以外はGlobalVar.MinDateTimeとして保持)
        private List<int> _filterFlg;//カラム毎のフィルタ種類のフラグ(0:なし、1:一致、2:ワイルドカード前、3:ワイルドカード後、4:ワイルドカード前後、
                                    //10:上限整数、11:下限整数、12:上下限整数、20:上限64bit整数、21:下限64bit整数、22:上下限64bit整数、
                                    //30:上限小数、31:下限小数、32:上下限小数、40:上限日時、41:下限日時、42:上下限日時)
        private List<string> _searchString;//カラムごとの一致判定文字列のリスト
        private List<double> _upValue;//カラムごとのフィルタ上限値(数値)
        private List<double> _downValue;//カラムごとのフィルタ下限値(数値)
        private List<DateTime> _upDateTime;//カラムごとのフィルタ上限値(日時)
        private List<DateTime> _downDateTime;//カラムごとのフィルタ下限値(日時)
        private List<bool> columnOutputFlg;//
        private ToolStripStatusLabel _toolStripStatusLabel;//処理内容表示用のToolStripStatusLabel
        private StatusStrip _statusStrip;//処理内容表示用のStatusStrip
        private Label _labelReadCsv;//CSV読込完了表示用のラベル
        private Label _labelRowCount;//総行数表示用のラベル
        private DataGridView _dataGridViewReadCsv;//読み込んだCSV表示用DataGridView
        private DataGridView _dataGridViewStats;//型判定と統計値表示用DataGridView
        private DataGridView _dataGridViewExtractColumnsAndFilters;//抽出カラムとフィルタ表示用DataGridView

        //コンストラクタ
        public CsvAnalysisAndFilter(
            double allowStrRatio,
            string readCSVPath,
            ToolStripStatusLabel toolStripStatusLabel,
            StatusStrip StatusStrip,
            Label labelReadCsv,
            Label labelRowCount,
            DataGridView dataGridViewReadCsv,
            DataGridView dataGridViewStats,
            DataGridView dataGridViewExtractColumnsAndFilters)
        {
            _allowStrRatio = allowStrRatio;
            _readCSVPath = readCSVPath;
            _toolStripStatusLabel = toolStripStatusLabel;
            _statusStrip = StatusStrip;
            _labelReadCsv = labelReadCsv;
            _labelRowCount = labelRowCount;
            _dataGridViewReadCsv = dataGridViewReadCsv;
            _dataGridViewStats = dataGridViewStats;
            _dataGridViewExtractColumnsAndFilters = dataGridViewExtractColumnsAndFilters;
        }

        //StatusStrip表示用メソッド
        private void DisplayStatusStrip(string displayString)
        {
            _toolStripStatusLabel.Text = displayString;
            _statusStrip.Refresh();
            Application.DoEvents();//メッセージ・キューにあるWindowsメッセージをすべて処理する(フリーズ対策)
        }

        /// <summary>
        /// 型のカウント
        /// </summary>
        /// <param name="firstHeaderFlg">1行目がヘッダーかどうかを表すフラグ</param>
        public void ParseCount(bool firstHeaderFlg)
        {
            //DataGridViewの初期化
            _dataGridViewStats.Columns.Clear();
            //firstHeaderFlgを読み込み
            _firstHeaderFlg = firstHeaderFlg;

            //CSVファイルを読み込むときに使うEncoding
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

            //CSVが存在するときのみ、読み込む
            if (System.IO.File.Exists(_readCSVPath))//ファイルが存在しているときのみ処理を進める
            {
                //CSVファイルのオープン 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(_readCSVPath, enc))
                {
                    string line = null;//1行読込用変数
                    string[] cells = null;//1行を1マス毎に分割した配列
                    string[] headerNames = null;//列名保持用
                    int nCol = 0;//カラム数
                    string[] firstRow = null;//1行目保持用（全行同一値の判定用）
                    int rowCount = 0;//行数カウント

                    //1行目がヘッダーのとき、1行目を読み込んでヘッダー名に登録
                    if (firstHeaderFlg)
                    {
                        line = sr.ReadLine();//1行読込
                        headerNames = line.Split(',');
                        nCol = headerNames.Length;//カラム数保持
                    }

                    //型の判定用変数
                    int tmpi = 0;//int用
                    long tmpl = 0;//long用
                    double tmpd = 0.0;//double用
                    DateTime tmpdt = new DateTime();//DateTime用
                    Boolean tmpb = false;//Boolean用

                    //CSVを1行ずつ読み込み、型の判定
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();//1行読込
                        cells = line.Split(',');

                        //最初の行の処理
                        if (rowCount == 0)
                        {
                            firstRow = line.Split(',');
                            //1行目がヘッダーでないとき、カラム数保持＆ヘッダー名は列カウントを登録
                            if (!firstHeaderFlg)
                            {
                                nCol = cells.Length;
                                headerNames = Enumerable.Range(1, nCol).Select(a => a.ToString()).ToArray();
                            }
                            //各種変数の初期化
                            _intCount = new int[nCol];
                            _zeroCount = new int[nCol];
                            _oneCount = new int[nCol];
                            _longCount = new int[nCol];
                            _doubleCount = new int[nCol];
                            _DateTimeCount = new int[nCol];
                            _BooleanCount = new int[nCol];
                            _nullCount = new int[nCol];
                            _allSameFlg = new bool[nCol];
                            rowCount = 0;
                            for (int j = 0; j < nCol; j++)
                            {
                                _intCount[j] = 0;
                                _zeroCount[j] = 0;
                                _oneCount[j] = 0;
                                _longCount[j] = 0;
                                _doubleCount[j] = 0;
                                _DateTimeCount[j] = 0;
                                _BooleanCount[j] = 0;
                                _nullCount[j] = 0;
                                _allSameFlg[j] = true;
                            }
                        }

                        //1カラムごとに判定
                        for (int j = 0; j < nCol; j++)
                        {
                            //null判定
                            if (NULL_STR_LIST.Contains(cells[j])) _nullCount[j]++;
                            //全行同一値の判定
                            if (cells[j] != firstRow[j]) _allSameFlg[j] = false;
                            //整数intの判定
                            if (int.TryParse(cells[j], out tmpi))
                            {
                                _intCount[j]++;
                                if (tmpi == 0) _zeroCount[j]++;//0は別途カウント
                                else if (tmpi == 1) _oneCount[j]++;//1は別途カウント
                            }
                            //64bit整数longの判定
                            else if (long.TryParse(cells[j], out tmpl))
                            {
                                _longCount[j]++;
                            }
                            //小数doubleの判定
                            else if (double.TryParse(cells[j], out tmpd))
                            {
                                _doubleCount[j]++;
                                if (tmpd == 0) _zeroCount[j]++;//0は別途カウント
                                else if (tmpd == 1) _oneCount[j]++;//1は別途カウント
                            }
                            //日時DateTimeの判定
                            else if (DateTime.TryParse(cells[j], out tmpdt))
                            {
                                _DateTimeCount[j]++;
                            }
                            //Boolean判定
                            else if (Boolean.TryParse(cells[j], out tmpb))
                            {
                                _BooleanCount[j]++;
                            }
                        }
                        rowCount++;//行カウントをプラス
                        //処理している行数を表示
                        if (rowCount % 100 == 0) DisplayStatusStrip("型の判定中" + rowCount.ToString() + "行目");
                    }

                    //行数の保持と表示
                    _nRow = rowCount;
                    _labelRowCount.Text = "総行数" + rowCount.ToString();

                    //型の判定結果の表示
                    // データテーブルの作成
                    DataTable dataTableStats = new DataTable();
                    //カラム番号をセット
                    for (int j = 0; j < nCol; j++)
                    {
                        dataTableStats.Columns.Add((j + 1).ToString());
                    }
                    //カラム名をセット
                    DataRow row = dataTableStats.NewRow();
                    for (int j = 0; j < nCol; j++)
                    {
                        row[j] = headerNames[j];
                    }
                    dataTableStats.Rows.Add(row);
                    //型カウント結果をセット
                    row = dataTableStats.NewRow();
                    for (int j = 0; j < nCol; j++)
                    {
                        if ((double)_nullCount[j] / rowCount == 1) row[j] = "全て空白";
                        else if ((double)_zeroCount[j] / rowCount == 1) row[j] = "全て0";
                        else if (_allSameFlg[j]) row[j] = "全て同一値「" + firstRow[j] + "」";
                        else if ((double)(_zeroCount[j] + _oneCount[j]) / (rowCount - _nullCount[j]) == 1) row[j] = "Boolean";//ブーリアン（0 or 1のみのとき）
                        else if ((double)_BooleanCount[j] / (rowCount - _nullCount[j]) == 1) row[j] = "Boolean";//ブーリアン（true or falseからParse）
                        else if ((double)_intCount[j] / (rowCount - _nullCount[j]) >= 1 - _allowStrRatio && _longCount[j] == 0 && _doubleCount[j] == 0) row[j] = "整数";
                        else if ((double)(_intCount[j] + _longCount[j]) / (rowCount - _nullCount[j]) >= 1 - _allowStrRatio && _doubleCount[j] == 0) row[j] = "64bit整数";
                        else if ((double)(_intCount[j] + _longCount[j] + _doubleCount[j]) / (rowCount - _nullCount[j]) >= 1 - _allowStrRatio) row[j] = "小数";
                        else if ((double)_DateTimeCount[j] / (rowCount - _nullCount[j]) >= 1 - _allowStrRatio) row[j] = "日時";
                        else row[j] = "文字列";
                    }
                    dataTableStats.Rows.Add(row);
                    //個々の型の割合
                    for (int i = 0; i < 8; i++)
                    {
                        row = dataTableStats.NewRow();
                        for (int j = 0; j < nCol; j++)
                        {
                            if (i == 0) row[j] = ((double)_intCount[j] / rowCount * 100).ToString("f1") + "%";//整数の割合
                            if (i == 1) row[j] = ((double)_longCount[j] / rowCount * 100).ToString("f1") + "%";//64bit整数の割合
                            if (i == 2) row[j] = ((double)_doubleCount[j] / rowCount * 100).ToString("f1") + "%";//小数の割合
                            if (i == 3) row[j] = ((double)_zeroCount[j] / rowCount * 100).ToString("f1") + "%";//0の割合
                            if (i == 4) row[j] = ((double)_oneCount[j] / rowCount * 100).ToString("f1") + "%";//1の割合
                            if (i == 5) row[j] = ((double)_DateTimeCount[j] / rowCount * 100).ToString("f1") + "%";//日時の割合
                            if (i == 6) row[j] = ((double)_BooleanCount[j] / rowCount * 100).ToString("f1") + "%";//Booleanの割合
                            if (i == 7) row[j] = ((double)_nullCount[j] / rowCount * 100).ToString("f1") + "%";//nullの割合
                        }
                        dataTableStats.Rows.Add(row);
                    }
                    //DataGridViewに登録
                    _dataGridViewStats.DataSource = dataTableStats;

                    //行ヘッダーの表示
                    _dataGridViewStats.Rows[0].HeaderCell.Value = "列名";
                    _dataGridViewStats.Rows[1].HeaderCell.Value = "型判定結果";
                    _dataGridViewStats.Rows[2].HeaderCell.Value = "整数の割合";
                    _dataGridViewStats.Rows[3].HeaderCell.Value = "64bit整数割合";
                    _dataGridViewStats.Rows[4].HeaderCell.Value = "小数の割合";
                    _dataGridViewStats.Rows[5].HeaderCell.Value = "0の割合";
                    _dataGridViewStats.Rows[6].HeaderCell.Value = "1の割合";
                    _dataGridViewStats.Rows[7].HeaderCell.Value = "日時の割合";
                    _dataGridViewStats.Rows[8].HeaderCell.Value = "Booleanの割合";
                    _dataGridViewStats.Rows[9].HeaderCell.Value = "nullの割合";
                    //行ヘッダーの幅を調節する
                    _dataGridViewStats.RowHeadersWidth = 120;
                    //先頭行を太字に
                    _dataGridViewStats.Rows[0].DefaultCellStyle.Font = new Font(_dataGridViewStats.DefaultCellStyle.Font, FontStyle.Bold);
                    //先頭行と2行目（型判定）の固定
                    _dataGridViewStats.Rows[0].Frozen = true;
                    _dataGridViewStats.Rows[1].Frozen = true;
                    //読込完了を表示
                    DisplayStatusStrip("型のカウント完了");
                    _dataGridViewStats.Text = "型判定結果";
                }
            }
        }

        //数値データの保持と、統計値(最大、最小、平均、メディアン、1/4分位点、標準偏差)の算出
        public void CalcStats()
        {
            //型の判定をしていない場合、メッセージを出して終了
            if (_dataGridViewStats.Columns.Count == 0)
            {
                MessageBox.Show("先に型の判定をしてください");
                return;
            }

            //フィルタ用DataGridViewの初期化
            _dataGridViewExtractColumnsAndFilters.Columns.Clear();
            
            //統計値DataGridViewのデータ取得
            DataTable dataTableStats = (DataTable)_dataGridViewStats.DataSource;

            //各種変数の宣言
            int nCol = dataTableStats.Columns.Count;//列数
            int rowCount = 0;//行数カウント用変数
            List<bool> intCalcFlg = new List<bool>();//その列が整数データかどうかを表すフラグ
            List<bool> longCalcFlg = new List<bool>();//その列が64bit整数データかどうかを表すフラグ
            List<bool> doubleCalcFlg = new List<bool>();//その列が小数データかどうかを表すフラグ
            List<bool> datetimeCalcFlg = new List<bool>();//その列が日時データかどうかを表すフラグ
            DateTime maxDateTime = DateTime.MaxValue;
            //型の判定用変数
            int tmpi = 0;//int用
            long tmpl = 0;//long用
            double tmpd = 0.0;//double用
            DateTime tmpdt = new DateTime();//DateTime用          

            //数値データ保持用リストの初期化
            _intValueList = new List<List<int>>();//整数データ保持用リスト
            _longValueList = new List<List<long>>();//64bit整数データ保持用リスト
            _doubleValueList = new List<List<double>>();//小数データ保持用リスト
            _datetimeValueList = new List<List<DateTime>>(); ;//日時データ保持用リスト

            //カラムを走査し、数値データ保持用リストを初期化＆各種数値保持対象フラグの判定
            for (int j = 0; j < nCol; j++)
            {
                //そのカラムの数値データ保持用リスト
                List<int> intValueCol = new List<int>();
                List<long> longValueCol = new List<long>();
                List<double> doubleValueCol = new List<double>();
                List<DateTime> datetimeValueCol = new List<DateTime>();
                _intValueList.Add(intValueCol);
                _longValueList.Add(longValueCol);
                _doubleValueList.Add(doubleValueCol);
                _datetimeValueList.Add(datetimeValueCol);

                //各種数値保持対象フラグの判定
                //整数のとき
                if (dataTableStats.Rows[1][j].ToString() == "整数") intCalcFlg.Add(true);
                else intCalcFlg.Add(false);
                //64bit整数のとき
                if (dataTableStats.Rows[1][j].ToString() == "64bit整数") longCalcFlg.Add(true);
                else longCalcFlg.Add(false);
                //小数のとき
                if (dataTableStats.Rows[1][j].ToString() == "小数") doubleCalcFlg.Add(true);
                else doubleCalcFlg.Add(false);
                //日時のとき
                if (dataTableStats.Rows[1][j].ToString() == "日時") datetimeCalcFlg.Add(true);
                else datetimeCalcFlg.Add(false);
            }

            //CSVファイルを読み込むときに使うEncoding
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

            //CSVが存在するときのみ、読み込む
            if (System.IO.File.Exists(_readCSVPath))//ファイルが存在しているときのみ処理を進める
            {
                //CSVファイルのオープン 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(_readCSVPath, enc))
                {
                    string line = null;//1行読込用変数
                    string[] cells = null;//1行を1マス毎に分割した配列

                    //1行目がヘッダーのとき、数値に含めない
                    if (_firstHeaderFlg) line = sr.ReadLine();//1行進める

                    ////////CSVを1行ずつ読み込み、型の判定と数値の読込/////////
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();//1行読込
                        cells = line.Split(',');
                        rowCount++;
                        //カラムごとに判定
                        for (int j = 0; j < nCol; j++)
                        {
                            //整数intの判定
                            if (intCalcFlg[j])
                            {
                                if (int.TryParse(cells[j], out tmpi))
                                {
                                    _intValueList[j].Add(tmpi);
                                }
                                else _intValueList[j].Add(int.MaxValue);
                            }
                            //64bit整数longの判定
                            else if (longCalcFlg[j])
                            {
                                if (long.TryParse(cells[j], out tmpl))
                                {
                                    _longValueList[j].Add(tmpl);
                                }
                                else _longValueList[j].Add(long.MaxValue);
                            }
                            //小数doubleの判定
                            else if (doubleCalcFlg[j])
                            {
                                if (double.TryParse(cells[j], out tmpd))
                                {
                                    _doubleValueList[j].Add(tmpd);
                                }
                                else _doubleValueList[j].Add(double.MaxValue);
                            }
                            //日時DateTimeの判定
                            else if (datetimeCalcFlg[j])
                            {
                                if (DateTime.TryParse(cells[j], out tmpdt))
                                {
                                    _datetimeValueList[j].Add(tmpdt);
                                }
                                else _datetimeValueList[j].Add(maxDateTime);
                            }
                        }
                        //処理している行数を表示
                        if (rowCount % 100 == 0)
                        {
                            DisplayStatusStrip("数値の読込中" + rowCount.ToString() + "/" + _nRow.ToString() + "行目");
                        }
                    }
                }
                //いったんガベージコレクションでメモリに空きを作る
                GC.Collect();

                /////////統計値の算出/////////
                //最小
                DisplayStatusStrip("最小値の算出中");
                DataRow row = dataTableStats.NewRow();
                for (int j = 0; j < nCol; j++)
                {
                    //整数
                    if (intCalcFlg[j])
                    {
                        row[j] = _intValueList[j].Where(a => a != int.MaxValue).Min().ToString();
                    }
                    //64bit整数
                    else if (longCalcFlg[j])
                    {
                        row[j] = _longValueList[j].Where(a => a != long.MaxValue).Min().ToString();
                    }
                    //小数
                    else if (doubleCalcFlg[j])
                    {
                        row[j] = _doubleValueList[j].Where(a => a != double.MaxValue).Min().ToString("f4");
                    }
                    //日時
                    else if (datetimeCalcFlg[j])
                    {
                        row[j] = _datetimeValueList[j].Where(a => a != maxDateTime).Min().ToString();
                    }
                }
                dataTableStats.Rows.Add(row);

                //最大
                DisplayStatusStrip("最大値の算出中");
                row = dataTableStats.NewRow();
                for (int j = 0; j < nCol; j++)
                {
                    //整数
                    if (intCalcFlg[j])
                    {
                        row[j] = _intValueList[j].Where(a => a != int.MaxValue).Max().ToString();
                    }
                    //64bit整数
                    if (longCalcFlg[j])
                    {
                        row[j] = _longValueList[j].Where(a => a != long.MaxValue).Max().ToString();
                    }
                    //小数
                    else if (doubleCalcFlg[j])
                    {
                        row[j] = _doubleValueList[j].Where(a => a != double.MaxValue).Max().ToString("f4");
                    }
                    //日時
                    else if (datetimeCalcFlg[j])
                    {
                        row[j] = _datetimeValueList[j].Where(a => a != maxDateTime).Max().ToString();
                    }
                }
                dataTableStats.Rows.Add(row);

                //平均
                DisplayStatusStrip("平均値の算出中");
                row = dataTableStats.NewRow();
                for (int j = 0; j < nCol; j++)
                {
                    //整数
                    if (intCalcFlg[j])
                    {
                        row[j] = _intValueList[j].Where(a => a != int.MaxValue).Average().ToString("f4");
                    }
                    //64bit整数
                    if (longCalcFlg[j])
                    {
                        row[j] = _longValueList[j].Where(a => a != long.MaxValue).Average().ToString("f4");
                    }
                    //小数
                    else if (doubleCalcFlg[j])
                    {
                        row[j] = _doubleValueList[j].Where(a => a != double.MaxValue).Average().ToString("f4");
                    }
                }
                dataTableStats.Rows.Add(row);

                //標準偏差
                DisplayStatusStrip("標準偏差の算出中");
                row = dataTableStats.NewRow();
                for (int j = 0; j < nCol; j++)
                {
                    //整数
                    if (intCalcFlg[j])
                    {
                        //intのみ抜き出し(null除去)
                        var intList = _intValueList[j].Where(a => a != int.MaxValue).ToList();
                        //double型に変換
                        List<double> intToDoubleList = new List<double>();
                        foreach (var intvalue in intList) intToDoubleList.Add((double)intvalue);
                        //標準偏差算出
                        row[j] = CSStatistics.CalcStdev(intToDoubleList).ToString("f4");
                    }
                    //64bit整数
                    if (longCalcFlg[j])
                    {
                        //longのみ抜き出し(null除去)
                        var longList = _longValueList[j].Where(a => a != long.MaxValue).ToList();
                        //double型に変換
                        List<double> longToDoubleList = new List<double>();
                        foreach (var longvalue in longList) longToDoubleList.Add((double)longvalue);
                        //標準偏差算出
                        row[j] = CSStatistics.CalcStdev(longToDoubleList).ToString("f4");
                    }
                    //小数
                    else if (doubleCalcFlg[j])
                    {
                        //doubleのみ抜き出し(null除去)
                        var doubleList = _doubleValueList[j].Where(a => a != double.MaxValue).ToList();
                        //標準偏差算出
                        row[j] = CSStatistics.CalcStdev(doubleList).ToString("f4");
                    }
                    //ガベージコレクションでメモリに空きを作る
                    GC.Collect();
                }
                dataTableStats.Rows.Add(row);

                //メディアン、1/4分位点、3/4分位点
                DisplayStatusStrip("メディアンの算出中");
                DataRow rowMedian = dataTableStats.NewRow();
                DataRow rowQuarter = dataTableStats.NewRow();
                DataRow rowThreeQuarters = dataTableStats.NewRow();
                for (int j = 0; j < nCol; j++)
                {
                    //整数
                    if (intCalcFlg[j])
                    {
                        var intList = _intValueList[j].Where(a => a != int.MaxValue).ToList();
                        intList.Sort();
                        rowMedian[j] = intList[intList.Count / 2].ToString();
                        rowQuarter[j] = intList[intList.Count / 4].ToString();
                        rowThreeQuarters[j] = intList[intList.Count * 3 / 4].ToString();
                    }
                    //64bit整数
                    if (longCalcFlg[j])
                    {
                        var longList = _longValueList[j].Where(a => a != long.MaxValue).ToList();
                        longList.Sort();
                        rowMedian[j] = longList[longList.Count / 2].ToString();
                        rowQuarter[j] = longList[longList.Count / 4].ToString();
                        rowThreeQuarters[j] = longList[longList.Count * 3 / 4].ToString();
                    }
                    //小数
                    else if (doubleCalcFlg[j])
                    {
                        var doubleList = _doubleValueList[j].Where(a => a != double.MaxValue).ToList();
                        doubleList.Sort();
                        rowMedian[j] = doubleList[doubleList.Count / 2];
                        rowQuarter[j] = doubleList[doubleList.Count / 4];
                        rowThreeQuarters[j] = doubleList[doubleList.Count * 3 / 4];
                    }
                    //日時
                    else if (datetimeCalcFlg[j])
                    {
                        var datetimeList = _datetimeValueList[j].Where(a => a != maxDateTime).ToList();
                        datetimeList.Sort();
                        rowMedian[j] = datetimeList[datetimeList.Count / 2];
                        rowQuarter[j] = datetimeList[datetimeList.Count / 4];
                        rowThreeQuarters[j] = datetimeList[datetimeList.Count * 3 / 4];
                    }
                    //ガベージコレクションでメモリに空きを作る
                    GC.Collect();
                }
                dataTableStats.Rows.Add(rowMedian);
                dataTableStats.Rows.Add(rowQuarter);
                dataTableStats.Rows.Add(rowThreeQuarters);

                //行ヘッダーの表示
                _dataGridViewStats.Rows[10].HeaderCell.Value = "最小";
                _dataGridViewStats.Rows[11].HeaderCell.Value = "最大";
                _dataGridViewStats.Rows[12].HeaderCell.Value = "平均";
                _dataGridViewStats.Rows[13].HeaderCell.Value = "標準偏差";
                _dataGridViewStats.Rows[14].HeaderCell.Value = "メディアン";
                _dataGridViewStats.Rows[15].HeaderCell.Value = "1/4分位点";
                _dataGridViewStats.Rows[16].HeaderCell.Value = "3/4分位点";
                //フィルタの表示生成
                DisplayFilters();
                //ガベージコレクションでメモリに空きを作る
                GC.Collect();
                //算出完了を表示
                DisplayStatusStrip("統計値算出完了");
                //labelCalcStats.Text = "各種統計値";
            }
        }

        //フィルタの表示生成(チェックボックス表示のためデータバインドはしない)
        private void DisplayFilters()
        {
            //型の判定をしていない場合、メッセージを出して終了
            if (_dataGridViewStats.Columns.Count == 0)
            {
                MessageBox.Show("先に型の判定をしてください");
                return;
            }
            //各種変数の宣言
            int nCol = _dataGridViewStats.Columns.Count;//列数

            //カラム番号をセット
            for (int j = 0; j < nCol; j++)
            {
                _dataGridViewExtractColumnsAndFilters.Columns.Add((j + 1).ToString(), (j + 1).ToString());
            }
            //カラム名をセット
            DataGridViewRow nameRow = new DataGridViewRow();
            for (int j = 0; j < _dataGridViewExtractColumnsAndFilters.Columns.Count; j++)
            {
                DataGridViewTextBoxCell nameCell = new DataGridViewTextBoxCell();
                nameCell.Value = _dataGridViewStats[j, 0].Value.ToString();
                nameRow.Cells.Add(nameCell);
            }
            _dataGridViewExtractColumnsAndFilters.Rows.Add(nameRow);
            //カラム抽出用チェックボックスの生成
            DataGridViewRow chkRow = new DataGridViewRow();
            for (int j = 0; j < nCol; j++)
            {
                DataGridViewCheckBoxCell chkCell = new DataGridViewCheckBoxCell();
                chkCell.Value = true;
                chkRow.Cells.Add(chkCell);
            }
            _dataGridViewExtractColumnsAndFilters.Rows.Add(chkRow);

            //フィルタの生成
            for (int i = 0; i < 3; i++)
            {
                DataGridViewRow filterRow = new DataGridViewRow();
                for (int j = 0; j < _dataGridViewExtractColumnsAndFilters.Columns.Count; j++)
                {
                    DataGridViewTextBoxCell filterCell = new DataGridViewTextBoxCell();
                    filterCell.Value = "";
                    filterRow.Cells.Add(filterCell);
                }
                _dataGridViewExtractColumnsAndFilters.Rows.Add(filterRow);
            }

            //行ヘッダーの表示
            _dataGridViewExtractColumnsAndFilters.Rows[0].HeaderCell.Value = "列名";
            _dataGridViewExtractColumnsAndFilters.Rows[1].HeaderCell.Value = "列出力有無";
            _dataGridViewExtractColumnsAndFilters.Rows[2].HeaderCell.Value = "一致フィルタ";
            _dataGridViewExtractColumnsAndFilters.Rows[3].HeaderCell.Value = "上限フィルタ";
            _dataGridViewExtractColumnsAndFilters.Rows[4].HeaderCell.Value = "下限フィルタ";
            //行ヘッダーの幅を調節する
            _dataGridViewExtractColumnsAndFilters.RowHeadersWidth = 120;
        }

        //読み込んだCSVの最初1000行表示
        public void RefreshReadCSVDataGrid(Encoding enc)
        {
            //CSVが存在するときのみ、読み込む
            if (System.IO.File.Exists(_readCSVPath))//ファイルが存在しているときのみ処理を進める
            {
                //CSVファイルのオープン 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(_readCSVPath, enc))
                {
                    string line = null;//1行読込用変数
                    string[] cells = null;//1行を1マス毎に分割した配列
                    int nCol = 0;//カラム数
                    int rowCnt = 0;//行数のカウント

                    // データテーブルの作成
                    DataTable dataTableReadCSV = new DataTable();

                    //1行目の読込
                    line = sr.ReadLine();//1行読込
                    cells = line.Split(',');
                    if (!_firstHeaderFlg) rowCnt++;
                    //カラム数保持
                    nCol = cells.Length;
                    //カラム番号をセット
                    for (int j = 0; j < nCol; j++)
                    {
                        dataTableReadCSV.Columns.Add((j + 1).ToString());
                    }
                    //カラム名をセット
                    DataRow row = dataTableReadCSV.NewRow();
                    for (int j = 0; j < nCol; j++)
                    {
                        row[j] = cells[j];
                    }
                    dataTableReadCSV.Rows.Add(row);

                    //CSVをデータテーブルに格納
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine();//1行読込
                        cells = line.Split(',');
                        row = dataTableReadCSV.NewRow();
                        //全列走査してデータテーブルに格納
                        for (int j = 0; j < nCol; j++)
                        {
                            row[j] = cells[j];
                        }
                        dataTableReadCSV.Rows.Add(row);
                        rowCnt++;

                        //処理している行数を表示
                        if (rowCnt % 10 == 0)
                        {
                            DisplayStatusStrip(rowCnt.ToString());
                        }
                        //行数が1000を超えたら読込終了
                        if (rowCnt > 1000 - 1) break;
                    }
                    //データグリッドにデータテーブルを登録
                    _dataGridViewReadCsv.DataSource = dataTableReadCSV;

                    //行ヘッダーに「列名」と表示
                    _dataGridViewReadCsv.Rows[0].HeaderCell.Value = "列名";
                    //行ヘッダーの幅を調節する
                    _dataGridViewReadCsv.RowHeadersWidth = 100;
                    //行ヘッダを何行目(0スタート)から書き始めるか（1行目がヘッダのときは1、ヘッダでないときは0）
                    int headerStartRow = 0;
                    if (_firstHeaderFlg) headerStartRow = 1;
                    //行ヘッダーに行番号を表示
                    for (int i = 0; i < rowCnt; i++)
                    {
                        //行ヘッダーに行番号を表示
                        _dataGridViewReadCsv.Rows[i + headerStartRow].HeaderCell.Value = (i + 1).ToString();
                    }

                    //読込完了を表示
                    DisplayStatusStrip("読込完了");
                    _labelReadCsv.Text = "読み込んだCSV(上位1000行表示)";
                }
            }
        }


        //DataGridViewからフィルタの読み込み
        public bool ReadFilters()
        {
            int nCol = _dataGridViewStats.Columns.Count;//カラム数

            //型の判定用変数
            int tmpi = 0;//int用
            long tmpl = 0;//long用
            double tmpd = 0.0;//double用
            DateTime tmpdt = new DateTime();//DateTime用
            //各リストに初期値を入力
            _searchString = new List<string>();
            _upValue = new List<double>();
            _downValue = new List<double>();
            _upDateTime = new List<DateTime>();
            _downDateTime = new List<DateTime>();
            _filterFlg = new List<int>();
            for (int j = 0; j < nCol; j++)
            {
                _searchString.Add(null);
                _upValue.Add(double.MaxValue);
                _downValue.Add(double.MinValue);
                _upDateTime.Add(DateTime.MaxValue);
                _downDateTime.Add(DateTime.MinValue);
            }

            ////全カラムを走査し、フィルタ内容をリストに入力////
            for (int j = 0; j < nCol; j++)
            {
                //一致、上限、下限のセルに入力されている値を取得
                string matchCell = (string)_dataGridViewExtractColumnsAndFilters[j, 2].Value;
                string upCell = (string)_dataGridViewExtractColumnsAndFilters[j, 3].Value;
                string downCell = (string)_dataGridViewExtractColumnsAndFilters[j, 4].Value;
                //nullの場合空欄に変える
                if (matchCell == null) matchCell = "";
                if (upCell == null) upCell = "";
                if (downCell == null) downCell = "";

                //1. 何も入力されていないとき
                if (matchCell.Length == 0 &&
                    upCell.Length == 0 &&
                    downCell.Length == 0)
                {
                    _filterFlg.Add(0);
                }

                //2. 一致フィルタと上下限フィルタが同時に入力されている場合、指定不可メッセージを出して終了
                if (matchCell.Length > 0 &&
                (upCell.Length > 0 || downCell.Length > 0))
                {
                    MessageBox.Show("一致フィルタと上下限フィルタを同時に入力しないでください " + (j + 1).ToString() + "列目");
                    GC.Collect();
                    return false;
                }

                //3. 一致フィルタのとき
                else if (matchCell.Length > 0)
                {
                    int stLength = matchCell.Length;
                    //1 ワイルドカードなし
                    if (matchCell.IndexOf('*') < 0)
                    {
                        _filterFlg.Add(1);
                        _searchString[j] = matchCell;
                    }
                    //2 ワイルドカード前
                    else if (matchCell.IndexOf('*') == 0 &&
                        matchCell.Split('*').Length == 2)
                    {
                        _filterFlg.Add(2);
                        _searchString[j] = matchCell.Substring(1, stLength - 1);
                    }
                    //3 ワイルドカード後
                    else if (matchCell.IndexOf('*') == stLength - 1 &&
                        matchCell.Split('*').Length == 2)
                    {
                        _filterFlg.Add(3);
                        _searchString[j] = matchCell.Substring(0, stLength - 1);
                    }
                    //4 ワイルドカード前後
                    else if (matchCell.IndexOf('*') == 0 &&
                        matchCell.Substring(stLength - 1, 1) == "*" &&
                        matchCell.Split('*').Length == 3)
                    {
                        _filterFlg.Add(4);
                        _searchString[j] = matchCell.Substring(1, stLength - 2);
                    }
                    //1～4どれでもないとき、エラーを出す
                    else
                    {
                        MessageBox.Show("ワイルドカードの指定方法が間違っています。「*文字列」「文字列*」「*文字列*」のどれかにしてください " + (j + 1).ToString() + "列目");
                        return false;
                    }
                }

                //4. 上限フィルタ
                else if (upCell.Length > 0)
                {
                    //数値のとき
                    if (_dataGridViewStats[j, 1].Value.ToString() == "整数"
                        || _dataGridViewStats[j, 1].Value.ToString() == "64bit整数"
                        || _dataGridViewStats[j, 1].Value.ToString() == "小数")
                    {
                        //上限に入力された値が数値のとき、処理を進める
                        if (double.TryParse(upCell, out tmpd))
                        {
                            _upValue[j] = tmpd;
                            //下限が入力されているとき
                            if (downCell.Length > 0)
                            {
                                //下限に入力された値が数値のとき、「整数上下限:12」「64bit整数上下限:22」「小数上下限:32」を入力
                                if (double.TryParse(downCell, out tmpd))
                                {
                                    _downValue[j] = tmpd;
                                    if (_dataGridViewStats[j, 1].Value.ToString() == "整数") _filterFlg.Add(12);
                                    else if (_dataGridViewStats[j, 1].Value.ToString() == "64bit整数") _filterFlg.Add(22);
                                    else _filterFlg.Add(32);
                                    //上限より下限が大きいとき、処理を打ち切り
                                    if (_downValue[j] > _upValue[j])
                                    {
                                        MessageBox.Show("上限より下限の方が大きいです " + (j + 1).ToString() + "列目");
                                        return false;
                                    }
                                }
                                //上下限に入力されたのが数値でないとき、処理を打ち切り
                                else
                                {
                                    MessageBox.Show("下限には数値を指定してください " + (j + 1).ToString() + "列目");
                                    return false;
                                }
                            }
                            //下限が入力されていないとき、「整数上限のみ:10」「64bit整数上限のみ:20」「小数上限のみ:30」を入力
                            else
                            {
                                if (_dataGridViewStats[j, 1].Value.ToString() == "整数") _filterFlg.Add(10);
                                else if (_dataGridViewStats[j, 1].Value.ToString() == "64bit整数") _filterFlg.Add(2);
                                else _filterFlg.Add(30);
                            }
                        }
                        //上限に入力されたのが数値でないとき、処理を打ち切り
                        else
                        {
                            MessageBox.Show("上限には数値を指定してください " + (j + 1).ToString() + "列目");
                            return false;
                        }
                    }
                    //日時のとき
                    else if (_dataGridViewStats[j, 1].Value.ToString() == "日時")
                    {
                        //上限に入力された値が日時のとき、処理を進める
                        if (DateTime.TryParse(upCell, out tmpdt))
                        {
                            _upDateTime[j] = tmpdt;
                            //下限が入力されているとき
                            if (downCell.Length > 0)
                            {
                                //下限に入力された値が数値のとき、「日時上下限:42」を入力
                                if (DateTime.TryParse(downCell, out tmpdt))
                                {
                                    _downDateTime[j] = tmpdt;
                                    _filterFlg.Add(42);
                                    //上限より下限が大きいとき、処理を打ち切り
                                    if (_downDateTime[j] > _upDateTime[j])
                                    {
                                        MessageBox.Show("上限より下限の方が大きいです " + (j + 1).ToString() + "列目");
                                        return false;
                                    }
                                }
                                //上下限に入力されたのが日時でないとき、処理を打ち切り
                                else
                                {
                                    MessageBox.Show("下限には日時を指定してください " + (j + 1).ToString() + "列目");
                                    return false;
                                }
                            }
                            //下限が入力されていないとき、「日時上限のみ40」を入力
                            else
                            {
                                _filterFlg.Add(40);
                            }
                        }
                        //上限に入力されたのが日時でないとき、処理を打ち切り
                        else
                        {
                            MessageBox.Show("上限には日時を指定してください " + (j + 1).ToString() + "列目");
                            return false;
                        }
                    }
                    //数値、日時でないとき、処理を打ち切り
                    else
                    {
                        MessageBox.Show("数値、日時以外の列に上限を入力しないでください " + (j + 1).ToString() + "列目");
                        return false;
                    }
                }

                //5. 下限フィルタ
                else if (downCell.Length > 0)
                {
                    //数値のとき
                    if (_dataGridViewStats[j, 1].Value.ToString() == "整数"
                        || _dataGridViewStats[j, 1].Value.ToString() == "64bit整数"
                        || _dataGridViewStats[j, 1].Value.ToString() == "小数")
                    {
                        //下限に入力された値が数値のとき、「整数下限のみ:11」「64bit整数下限のみ:21」「小数下限のみ:31」を入力
                        if (double.TryParse(downCell, out tmpd))
                        {
                            _downValue[j] = tmpd;
                            if (_dataGridViewStats[j, 1].Value.ToString() == "整数") _filterFlg.Add(11);
                            else if (_dataGridViewStats[j, 1].Value.ToString() == "64bit整数") _filterFlg.Add(21);
                            else _filterFlg.Add(31);
                        }
                        //上下限に入力されたのが数値でないとき、処理を打ち切り
                        else
                        {
                            MessageBox.Show("下限には数値を指定してください " + (j + 1).ToString() + "列目");
                            return false;
                        }
                    }
                    //日時のとき
                    else if (_dataGridViewStats[j, 1].Value.ToString() == "日時")
                    {
                        //下限に入力された値が数値のとき、「日時下限のみ:31」を入力
                        if (DateTime.TryParse(downCell, out tmpdt))
                        {
                            _downDateTime[j] = tmpdt;
                            _filterFlg.Add(41);
                        }
                        //上下限に入力されたのが数値でないとき、処理を打ち切り
                        else
                        {
                            MessageBox.Show("下限には日時を指定してください " + (j + 1).ToString() + "列目");
                            return false;
                        }
                    }
                    //数値、日時でないとき、処理を打ち切り
                    else
                    {
                        MessageBox.Show("数値、日時以外の列に上限を入力しないでください " + (j + 1).ToString() + "列目");
                        return false;
                    }
                }
            }

            //upDateTime、downDateTimeに入力されている場合、正確な日時に変換してDataGridViewに表示する
            for (int j = 0; j < nCol; j++)
            {
                if (_upDateTime[j] < DateTime.MaxValue) _dataGridViewExtractColumnsAndFilters[j, 3].Value = _upDateTime[j].ToString();
                if (_downDateTime[j] > DateTime.MinValue) _dataGridViewExtractColumnsAndFilters[j, 4].Value = _downDateTime[j].ToString();
            }
            //正常に読み込み終了したので、trueを返す
            return true;
        }

        /// <summary>
        /// フィルタ処理の実行と結果CSV出力
        /// </summary>
        /// <param name="savePath"></param>
        /// <param name="maxOutputRows">最大出力行数</param>
        /// <param name="enc">CSV読み書き時のエンコード</param>
        public void ExecuteFiltersAndOutputCSV(string savePath, int maxOutputRows, System.Text.Encoding enc)
        {
            //各種変数の宣言
            string line = null;//1行読込用変数
            string[] cells = null;//1行を1マス毎に分割した配列                    
            int readRowCount = 0;//読み込んだ行数カウント
            int outputRowCount = 0;//出力した行数カウント
            int nCol = _dataGridViewStats.Columns.Count;//カラム数
            //各変数型の最大値を保持
            int maxInt = int.MaxValue;
            long maxLong = long.MaxValue;
            double maxDouble = double.MaxValue;
            DateTime maxDateTime = DateTime.MaxValue;

            /////DataGridViewのチェックボックスを読み取り、カラムの出力有無のフラグを作成////
            List<bool> columnOutputFlg = new List<bool>();
            //全カラム走査し、チェックボックスがtrueかfalseかを保持
            for (int j = 0; j < nCol; j++)
            {
                columnOutputFlg.Add((bool)_dataGridViewExtractColumnsAndFilters[j, 1].Value);
            }

            //CSVが存在するときのみ、読み込む
            if (System.IO.File.Exists(_readCSVPath))//ファイルが存在しているときのみ処理を進める
            {
                //CSVファイルのオープン 
                using (System.IO.StreamReader sr = new System.IO.StreamReader(_readCSVPath, enc))
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(savePath, false, enc))
                    {
                        //1行目がヘッダーのとき、その1行を読み込んでヘッダー名として出力（出力フラグがtrueになっている列のみ）
                        if (_firstHeaderFlg)
                        {
                            line = sr.ReadLine();//1行読み込み
                            cells = line.Split(',');//行をカンマで区切ってセルに分割
                            List<string> rowString = new List<string>();
                            for (int j = 0; j < nCol; j++)
                            {
                                //出力フラグがtrueになっている列のみ出力
                                if (columnOutputFlg[j]) rowString.Add(cells[j]);
                            }
                            //選択した列を結合して1行出力
                            sw.WriteLine(string.Join(",", rowString));
                        }

                        ////////CSVを1行ずつ読み込み、フィルタ判定/////////
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();//1行読込
                            cells = line.Split(',');
                            bool deleteFlg = false;//フィルタに当てはまらなったときのフラグ

                            //ステップ1：フィルタの判定を列ごとに実施
                            for (int j = 0; j < nCol; j++)
                            {
                                //フィルタないとき、次行へ
                                if (_filterFlg[j] == 0) continue;

                                ////一致フィルタ////
                                //①ワイルドカードなし（完全一致）
                                else if (_filterFlg[j] == 1)
                                {
                                    //一致したとき、次列の判定に
                                    if (cells[j] == _searchString[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //②ワイルドカード前（後方一致）
                                else if (_filterFlg[j] == 2)
                                {
                                    int stLen = _searchString[j].Length;//検索文字列の文字数を保持
                                    //一致したとき、次列の判定に
                                    if (cells[j].Length >= stLen && cells[j].Substring(cells[j].Length - stLen, stLen) == _searchString[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //③ワイルドカード後（前方一致）
                                else if (_filterFlg[j] == 3)
                                {
                                    //一致したとき、次列の判定に
                                    if (cells[j].IndexOf(_searchString[j]) == 0) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //④ワイルドカード前後（部分一致）
                                else if (_filterFlg[j] == 4)
                                {
                                    //一致したとき、次列の判定に
                                    if (cells[j].IndexOf(_searchString[j]) >= 0) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }

                                ////上限フィルタ////
                                //10：整数の上限
                                else if (_filterFlg[j] == 10)
                                {
                                    //値がUpValue以下なら、次列の判定に
                                    if (_intValueList[j][readRowCount] <= _upValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //20：64bit整数の上限
                                else if (_filterFlg[j] == 20)
                                {
                                    //値がUpValue以下なら、次列の判定に
                                    if (_longValueList[j][readRowCount] <= _upValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //30：小数の上限
                                else if (_filterFlg[j] == 30)
                                {
                                    //値がUpValue以下なら、次列の判定に
                                    if (_doubleValueList[j][readRowCount] <= _upValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //40：日時の上限
                                else if (_filterFlg[j] == 40)
                                {
                                    //値がUpDateTime以下なら、次列の判定に
                                    if (_datetimeValueList[j][readRowCount] <= _upDateTime[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }

                                ////下限フィルタ////
                                //11：整数の下限
                                else if (_filterFlg[j] == 11)
                                {
                                    //値の取得
                                    int cellValue = _intValueList[j][readRowCount];
                                    //値が整数(int.MaxValueでない)かつDownValue以上なら、次列の判定に
                                    if (cellValue != maxInt && cellValue >= _downValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //21：64bit整数の下限
                                else if (_filterFlg[j] == 21)
                                {
                                    //値の取得
                                    long cellValue = _longValueList[j][readRowCount];
                                    //値が整数(long.MaxValueでない)かつDownValue以上なら、次列の判定に
                                    if (cellValue != maxLong && cellValue >= _downValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //31：小数の下限
                                else if (_filterFlg[j] == 31)
                                {
                                    //値の取得
                                    double cellValue = _doubleValueList[j][readRowCount];
                                    //値が小数(double.MaxValueでない)かつDownValue以上なら、次列の判定に
                                    if (cellValue != maxDouble && cellValue >= _downValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //41：日時の下限
                                else if (_filterFlg[j] == 41)
                                {
                                    //値の取得
                                    DateTime cellValue = _datetimeValueList[j][readRowCount];
                                    //値が日時(DateTime.MaxValueでない)かつDownDateTime以上なら、次列の判定に
                                    if (cellValue != maxDateTime && cellValue >= _downDateTime[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }

                                ////上下限フィルタ////
                                //12：整数の上下限
                                else if (_filterFlg[j] == 12)
                                {
                                    //値の取得
                                    int cellValue = _intValueList[j][readRowCount];
                                    //値がDownValue以上UpValue以下なら、次列の判定に
                                    if (cellValue <= _upValue[j] && cellValue >= _downValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //22：64bit整数の上下限
                                else if (_filterFlg[j] == 22)
                                {
                                    //値の取得
                                    long cellValue = _longValueList[j][readRowCount];
                                    //値がDownValue以上UpValue以下なら、次列の判定に
                                    if (cellValue <= _upValue[j] && cellValue >= _downValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //32：小数の上下限
                                else if (_filterFlg[j] == 32)
                                {
                                    //値の取得
                                    double cellValue = _doubleValueList[j][readRowCount];
                                    //値がDownValue以上UpValue以下な、次列の判定に
                                    if (cellValue <= _upValue[j] && cellValue >= _downValue[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                                //42：日時の上下限
                                else if (_filterFlg[j] == 42)
                                {
                                    //値の取得
                                    DateTime cellValue = _datetimeValueList[j][readRowCount];
                                    //値がDownValue以上UpValue以下な、次列の判定に
                                    if (cellValue <= _upDateTime[j] && cellValue >= _downDateTime[j]) continue;
                                    //一致しなかったとき、削除フラグをtrueにしてその行の判定を終了
                                    else
                                    {
                                        deleteFlg = true;
                                        break;
                                    }
                                }
                            }

                            //読み込んだ行数を1プラス
                            readRowCount++;
                            //読み込んだ＆書き込んだ行数を表示

                            if (readRowCount % 100 == 0)
                            {
                                DisplayStatusStrip(readRowCount.ToString() + "/" + _nRow.ToString() + "行目読込中    " + outputRowCount.ToString() + "行出力済");
                            }

                            //削除フラグONのとき、出力せずに次の行へ
                            if (deleteFlg) continue;


                            //ステップ2：出力列の選択
                            //1行分の文字列を作成
                            List<string> rowString = new List<string>();
                            for (int j = 0; j < nCol; j++)
                            {
                                //出力フラグがtrueになっている列のみ出力
                                if (columnOutputFlg[j]) rowString.Add(cells[j]);
                            }
                            //選択した列を結合して1行出力
                            sw.WriteLine(string.Join(",", rowString));

                            //書き込んだ行数を1プラス
                            outputRowCount++;

                            //行数が上限を超えたら処理を終了
                            if (outputRowCount >= maxOutputRows) break;
                        }
                    }
                }

                //出力完了を表示
                {
                    DisplayStatusStrip(outputRowCount.ToString() + "行 / " + _nRow.ToString() + "行出力");
                    MessageBox.Show("出力完了\r\n" + outputRowCount.ToString() + "行 / " + _nRow.ToString() + "行出力");
                }
            }
        }
    }
}
