using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsvAnalysisAndFilterTool
{
    public partial class Form1 : Form
    {
        //分析＆フィルタ用クラスを保持
        CsvAnalysisAndFilter csvAnalysisAndFilter;

        public Form1()
        {
            InitializeComponent();
        }
        
        //起動時の初期化
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        //StatusStrip表示用メソッド
        private void DisplayStatusStrip(string displayString)
        {
            toolStripStatusLabel1.Text = displayString;
            statusStrip1.Refresh();
            Application.DoEvents();//メッセージ・キューにあるWindowsメッセージをすべて処理する(フリーズ対策)
        }
        

        private void dataGridViewReadCSV_DragDrop(object sender, DragEventArgs e)
        {
            string[] fName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //ドロップされたファイルが複数のとき、エラーを返す
            if (fName.Length > 1)
            {
                MessageBox.Show("2個以上のファイルをドロップしないでください");
                return;
            }
            
            //ドロップされたファイルがCSVでないとき、エラーを返す
            if (System.IO.Path.GetExtension(fName[0]) != ".csv")
            {
                MessageBox.Show("CSV以外のファイルをドロップしないでください");
                return;
            }

            //読み込んだパスを保持
            csvAnalysisAndFilter = new CsvAnalysisAndFilter(
                (double)numericUpDownAllowStrRatio.Value / 100.0,
                fName[0],
                toolStripStatusLabel1,
                statusStrip1,
                labelReadCSV,
                labelRowCount,
                dataGridViewReadCSV,
                dataGridViewStats,
                dataGridViewExtractColumnsAndFilters);

            //dataGridViewに表示
            var enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            if (radioButtonUTF8.Checked) enc = System.Text.Encoding.GetEncoding("UTF-8");
            csvAnalysisAndFilter.RefreshReadCSVDataGrid(enc);
        }

        private void dataGridViewReadCSV_DragEnter(object sender, DragEventArgs e)
        {
            //コントロール内にドラッグされたときに実行
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                //ドラッグされたデータ形式を調べ、ファイルのときはコピーする
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                //ファイル以外は受け付けない
                e.Effect = DragDropEffects.None;
            }
        }

        private void buttonJudgeColTypeAndCalcStats_Click(object sender, EventArgs e)
        {
            csvAnalysisAndFilter.ParseCount(checkBoxFirstRowHeader.Checked);
            csvAnalysisAndFilter.CalcStats();
        }

        private void dataGridViewStats_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridViewExtractColumnsAndFilters.HorizontalScrollingOffset = dataGridViewStats.HorizontalScrollingOffset;
        }

        private void dataGridViewExtractColumnsAndFilters_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridViewStats.HorizontalScrollingOffset = dataGridViewExtractColumnsAndFilters.HorizontalScrollingOffset;
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            //フィルタが表示されていない場合、メッセージを出して終了
            if (dataGridViewStats.Columns.Count == 0)
            {
                MessageBox.Show("先に型の判定をしてください");
                return;
            }
            if (dataGridViewExtractColumnsAndFilters.Columns.Count == 0)
            {
                MessageBox.Show("先に統計値の算出をしてください");
                return;
            }

            //DataGridView→リストへのフィルタ内容の読み込み。失敗したら処理を打ち切り
            if (!csvAnalysisAndFilter.ReadFilters()) return;

            /////////////フィルタを適用してCSVを書き込む///////////////
            //保存するCSVのパスを指定する
            MessageBox.Show("保存するCSV名を指定してください");
            string savePath = "";//保存するCSVのパス            
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                sfd.Filter = "CSVﾌｧｲﾙ(*.csv)|*.csv";//ファイルフィルタ                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    savePath = System.IO.Path.ChangeExtension(sfd.FileName, "csv");//拡張子をCSVにする
                }
                else return;
            }
            
            //CSVファイルを読み書きするときに使うEncoding
            var enc = System.Text.Encoding.GetEncoding("Shift_JIS");
            if (radioButtonUTF8.Checked) enc = System.Text.Encoding.GetEncoding("UTF-8");

            //CSVを読み込んでフィルタを適用し、CSV保存
            csvAnalysisAndFilter.ExecuteFiltersAndOutputCSV(savePath, (int)numericUpDownMaxOutputRows.Value * 10000, enc);
        }
        
        private void buttonOutputStatsCSV_Click(object sender, EventArgs e)
        {
            //CSVファイルを読み書きするときに使うEncoding
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("Shift_JIS");

            MessageBox.Show("保存するCSV名を指定してください");
            string savePath = "";//保存するCSVのパス
            //保存するCSVのパスを指定する
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                sfd.Filter = "CSVﾌｧｲﾙ(*.csv)|*.csv";//ファイルフィルタ                
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    savePath = System.IO.Path.ChangeExtension(sfd.FileName, "csv");//拡張子をCSVにする
                }
                else return;
            }

            //CSVを書き込む
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(savePath, false, enc))
            {
                //データの書込み
                for (int i = 0; i < dataGridViewStats.Rows.Count; i++)
                {
                    //1行分の文字列
                    List<string> rowString = new List<string>();

                    //行ヘッダーの書き込み
                    rowString.Add(dataGridViewStats.Rows[i].HeaderCell.Value.ToString());

                    //データの書き込み
                    for (int j = 0; j < dataGridViewStats.Columns.Count; j++)
                    {
                        rowString.Add(dataGridViewStats[j, i].Value.ToString());
                    }
                    sw.WriteLine(string.Join(",", rowString));
                }
                DisplayStatusStrip("出力完了");
            }
        }
    }
}