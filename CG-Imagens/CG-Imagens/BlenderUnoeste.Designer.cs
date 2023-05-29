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
            tabPage1.SuspendLayout();
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
            tabPage1.BackColor = Color.FromArgb(33, 104, 105);
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
            label1.Click += label1_Click;
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
            cbProjecao.SelectedIndexChanged += cbProjecao_SelectedIndexChanged;
            cbProjecao.SelectionChangeCommitted += selecionaProjecao;
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
            labelPerspectiva.Click += labelPerspectiva_Click;
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
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
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
            pbPrincipal.Click += pbPrincipal_Click;
            pbPrincipal.MouseDown += mouseDesce;
            pbPrincipal.MouseMove += movimentaMouse;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1348, 633);
            Controls.Add(pbPrincipal);
            Controls.Add(tabControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormPrincipal";
            Text = "BlenderUnoeste";
            WindowState = FormWindowState.Maximized;
            KeyDown += pressionaBotao;
            KeyUp += soltaBotao;
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
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
        private System.Windows.Forms.Label labelPerspectiva;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox cbProjecao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
    }
}

