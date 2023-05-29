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
            this.tbD = new System.Windows.Forms.TextBox();
            this.labelPerspectiva = new System.Windows.Forms.Label();
            this.ckFacesOcultas = new System.Windows.Forms.CheckBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbProjecao = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbPrincipal = new System.Windows.Forms.PictureBox();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DodgerBlue;
            this.tabPage1.Controls.Add(this.tbD);
            this.tabPage1.Controls.Add(this.labelPerspectiva);
            this.tabPage1.Controls.Add(this.ckFacesOcultas);
            this.tabPage1.Controls.Add(this.btOpen);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(1356, 70);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Programa";
            // 
            // tbD
            // 
            this.tbD.BackColor = System.Drawing.SystemColors.Highlight;
            this.tbD.Enabled = false;
            this.tbD.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbD.ForeColor = System.Drawing.SystemColors.Window;
            this.tbD.Location = new System.Drawing.Point(361, 35);
            this.tbD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(66, 29);
            this.tbD.TabIndex = 2;
            this.tbD.Text = "-500";
            this.tbD.TextChanged += new System.EventHandler(this.mudaTexto);
            // 
            // labelPerspectiva
            // 
            this.labelPerspectiva.AutoSize = true;
            this.labelPerspectiva.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPerspectiva.ForeColor = System.Drawing.SystemColors.Window;
            this.labelPerspectiva.Location = new System.Drawing.Point(327, 38);
            this.labelPerspectiva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPerspectiva.Name = "labelPerspectiva";
            this.labelPerspectiva.Size = new System.Drawing.Size(38, 21);
            this.labelPerspectiva.TabIndex = 1;
            this.labelPerspectiva.Text = "d = ";
            // 
            // ckFacesOcultas
            // 
            this.ckFacesOcultas.AutoSize = true;
            this.ckFacesOcultas.Checked = true;
            this.ckFacesOcultas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFacesOcultas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ckFacesOcultas.ForeColor = System.Drawing.SystemColors.Window;
            this.ckFacesOcultas.Location = new System.Drawing.Point(327, 7);
            this.ckFacesOcultas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckFacesOcultas.Name = "ckFacesOcultas";
            this.ckFacesOcultas.Size = new System.Drawing.Size(122, 25);
            this.ckFacesOcultas.TabIndex = 1;
            this.ckFacesOcultas.Text = "Faces Ocultas";
            this.ckFacesOcultas.UseVisualStyleBackColor = true;
            this.ckFacesOcultas.CheckedChanged += new System.EventHandler(this.mudarFace);
            // 
            // btOpen
            // 
            this.btOpen.BackColor = System.Drawing.Color.DarkGreen;
            this.btOpen.ForeColor = System.Drawing.SystemColors.Window;
            this.btOpen.Location = new System.Drawing.Point(9, 24);
            this.btOpen.Margin = new System.Windows.Forms.Padding(1);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(124, 30);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "Abrir Objeto";
            this.btOpen.UseVisualStyleBackColor = false;
            this.btOpen.Click += new System.EventHandler(this.abrirArquivo);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbProjecao);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Location = new System.Drawing.Point(141, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(178, 45);
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
            this.cbProjecao.Location = new System.Drawing.Point(6, 17);
            this.cbProjecao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbProjecao.Name = "cbProjecao";
            this.cbProjecao.Size = new System.Drawing.Size(164, 23);
            this.cbProjecao.TabIndex = 0;
            this.cbProjecao.SelectionChangeCommitted += new System.EventHandler(this.selecionaProjecao);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1364, 98);
            this.tabControl.TabIndex = 3;
            // 
            // pbPrincipal
            // 
            this.pbPrincipal.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPrincipal.Location = new System.Drawing.Point(0, 98);
            this.pbPrincipal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbPrincipal.Name = "pbPrincipal";
            this.pbPrincipal.Size = new System.Drawing.Size(1364, 535);
            this.pbPrincipal.TabIndex = 0;
            this.pbPrincipal.TabStop = false;
            this.pbPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDesce);
            this.pbPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movimentaMouse);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 633);
            this.Controls.Add(this.pbPrincipal);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormPrincipal";
            this.Text = "BlenderUnoeste";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pressionaBotao);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.soltaBotao);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelPerspectiva;
        private System.Windows.Forms.TextBox tbD;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.ComboBox cbProjecao;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

