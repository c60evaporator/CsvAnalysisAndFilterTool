namespace CsvAnalysisAndFilterTool
{
    partial class FormMerge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCsvPath = new System.Windows.Forms.TextBox();
            this.buttonSelectCsv = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButtonShiftJis = new System.Windows.Forms.RadioButton();
            this.radioButtonUtf8 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxReadSplit = new System.Windows.Forms.ComboBox();
            this.comboBoxWriteSplit = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxReadSuffix = new System.Windows.Forms.ComboBox();
            this.comboBoxSaveSuffix = new System.Windows.Forms.ComboBox();
            this.numericUpDownNeglectRows = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxNeglectFirstHeader = new System.Windows.Forms.CheckBox();
            this.checkBoxAddFileName = new System.Windows.Forms.CheckBox();
            this.buttonMergeCsv = new System.Windows.Forms.Button();
            this.radioButtonOnlyThisFolder = new System.Windows.Forms.RadioButton();
            this.radioButtonUpper1Layer = new System.Windows.Forms.RadioButton();
            this.radioButtonUpper2Layers = new System.Windows.Forms.RadioButton();
            this.textBoxMergeCsvList = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeglectRows)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(882, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 20);
            this.toolStripStatusLabel1.Text = "    ";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(882, 528);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 3);
            this.panel1.Controls.Add(this.buttonSelectCsv);
            this.panel1.Controls.Add(this.textBoxCsvPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(876, 52);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "フォルダ\r\n(ドラッグ＆ドロップ可)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxCsvPath
            // 
            this.textBoxCsvPath.AllowDrop = true;
            this.textBoxCsvPath.Location = new System.Drawing.Point(152, 12);
            this.textBoxCsvPath.Name = "textBoxCsvPath";
            this.textBoxCsvPath.Size = new System.Drawing.Size(512, 27);
            this.textBoxCsvPath.TabIndex = 1;
            this.textBoxCsvPath.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBoxCsvPath_DragDrop);
            this.textBoxCsvPath.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBoxCsvPath_DragEnter);
            // 
            // buttonSelectCsv
            // 
            this.buttonSelectCsv.Location = new System.Drawing.Point(733, 5);
            this.buttonSelectCsv.Name = "buttonSelectCsv";
            this.buttonSelectCsv.Size = new System.Drawing.Size(108, 34);
            this.buttonSelectCsv.TabIndex = 2;
            this.buttonSelectCsv.Text = "選択";
            this.buttonSelectCsv.UseVisualStyleBackColor = true;
            this.buttonSelectCsv.Click += new System.EventHandler(this.buttonSelectCsv_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonUtf8);
            this.groupBox1.Controls.Add(this.radioButtonShiftJis);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "エンコード";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxWriteSplit);
            this.groupBox2.Controls.Add(this.comboBoxReadSplit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 203);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 181);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "区切り文字変換";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.comboBoxSaveSuffix);
            this.groupBox3.Controls.Add(this.comboBoxReadSuffix);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 390);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 135);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "ファイル拡張子";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBoxNeglectFirstHeader);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.numericUpDownNeglectRows);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(267, 63);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 134);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ヘッダー";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButtonUpper2Layers);
            this.groupBox5.Controls.Add(this.radioButtonUpper1Layer);
            this.groupBox5.Controls.Add(this.radioButtonOnlyThisFolder);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(267, 203);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(258, 181);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "上位フォルダ探索";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonMergeCsv);
            this.panel2.Controls.Add(this.checkBoxAddFileName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(267, 390);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(258, 135);
            this.panel2.TabIndex = 6;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBoxMergeCsvList);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(531, 63);
            this.groupBox6.Name = "groupBox6";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox6, 3);
            this.groupBox6.Size = new System.Drawing.Size(348, 462);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "マージ対象CSV一覧";
            // 
            // radioButtonShiftJis
            // 
            this.radioButtonShiftJis.AutoSize = true;
            this.radioButtonShiftJis.Checked = true;
            this.radioButtonShiftJis.Location = new System.Drawing.Point(22, 36);
            this.radioButtonShiftJis.Name = "radioButtonShiftJis";
            this.radioButtonShiftJis.Size = new System.Drawing.Size(93, 23);
            this.radioButtonShiftJis.TabIndex = 0;
            this.radioButtonShiftJis.TabStop = true;
            this.radioButtonShiftJis.Text = "Shift-JIS";
            this.radioButtonShiftJis.UseVisualStyleBackColor = true;
            // 
            // radioButtonUtf8
            // 
            this.radioButtonUtf8.AutoSize = true;
            this.radioButtonUtf8.Location = new System.Drawing.Point(22, 65);
            this.radioButtonUtf8.Name = "radioButtonUtf8";
            this.radioButtonUtf8.Size = new System.Drawing.Size(69, 23);
            this.radioButtonUtf8.TabIndex = 1;
            this.radioButtonUtf8.Text = "UTF8";
            this.radioButtonUtf8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "入力";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "出力";
            // 
            // comboBoxReadSplit
            // 
            this.comboBoxReadSplit.FormattingEnabled = true;
            this.comboBoxReadSplit.Items.AddRange(new object[] {
            "カンマ",
            "セミコロン",
            "スペース"});
            this.comboBoxReadSplit.Location = new System.Drawing.Point(92, 36);
            this.comboBoxReadSplit.Name = "comboBoxReadSplit";
            this.comboBoxReadSplit.Size = new System.Drawing.Size(121, 27);
            this.comboBoxReadSplit.TabIndex = 2;
            this.comboBoxReadSplit.Text = "カンマ";
            // 
            // comboBoxWriteSplit
            // 
            this.comboBoxWriteSplit.FormattingEnabled = true;
            this.comboBoxWriteSplit.Location = new System.Drawing.Point(92, 76);
            this.comboBoxWriteSplit.Name = "comboBoxWriteSplit";
            this.comboBoxWriteSplit.Size = new System.Drawing.Size(121, 27);
            this.comboBoxWriteSplit.TabIndex = 3;
            this.comboBoxWriteSplit.Text = "カンマ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "入力";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "出力";
            // 
            // comboBoxReadSuffix
            // 
            this.comboBoxReadSuffix.FormattingEnabled = true;
            this.comboBoxReadSuffix.Items.AddRange(new object[] {
            "csv",
            "dat"});
            this.comboBoxReadSuffix.Location = new System.Drawing.Point(92, 39);
            this.comboBoxReadSuffix.Name = "comboBoxReadSuffix";
            this.comboBoxReadSuffix.Size = new System.Drawing.Size(121, 27);
            this.comboBoxReadSuffix.TabIndex = 2;
            this.comboBoxReadSuffix.Text = "csv";
            this.comboBoxReadSuffix.TextChanged += new System.EventHandler(this.comboBoxReadSuffix_TextChanged);
            // 
            // comboBoxSaveSuffix
            // 
            this.comboBoxSaveSuffix.FormattingEnabled = true;
            this.comboBoxSaveSuffix.Items.AddRange(new object[] {
            "csv",
            "dat"});
            this.comboBoxSaveSuffix.Location = new System.Drawing.Point(92, 78);
            this.comboBoxSaveSuffix.Name = "comboBoxSaveSuffix";
            this.comboBoxSaveSuffix.Size = new System.Drawing.Size(121, 27);
            this.comboBoxSaveSuffix.TabIndex = 3;
            this.comboBoxSaveSuffix.Text = "csv";
            // 
            // numericUpDownNeglectRows
            // 
            this.numericUpDownNeglectRows.Location = new System.Drawing.Point(21, 36);
            this.numericUpDownNeglectRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNeglectRows.Name = "numericUpDownNeglectRows";
            this.numericUpDownNeglectRows.Size = new System.Drawing.Size(120, 27);
            this.numericUpDownNeglectRows.TabIndex = 0;
            this.numericUpDownNeglectRows.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "行目";
            // 
            // checkBoxNeglectFirstHeader
            // 
            this.checkBoxNeglectFirstHeader.AutoSize = true;
            this.checkBoxNeglectFirstHeader.Location = new System.Drawing.Point(6, 90);
            this.checkBoxNeglectFirstHeader.Name = "checkBoxNeglectFirstHeader";
            this.checkBoxNeglectFirstHeader.Size = new System.Drawing.Size(188, 23);
            this.checkBoxNeglectFirstHeader.TabIndex = 2;
            this.checkBoxNeglectFirstHeader.Text = "最初のファイルもヘッダ無視";
            this.checkBoxNeglectFirstHeader.UseVisualStyleBackColor = true;
            // 
            // checkBoxAddFileName
            // 
            this.checkBoxAddFileName.AutoSize = true;
            this.checkBoxAddFileName.Location = new System.Drawing.Point(21, 13);
            this.checkBoxAddFileName.Name = "checkBoxAddFileName";
            this.checkBoxAddFileName.Size = new System.Drawing.Size(151, 23);
            this.checkBoxAddFileName.TabIndex = 0;
            this.checkBoxAddFileName.Text = "ファイル名カラム追加";
            this.checkBoxAddFileName.UseVisualStyleBackColor = true;
            // 
            // buttonMergeCsv
            // 
            this.buttonMergeCsv.Location = new System.Drawing.Point(39, 58);
            this.buttonMergeCsv.Name = "buttonMergeCsv";
            this.buttonMergeCsv.Size = new System.Drawing.Size(110, 31);
            this.buttonMergeCsv.TabIndex = 1;
            this.buttonMergeCsv.Text = "合体";
            this.buttonMergeCsv.UseVisualStyleBackColor = true;
            this.buttonMergeCsv.Click += new System.EventHandler(this.buttonMergeCsv_Click);
            // 
            // radioButtonOnlyThisFolder
            // 
            this.radioButtonOnlyThisFolder.AutoSize = true;
            this.radioButtonOnlyThisFolder.Checked = true;
            this.radioButtonOnlyThisFolder.Location = new System.Drawing.Point(21, 35);
            this.radioButtonOnlyThisFolder.Name = "radioButtonOnlyThisFolder";
            this.radioButtonOnlyThisFolder.Size = new System.Drawing.Size(128, 23);
            this.radioButtonOnlyThisFolder.TabIndex = 0;
            this.radioButtonOnlyThisFolder.TabStop = true;
            this.radioButtonOnlyThisFolder.Text = "選択フォルダのみ";
            this.radioButtonOnlyThisFolder.UseVisualStyleBackColor = true;
            this.radioButtonOnlyThisFolder.CheckedChanged += new System.EventHandler(this.radioButtonOnlyThisFolder_CheckedChanged);
            // 
            // radioButtonUpper1Layer
            // 
            this.radioButtonUpper1Layer.AutoSize = true;
            this.radioButtonUpper1Layer.Location = new System.Drawing.Point(21, 64);
            this.radioButtonUpper1Layer.Name = "radioButtonUpper1Layer";
            this.radioButtonUpper1Layer.Size = new System.Drawing.Size(99, 23);
            this.radioButtonUpper1Layer.TabIndex = 1;
            this.radioButtonUpper1Layer.Text = "上位1階層";
            this.radioButtonUpper1Layer.UseVisualStyleBackColor = true;
            this.radioButtonUpper1Layer.CheckedChanged += new System.EventHandler(this.radioButtonUpper1Layer_CheckedChanged);
            // 
            // radioButtonUpper2Layers
            // 
            this.radioButtonUpper2Layers.AutoSize = true;
            this.radioButtonUpper2Layers.Location = new System.Drawing.Point(21, 93);
            this.radioButtonUpper2Layers.Name = "radioButtonUpper2Layers";
            this.radioButtonUpper2Layers.Size = new System.Drawing.Size(99, 23);
            this.radioButtonUpper2Layers.TabIndex = 2;
            this.radioButtonUpper2Layers.Text = "上位2階層";
            this.radioButtonUpper2Layers.UseVisualStyleBackColor = true;
            this.radioButtonUpper2Layers.CheckedChanged += new System.EventHandler(this.radioButtonUpper2Layers_CheckedChanged);
            // 
            // textBoxMergeCsvList
            // 
            this.textBoxMergeCsvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMergeCsvList.Location = new System.Drawing.Point(3, 23);
            this.textBoxMergeCsvList.Multiline = true;
            this.textBoxMergeCsvList.Name = "textBoxMergeCsvList";
            this.textBoxMergeCsvList.Size = new System.Drawing.Size(342, 436);
            this.textBoxMergeCsvList.TabIndex = 0;
            // 
            // FormMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMerge";
            this.Text = "CsvMerge";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeglectRows)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSelectCsv;
        private System.Windows.Forms.TextBox textBoxCsvPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButtonUtf8;
        private System.Windows.Forms.RadioButton radioButtonShiftJis;
        private System.Windows.Forms.ComboBox comboBoxWriteSplit;
        private System.Windows.Forms.ComboBox comboBoxReadSplit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSaveSuffix;
        private System.Windows.Forms.ComboBox comboBoxReadSuffix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxNeglectFirstHeader;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownNeglectRows;
        private System.Windows.Forms.RadioButton radioButtonUpper2Layers;
        private System.Windows.Forms.RadioButton radioButtonUpper1Layer;
        private System.Windows.Forms.RadioButton radioButtonOnlyThisFolder;
        private System.Windows.Forms.Button buttonMergeCsv;
        private System.Windows.Forms.CheckBox checkBoxAddFileName;
        private System.Windows.Forms.TextBox textBoxMergeCsvList;
    }
}