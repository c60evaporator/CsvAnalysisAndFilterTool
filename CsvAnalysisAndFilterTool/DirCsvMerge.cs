using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace CsvAnalysisAndFilterTool
{
    class DirCsvMerge
    {
        //クラス内変数
        string _seedCsvPath;//検索対象フォルダを指定するためのCSVファイル
        private ToolStripStatusLabel _toolStripStatusLabel;//処理内容表示用のToolStripStatusLabel
        private StatusStrip _statusStrip;//処理内容表示用のStatusStrip

        //コンストラクタ
        public DirCsvMerge(
            string seedCsvPath,
            ToolStripStatusLabel toolStripStatusLabel,
            StatusStrip StatusStrip)
        {
            _seedCsvPath = seedCsvPath;
            _toolStripStatusLabel = toolStripStatusLabel;
            _statusStrip = StatusStrip;
        }

        //取得したCSVリストを上位2フォルダ分までのパスを取得し、改行つき文字列で返す
        public string DistplayCSVList(bool thisFolderOnly, bool upper1Layer, bool upper2Layers, string readSuffix)
        {
            List<string> csvFullPathList = GetCSVList(thisFolderOnly, upper1Layer, upper2Layers, readSuffix);
            var csvList = csvFullPathList.Select(a => $"\\{Path.GetFileName(Path.GetDirectoryName(Path.GetDirectoryName(a)))}\\{Path.GetFileName(Path.GetDirectoryName(a))}\\{Path.GetFileName(a)}");
            return string.Join("\r\n", csvList);
        }

        /// <summary>
        /// マージ対象のCSVリストを取得
        /// </summary>
        /// <param name="thisFolderOnly">Trueならそのフォルダ内のみ探索</param>
        /// <param name="upper1Layer">Trueなら上位1階層まで探索</param>
        /// <param name="upper2Layers">Trueなら上位2階層まで探索</param>
        /// <param name="readSuffix">マージ対象の拡張子(.csv or .dat)</param>
        /// <returns></returns>
        private List<string> GetCSVList(bool thisFolderOnly, bool upper1Layer, bool upper2Layers, string readSuffix)
        {
            List<string> files = new List<string>();
            if (thisFolderOnly) files = GetThisFolderCSVList(readSuffix);
            else if (upper1Layer) files = GetUpper1LayerCSVList(readSuffix);
            else if (upper2Layers) files = GetUpper2LayersCSVList(readSuffix);
            return files;
        }

        //フォルダ内のCSVリストを取得
        private List<string> GetThisFolderCSVList(string readSuffix)
        {
            List<string> files = new List<string>();
            //フォルダ内の全CSVファイルを取得
            files.AddRange(GetFileOrFolderList(Path.GetDirectoryName(_seedCsvPath), readSuffix).OrderBy(a => a));
            return files;
        }

        //フォルダ内のCSVリストを取得
        private List<string> GetUpper1LayerCSVList(string readSuffix)
        {
            List<string> files = new List<string>();
            //上位フォルダ内のディレクトリを全て取得
            string[] upperDirectries = GetFileOrFolderList(Path.GetDirectoryName(Path.GetDirectoryName(_seedCsvPath)), "folder");
            //ディレクトリを名前順でソート
            Array.Sort(upperDirectries);
            //上位フォルダ内のディレクトリを走査
            foreach (string directoryPath in upperDirectries)
            {
                files.AddRange(GetFileOrFolderList(directoryPath, readSuffix).OrderBy(a => a));
            }
            return files;
        }

        //フォルダ内のCSVリストを取得
        private List<string> GetUpper2LayersCSVList(string readSuffix)
        {
            List<string> files = new List<string>();
            //上々位フォルダ内のディレクトリを全て取得
            string[] upperUpperDirectries = GetFileOrFolderList(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(_seedCsvPath))), "folder");
            //ディレクトリを名前順でソート
            Array.Sort(upperUpperDirectries);
            //上々位フォルダ内のディレクトリを全て操作
            foreach (string upperDirectoryPath in upperUpperDirectries)
            {
                //上位フォルダ内のディレクトリを全て取得
                string[] upperDirectries = GetFileOrFolderList(upperDirectoryPath, "folder");
                //ディレクトリを名前順でソート
                Array.Sort(upperDirectries);
                //上位フォルダ内のディレクトリを走査
                foreach (string directoryPath in upperDirectries)
                {
                    files.AddRange(GetFileOrFolderList(directoryPath, readSuffix).OrderBy(a => a));
                }
            }
            return files;
        }

        //フォルダ内の特定形式ファイルorサブフォルダのリストを取得
        private string[] GetFileOrFolderList(string FolderPath, string fileType)
        {
            string[] files = null;
            //フォルダ内の全CSVファイルを取得
            if (fileType == "csv")
            {
                files = Directory.GetFiles(FolderPath, "*.csv", SearchOption.TopDirectoryOnly);
            }
            //フォルダ内の全Datファイルを取得
            if (fileType == "dat")
            {
                files = Directory.GetFiles(FolderPath, "*.dat", SearchOption.TopDirectoryOnly);
            }
            //フォルダ内の全サブフォルダを取得
            if (fileType == "folder")
            {
                files = Directory.GetDirectories(FolderPath, "*", SearchOption.TopDirectoryOnly);
            }
            return files;
        }

        /// <summary>
        /// マージ実行（外部から叩く関数）
        /// </summary>
        /// <param name="selectUTF8">TrueならUTF8形式、FalseならでShift-JIS形式で読み書き</param>
        /// <param name="readSplitChar">変換前区切り文字</param>
        /// <param name="writeSplitChar">変換後区切り文字</param>
        /// <param name="readSuffix"></param>
        /// <param name="saveSuffix"></param>
        /// <param name="addFileName"></param>
        /// <param name="neglectRows"></param>
        /// <param name="neglectFirstHeader"></param>
        /// <param name="thisFolderOnly"></param>
        /// <param name="upper1Layer"></param>
        /// <param name="upper2Layers"></param>
        public void MergeCSV(bool selectUTF8, string readSplit, string writeSplit, string readSuffix, string saveSuffix,
            bool addFileName, int neglectRows, bool neglectFirstHeader, bool thisFolderOnly, bool upper1Layer, bool upper2Layers)
        {
            //マージ対象のCSVリストを取得(入力ファイル拡張子もここで指定)
            List<string> csvList = GetCSVList(thisFolderOnly, upper1Layer, upper2Layers, readSuffix);

            //保存するCSVのパスを指定する
            string savePath = null;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                if (saveSuffix == "csv") sfd.Filter = "CSVﾌｧｲﾙ(*.csv)|*.csv";//ファイルフィルタ(csv)
                else if (saveSuffix == "dat") sfd.Filter = "Datﾌｧｲﾙ(*.dat)|*.dat";//ファイルフィルタ(Dat)
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (saveSuffix == "csv") savePath = Path.ChangeExtension(sfd.FileName, "csv");//拡張子をCSVにする
                    else if (saveSuffix == "dat") savePath = Path.ChangeExtension(sfd.FileName, "dat");//拡張子をDatにする
                }
                else return;
            }

            //区切り文字の指定
            char readSplitChar = ',';
            if (readSplit == "セミコロン") readSplitChar = ';';
            else if (readSplit == "スペース") readSplitChar = ' ';
            char writeSplitChar = ',';
            if (writeSplit == "セミコロン") writeSplitChar = ';';
            else if (writeSplit == "スペース") writeSplitChar = ' ';

            //CSVファイルを読み書きするときに使うEncoding
            Encoding enc = Encoding.GetEncoding("Shift_JIS");
            if (selectUTF8) enc = Encoding.GetEncoding("UTF-8");

            //マージ実行
            MergeCSVList(csvList, savePath, enc, readSplitChar, writeSplitChar, saveSuffix, addFileName, neglectRows, neglectFirstHeader);
        }

        /// <summary>
        /// リスト内のCSV(あるいはdat)にマージ実行
        /// </summary>
        /// <param name="csvList">マージ対象のCSVのリスト</param>
        /// <param name="savePath">保存先のパス</param>
        /// <param name="addFileName">Trueならファイル名のカラムを追加</param>
        /// <param name="enc">CSVファイルのエンコード</param>
        /// <param name="readSplitChar">変換前区切り文字</param>
        /// <param name="writeSplitChar">変換後区切り文字</param>
        /// <param name="addFileName">Trueならファイル名のカラムを追加</param>
        /// <param name="neglectFirstHeader">Trueならヘッダー記載しない</param>
        /// <param name="saveSuffix">保存ファイル形式</param>
        private void MergeCSVList(List<string> csvList, string savePath, Encoding enc, char readSplitChar, char writeSplitChar, string saveSuffix,
            bool addFileName, int neglectRows, bool neglectFirstHeader)
        {
            ////CSVファイル以外ではファイル名カラム追加できない
            //if (saveSuffix != "csv" && addFileName)
            //{
            //    MessageBox.Show("CSVファイル以外ではファイル名カラム追加できません");
            //    return;
            //}

            StreamWriter sw = new StreamWriter(savePath, false, enc);//書き込み先CSVファイルを開く
            string line = null;//1行読込用変数
            int rowCnt = 0;//行数カウント用

            for (int k = 0; k < csvList.Count; k++)
            {
                //処理中のファイルが何番目か表示
                _toolStripStatusLabel.Text = (k + 1).ToString() + "/" + csvList.Count.ToString();
                _statusStrip.Refresh();
                Application.DoEvents();//メッセージ・キューにあるWindowsメッセージをすべて処理する(フリーズ対策)
                rowCnt = 0;//行数カウントをリセット
                
                //CSVが存在するときのみ、読み込む
                if (System.IO.File.Exists(csvList[k]))//ファイルが存在しているときのみ処理を進める
                {
                    //CSVファイルのオープン
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(csvList[k], enc))
                    {
                        while (!sr.EndOfStream)
                        {
                            line = sr.ReadLine();
                            //ヘッダーの書き込み(最初のファイル＆ヘッダ無視がチェックされていない＆rowCnt=ヘッダ行-1)
                            if (k == 0 && !neglectFirstHeader && rowCnt == neglectRows - 1)
                            {
                                //ファイル名カラム追加するとき、ヘッダに「ファイル名」を追加
                                if (addFileName) sw.Write("ファイル名,");
                                //入出力の区切り文字が異なるとき、置換
                                if (readSplitChar != writeSplitChar)
                                {
                                    sw.WriteLine(line.Replace(readSplitChar, writeSplitChar));
                                }
                                //1行書き込み
                                else sw.WriteLine(line);
                            }
                            //ヘッダー以外の書き込み
                            else if (rowCnt > neglectRows - 1)
                            {
                                //ファイル名カラム追加するとき
                                if (addFileName) sw.Write(csvList[k] + ",");
                                //入出力の区切り文字が異なるとき、置換
                                if (readSplitChar != writeSplitChar)
                                {
                                    sw.WriteLine(line.Replace(readSplitChar, writeSplitChar));
                                }
                                //1行書き込み
                                else sw.WriteLine(line);
                            }
                            rowCnt++;
                        }
                    }
                }
            }
            sw.Close();//CSVファイルを閉じる
            MessageBox.Show("完了しました");
        }
    }
}
