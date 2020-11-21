using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CsvAnalysisAndFilterTool
{
    public partial class FormMerge : Form
    {
        //マージ用クラスを保持
        DirCsvMerge dirCsvMerge;

        public FormMerge()
        {
            InitializeComponent();
            dirCsvMerge = null;
        }

        //マージ対象フォルダ指定用CSVファイルを読込
        private void ReadCsvPath()
        {
            //マージ用クラス生成
            dirCsvMerge = new DirCsvMerge(textBoxCsvPath.Text, toolStripStatusLabel1, statusStrip1);
            //マージ対象のCSV一覧表示
            textBoxMergeCsvList.Text
                    = dirCsvMerge.DistplayCSVList(radioButtonOnlyThisFolder.Checked, radioButtonUpper1Layer.Checked, radioButtonUpper2Layers.Checked, comboBoxReadSuffix.Text);
        }

        //親フォームから呼び出されたときの処理
        public void ShowDialog(IWin32Window owner, string csvPath)
        {
            //親フォームから渡したCSVファイルのパスを読込
            if(csvPath != null)
            {
                textBoxCsvPath.Text = csvPath;
                ReadCsvPath();
            }
            base.ShowDialog(owner);
        }

        private void buttonSelectCsv_Click(object sender, EventArgs e)
        {
            //CSVファイルのパス指定
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                if (comboBoxReadSuffix.Text == "csv") dlg.Filter = "CSVﾌｧｲﾙ(*.csv)|*.csv";//ファイルフィルタ(CSV)
                else if (comboBoxReadSuffix.Text == "dat") dlg.Filter = "DATﾌｧｲﾙ(*.dat)|*.dat";//ファイルフィルタ(dat)
                if (dlg.ShowDialog() == DialogResult.Cancel) { return; }//ダイアログの表示
                textBoxCsvPath.Text = dlg.FileName;//ファイル名の保持
                //マージ対象フォルダ指定用CSVファイルを読込
                ReadCsvPath();
            }
        }

        private void textBoxCsvPath_DragDrop(object sender, DragEventArgs e)
        {
            string[] fName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            //ドロップされたファイルが複数のとき、エラーを返す
            if (fName.Length > 1)
            {
                MessageBox.Show("2個以上のファイルをドロップしないでください");
                return;
            }

            //CSV選択しているのにドロップされたファイルがCSVでないとき、エラーを返す
            if (comboBoxReadSuffix.Text == "csv" && Path.GetExtension(fName[0]) != ".csv")
            {
                MessageBox.Show("CSV以外のファイルをドロップしないでください");
                return;
            }

            //DAT選択しているのにドロップされたファイルがDATでないとき、エラーを返す
            if (comboBoxReadSuffix.Text == "dat" && Path.GetExtension(fName[0]) != ".dat")
            {
                MessageBox.Show("Dat以外のファイルをドロップしないでください");
                return;
            }

            textBoxCsvPath.Text = fName[0];
            //マージ対象フォルダ指定用CSVファイルを読込
            ReadCsvPath();
        }

        private void textBoxCsvPath_DragEnter(object sender, DragEventArgs e)
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

        private void buttonMergeCsv_Click(object sender, EventArgs e)
        {
            //読込ファイル形式(csv or dat)
            string readSuffix = comboBoxReadSuffix.Text;
            //保存ファイル形式(csv or dat)
            string saveSuffix = comboBoxSaveSuffix.Text;
            int neglectRows = (int)numericUpDownNeglectRows.Value;//無視する行数

            //マージ実行
            dirCsvMerge.MergeCSV(radioButtonUtf8.Checked, comboBoxReadSplit.Text, comboBoxWriteSplit.Text, comboBoxReadSuffix.Text, comboBoxSaveSuffix.Text,
                checkBoxAddFileName.Checked, (int)numericUpDownNeglectRows.Value, checkBoxNeglectFirstHeader.Checked, radioButtonOnlyThisFolder.Checked, radioButtonUpper1Layer.Checked, radioButtonUpper2Layers.Checked);
        }

        private void radioButtonOnlyThisFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOnlyThisFolder.Checked && dirCsvMerge != null)
            {
                textBoxMergeCsvList.Text
                    = dirCsvMerge.DistplayCSVList(radioButtonOnlyThisFolder.Checked, radioButtonUpper1Layer.Checked, radioButtonUpper2Layers.Checked, comboBoxReadSuffix.Text);
            }
        }

        private void radioButtonUpper1Layer_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUpper1Layer.Checked && dirCsvMerge != null)
            {
                textBoxMergeCsvList.Text
                    = dirCsvMerge.DistplayCSVList(radioButtonOnlyThisFolder.Checked, radioButtonUpper1Layer.Checked, radioButtonUpper2Layers.Checked, comboBoxReadSuffix.Text);
            }
        }

        private void radioButtonUpper2Layers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUpper2Layers.Checked && dirCsvMerge != null)
            {
                textBoxMergeCsvList.Text
                    = dirCsvMerge.DistplayCSVList(radioButtonOnlyThisFolder.Checked, radioButtonUpper1Layer.Checked, radioButtonUpper2Layers.Checked, comboBoxReadSuffix.Text);
            }
        }

        private void comboBoxReadSuffix_TextChanged(object sender, EventArgs e)
        {
            textBoxMergeCsvList.Text
                    = dirCsvMerge.DistplayCSVList(radioButtonOnlyThisFolder.Checked, radioButtonUpper1Layer.Checked, radioButtonUpper2Layers.Checked, comboBoxReadSuffix.Text);
        }
    }
}
