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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cores = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btFundo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btMaterial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbProjecao = new System.Windows.Forms.ComboBox();
            this.tbD = new System.Windows.Forms.TextBox();
            this.labelPerspectiva = new System.Windows.Forms.Label();
            this.ckFacesOcultas = new System.Windows.Forms.CheckBox();
            this.btOpen = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pbPrincipal = new System.Windows.Forms.PictureBox();
            this.materialColor = new System.Windows.Forms.ColorDialog();
            this.fundoColor = new System.Windows.Forms.ColorDialog();
            this.tabPage1.SuspendLayout();
            this.cores.SuspendLayout();
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
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.tabPage1.Controls.Add(this.cores);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbProjecao);
            this.tabPage1.Controls.Add(this.tbD);
            this.tabPage1.Controls.Add(this.labelPerspectiva);
            this.tabPage1.Controls.Add(this.ckFacesOcultas);
            this.tabPage1.Controls.Add(this.btOpen);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage1.Size = new System.Drawing.Size(1340, 70);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Programa";
            // 
            // cores
            // 
            this.cores.Controls.Add(this.label3);
            this.cores.Controls.Add(this.btFundo);
            this.cores.Controls.Add(this.label2);
            this.cores.Controls.Add(this.btMaterial);
            this.cores.ForeColor = System.Drawing.SystemColors.Window;
            this.cores.Location = new System.Drawing.Point(144, 11);
            this.cores.Name = "cores";
            this.cores.Size = new System.Drawing.Size(132, 59);
            this.cores.TabIndex = 4;
            this.cores.TabStop = false;
            this.cores.Text = "Cores";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fundo";
            // 
            // btFundo
            // 
            this.btFundo.Location = new System.Drawing.Point(73, 14);
            this.btFundo.Name = "btFundo";
            this.btFundo.Size = new System.Drawing.Size(54, 23);
            this.btFundo.TabIndex = 2;
            this.btFundo.UseVisualStyleBackColor = true;
            this.btFundo.Click += new System.EventHandler(this.trocarFundo);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Material";
            // 
            // btMaterial
            // 
            this.btMaterial.Location = new System.Drawing.Point(6, 13);
            this.btMaterial.Name = "btMaterial";
            this.btMaterial.Size = new System.Drawing.Size(54, 23);
            this.btMaterial.TabIndex = 0;
            this.btMaterial.UseVisualStyleBackColor = true;
            this.btMaterial.Click += new System.EventHandler(this.abrirSeletorMaterial);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(758, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Projeções";
            // 
            // cbProjecao
            // 
            this.cbProjecao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProjecao.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbProjecao.FormattingEnabled = true;
            this.cbProjecao.Items.AddRange(new object[] {
            "Paralela",
            "Cabinet",
            "Cavaleira",
            "Perspectiva"});
            this.cbProjecao.Location = new System.Drawing.Point(722, 35);
            this.cbProjecao.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbProjecao.Name = "cbProjecao";
            this.cbProjecao.Size = new System.Drawing.Size(190, 24);
            this.cbProjecao.TabIndex = 0;
            this.cbProjecao.SelectedIndexChanged += new System.EventHandler(this.selecionaProjecao);
            // 
            // tbD
            // 
            this.tbD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(162)))), ((int)(((byte)(164)))));
            this.tbD.Enabled = false;
            this.tbD.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tbD.ForeColor = System.Drawing.SystemColors.Window;
            this.tbD.Location = new System.Drawing.Point(956, 32);
            this.tbD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbD.Name = "tbD";
            this.tbD.Size = new System.Drawing.Size(66, 26);
            this.tbD.TabIndex = 2;
            this.tbD.Text = "-500";
            this.tbD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbD.TextChanged += new System.EventHandler(this.mudaTexto);
            // 
            // labelPerspectiva
            // 
            this.labelPerspectiva.AutoSize = true;
            this.labelPerspectiva.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPerspectiva.ForeColor = System.Drawing.SystemColors.Window;
            this.labelPerspectiva.Location = new System.Drawing.Point(978, 11);
            this.labelPerspectiva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPerspectiva.Name = "labelPerspectiva";
            this.labelPerspectiva.Size = new System.Drawing.Size(21, 23);
            this.labelPerspectiva.TabIndex = 1;
            this.labelPerspectiva.Text = "d";
            // 
            // ckFacesOcultas
            // 
            this.ckFacesOcultas.AutoSize = true;
            this.ckFacesOcultas.Checked = true;
            this.ckFacesOcultas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckFacesOcultas.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ckFacesOcultas.ForeColor = System.Drawing.SystemColors.Window;
            this.ckFacesOcultas.Location = new System.Drawing.Point(535, 32);
            this.ckFacesOcultas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ckFacesOcultas.Name = "ckFacesOcultas";
            this.ckFacesOcultas.Size = new System.Drawing.Size(156, 27);
            this.ckFacesOcultas.TabIndex = 1;
            this.ckFacesOcultas.Text = "Faces Ocultas";
            this.ckFacesOcultas.UseVisualStyleBackColor = true;
            this.ckFacesOcultas.CheckedChanged += new System.EventHandler(this.mudarFace);
            // 
            // btOpen
            // 
            this.btOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(162)))), ((int)(((byte)(164)))));
            this.btOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btOpen.Font = new System.Drawing.Font("Arial Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btOpen.ForeColor = System.Drawing.SystemColors.Window;
            this.btOpen.Location = new System.Drawing.Point(26, 17);
            this.btOpen.Margin = new System.Windows.Forms.Padding(1);
            this.btOpen.Name = "btOpen";
            this.btOpen.Size = new System.Drawing.Size(78, 38);
            this.btOpen.TabIndex = 0;
            this.btOpen.Text = "ABRIR";
            this.btOpen.UseVisualStyleBackColor = false;
            this.btOpen.Click += new System.EventHandler(this.abrirArquivo);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1348, 98);
            this.tabControl.TabIndex = 3;
            this.tabControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pressionaBotao);
            this.tabControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.soltaBotao);
            // 
            // pbPrincipal
            // 
            this.pbPrincipal.BackColor = System.Drawing.Color.Black;
            this.pbPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPrincipal.Location = new System.Drawing.Point(0, 98);
            this.pbPrincipal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbPrincipal.Name = "pbPrincipal";
            this.pbPrincipal.Size = new System.Drawing.Size(1348, 535);
            this.pbPrincipal.TabIndex = 0;
            this.pbPrincipal.TabStop = false;
            this.pbPrincipal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDesce);
            this.pbPrincipal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.movimentaMouse);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 633);
            this.Controls.Add(this.pbPrincipal);
            this.Controls.Add(this.tabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormPrincipal";
            this.Text = "BlenderUnoeste";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.cores.ResumeLayout(false);
            this.cores.PerformLayout();
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
    }
}

