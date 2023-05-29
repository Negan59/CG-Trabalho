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
            openFileDialog = new OpenFileDialog();
            tabPage1 = new TabPage();
            tbD = new TextBox();
            labelPerspectiva = new Label();
            ckFacesOcultas = new CheckBox();
            btOpen = new Button();
            groupBox1 = new GroupBox();
            cbProjecao = new ComboBox();
            tabControl = new TabControl();
            colorDialog = new ColorDialog();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pbPrincipal = new PictureBox();
            tabPage1.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPrincipal).BeginInit();
            SuspendLayout();
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.DodgerBlue;
            tabPage1.Controls.Add(tbD);
            tabPage1.Controls.Add(labelPerspectiva);
            tabPage1.Controls.Add(ckFacesOcultas);
            tabPage1.Controls.Add(btOpen);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1356, 70);
            tabPage1.TabIndex = 1;
            tabPage1.Text = "Programa";
            // 
            // tbD
            // 
            tbD.BackColor = SystemColors.Highlight;
            tbD.Enabled = false;
            tbD.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tbD.ForeColor = SystemColors.Window;
            tbD.Location = new Point(361, 35);
            tbD.Margin = new Padding(4, 3, 4, 3);
            tbD.Name = "tbD";
            tbD.Size = new Size(66, 29);
            tbD.TabIndex = 2;
            tbD.Text = "-500";
            tbD.TextChanged += tbD_TextChanged;
            // 
            // labelPerspectiva
            // 
            labelPerspectiva.AutoSize = true;
            labelPerspectiva.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelPerspectiva.ForeColor = SystemColors.Window;
            labelPerspectiva.Location = new Point(327, 38);
            labelPerspectiva.Margin = new Padding(4, 0, 4, 0);
            labelPerspectiva.Name = "labelPerspectiva";
            labelPerspectiva.Size = new Size(38, 21);
            labelPerspectiva.TabIndex = 1;
            labelPerspectiva.Text = "d = ";
            // 
            // ckFacesOcultas
            // 
            ckFacesOcultas.AutoSize = true;
            ckFacesOcultas.Checked = true;
            ckFacesOcultas.CheckState = CheckState.Checked;
            ckFacesOcultas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ckFacesOcultas.ForeColor = SystemColors.Window;
            ckFacesOcultas.Location = new Point(327, 7);
            ckFacesOcultas.Margin = new Padding(4, 3, 4, 3);
            ckFacesOcultas.Name = "ckFacesOcultas";
            ckFacesOcultas.Size = new Size(121, 25);
            ckFacesOcultas.TabIndex = 1;
            ckFacesOcultas.Text = "Rm F Ocultas";
            ckFacesOcultas.UseVisualStyleBackColor = true;
            ckFacesOcultas.CheckedChanged += ckFacesOcultas_CheckedChanged;
            // 
            // btOpen
            // 
            btOpen.BackColor = Color.DarkGreen;
            btOpen.ForeColor = SystemColors.Window;
            btOpen.Location = new Point(9, 24);
            btOpen.Margin = new Padding(1);
            btOpen.Name = "btOpen";
            btOpen.Size = new Size(124, 30);
            btOpen.TabIndex = 0;
            btOpen.Text = "Abrir Objeto";
            btOpen.UseVisualStyleBackColor = false;
            btOpen.Click += clkOpen;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbProjecao);
            groupBox1.ForeColor = SystemColors.Window;
            groupBox1.Location = new Point(141, 14);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(178, 45);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Projeções";
            // 
            // cbProjecao
            // 
            cbProjecao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProjecao.FormattingEnabled = true;
            cbProjecao.Items.AddRange(new object[] { "Paralela", "Cabinet", "Cavaleira", "Perspectiva" });
            cbProjecao.Location = new Point(6, 17);
            cbProjecao.Margin = new Padding(4, 3, 4, 3);
            cbProjecao.Name = "cbProjecao";
            cbProjecao.Size = new Size(164, 23);
            cbProjecao.TabIndex = 0;
            cbProjecao.SelectedIndexChanged += cbProjecao_SelectedIndexChanged;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Dock = DockStyle.Top;
            tabControl.Location = new Point(0, 0);
            tabControl.Margin = new Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1364, 98);
            tabControl.TabIndex = 3;
            // 
            // pbPrincipal
            // 
            pbPrincipal.BackColor = SystemColors.ActiveCaptionText;
            pbPrincipal.Dock = DockStyle.Fill;
            pbPrincipal.Location = new Point(0, 98);
            pbPrincipal.Margin = new Padding(4, 3, 4, 3);
            pbPrincipal.Name = "pbPrincipal";
            pbPrincipal.Size = new Size(1364, 535);
            pbPrincipal.TabIndex = 0;
            pbPrincipal.TabStop = false;
            pbPrincipal.Click += pictureBox_Click;
            pbPrincipal.MouseDown += mouseDown;
            pbPrincipal.MouseMove += mouseMove;
            pbPrincipal.MouseUp += mouseUp;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 633);
            Controls.Add(pbPrincipal);
            Controls.Add(tabControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPrincipal";
            Text = "BlenderUnoeste";
            WindowState = FormWindowState.Maximized;
            Load += FormPrincipal_Load;
            KeyDown += FormPrincipal_KeyDown;
            KeyUp += FormPrincipal_KeyUp;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            groupBox1.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPrincipal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pbPrincipal;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox ckFacesOcultas;
        private System.Windows.Forms.Button btOpen;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPerspectiva;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox cbProjecao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

