namespace CG_Trabalho
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
            openFileDialog = new OpenFileDialog();
            tabPage1 = new TabPage();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            radioButton3 = new RadioButton();
            Phong = new RadioButton();
            radioButton1 = new RadioButton();
            cores = new GroupBox();
            label3 = new Label();
            btFundo = new Button();
            label2 = new Label();
            btMaterial = new Button();
            label1 = new Label();
            cbProjecao = new ComboBox();
            tbD = new TextBox();
            labelPerspectiva = new Label();
            ckFacesOcultas = new CheckBox();
            btOpen = new Button();
            tabControl = new TabControl();
            colorDialog = new ColorDialog();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pbPrincipal = new PictureBox();
            materialColor = new ColorDialog();
            fundoColor = new ColorDialog();
            luzBtn = new Button();
            luzPotencia = new NumericUpDown();
            label5 = new Label();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            cores.SuspendLayout();
            tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPrincipal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)luzPotencia).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(33, 104, 105);
            tabPage1.Controls.Add(numericUpDown1);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(radioButton3);
            tabPage1.Controls.Add(Phong);
            tabPage1.Controls.Add(radioButton1);
            tabPage1.Controls.Add(cores);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(cbProjecao);
            tabPage1.Controls.Add(tbD);
            tabPage1.Controls.Add(labelPerspectiva);
            tabPage1.Controls.Add(ckFacesOcultas);
            tabPage1.Controls.Add(btOpen);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1340, 70);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "Programa";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(390, 13);
            numericUpDown1.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 10;
            numericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Window;
            label4.Location = new Point(390, 39);
            label4.Name = "label4";
            label4.Size = new Size(86, 15);
            label4.TabIndex = 9;
            label4.Text = "Especularidade";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.ForeColor = SystemColors.Window;
            radioButton3.Location = new Point(305, 50);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(68, 19);
            radioButton3.TabIndex = 7;
            radioButton3.TabStop = true;
            radioButton3.Text = "Gourard";
            radioButton3.UseVisualStyleBackColor = true;
            radioButton3.Click += gouraudTeste;
            // 
            // Phong
            // 
            Phong.AutoSize = true;
            Phong.ForeColor = SystemColors.Window;
            Phong.Location = new Point(304, 31);
            Phong.Name = "Phong";
            Phong.Size = new Size(60, 19);
            Phong.TabIndex = 6;
            Phong.TabStop = true;
            Phong.Text = "Phong";
            Phong.UseVisualStyleBackColor = true;
            Phong.Click += phongTeste;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = SystemColors.Window;
            radioButton1.Location = new Point(304, 8);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(44, 19);
            radioButton1.TabIndex = 5;
            radioButton1.TabStop = true;
            radioButton1.Text = "Flat";
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.MouseClick += flatTeste;
            // 
            // cores
            // 
            cores.Controls.Add(label3);
            cores.Controls.Add(btFundo);
            cores.Controls.Add(label2);
            cores.Controls.Add(btMaterial);
            cores.ForeColor = SystemColors.Window;
            cores.Location = new Point(144, 11);
            cores.Name = "cores";
            cores.Size = new Size(132, 59);
            cores.TabIndex = 4;
            cores.TabStop = false;
            cores.Text = "Cores";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(80, 38);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 3;
            label3.Text = "Fundo";
            // 
            // btFundo
            // 
            btFundo.Location = new Point(73, 14);
            btFundo.Name = "btFundo";
            btFundo.Size = new Size(54, 23);
            btFundo.TabIndex = 2;
            btFundo.UseVisualStyleBackColor = true;
            btFundo.Click += trocarFundo;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 37);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "Material";
            // 
            // btMaterial
            // 
            btMaterial.Location = new Point(6, 13);
            btMaterial.Name = "btMaterial";
            btMaterial.Size = new Size(54, 23);
            btMaterial.TabIndex = 0;
            btMaterial.UseVisualStyleBackColor = true;
            btMaterial.Click += abrirSeletorMaterial;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Window;
            label1.Location = new Point(758, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(99, 23);
            label1.TabIndex = 3;
            label1.Text = "Projeções";
            // 
            // cbProjecao
            // 
            cbProjecao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProjecao.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            cbProjecao.FormattingEnabled = true;
            cbProjecao.Items.AddRange(new object[] { "Paralela", "Cabinet", "Cavaleira", "Perspectiva" });
            cbProjecao.Location = new Point(722, 35);
            cbProjecao.Margin = new Padding(4, 3, 4, 3);
            cbProjecao.Name = "cbProjecao";
            cbProjecao.Size = new Size(190, 24);
            cbProjecao.TabIndex = 0;
            cbProjecao.SelectedIndexChanged += selecionaProjecao;
            // 
            // tbD
            // 
            tbD.BackColor = Color.FromArgb(70, 162, 164);
            tbD.Enabled = false;
            tbD.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            tbD.ForeColor = SystemColors.Window;
            tbD.Location = new Point(956, 32);
            tbD.Margin = new Padding(4, 3, 4, 3);
            tbD.Name = "tbD";
            tbD.Size = new Size(66, 26);
            tbD.TabIndex = 2;
            tbD.Text = "-500";
            tbD.TextAlign = HorizontalAlignment.Center;
            tbD.TextChanged += mudaTexto;
            // 
            // labelPerspectiva
            // 
            labelPerspectiva.AutoSize = true;
            labelPerspectiva.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelPerspectiva.ForeColor = SystemColors.Window;
            labelPerspectiva.Location = new Point(978, 11);
            labelPerspectiva.Margin = new Padding(4, 0, 4, 0);
            labelPerspectiva.Name = "labelPerspectiva";
            labelPerspectiva.Size = new Size(21, 23);
            labelPerspectiva.TabIndex = 1;
            labelPerspectiva.Text = "d";
            // 
            // ckFacesOcultas
            // 
            ckFacesOcultas.AutoSize = true;
            ckFacesOcultas.Checked = true;
            ckFacesOcultas.CheckState = CheckState.Checked;
            ckFacesOcultas.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            ckFacesOcultas.ForeColor = SystemColors.Window;
            ckFacesOcultas.Location = new Point(535, 32);
            ckFacesOcultas.Margin = new Padding(4, 3, 4, 3);
            ckFacesOcultas.Name = "ckFacesOcultas";
            ckFacesOcultas.Size = new Size(156, 27);
            ckFacesOcultas.TabIndex = 1;
            ckFacesOcultas.Text = "Faces Ocultas";
            ckFacesOcultas.UseVisualStyleBackColor = true;
            ckFacesOcultas.CheckedChanged += mudarFace;
            // 
            // btOpen
            // 
            btOpen.BackColor = Color.FromArgb(70, 162, 164);
            btOpen.FlatStyle = FlatStyle.Flat;
            btOpen.Font = new Font("Arial Black", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            btOpen.ForeColor = SystemColors.Window;
            btOpen.Location = new Point(26, 17);
            btOpen.Margin = new Padding(1);
            btOpen.Name = "btOpen";
            btOpen.Size = new Size(78, 38);
            btOpen.TabIndex = 0;
            btOpen.Text = "ABRIR";
            btOpen.UseVisualStyleBackColor = false;
            btOpen.Click += abrirArquivo;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1348, 98);
            tabControl.TabIndex = 3;
            tabControl.KeyDown += pressionaBotao;
            tabControl.KeyUp += soltaBotao;
            // 
            // pbPrincipal
            // 
            pbPrincipal.BackColor = Color.Black;
            pbPrincipal.Dock = DockStyle.Fill;
            pbPrincipal.Location = new Point(0, 98);
            pbPrincipal.Margin = new Padding(4, 3, 4, 3);
            pbPrincipal.Name = "pbPrincipal";
            pbPrincipal.Size = new Size(1348, 535);
            pbPrincipal.TabIndex = 0;
            pbPrincipal.TabStop = false;
            pbPrincipal.MouseDown += mouseDesce;
            pbPrincipal.MouseMove += movimentaMouse;
            // 
            // luzBtn
            // 
            luzBtn.Location = new Point(25, 136);
            luzBtn.Name = "luzBtn";
            luzBtn.Size = new Size(62, 53);
            luzBtn.TabIndex = 4;
            luzBtn.Text = "Luz";
            luzBtn.UseVisualStyleBackColor = true;
            luzBtn.MouseDown += mouseAbaixa;
            luzBtn.MouseMove += mouseLuzMove;
            luzBtn.MouseUp += mouseSobe;
            // 
            // luzPotencia
            // 
            luzPotencia.Location = new Point(796, 100);
            luzPotencia.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            luzPotencia.Name = "luzPotencia";
            luzPotencia.Size = new Size(120, 23);
            luzPotencia.TabIndex = 5;
            luzPotencia.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.WindowText;
            label5.ForeColor = SystemColors.Window;
            label5.Location = new Point(718, 102);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 6;
            label5.Text = "Luz distância";
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 633);
            Controls.Add(label5);
            Controls.Add(luzPotencia);
            Controls.Add(luzBtn);
            Controls.Add(pbPrincipal);
            Controls.Add(tabControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPrincipal";
            Text = "BlenderUnoeste";
            WindowState = FormWindowState.Maximized;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            cores.ResumeLayout(false);
            cores.PerformLayout();
            tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPrincipal).EndInit();
            ((System.ComponentModel.ISupportInitialize)luzPotencia).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pbPrincipal;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox ckFacesOcultas;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Label labelPerspectiva;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox cbProjecao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private GroupBox cores;
        private Label label2;
        private Button btMaterial;
        private Label label3;
        private Button btFundo;
        private ColorDialog materialColor;
        private ColorDialog fundoColor;
        private RadioButton radioButton3;
        private RadioButton Phong;
        private RadioButton radioButton1;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private Button luzBtn;
        private NumericUpDown luzPotencia;
        private Label label5;
    }
}

