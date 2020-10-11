namespace CsvAnalysisAndFilterTool
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewReadCSV = new System.Windows.Forms.DataGridView();
            this.labelReadCSV = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonJudgeColumnType = new System.Windows.Forms.Button();
            this.labelCalcStats = new System.Windows.Forms.Label();
            this.buttonCalcStats = new System.Windows.Forms.Button();
            this.buttonOutputStatsCSV = new System.Windows.Forms.Button();
            this.dataGridViewStats = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewExtractColumnsAndFilters = new System.Windows.Forms.DataGridView();
            this.buttonExtract = new System.Windows.Forms.Button();
            this.checkBoxFirstRowHeader = new System.Windows.Forms.CheckBox();
            this.labelRowCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownMaxOutputRows = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxOutputEncode = new System.Windows.Forms.GroupBox();
            this.radioButtonUTF8 = new System.Windows.Forms.RadioButton();
            this.radioButtonShiftJIS = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadCSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtractColumnsAndFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxOutputRows)).BeginInit();
            this.groupBoxOutputEncode.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 648);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1182, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 20);
            this.toolStripStatusLabel1.Text = "    ";
            // 
            // dataGridViewReadCSV
            // 
            this.dataGridViewReadCSV.AllowDrop = true;
            this.dataGridViewReadCSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReadCSV.Location = new System.Drawing.Point(12, 31);
            this.dataGridViewReadCSV.Name = "dataGridViewReadCSV";
            this.dataGridViewReadCSV.RowTemplate.Height = 24;
            this.dataGridViewReadCSV.Size = new System.Drawing.Size(1000, 214);
            this.dataGridViewReadCSV.TabIndex = 1;
            this.dataGridViewReadCSV.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewReadCSV_DragDrop);
            this.dataGridViewReadCSV.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewReadCSV_DragEnter);
            // 
            // labelReadCSV
            // 
            this.labelReadCSV.AutoSize = true;
            this.labelReadCSV.Location = new System.Drawing.Point(12, 9);
            this.labelReadCSV.Name = "labelReadCSV";
            this.labelReadCSV.Size = new System.Drawing.Size(294, 19);
            this.labelReadCSV.TabIndex = 2;
            this.labelReadCSV.Text = "読み込みたいCSVをドラッグ＆ドロップしてください";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1018, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 473);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "各種ツール起動";
            // 
            // buttonJudgeColumnType
            // 
            this.buttonJudgeColumnType.Location = new System.Drawing.Point(245, 251);
            this.buttonJudgeColumnType.Name = "buttonJudgeColumnType";
            this.buttonJudgeColumnType.Size = new System.Drawing.Size(113, 28);
            this.buttonJudgeColumnType.TabIndex = 4;
            this.buttonJudgeColumnType.Text = "↓型の判定";
            this.buttonJudgeColumnType.UseVisualStyleBackColor = true;
            this.buttonJudgeColumnType.Click += new System.EventHandler(this.buttonJudgeColumnType_Click);
            // 
            // labelCalcStats
            // 
            this.labelCalcStats.AutoSize = true;
            this.labelCalcStats.Location = new System.Drawing.Point(8, 259);
            this.labelCalcStats.Name = "labelCalcStats";
            this.labelCalcStats.Size = new System.Drawing.Size(231, 19);
            this.labelCalcStats.TabIndex = 5;
            this.labelCalcStats.Text = "ボタンを押して統計値算出してください";
            // 
            // buttonCalcStats
            // 
            this.buttonCalcStats.Location = new System.Drawing.Point(364, 251);
            this.buttonCalcStats.Name = "buttonCalcStats";
            this.buttonCalcStats.Size = new System.Drawing.Size(129, 28);
            this.buttonCalcStats.TabIndex = 6;
            this.buttonCalcStats.Text = "→統計値算出";
            this.buttonCalcStats.UseVisualStyleBackColor = true;
            this.buttonCalcStats.Click += new System.EventHandler(this.buttonCalcStats_Click);
            // 
            // buttonOutputStatsCSV
            // 
            this.buttonOutputStatsCSV.Location = new System.Drawing.Point(875, 251);
            this.buttonOutputStatsCSV.Name = "buttonOutputStatsCSV";
            this.buttonOutputStatsCSV.Size = new System.Drawing.Size(137, 28);
            this.buttonOutputStatsCSV.TabIndex = 7;
            this.buttonOutputStatsCSV.Text = "統計値CSV出力";
            this.buttonOutputStatsCSV.UseVisualStyleBackColor = true;
            this.buttonOutputStatsCSV.Click += new System.EventHandler(this.buttonOutputStatsCSV_Click);
            // 
            // dataGridViewStats
            // 
            this.dataGridViewStats.AllowUserToAddRows = false;
            this.dataGridViewStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStats.Location = new System.Drawing.Point(12, 285);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.RowTemplate.Height = 24;
            this.dataGridViewStats.Size = new System.Drawing.Size(1000, 200);
            this.dataGridViewStats.TabIndex = 8;
            this.dataGridViewStats.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewStats_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 496);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "抽出するカラムとフィルタ";
            // 
            // dataGridViewExtractColumnsAndFilters
            // 
            this.dataGridViewExtractColumnsAndFilters.AllowDrop = true;
            this.dataGridViewExtractColumnsAndFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExtractColumnsAndFilters.Location = new System.Drawing.Point(12, 525);
            this.dataGridViewExtractColumnsAndFilters.Name = "dataGridViewExtractColumnsAndFilters";
            this.dataGridViewExtractColumnsAndFilters.RowTemplate.Height = 24;
            this.dataGridViewExtractColumnsAndFilters.Size = new System.Drawing.Size(1000, 120);
            this.dataGridViewExtractColumnsAndFilters.TabIndex = 10;
            this.dataGridViewExtractColumnsAndFilters.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewExtractColumnsAndFilters_Scroll);
            // 
            // buttonExtract
            // 
            this.buttonExtract.Location = new System.Drawing.Point(245, 491);
            this.buttonExtract.Name = "buttonExtract";
            this.buttonExtract.Size = new System.Drawing.Size(101, 28);
            this.buttonExtract.TabIndex = 11;
            this.buttonExtract.Text = "抽出";
            this.buttonExtract.UseVisualStyleBackColor = true;
            this.buttonExtract.Click += new System.EventHandler(this.buttonExtract_Click);
            // 
            // checkBoxFirstRowHeader
            // 
            this.checkBoxFirstRowHeader.AutoSize = true;
            this.checkBoxFirstRowHeader.Checked = true;
            this.checkBoxFirstRowHeader.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFirstRowHeader.Location = new System.Drawing.Point(499, 255);
            this.checkBoxFirstRowHeader.Name = "checkBoxFirstRowHeader";
            this.checkBoxFirstRowHeader.Size = new System.Drawing.Size(178, 23);
            this.checkBoxFirstRowHeader.TabIndex = 12;
            this.checkBoxFirstRowHeader.Text = "1行目はヘッダ名とみなす";
            this.checkBoxFirstRowHeader.UseVisualStyleBackColor = true;
            // 
            // labelRowCount
            // 
            this.labelRowCount.AutoSize = true;
            this.labelRowCount.Location = new System.Drawing.Point(683, 256);
            this.labelRowCount.Name = "labelRowCount";
            this.labelRowCount.Size = new System.Drawing.Size(23, 19);
            this.labelRowCount.TabIndex = 13;
            this.labelRowCount.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(782, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "最大出力行数";
            // 
            // numericUpDownMaxOutputRows
            // 
            this.numericUpDownMaxOutputRows.Location = new System.Drawing.Point(887, 494);
            this.numericUpDownMaxOutputRows.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownMaxOutputRows.Name = "numericUpDownMaxOutputRows";
            this.numericUpDownMaxOutputRows.Size = new System.Drawing.Size(80, 27);
            this.numericUpDownMaxOutputRows.TabIndex = 15;
            this.numericUpDownMaxOutputRows.Value = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(973, 496);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "万行";
            // 
            // groupBoxOutputEncode
            // 
            this.groupBoxOutputEncode.Controls.Add(this.radioButtonUTF8);
            this.groupBoxOutputEncode.Controls.Add(this.radioButtonShiftJIS);
            this.groupBoxOutputEncode.Location = new System.Drawing.Point(1018, 525);
            this.groupBoxOutputEncode.Name = "groupBoxOutputEncode";
            this.groupBoxOutputEncode.Size = new System.Drawing.Size(152, 120);
            this.groupBoxOutputEncode.TabIndex = 17;
            this.groupBoxOutputEncode.TabStop = false;
            this.groupBoxOutputEncode.Text = "出力エンコード";
            // 
            // radioButtonUTF8
            // 
            this.radioButtonUTF8.AutoSize = true;
            this.radioButtonUTF8.Location = new System.Drawing.Point(6, 55);
            this.radioButtonUTF8.Name = "radioButtonUTF8";
            this.radioButtonUTF8.Size = new System.Drawing.Size(76, 23);
            this.radioButtonUTF8.TabIndex = 1;
            this.radioButtonUTF8.Text = "UTF-8";
            this.radioButtonUTF8.UseVisualStyleBackColor = true;
            // 
            // radioButtonShiftJIS
            // 
            this.radioButtonShiftJIS.AutoSize = true;
            this.radioButtonShiftJIS.Checked = true;
            this.radioButtonShiftJIS.Location = new System.Drawing.Point(6, 26);
            this.radioButtonShiftJIS.Name = "radioButtonShiftJIS";
            this.radioButtonShiftJIS.Size = new System.Drawing.Size(93, 23);
            this.radioButtonShiftJIS.TabIndex = 0;
            this.radioButtonShiftJIS.TabStop = true;
            this.radioButtonShiftJIS.Text = "Shift-JIS";
            this.radioButtonShiftJIS.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.groupBoxOutputEncode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDownMaxOutputRows);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelRowCount);
            this.Controls.Add(this.checkBoxFirstRowHeader);
            this.Controls.Add(this.buttonExtract);
            this.Controls.Add(this.dataGridViewExtractColumnsAndFilters);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewStats);
            this.Controls.Add(this.buttonOutputStatsCSV);
            this.Controls.Add(this.buttonCalcStats);
            this.Controls.Add(this.labelCalcStats);
            this.Controls.Add(this.buttonJudgeColumnType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelReadCSV);
            this.Controls.Add(this.dataGridViewReadCSV);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "CSV分析フィルタツール";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadCSV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtractColumnsAndFilters)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxOutputRows)).EndInit();
            this.groupBoxOutputEncode.ResumeLayout(false);
            this.groupBoxOutputEncode.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridViewReadCSV;
        private System.Windows.Forms.Label labelReadCSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonJudgeColumnType;
        private System.Windows.Forms.Label labelCalcStats;
        private System.Windows.Forms.Button buttonCalcStats;
        private System.Windows.Forms.Button buttonOutputStatsCSV;
        private System.Windows.Forms.DataGridView dataGridViewStats;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewExtractColumnsAndFilters;
        private System.Windows.Forms.Button buttonExtract;
        private System.Windows.Forms.CheckBox checkBoxFirstRowHeader;
        private System.Windows.Forms.Label labelRowCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxOutputRows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxOutputEncode;
        private System.Windows.Forms.RadioButton radioButtonUTF8;
        private System.Windows.Forms.RadioButton radioButtonShiftJIS;
    }
}

