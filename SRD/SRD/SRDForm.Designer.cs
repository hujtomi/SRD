namespace SRD
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.maskHeightTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.maskWidthTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.recountButton = new System.Windows.Forms.Button();
            this.thresholdTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.qtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.w3textBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.w2textBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.w1textBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.clickedPointLabel = new System.Windows.Forms.Label();
            this.SRDclickedPointLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.originalImageSizetextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.SRDImageSizetextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSRDAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterDeterminationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterDeterminationBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.batchRunningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxExtended1 = new SRD.Utils.PictureBoxExtended();
            this.pictureBoxExtended2 = new SRD.Utils.PictureBoxExtended();
            this.pictureBoxExtended3 = new SRD.Utils.PictureBoxExtended();
            this.batchRunningBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtended1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtended2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtended3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Browse image:";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(82, 3);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 382);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.infoLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.browseButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(815, 34);
            this.panel1.TabIndex = 0;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(176, 8);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(0, 13);
            this.infoLabel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.maskHeightTextBox);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.maskWidthTextBox);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.recountButton);
            this.panel2.Controls.Add(this.thresholdTextBox);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.qtextBox);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.w3textBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.w2textBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.w1textBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 345);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(815, 34);
            this.panel2.TabIndex = 1;
            // 
            // maskHeightTextBox
            // 
            this.maskHeightTextBox.Location = new System.Drawing.Point(653, 3);
            this.maskHeightTextBox.Name = "maskHeightTextBox";
            this.maskHeightTextBox.Size = new System.Drawing.Size(50, 20);
            this.maskHeightTextBox.TabIndex = 14;
            this.maskHeightTextBox.Text = "10";
            this.maskHeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(580, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "mask height:";
            // 
            // maskWidthTextBox
            // 
            this.maskWidthTextBox.Location = new System.Drawing.Point(524, 3);
            this.maskWidthTextBox.Name = "maskWidthTextBox";
            this.maskWidthTextBox.Size = new System.Drawing.Size(50, 20);
            this.maskWidthTextBox.TabIndex = 12;
            this.maskWidthTextBox.Text = "10";
            this.maskWidthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(455, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "mask width:";
            // 
            // recountButton
            // 
            this.recountButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.recountButton.Location = new System.Drawing.Point(737, 3);
            this.recountButton.Name = "recountButton";
            this.recountButton.Size = new System.Drawing.Size(75, 23);
            this.recountButton.TabIndex = 10;
            this.recountButton.Text = "Recount";
            this.recountButton.UseVisualStyleBackColor = true;
            this.recountButton.Click += new System.EventHandler(this.recountButton_Click);
            // 
            // thresholdTextBox
            // 
            this.thresholdTextBox.Location = new System.Drawing.Point(399, 3);
            this.thresholdTextBox.Name = "thresholdTextBox";
            this.thresholdTextBox.Size = new System.Drawing.Size(50, 20);
            this.thresholdTextBox.TabIndex = 9;
            this.thresholdTextBox.Text = "2";
            this.thresholdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "threshold:";
            // 
            // qtextBox
            // 
            this.qtextBox.Location = new System.Drawing.Point(284, 3);
            this.qtextBox.Name = "qtextBox";
            this.qtextBox.Size = new System.Drawing.Size(50, 20);
            this.qtextBox.TabIndex = 7;
            this.qtextBox.Text = "11";
            this.qtextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "q:";
            // 
            // w3textBox
            // 
            this.w3textBox.Location = new System.Drawing.Point(206, 3);
            this.w3textBox.Name = "w3textBox";
            this.w3textBox.Size = new System.Drawing.Size(50, 20);
            this.w3textBox.TabIndex = 5;
            this.w3textBox.Text = "11";
            this.w3textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "w3:";
            // 
            // w2textBox
            // 
            this.w2textBox.Location = new System.Drawing.Point(120, 3);
            this.w2textBox.Name = "w2textBox";
            this.w2textBox.Size = new System.Drawing.Size(50, 20);
            this.w2textBox.TabIndex = 3;
            this.w2textBox.Text = "7";
            this.w2textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "w2:";
            // 
            // w1textBox
            // 
            this.w1textBox.Location = new System.Drawing.Point(34, 3);
            this.w1textBox.Name = "w1textBox";
            this.w1textBox.Size = new System.Drawing.Size(50, 20);
            this.w1textBox.TabIndex = 1;
            this.w1textBox.Text = "3";
            this.w1textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "w1:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoScroll = true;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel2.Controls.Add(this.clickedPointLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SRDclickedPointLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.panel7, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(815, 296);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // clickedPointLabel
            // 
            this.clickedPointLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clickedPointLabel.AutoSize = true;
            this.clickedPointLabel.Location = new System.Drawing.Point(135, 8);
            this.clickedPointLabel.Name = "clickedPointLabel";
            this.clickedPointLabel.Size = new System.Drawing.Size(0, 13);
            this.clickedPointLabel.TabIndex = 2;
            // 
            // SRDclickedPointLabel
            // 
            this.SRDclickedPointLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SRDclickedPointLabel.AutoSize = true;
            this.SRDclickedPointLabel.Location = new System.Drawing.Point(678, 8);
            this.SRDclickedPointLabel.Name = "SRDclickedPointLabel";
            this.SRDclickedPointLabel.Size = new System.Drawing.Size(0, 13);
            this.SRDclickedPointLabel.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.originalImageSizetextBox);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(265, 24);
            this.panel3.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "%";
            // 
            // originalImageSizetextBox
            // 
            this.originalImageSizetextBox.Location = new System.Drawing.Point(39, 1);
            this.originalImageSizetextBox.Name = "originalImageSizetextBox";
            this.originalImageSizetextBox.Size = new System.Drawing.Size(100, 20);
            this.originalImageSizetextBox.TabIndex = 1;
            this.originalImageSizetextBox.Text = "100";
            this.originalImageSizetextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.originalImageSizetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.originalImageSizetextBox_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Size:";
            // 
            // panel4
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.SRDImageSizetextBox);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(274, 33);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(538, 24);
            this.panel4.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(259, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "%";
            // 
            // SRDImageSizetextBox
            // 
            this.SRDImageSizetextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SRDImageSizetextBox.Location = new System.Drawing.Point(153, 1);
            this.SRDImageSizetextBox.Name = "SRDImageSizetextBox";
            this.SRDImageSizetextBox.Size = new System.Drawing.Size(100, 20);
            this.SRDImageSizetextBox.TabIndex = 1;
            this.SRDImageSizetextBox.Text = "100";
            this.SRDImageSizetextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SRDImageSizetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SRDImageSizetextBox_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "SRD image size:";
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.Controls.Add(this.pictureBoxExtended1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 63);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(265, 230);
            this.panel5.TabIndex = 11;
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.Controls.Add(this.pictureBoxExtended2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(274, 63);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(265, 230);
            this.panel6.TabIndex = 12;
            // 
            // panel7
            // 
            this.panel7.AutoScroll = true;
            this.panel7.Controls.Add(this.pictureBoxExtended3);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(545, 63);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(267, 230);
            this.panel7.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(845, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveSRDAsToolStripMenuItem,
            this.parameterDeterminationToolStripMenuItem,
            this.batchRunningToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveSRDAsToolStripMenuItem
            // 
            this.saveSRDAsToolStripMenuItem.Name = "saveSRDAsToolStripMenuItem";
            this.saveSRDAsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.saveSRDAsToolStripMenuItem.Text = "Save SRD As";
            this.saveSRDAsToolStripMenuItem.Click += new System.EventHandler(this.saveSRDAsToolStripMenuItem_Click);
            // 
            // parameterDeterminationToolStripMenuItem
            // 
            this.parameterDeterminationToolStripMenuItem.Name = "parameterDeterminationToolStripMenuItem";
            this.parameterDeterminationToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.parameterDeterminationToolStripMenuItem.Text = "Parameter determination";
            this.parameterDeterminationToolStripMenuItem.Click += new System.EventHandler(this.parameterDeterminationToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // parameterDeterminationBackgroundWorker
            // 
            this.parameterDeterminationBackgroundWorker.WorkerReportsProgress = true;
            this.parameterDeterminationBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.parameterDeterminationBackgroundWorker_DoWork);
            this.parameterDeterminationBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.parameterDeterminationBackgroundWorker_ProgressChanged);
            // 
            // batchRunningToolStripMenuItem
            // 
            this.batchRunningToolStripMenuItem.Name = "batchRunningToolStripMenuItem";
            this.batchRunningToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.batchRunningToolStripMenuItem.Text = "Batch running";
            this.batchRunningToolStripMenuItem.Click += new System.EventHandler(this.batchRunningToolStripMenuItem_Click);
            // 
            // pictureBoxExtended1
            // 
            this.pictureBoxExtended1.Location = new System.Drawing.Point(0, 3);
            this.pictureBoxExtended1.Name = "pictureBoxExtended1";
            this.pictureBoxExtended1.Size = new System.Drawing.Size(167, 162);
            this.pictureBoxExtended1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExtended1.TabIndex = 5;
            this.pictureBoxExtended1.TabStop = false;
            this.pictureBoxExtended1.Click += new System.EventHandler(this.pictureBoxExtended1_Click);
            // 
            // pictureBoxExtended2
            // 
            this.pictureBoxExtended2.Location = new System.Drawing.Point(3, 0);
            this.pictureBoxExtended2.Name = "pictureBoxExtended2";
            this.pictureBoxExtended2.Size = new System.Drawing.Size(156, 165);
            this.pictureBoxExtended2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExtended2.TabIndex = 6;
            this.pictureBoxExtended2.TabStop = false;
            this.pictureBoxExtended2.Click += new System.EventHandler(this.pictureBoxExtended2_Click);
            this.pictureBoxExtended2.DoubleClick += new System.EventHandler(this.pictureBoxExtended2_DoubleClick);
            this.pictureBoxExtended2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxExtended2_MouseDown);
            this.pictureBoxExtended2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxExtended2_MouseUp);
            // 
            // pictureBoxExtended3
            // 
            this.pictureBoxExtended3.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxExtended3.Name = "pictureBoxExtended3";
            this.pictureBoxExtended3.Size = new System.Drawing.Size(161, 165);
            this.pictureBoxExtended3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExtended3.TabIndex = 7;
            this.pictureBoxExtended3.TabStop = false;
            this.pictureBoxExtended3.Click += new System.EventHandler(this.pictureBoxExtended3_Click);
            // 
            // batchRunningBackgroundWorker
            // 
            this.batchRunningBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.batchRunningBackgroundWorker_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "SRD";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtended1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtended2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExtended3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox qtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox w3textBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox w2textBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox w1textBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Utils.PictureBoxExtended pictureBoxExtended1;
        private System.Windows.Forms.Button recountButton;
        private System.Windows.Forms.TextBox thresholdTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label clickedPointLabel;
        private Utils.PictureBoxExtended pictureBoxExtended2;
        private Utils.PictureBoxExtended pictureBoxExtended3;
        private System.Windows.Forms.Label SRDclickedPointLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox originalImageSizetextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox SRDImageSizetextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSRDAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox maskHeightTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox maskWidthTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem parameterDeterminationToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker parameterDeterminationBackgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem batchRunningToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker batchRunningBackgroundWorker;
    }
}

