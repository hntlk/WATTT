namespace WAT
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.txt_Browse = new System.Windows.Forms.TextBox();
            this.rdb_MinMax = new System.Windows.Forms.RadioButton();
            this.rdb_ZeroMean = new System.Windows.Forms.RadioButton();
            this.txt_Min = new System.Windows.Forms.TextBox();
            this.txt_Max = new System.Windows.Forms.TextBox();
            this.lb_LengthUnusual = new System.Windows.Forms.Label();
            this.lb_LengthTime = new System.Windows.Forms.Label();
            this.cbb_LengthTime = new System.Windows.Forms.ComboBox();
            this.btn_BruteForce = new System.Windows.Forms.Button();
            this.zedGraphControlMain = new ZedGraph.ZedGraphControl();
            this.zedGraphControlBruteForce = new ZedGraph.ZedGraphControl();
            this.zedWat_TREE = new ZedGraph.ZedGraphControl();
            this.lb_Title = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbPoint = new System.Windows.Forms.ComboBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.Normalize = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cb_length = new System.Windows.Forms.ComboBox();
            this.cb_des = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.btn_watHash = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Wattree = new System.Windows.Forms.Button();
            this.zedWat_HASH = new ZedGraph.ZedGraphControl();
            this.btn_Draw = new System.Windows.Forms.Button();
            this.Namw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BRUTEFORCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAT_TREE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WAT_IMPROVED = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Normalize.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Browse
            // 
            this.btn_Browse.Location = new System.Drawing.Point(13, 49);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(75, 23);
            this.btn_Browse.TabIndex = 0;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // txt_Browse
            // 
            this.txt_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Browse.Location = new System.Drawing.Point(94, 51);
            this.txt_Browse.Name = "txt_Browse";
            this.txt_Browse.Size = new System.Drawing.Size(309, 20);
            this.txt_Browse.TabIndex = 1;
            this.txt_Browse.Text = "Double click to pick input file";
            this.txt_Browse.DoubleClick += new System.EventHandler(this.txt_Browse_DoubleClick);
            // 
            // rdb_MinMax
            // 
            this.rdb_MinMax.AutoSize = true;
            this.rdb_MinMax.Location = new System.Drawing.Point(16, 19);
            this.rdb_MinMax.Name = "rdb_MinMax";
            this.rdb_MinMax.Size = new System.Drawing.Size(65, 17);
            this.rdb_MinMax.TabIndex = 4;
            this.rdb_MinMax.Text = "Min-Max";
            this.rdb_MinMax.UseVisualStyleBackColor = true;
            // 
            // rdb_ZeroMean
            // 
            this.rdb_ZeroMean.AutoSize = true;
            this.rdb_ZeroMean.Checked = true;
            this.rdb_ZeroMean.Location = new System.Drawing.Point(304, 17);
            this.rdb_ZeroMean.Name = "rdb_ZeroMean";
            this.rdb_ZeroMean.Size = new System.Drawing.Size(77, 17);
            this.rdb_ZeroMean.TabIndex = 5;
            this.rdb_ZeroMean.TabStop = true;
            this.rdb_ZeroMean.Text = "Zero-Mean";
            this.rdb_ZeroMean.UseVisualStyleBackColor = true;
            // 
            // txt_Min
            // 
            this.txt_Min.Location = new System.Drawing.Point(127, 16);
            this.txt_Min.Name = "txt_Min";
            this.txt_Min.Size = new System.Drawing.Size(61, 20);
            this.txt_Min.TabIndex = 6;
            this.txt_Min.Text = "-1";
            this.txt_Min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Min.Click += new System.EventHandler(this.txt_Min_Click);
            // 
            // txt_Max
            // 
            this.txt_Max.Location = new System.Drawing.Point(222, 16);
            this.txt_Max.Name = "txt_Max";
            this.txt_Max.Size = new System.Drawing.Size(59, 20);
            this.txt_Max.TabIndex = 7;
            this.txt_Max.Text = "1";
            this.txt_Max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Max.Click += new System.EventHandler(this.txt_Max_Click);
            // 
            // lb_LengthUnusual
            // 
            this.lb_LengthUnusual.AutoSize = true;
            this.lb_LengthUnusual.Location = new System.Drawing.Point(231, 30);
            this.lb_LengthUnusual.Name = "lb_LengthUnusual";
            this.lb_LengthUnusual.Size = new System.Drawing.Size(147, 13);
            this.lb_LengthUnusual.TabIndex = 9;
            this.lb_LengthUnusual.Text = "Length of Unusual sequence:";
            // 
            // lb_LengthTime
            // 
            this.lb_LengthTime.AutoSize = true;
            this.lb_LengthTime.Location = new System.Drawing.Point(231, 56);
            this.lb_LengthTime.Name = "lb_LengthTime";
            this.lb_LengthTime.Size = new System.Drawing.Size(113, 13);
            this.lb_LengthTime.TabIndex = 10;
            this.lb_LengthTime.Text = "Length of Time Series:";
            // 
            // cbb_LengthTime
            // 
            this.cbb_LengthTime.FormattingEnabled = true;
            this.cbb_LengthTime.Items.AddRange(new object[] {
            "1000",
            "1024",
            "2000",
            "2048",
            "4000",
            "4096",
            "5000",
            "6000",
            "8000",
            "8192",
            "10000",
            "15000",
            "20000",
            "30000",
            "All"});
            this.cbb_LengthTime.Location = new System.Drawing.Point(384, 53);
            this.cbb_LengthTime.Name = "cbb_LengthTime";
            this.cbb_LengthTime.Size = new System.Drawing.Size(90, 21);
            this.cbb_LengthTime.TabIndex = 12;
            // 
            // btn_BruteForce
            // 
            this.btn_BruteForce.Location = new System.Drawing.Point(1179, 54);
            this.btn_BruteForce.Name = "btn_BruteForce";
            this.btn_BruteForce.Size = new System.Drawing.Size(106, 23);
            this.btn_BruteForce.TabIndex = 13;
            this.btn_BruteForce.Text = "Brute-Force";
            this.btn_BruteForce.UseVisualStyleBackColor = true;
            this.btn_BruteForce.Click += new System.EventHandler(this.btn_BruteForce_Click);
            // 
            // zedGraphControlMain
            // 
            this.zedGraphControlMain.IsAutoScrollRange = true;
            this.zedGraphControlMain.IsShowHScrollBar = true;
            this.zedGraphControlMain.IsShowPointValues = true;
            this.zedGraphControlMain.IsShowVScrollBar = true;
            this.zedGraphControlMain.Location = new System.Drawing.Point(4, 140);
            this.zedGraphControlMain.Name = "zedGraphControlMain";
            this.zedGraphControlMain.ScrollGrace = 0D;
            this.zedGraphControlMain.ScrollMaxX = 0D;
            this.zedGraphControlMain.ScrollMaxY = 0D;
            this.zedGraphControlMain.ScrollMaxY2 = 0D;
            this.zedGraphControlMain.ScrollMinX = 0D;
            this.zedGraphControlMain.ScrollMinY = 0D;
            this.zedGraphControlMain.ScrollMinY2 = 0D;
            this.zedGraphControlMain.Size = new System.Drawing.Size(1299, 219);
            this.zedGraphControlMain.TabIndex = 17;
            // 
            // zedGraphControlBruteForce
            // 
            this.zedGraphControlBruteForce.IsAutoScrollRange = true;
            this.zedGraphControlBruteForce.IsShowHScrollBar = true;
            this.zedGraphControlBruteForce.IsShowPointValues = true;
            this.zedGraphControlBruteForce.IsShowVScrollBar = true;
            this.zedGraphControlBruteForce.Location = new System.Drawing.Point(14, 365);
            this.zedGraphControlBruteForce.Name = "zedGraphControlBruteForce";
            this.zedGraphControlBruteForce.ScrollGrace = 0D;
            this.zedGraphControlBruteForce.ScrollMaxX = 0D;
            this.zedGraphControlBruteForce.ScrollMaxY = 0D;
            this.zedGraphControlBruteForce.ScrollMaxY2 = 0D;
            this.zedGraphControlBruteForce.ScrollMinX = 0D;
            this.zedGraphControlBruteForce.ScrollMinY = 0D;
            this.zedGraphControlBruteForce.ScrollMinY2 = 0D;
            this.zedGraphControlBruteForce.Size = new System.Drawing.Size(279, 205);
            this.zedGraphControlBruteForce.TabIndex = 18;
            // 
            // zedWat_TREE
            // 
            this.zedWat_TREE.IsShowHScrollBar = true;
            this.zedWat_TREE.IsShowPointValues = true;
            this.zedWat_TREE.IsShowVScrollBar = true;
            this.zedWat_TREE.Location = new System.Drawing.Point(298, 365);
            this.zedWat_TREE.Name = "zedWat_TREE";
            this.zedWat_TREE.ScrollGrace = 0D;
            this.zedWat_TREE.ScrollMaxX = 0D;
            this.zedWat_TREE.ScrollMaxY = 0D;
            this.zedWat_TREE.ScrollMaxY2 = 0D;
            this.zedWat_TREE.ScrollMinX = 0D;
            this.zedWat_TREE.ScrollMinY = 0D;
            this.zedWat_TREE.ScrollMinY2 = 0D;
            this.zedWat_TREE.Size = new System.Drawing.Size(279, 205);
            this.zedWat_TREE.TabIndex = 19;
            // 
            // lb_Title
            // 
            this.lb_Title.AutoSize = true;
            this.lb_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Title.Location = new System.Drawing.Point(338, 9);
            this.lb_Title.Name = "lb_Title";
            this.lb_Title.Size = new System.Drawing.Size(522, 24);
            this.lb_Title.TabIndex = 20;
            this.lb_Title.Text = "WAT: Finding Top-K Discords in Time Series Database";
            // 
            // cbPoint
            // 
            this.cbPoint.FormattingEnabled = true;
            this.cbPoint.Items.AddRange(new object[] {
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbPoint.Location = new System.Drawing.Point(88, 53);
            this.cbPoint.Name = "cbPoint";
            this.cbPoint.Size = new System.Drawing.Size(68, 21);
            this.cbPoint.TabIndex = 33;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(10, 58);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(57, 13);
            this.lblPoint.TabIndex = 32;
            this.lblPoint.Text = "Alphabets:";
            // 
            // Normalize
            // 
            this.Normalize.Controls.Add(this.label2);
            this.Normalize.Controls.Add(this.label1);
            this.Normalize.Controls.Add(this.txt_Max);
            this.Normalize.Controls.Add(this.txt_Min);
            this.Normalize.Controls.Add(this.rdb_MinMax);
            this.Normalize.Controls.Add(this.rdb_ZeroMean);
            this.Normalize.Location = new System.Drawing.Point(17, 78);
            this.Normalize.Name = "Normalize";
            this.Normalize.Size = new System.Drawing.Size(386, 46);
            this.Normalize.TabIndex = 34;
            this.Normalize.TabStop = false;
            this.Normalize.Text = "Normalize";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(194, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Max";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Min";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cb_length);
            this.groupBox1.Controls.Add(this.cb_des);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblPoint);
            this.groupBox1.Controls.Add(this.lb_LengthUnusual);
            this.groupBox1.Controls.Add(this.cbPoint);
            this.groupBox1.Controls.Add(this.cbb_LengthTime);
            this.groupBox1.Controls.Add(this.lb_LengthTime);
            this.groupBox1.Location = new System.Drawing.Point(565, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(578, 86);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(480, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 44;
            this.label4.Text = "All";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(162, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(19, 20);
            this.textBox1.TabIndex = 37;
            this.textBox1.Text = ":1";
            // 
            // cb_length
            // 
            this.cb_length.FormattingEnabled = true;
            this.cb_length.Items.AddRange(new object[] {
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.cb_length.Location = new System.Drawing.Point(384, 23);
            this.cb_length.Name = "cb_length";
            this.cb_length.Size = new System.Drawing.Size(90, 21);
            this.cb_length.TabIndex = 36;
            // 
            // cb_des
            // 
            this.cb_des.FormattingEnabled = true;
            this.cb_des.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.cb_des.Location = new System.Drawing.Point(88, 23);
            this.cb_des.Name = "cb_des";
            this.cb_des.Size = new System.Drawing.Size(68, 21);
            this.cb_des.TabIndex = 35;
            this.cb_des.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Tỷ lệ thu giảm";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(863, 365);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 196);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Namw,
            this.BRUTEFORCE,
            this.WAT_TREE,
            this.WAT_IMPROVED});
            this.dataGridView1.Location = new System.Drawing.Point(8, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(422, 160);
            this.dataGridView1.TabIndex = 0;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.IsAutoScrollRange = true;
            this.zedGraphControl1.IsShowHScrollBar = true;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.IsShowVScrollBar = true;
            this.zedGraphControl1.Location = new System.Drawing.Point(4, 140);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1299, 219);
            this.zedGraphControl1.TabIndex = 37;
            // 
            // btn_watHash
            // 
            this.btn_watHash.Location = new System.Drawing.Point(1179, 110);
            this.btn_watHash.Name = "btn_watHash";
            this.btn_watHash.Size = new System.Drawing.Size(106, 23);
            this.btn_watHash.TabIndex = 39;
            this.btn_watHash.Text = "WAT_IMPROVED";
            this.btn_watHash.UseVisualStyleBackColor = true;
            this.btn_watHash.Click += new System.EventHandler(this.btn_watHash_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightCoral;
            this.button1.Location = new System.Drawing.Point(418, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 40;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btn_Wattree
            // 
            this.btn_Wattree.Location = new System.Drawing.Point(1179, 82);
            this.btn_Wattree.Name = "btn_Wattree";
            this.btn_Wattree.Size = new System.Drawing.Size(106, 23);
            this.btn_Wattree.TabIndex = 41;
            this.btn_Wattree.Text = "WAT_TRIE";
            this.btn_Wattree.UseVisualStyleBackColor = true;
            this.btn_Wattree.Click += new System.EventHandler(this.btn_Wattree_Click);
            // 
            // zedWat_HASH
            // 
            this.zedWat_HASH.IsShowHScrollBar = true;
            this.zedWat_HASH.IsShowPointValues = true;
            this.zedWat_HASH.IsShowVScrollBar = true;
            this.zedWat_HASH.Location = new System.Drawing.Point(581, 365);
            this.zedWat_HASH.Name = "zedWat_HASH";
            this.zedWat_HASH.ScrollGrace = 0D;
            this.zedWat_HASH.ScrollMaxX = 0D;
            this.zedWat_HASH.ScrollMaxY = 0D;
            this.zedWat_HASH.ScrollMaxY2 = 0D;
            this.zedWat_HASH.ScrollMinX = 0D;
            this.zedWat_HASH.ScrollMinY = 0D;
            this.zedWat_HASH.ScrollMinY2 = 0D;
            this.zedWat_HASH.Size = new System.Drawing.Size(279, 205);
            this.zedWat_HASH.TabIndex = 42;
            // 
            // btn_Draw
            // 
            this.btn_Draw.Location = new System.Drawing.Point(418, 101);
            this.btn_Draw.Name = "btn_Draw";
            this.btn_Draw.Size = new System.Drawing.Size(83, 23);
            this.btn_Draw.TabIndex = 43;
            this.btn_Draw.Text = "Draw";
            this.btn_Draw.UseVisualStyleBackColor = true;
            this.btn_Draw.Click += new System.EventHandler(this.btn_Draw_Click);
            // 
            // Namw
            // 
            this.Namw.HeaderText = "Name";
            this.Namw.Name = "Namw";
            this.Namw.Width = 80;
            // 
            // BRUTEFORCE
            // 
            this.BRUTEFORCE.HeaderText = "BRUTEFORCE";
            this.BRUTEFORCE.Name = "BRUTEFORCE";
            // 
            // WAT_TREE
            // 
            this.WAT_TREE.HeaderText = "WAT_TRIE";
            this.WAT_TREE.Name = "WAT_TREE";
            // 
            // WAT_IMPROVED
            // 
            this.WAT_IMPROVED.HeaderText = "WAT_IMPROVED";
            this.WAT_IMPROVED.Name = "WAT_IMPROVED";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1312, 594);
            this.Controls.Add(this.btn_Draw);
            this.Controls.Add(this.zedWat_HASH);
            this.Controls.Add(this.btn_Wattree);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_watHash);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lb_Title);
            this.Controls.Add(this.zedWat_TREE);
            this.Controls.Add(this.zedGraphControlBruteForce);
            this.Controls.Add(this.zedGraphControlMain);
            this.Controls.Add(this.btn_BruteForce);
            this.Controls.Add(this.txt_Browse);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.Normalize);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Normalize.ResumeLayout(false);
            this.Normalize.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox txt_Browse;
        private System.Windows.Forms.RadioButton rdb_MinMax;
        private System.Windows.Forms.RadioButton rdb_ZeroMean;
        private System.Windows.Forms.TextBox txt_Min;
        private System.Windows.Forms.TextBox txt_Max;
        private System.Windows.Forms.Label lb_LengthUnusual;
        private System.Windows.Forms.Label lb_LengthTime;
        private System.Windows.Forms.ComboBox cbb_LengthTime;
        private System.Windows.Forms.Button btn_BruteForce;
        private ZedGraph.ZedGraphControl zedGraphControlMain;
        private ZedGraph.ZedGraphControl zedGraphControlBruteForce;
        private ZedGraph.ZedGraphControl zedWat_TREE;
        private System.Windows.Forms.Label lb_Title;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox cbPoint;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.GroupBox Normalize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        //private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_watHash;
        private System.Windows.Forms.ComboBox cb_des;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Wattree;
        private ZedGraph.ZedGraphControl zedWat_HASH;
        private System.Windows.Forms.ComboBox cb_length;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Draw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namw;
        private System.Windows.Forms.DataGridViewTextBoxColumn BRUTEFORCE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAT_TREE;
        private System.Windows.Forms.DataGridViewTextBoxColumn WAT_IMPROVED;
    }
}

