namespace _3DViewer
{
    partial class FormPrincipal
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ckFacesOcultas = new System.Windows.Forms.CheckBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.rbPhong = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.scCAmbG = new System.Windows.Forms.HScrollBar();
            this.scCAmbB = new System.Windows.Forms.HScrollBar();
            this.scCAmbR = new System.Windows.Forms.HScrollBar();
            this.scCMatG = new System.Windows.Forms.HScrollBar();
            this.scCMatB = new System.Windows.Forms.HScrollBar();
            this.scCMatR = new System.Windows.Forms.HScrollBar();
            this.scCBrilhoG = new System.Windows.Forms.HScrollBar();
            this.scCBrilhoB = new System.Windows.Forms.HScrollBar();
            this.scCBrilhoR = new System.Windows.Forms.HScrollBar();
            this.lbCBrilho = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbCMat = new System.Windows.Forms.Label();
            this.lbCAmb = new System.Windows.Forms.Label();
            this.rbGouraud = new System.Windows.Forms.RadioButton();
            this.txN = new System.Windows.Forms.NumericUpDown();
            this.rbFlat = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.rbWireframe = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbProjecao = new System.Windows.Forms.ComboBox();
            this.labelPerspectiva = new System.Windows.Forms.Label();
            this.tbD = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scIAmbG = new System.Windows.Forms.HScrollBar();
            this.scIAmbB = new System.Windows.Forms.HScrollBar();
            this.scIAmbR = new System.Windows.Forms.HScrollBar();
            this.scIMatG = new System.Windows.Forms.HScrollBar();
            this.scIMatB = new System.Windows.Forms.HScrollBar();
            this.scIMatR = new System.Windows.Forms.HScrollBar();
            this.scIBrilhoG = new System.Windows.Forms.HScrollBar();
            this.scIBrilhoB = new System.Windows.Forms.HScrollBar();
            this.scIBrilhoR = new System.Windows.Forms.HScrollBar();
            this.lbIBrilho = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbIMat = new System.Windows.Forms.Label();
            this.lbIAmb = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageVistas = new System.Windows.Forms.TabPage();
            this.pbLateral = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPlanta = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbFrontal = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btLuz = new System.Windows.Forms.Button();
            this.pbPrincipal = new System.Windows.Forms.PictureBox();
            this.tabPage1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txN)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageVistas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLateral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrontal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ckFacesOcultas);
            this.tabPage1.Controls.Add(this.btOpen);
            this.tabPage1.Controls.Add(this.rbPhong);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.rbGouraud);
            this.tabPage1.Controls.Add(this.txN);
            this.tabPage1.Controls.Add(this.rbFlat);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.rbWireframe);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1184, 128);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Opções";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ckFacesOcultas
            // 
            this.ckFacesOcultas.AutoSize = true;
            this.ckFacesOcultas.Checked = true;
            this.ckFacesOcultas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFacesOcultas.Location = new System.Drawing.Point(171, 105);
            this.ckFacesOcultas.Name = "ckFacesOcultas";
            this.ckFacesOcultas.Size = new System.Drawing.Size(90, 17);
            this.ckFacesOcultas.TabIndex = 1;
            this.ckFacesOcultas.Text = "Rm F Ocultas";
            this.ckFacesOcultas.UseVisualStyleBackColor = true;
            this.ckFacesOcultas.CheckedChanged += new System.EventHandler(this.ckFacesOcultas_CheckedChanged);
            // 
            // btOpen
            // 
            this.btOpen.Location = new System.Drawing.Point(8, 6);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(153, 26);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Abrir Objeto";
            this.btOpen.UseVisualStyleBackColor = true;
            this.btOpen.Click += new System.EventHandler(this.clkOpen);
            // 
            // rbPhong
            // 
            this.rbPhong.AutoSize = true;
            this.rbPhong.Location = new System.Drawing.Point(170, 49);
            this.rbPhong.Name = "rbPhong";
            this.rbPhong.Size = new System.Drawing.Size(56, 17);
            this.rbPhong.TabIndex = 9;
            this.rbPhong.TabStop = true;
            this.rbPhong.Text = "Phong";
            this.rbPhong.UseVisualStyleBackColor = true;
            this.rbPhong.CheckedChanged += new System.EventHandler(this.rbPhong_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.scCAmbG);
            this.groupBox4.Controls.Add(this.scCAmbB);
            this.groupBox4.Controls.Add(this.scCAmbR);
            this.groupBox4.Controls.Add(this.scCMatG);
            this.groupBox4.Controls.Add(this.scCMatB);
            this.groupBox4.Controls.Add(this.scCMatR);
            this.groupBox4.Controls.Add(this.scCBrilhoG);
            this.groupBox4.Controls.Add(this.scCBrilhoB);
            this.groupBox4.Controls.Add(this.scCBrilhoR);
            this.groupBox4.Controls.Add(this.lbCBrilho);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lbCMat);
            this.groupBox4.Controls.Add(this.lbCAmb);
            this.groupBox4.Location = new System.Drawing.Point(753, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(450, 104);
            this.groupBox4.TabIndex = 34;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cor";
            // 
            // scCAmbG
            // 
            this.scCAmbG.Location = new System.Drawing.Point(22, 61);
            this.scCAmbG.Name = "scCAmbG";
            this.scCAmbG.Size = new System.Drawing.Size(135, 15);
            this.scCAmbG.TabIndex = 33;
            this.scCAmbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCAmbG_Scroll);
            // 
            // scCAmbB
            // 
            this.scCAmbB.Location = new System.Drawing.Point(21, 82);
            this.scCAmbB.Name = "scCAmbB";
            this.scCAmbB.Size = new System.Drawing.Size(135, 15);
            this.scCAmbB.TabIndex = 32;
            this.scCAmbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCAmbB_Scroll);
            // 
            // scCAmbR
            // 
            this.scCAmbR.Location = new System.Drawing.Point(22, 39);
            this.scCAmbR.Name = "scCAmbR";
            this.scCAmbR.Size = new System.Drawing.Size(135, 15);
            this.scCAmbR.TabIndex = 31;
            this.scCAmbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCAmbR_Scroll);
            // 
            // scCMatG
            // 
            this.scCMatG.Location = new System.Drawing.Point(161, 61);
            this.scCMatG.Name = "scCMatG";
            this.scCMatG.Size = new System.Drawing.Size(135, 15);
            this.scCMatG.TabIndex = 30;
            this.scCMatG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCMatG_Scroll);
            // 
            // scCMatB
            // 
            this.scCMatB.Location = new System.Drawing.Point(161, 82);
            this.scCMatB.Name = "scCMatB";
            this.scCMatB.Size = new System.Drawing.Size(135, 15);
            this.scCMatB.TabIndex = 29;
            this.scCMatB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCMatB_Scroll);
            // 
            // scCMatR
            // 
            this.scCMatR.Location = new System.Drawing.Point(161, 39);
            this.scCMatR.Name = "scCMatR";
            this.scCMatR.Size = new System.Drawing.Size(135, 15);
            this.scCMatR.TabIndex = 28;
            this.scCMatR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCMatR_Scroll);
            // 
            // scCBrilhoG
            // 
            this.scCBrilhoG.Location = new System.Drawing.Point(300, 61);
            this.scCBrilhoG.Name = "scCBrilhoG";
            this.scCBrilhoG.Size = new System.Drawing.Size(135, 15);
            this.scCBrilhoG.TabIndex = 27;
            this.scCBrilhoG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCBrilhoG_Scroll);
            // 
            // scCBrilhoB
            // 
            this.scCBrilhoB.Location = new System.Drawing.Point(300, 82);
            this.scCBrilhoB.Name = "scCBrilhoB";
            this.scCBrilhoB.Size = new System.Drawing.Size(135, 15);
            this.scCBrilhoB.TabIndex = 26;
            this.scCBrilhoB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCBrilhoB_Scroll);
            // 
            // scCBrilhoR
            // 
            this.scCBrilhoR.Location = new System.Drawing.Point(300, 39);
            this.scCBrilhoR.Name = "scCBrilhoR";
            this.scCBrilhoR.Size = new System.Drawing.Size(135, 15);
            this.scCBrilhoR.TabIndex = 25;
            this.scCBrilhoR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scCBrilhoR_Scroll);
            // 
            // lbCBrilho
            // 
            this.lbCBrilho.AutoSize = true;
            this.lbCBrilho.BackColor = System.Drawing.Color.Black;
            this.lbCBrilho.ForeColor = System.Drawing.Color.White;
            this.lbCBrilho.Location = new System.Drawing.Point(355, 22);
            this.lbCBrilho.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCBrilho.Name = "lbCBrilho";
            this.lbCBrilho.Size = new System.Drawing.Size(36, 13);
            this.lbCBrilho.TabIndex = 17;
            this.lbCBrilho.Text = "Brilho:";
            this.lbCBrilho.Click += new System.EventHandler(this.lbCBrilho_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "B";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "G";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "R";
            // 
            // lbCMat
            // 
            this.lbCMat.AutoSize = true;
            this.lbCMat.BackColor = System.Drawing.Color.Black;
            this.lbCMat.ForeColor = System.Drawing.Color.White;
            this.lbCMat.Location = new System.Drawing.Point(210, 22);
            this.lbCMat.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCMat.Name = "lbCMat";
            this.lbCMat.Size = new System.Drawing.Size(47, 13);
            this.lbCMat.TabIndex = 10;
            this.lbCMat.Text = "Material:";
            this.lbCMat.Click += new System.EventHandler(this.lbCMat_Click);
            // 
            // lbCAmb
            // 
            this.lbCAmb.AutoSize = true;
            this.lbCAmb.BackColor = System.Drawing.Color.Black;
            this.lbCAmb.ForeColor = System.Drawing.Color.White;
            this.lbCAmb.Location = new System.Drawing.Point(67, 22);
            this.lbCAmb.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbCAmb.Name = "lbCAmb";
            this.lbCAmb.Size = new System.Drawing.Size(54, 13);
            this.lbCAmb.TabIndex = 3;
            this.lbCAmb.Text = "Ambiente:";
            this.lbCAmb.Click += new System.EventHandler(this.lbCAmb_Click);
            // 
            // rbGouraud
            // 
            this.rbGouraud.AutoSize = true;
            this.rbGouraud.Location = new System.Drawing.Point(170, 33);
            this.rbGouraud.Name = "rbGouraud";
            this.rbGouraud.Size = new System.Drawing.Size(66, 17);
            this.rbGouraud.TabIndex = 8;
            this.rbGouraud.TabStop = true;
            this.rbGouraud.Text = "Gouraud";
            this.rbGouraud.UseVisualStyleBackColor = true;
            this.rbGouraud.CheckedChanged += new System.EventHandler(this.rbGouraud_CheckedChanged);
            // 
            // txN
            // 
            this.txN.Location = new System.Drawing.Point(170, 81);
            this.txN.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txN.Name = "txN";
            this.txN.Size = new System.Drawing.Size(61, 20);
            this.txN.TabIndex = 6;
            this.txN.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txN.ValueChanged += new System.EventHandler(this.txN_ValueChanged);
            // 
            // rbFlat
            // 
            this.rbFlat.AutoSize = true;
            this.rbFlat.Location = new System.Drawing.Point(170, 17);
            this.rbFlat.Name = "rbFlat";
            this.rbFlat.Size = new System.Drawing.Size(42, 17);
            this.rbFlat.TabIndex = 7;
            this.rbFlat.TabStop = true;
            this.rbFlat.Text = "Flat";
            this.rbFlat.UseVisualStyleBackColor = true;
            this.rbFlat.CheckedChanged += new System.EventHandler(this.rbFlat_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(167, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Grau de Especularidade:";
            // 
            // rbWireframe
            // 
            this.rbWireframe.AutoSize = true;
            this.rbWireframe.Checked = true;
            this.rbWireframe.Location = new System.Drawing.Point(170, 1);
            this.rbWireframe.Name = "rbWireframe";
            this.rbWireframe.Size = new System.Drawing.Size(73, 17);
            this.rbWireframe.TabIndex = 6;
            this.rbWireframe.TabStop = true;
            this.rbWireframe.Text = "Wireframe";
            this.rbWireframe.UseVisualStyleBackColor = true;
            this.rbWireframe.CheckedChanged += new System.EventHandler(this.rbWireframe_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProjecao);
            this.groupBox1.Controls.Add(this.labelPerspectiva);
            this.groupBox1.Controls.Add(this.tbD);
            this.groupBox1.Location = new System.Drawing.Point(8, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 78);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projeções";
            // 
            // cbProjecao
            // 
            this.cbProjecao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjecao.FormattingEnabled = true;
            this.cbProjecao.Items.AddRange(new object[] {
            "Paralela",
            "Cabinet",
            "Cavaleira",
            "Perspectiva"});
            this.cbProjecao.Location = new System.Drawing.Point(6, 19);
            this.cbProjecao.Name = "cbProjecao";
            this.cbProjecao.Size = new System.Drawing.Size(141, 21);
            this.cbProjecao.TabIndex = 0;
            this.cbProjecao.SelectedIndexChanged += new System.EventHandler(this.cbProjecao_SelectedIndexChanged);
            // 
            // labelPerspectiva
            // 
            this.labelPerspectiva.AutoSize = true;
            this.labelPerspectiva.Location = new System.Drawing.Point(6, 53);
            this.labelPerspectiva.Name = "labelPerspectiva";
            this.labelPerspectiva.Size = new System.Drawing.Size(25, 13);
            this.labelPerspectiva.TabIndex = 1;
            this.labelPerspectiva.Text = "d = ";
            // 
            // tbD
            // 
            this.tbD.Enabled = false;
            this.tbD.Location = new System.Drawing.Point(37, 50);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(43, 20);
            this.tbD.TabIndex = 2;
            this.tbD.Text = "-500";
            this.tbD.TextChanged += new System.EventHandler(this.tbD_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scIAmbG);
            this.groupBox2.Controls.Add(this.scIAmbB);
            this.groupBox2.Controls.Add(this.scIAmbR);
            this.groupBox2.Controls.Add(this.scIMatG);
            this.groupBox2.Controls.Add(this.scIMatB);
            this.groupBox2.Controls.Add(this.scIMatR);
            this.groupBox2.Controls.Add(this.scIBrilhoG);
            this.groupBox2.Controls.Add(this.scIBrilhoB);
            this.groupBox2.Controls.Add(this.scIBrilhoR);
            this.groupBox2.Controls.Add(this.lbIBrilho);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.lbIMat);
            this.groupBox2.Controls.Add(this.lbIAmb);
            this.groupBox2.Location = new System.Drawing.Point(297, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Intensidade";
            // 
            // scIAmbG
            // 
            this.scIAmbG.Location = new System.Drawing.Point(21, 61);
            this.scIAmbG.Name = "scIAmbG";
            this.scIAmbG.Size = new System.Drawing.Size(135, 15);
            this.scIAmbG.TabIndex = 33;
            this.scIAmbG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIAmbG_Scroll);
            // 
            // scIAmbB
            // 
            this.scIAmbB.Location = new System.Drawing.Point(21, 82);
            this.scIAmbB.Name = "scIAmbB";
            this.scIAmbB.Size = new System.Drawing.Size(135, 15);
            this.scIAmbB.TabIndex = 32;
            this.scIAmbB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIAmbB_Scroll);
            // 
            // scIAmbR
            // 
            this.scIAmbR.Location = new System.Drawing.Point(21, 39);
            this.scIAmbR.Name = "scIAmbR";
            this.scIAmbR.Size = new System.Drawing.Size(135, 15);
            this.scIAmbR.TabIndex = 31;
            this.scIAmbR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIAmbR_Scroll);
            // 
            // scIMatG
            // 
            this.scIMatG.Location = new System.Drawing.Point(165, 61);
            this.scIMatG.Name = "scIMatG";
            this.scIMatG.Size = new System.Drawing.Size(135, 15);
            this.scIMatG.TabIndex = 30;
            this.scIMatG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIMatG_Scroll);
            // 
            // scIMatB
            // 
            this.scIMatB.Location = new System.Drawing.Point(165, 82);
            this.scIMatB.Name = "scIMatB";
            this.scIMatB.Size = new System.Drawing.Size(135, 15);
            this.scIMatB.TabIndex = 29;
            this.scIMatB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIMatB_Scroll);
            // 
            // scIMatR
            // 
            this.scIMatR.Location = new System.Drawing.Point(165, 39);
            this.scIMatR.Name = "scIMatR";
            this.scIMatR.Size = new System.Drawing.Size(135, 15);
            this.scIMatR.TabIndex = 28;
            this.scIMatR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIMatR_Scroll);
            // 
            // scIBrilhoG
            // 
            this.scIBrilhoG.Location = new System.Drawing.Point(307, 61);
            this.scIBrilhoG.Name = "scIBrilhoG";
            this.scIBrilhoG.Size = new System.Drawing.Size(135, 15);
            this.scIBrilhoG.TabIndex = 27;
            this.scIBrilhoG.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIBrilhoG_Scroll);
            // 
            // scIBrilhoB
            // 
            this.scIBrilhoB.Location = new System.Drawing.Point(307, 82);
            this.scIBrilhoB.Name = "scIBrilhoB";
            this.scIBrilhoB.Size = new System.Drawing.Size(135, 15);
            this.scIBrilhoB.TabIndex = 26;
            this.scIBrilhoB.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIBrilhoB_Scroll);
            // 
            // scIBrilhoR
            // 
            this.scIBrilhoR.Location = new System.Drawing.Point(307, 39);
            this.scIBrilhoR.Name = "scIBrilhoR";
            this.scIBrilhoR.Size = new System.Drawing.Size(135, 15);
            this.scIBrilhoR.TabIndex = 25;
            this.scIBrilhoR.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scIBrilhoR_Scroll);
            // 
            // lbIBrilho
            // 
            this.lbIBrilho.AutoSize = true;
            this.lbIBrilho.BackColor = System.Drawing.Color.Black;
            this.lbIBrilho.ForeColor = System.Drawing.Color.White;
            this.lbIBrilho.Location = new System.Drawing.Point(354, 22);
            this.lbIBrilho.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbIBrilho.Name = "lbIBrilho";
            this.lbIBrilho.Size = new System.Drawing.Size(36, 13);
            this.lbIBrilho.TabIndex = 17;
            this.lbIBrilho.Text = "Brilho:";
            this.lbIBrilho.Click += new System.EventHandler(this.lbIBrilho_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "B";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "G";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "R";
            // 
            // lbIMat
            // 
            this.lbIMat.AutoSize = true;
            this.lbIMat.BackColor = System.Drawing.Color.Black;
            this.lbIMat.ForeColor = System.Drawing.Color.White;
            this.lbIMat.Location = new System.Drawing.Point(211, 22);
            this.lbIMat.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbIMat.Name = "lbIMat";
            this.lbIMat.Size = new System.Drawing.Size(47, 13);
            this.lbIMat.TabIndex = 10;
            this.lbIMat.Text = "Material:";
            this.lbIMat.Click += new System.EventHandler(this.lbIMat_Click);
            // 
            // lbIAmb
            // 
            this.lbIAmb.AutoSize = true;
            this.lbIAmb.BackColor = System.Drawing.Color.Black;
            this.lbIAmb.ForeColor = System.Drawing.Color.White;
            this.lbIAmb.Location = new System.Drawing.Point(44, 22);
            this.lbIAmb.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lbIAmb.Name = "lbIAmb";
            this.lbIAmb.Size = new System.Drawing.Size(54, 13);
            this.lbIAmb.TabIndex = 3;
            this.lbIAmb.Text = "Ambiente:";
            this.lbIAmb.Click += new System.EventHandler(this.lbIAmb_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPageVistas);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1192, 154);
            this.tabControl.TabIndex = 3;
            this.tabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl_Selected);
            // 
            // tabPageVistas
            // 
            this.tabPageVistas.Controls.Add(this.pbLateral);
            this.tabPageVistas.Controls.Add(this.label3);
            this.tabPageVistas.Controls.Add(this.pbPlanta);
            this.tabPageVistas.Controls.Add(this.label1);
            this.tabPageVistas.Controls.Add(this.pbFrontal);
            this.tabPageVistas.Controls.Add(this.label2);
            this.tabPageVistas.Location = new System.Drawing.Point(4, 22);
            this.tabPageVistas.Name = "tabPageVistas";
            this.tabPageVistas.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVistas.Size = new System.Drawing.Size(1184, 128);
            this.tabPageVistas.TabIndex = 3;
            this.tabPageVistas.Text = "Vistas";
            this.tabPageVistas.UseVisualStyleBackColor = true;
            // 
            // pbLateral
            // 
            this.pbLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbLateral.Location = new System.Drawing.Point(678, 3);
            this.pbLateral.MaximumSize = new System.Drawing.Size(400, 200);
            this.pbLateral.Name = "pbLateral";
            this.pbLateral.Size = new System.Drawing.Size(280, 122);
            this.pbLateral.TabIndex = 2;
            this.pbLateral.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(639, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lateral";
            // 
            // pbPlanta
            // 
            this.pbPlanta.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbPlanta.Location = new System.Drawing.Point(359, 3);
            this.pbPlanta.MaximumSize = new System.Drawing.Size(300, 200);
            this.pbPlanta.Name = "pbPlanta";
            this.pbPlanta.Size = new System.Drawing.Size(280, 122);
            this.pbPlanta.TabIndex = 0;
            this.pbPlanta.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(322, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Planta";
            // 
            // pbFrontal
            // 
            this.pbFrontal.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbFrontal.Location = new System.Drawing.Point(42, 3);
            this.pbFrontal.MaximumSize = new System.Drawing.Size(300, 200);
            this.pbFrontal.Name = "pbFrontal";
            this.pbFrontal.Size = new System.Drawing.Size(280, 122);
            this.pbFrontal.TabIndex = 1;
            this.pbFrontal.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Frontal";
            // 
            // btLuz
            // 
            this.btLuz.BackColor = System.Drawing.Color.Transparent;
            this.btLuz.FlatAppearance.BorderSize = 0;
            this.btLuz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLuz.Image = global::_3DViewer.Properties.Resources.sol;
            this.btLuz.Location = new System.Drawing.Point(21, 180);
            this.btLuz.Name = "btLuz";
            this.btLuz.Size = new System.Drawing.Size(36, 36);
            this.btLuz.TabIndex = 44;
            this.btLuz.UseVisualStyleBackColor = false;
            this.btLuz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btLuz_MouseDown);
            this.btLuz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btLuz_MouseMove);
            this.btLuz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btLuz_MouseUp);
            // 
            // pbPrincipal
            // 
            this.pbPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPrincipal.Location = new System.Drawing.Point(0, 154);
            this.pbPrincipal.Name = "pbPrincipal";
            this.pbPrincipal.Size = new System.Drawing.Size(1192, 395);
            this.pbPrincipal.TabIndex = 0;
            this.pbPrincipal.TabStop = false;
            this.pbPrincipal.Click += new System.EventHandler(this.pictureBox_Click);
            this.pbPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pbPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove);
            this.pbPrincipal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 549);
            this.Controls.Add(this.btLuz);
            this.Controls.Add(this.pbPrincipal);
            this.Controls.Add(this.tabControl);
            this.Name = "FormPrincipal";
            this.Text = "3DViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormPrincipal_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormPrincipal_KeyUp);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageVistas.ResumeLayout(false);
            this.tabPageVistas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLateral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFrontal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPrincipal;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox ckFacesOcultas;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageVistas;
        public System.Windows.Forms.PictureBox pbLateral;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.PictureBox pbFrontal;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pbPlanta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPerspectiva;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox cbProjecao;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbWireframe;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton rbPhong;
        private System.Windows.Forms.RadioButton rbGouraud;
        private System.Windows.Forms.RadioButton rbFlat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txN;
        private System.Windows.Forms.Label lbIAmb;
        private System.Windows.Forms.Label lbIBrilho;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbIMat;
        private System.Windows.Forms.HScrollBar scIBrilhoR;
        private System.Windows.Forms.HScrollBar scIAmbG;
        private System.Windows.Forms.HScrollBar scIAmbB;
        private System.Windows.Forms.HScrollBar scIAmbR;
        private System.Windows.Forms.HScrollBar scIMatG;
        private System.Windows.Forms.HScrollBar scIMatB;
        private System.Windows.Forms.HScrollBar scIMatR;
        private System.Windows.Forms.HScrollBar scIBrilhoG;
        private System.Windows.Forms.HScrollBar scIBrilhoB;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.HScrollBar scCAmbG;
        private System.Windows.Forms.HScrollBar scCAmbB;
        private System.Windows.Forms.HScrollBar scCAmbR;
        private System.Windows.Forms.HScrollBar scCMatG;
        private System.Windows.Forms.HScrollBar scCMatB;
        private System.Windows.Forms.HScrollBar scCMatR;
        private System.Windows.Forms.HScrollBar scCBrilhoG;
        private System.Windows.Forms.HScrollBar scCBrilhoB;
        private System.Windows.Forms.HScrollBar scCBrilhoR;
        private System.Windows.Forms.Label lbCBrilho;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbCMat;
        private System.Windows.Forms.Label lbCAmb;
        private System.Windows.Forms.Button btLuz;
    }
}

