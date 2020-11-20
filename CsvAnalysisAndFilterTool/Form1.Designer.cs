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
            this.buttonJudgeColTypeAndCalcStats = new System.Windows.Forms.Button();
            this.labelCalcStats = new System.Windows.Forms.Label();
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
            this.groupBoxStatsSettings = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownAllowStrRatio = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReadCSV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExtractColumnsAndFilters)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxOutputRows)).BeginInit();
            this.groupBoxOutputEncode.SuspendLayout();
            this.groupBoxStatsSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllowStrRatio)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.dataGridViewReadCSV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewReadCSV.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewReadCSV.Name = "dataGridViewReadCSV";
            this.dataGridViewReadCSV.RowTemplate.Height = 24;
            this.dataGridViewReadCSV.Size = new System.Drawing.Size(1016, 185);
            this.dataGridViewReadCSV.TabIndex = 1;
            this.dataGridViewReadCSV.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridViewReadCSV_DragDrop);
            this.dataGridViewReadCSV.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridViewReadCSV_DragEnter);
            // 
            // labelReadCSV
            // 
            this.labelReadCSV.AutoSize = true;
            this.labelReadCSV.Location = new System.Drawing.Point(3, 0);
            this.labelReadCSV.Name = "labelReadCSV";
            this.labelReadCSV.Size = new System.Drawing.Size(294, 19);
            this.labelReadCSV.TabIndex = 2;
            this.labelReadCSV.Text = "読み込みたいCSVをドラッグ＆ドロップしてください";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(1025, 3);
            this.groupBox1.Name = "groupBox1";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox1, 2);
            this.groupBox1.Size = new System.Drawing.Size(154, 205);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "各種ツール起動";
            // 
            // buttonJudgeColTypeAndCalcStats
            // 
            this.buttonJudgeColTypeAndCalcStats.Location = new System.Drawing.Point(260, 2);
            this.buttonJudgeColTypeAndCalcStats.Name = "buttonJudgeColTypeAndCalcStats";
            this.buttonJudgeColTypeAndCalcStats.Size = new System.Drawing.Size(200, 28);
            this.buttonJudgeColTypeAndCalcStats.TabIndex = 4;
            this.buttonJudgeColTypeAndCalcStats.Text = "↓型の判定＆統計値算出";
            this.buttonJudgeColTypeAndCalcStats.UseVisualStyleBackColor = true;
            this.buttonJudgeColTypeAndCalcStats.Click += new System.EventHandler(this.buttonJudgeColTypeAndCalcStats_Click);
            // 
            // labelCalcStats
            // 
            this.labelCalcStats.AutoSize = true;
            this.labelCalcStats.Location = new System.Drawing.Point(6, 7);
            this.labelCalcStats.Name = "labelCalcStats";
            this.labelCalcStats.Size = new System.Drawing.Size(231, 19);
            this.labelCalcStats.TabIndex = 5;
            this.labelCalcStats.Text = "ボタンを押して統計値算出してください";
            // 
            // buttonOutputStatsCSV
            // 
            this.buttonOutputStatsCSV.Location = new System.Drawing.Point(707, 3);
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
            this.dataGridViewStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewStats.Location = new System.Drawing.Point(3, 254);
            this.dataGridViewStats.Name = "dataGridViewStats";
            this.dataGridViewStats.RowTemplate.Height = 24;
            this.dataGridViewStats.Size = new System.Drawing.Size(1016, 196);
            this.dataGridViewStats.TabIndex = 8;
            this.dataGridViewStats.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewStats_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "抽出するカラムとフィルタ";
            // 
            // dataGridViewExtractColumnsAndFilters
            // 
            this.dataGridViewExtractColumnsAndFilters.AllowDrop = true;
            this.dataGridViewExtractColumnsAndFilters.AllowUserToAddRows = false;
            this.dataGridViewExtractColumnsAndFilters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExtractColumnsAndFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewExtractColumnsAndFilters.Location = new System.Drawing.Point(3, 496);
            this.dataGridViewExtractColumnsAndFilters.Name = "dataGridViewExtractColumnsAndFilters";
            this.dataGridViewExtractColumnsAndFilters.RowTemplate.Height = 24;
            this.dataGridViewExtractColumnsAndFilters.Size = new System.Drawing.Size(1016, 149);
            this.dataGridViewExtractColumnsAndFilters.TabIndex = 10;
            this.dataGridViewExtractColumnsAndFilters.Scroll += new System.Windows.Forms.ScrollEventHandler(this.dataGridViewExtractColumnsAndFilters_Scroll);
            // 
            // buttonExtract
            // 
            this.buttonExtract.Location = new System.Drawing.Point(260, 3);
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
            this.checkBoxFirstRowHeader.Location = new System.Drawing.Point(475, 6);
            this.checkBoxFirstRowHeader.Name = "checkBoxFirstRowHeader";
            this.checkBoxFirstRowHeader.Size = new System.Drawing.Size(178, 23);
            this.checkBoxFirstRowHeader.TabIndex = 12;
            this.checkBoxFirstRowHeader.Text = "1行目はヘッダ名とみなす";
            this.checkBoxFirstRowHeader.UseVisualStyleBackColor = true;
            // 
            // labelRowCount
            // 
            this.labelRowCount.AutoSize = true;
            this.labelRowCount.Location = new System.Drawing.Point(659, 7);
            this.labelRowCount.Name = "labelRowCount";
            this.labelRowCount.Size = new System.Drawing.Size(23, 19);
            this.labelRowCount.TabIndex = 13;
            this.labelRowCount.Text = "--";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(471, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "最大出力行数";
            // 
            // numericUpDownMaxOutputRows
            // 
            this.numericUpDownMaxOutputRows.Location = new System.Drawing.Point(573, 4);
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
            this.label2.Location = new System.Drawing.Point(659, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "万行";
            // 
            // groupBoxOutputEncode
            // 
            this.groupBoxOutputEncode.Controls.Add(this.radioButtonUTF8);
            this.groupBoxOutputEncode.Controls.Add(this.radioButtonShiftJIS);
            this.groupBoxOutputEncode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOutputEncode.Location = new System.Drawing.Point(1025, 456);
            this.groupBoxOutputEncode.Name = "groupBoxOutputEncode";
            this.tableLayoutPanel1.SetRowSpan(this.groupBoxOutputEncode, 2);
            this.groupBoxOutputEncode.Size = new System.Drawing.Size(154, 189);
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
            // groupBoxStatsSettings
            // 
            this.groupBoxStatsSettings.Controls.Add(this.label5);
            this.groupBoxStatsSettings.Controls.Add(this.label4);
            this.groupBoxStatsSettings.Controls.Add(this.numericUpDownAllowStrRatio);
            this.groupBoxStatsSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxStatsSettings.Location = new System.Drawing.Point(1025, 214);
            this.groupBoxStatsSettings.Name = "groupBoxStatsSettings";
            this.tableLayoutPanel1.SetRowSpan(this.groupBoxStatsSettings, 2);
            this.groupBoxStatsSettings.Size = new System.Drawing.Size(154, 236);
            this.groupBoxStatsSettings.TabIndex = 18;
            this.groupBoxStatsSettings.TabStop = false;
            this.groupBoxStatsSettings.Text = "型判定の設定";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 19);
            this.label5.TabIndex = 2;
            this.label5.Text = "%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "・文字列許容率";
            // 
            // numericUpDownAllowStrRatio
            // 
            this.numericUpDownAllowStrRatio.DecimalPlaces = 1;
            this.numericUpDownAllowStrRatio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownAllowStrRatio.Location = new System.Drawing.Point(41, 58);
            this.numericUpDownAllowStrRatio.Name = "numericUpDownAllowStrRatio";
            this.numericUpDownAllowStrRatio.Size = new System.Drawing.Size(72, 27);
            this.numericUpDownAllowStrRatio.TabIndex = 0;
            this.numericUpDownAllowStrRatio.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.Controls.Add(this.labelReadCSV, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewReadCSV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxOutputEncode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxStatsSettings, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewStats, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewExtractColumnsAndFilters, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1182, 648);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonOutputStatsCSV);
            this.panel1.Controls.Add(this.labelRowCount);
            this.panel1.Controls.Add(this.checkBoxFirstRowHeader);
            this.panel1.Controls.Add(this.buttonJudgeColTypeAndCalcStats);
            this.panel1.Controls.Add(this.labelCalcStats);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 34);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.buttonExtract);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numericUpDownMaxOutputRows);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 456);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1016, 34);
            this.panel2.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 673);
            this.Controls.Add(this.tableLayoutPanel1);
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
            this.groupBoxStatsSettings.ResumeLayout(false);
            this.groupBoxStatsSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAllowStrRatio)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.DataGridView dataGridViewReadCSV;
        private System.Windows.Forms.Label labelReadCSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonJudgeColTypeAndCalcStats;
        private System.Windows.Forms.Label labelCalcStats;
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
        private System.Windows.Forms.GroupBox groupBoxStatsSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownAllowStrRatio;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

