namespace Agenda.WindowsForm
{
    partial class FrmCadastro
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
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblSobrenome = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtSobrenome = new System.Windows.Forms.TextBox();
            this.txtCpfCnpj = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCpfCnpj = new System.Windows.Forms.Label();
            this.lblConjuge = new System.Windows.Forms.Label();
            this.txtConjuge = new System.Windows.Forms.TextBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(13, 29);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(40, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.Click += new System.EventHandler(this.Label1_Click);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(13, 63);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(35, 13);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // lblSobrenome
            // 
            this.lblSobrenome.AutoSize = true;
            this.lblSobrenome.Location = new System.Drawing.Point(13, 95);
            this.lblSobrenome.Name = "lblSobrenome";
            this.lblSobrenome.Size = new System.Drawing.Size(61, 13);
            this.lblSobrenome.TabIndex = 2;
            this.lblSobrenome.Text = "Sobrenome";
            this.lblSobrenome.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblSobrenome.Click += new System.EventHandler(this.Label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(79, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(76, 20);
            this.txtCodigo.TabIndex = 4;
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(79, 60);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(195, 20);
            this.txtNome.TabIndex = 5;
            // 
            // txtSobrenome
            // 
            this.txtSobrenome.Location = new System.Drawing.Point(80, 95);
            this.txtSobrenome.Name = "txtSobrenome";
            this.txtSobrenome.Size = new System.Drawing.Size(194, 20);
            this.txtSobrenome.TabIndex = 6;
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.Location = new System.Drawing.Point(80, 133);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(195, 20);
            this.txtCpfCnpj.TabIndex = 7;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(459, 299);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(562, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // lblCpfCnpj
            // 
            this.lblCpfCnpj.AutoSize = true;
            this.lblCpfCnpj.Location = new System.Drawing.Point(13, 136);
            this.lblCpfCnpj.Name = "lblCpfCnpj";
            this.lblCpfCnpj.Size = new System.Drawing.Size(50, 13);
            this.lblCpfCnpj.TabIndex = 10;
            this.lblCpfCnpj.Text = "Cpf_Cnpj";
            this.lblCpfCnpj.Click += new System.EventHandler(this.Label1_Click_1);
            // 
            // lblConjuge
            // 
            this.lblConjuge.AutoSize = true;
            this.lblConjuge.Location = new System.Drawing.Point(13, 180);
            this.lblConjuge.Name = "lblConjuge";
            this.lblConjuge.Size = new System.Drawing.Size(46, 13);
            this.lblConjuge.TabIndex = 11;
            this.lblConjuge.Text = "Cônjuge";
            // 
            // txtConjuge
            // 
            this.txtConjuge.Location = new System.Drawing.Point(80, 173);
            this.txtConjuge.Name = "txtConjuge";
            this.txtConjuge.Size = new System.Drawing.Size(194, 20);
            this.txtConjuge.TabIndex = 12;
            // 
            // cmbTipo
            // 
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(80, 213);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(121, 21);
            this.cmbTipo.TabIndex = 13;
            this.cmbTipo.SelectedIndexChanged += new System.EventHandler(this.CmbTipo_SelectedIndexChanged_1);
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(16, 220);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(28, 13);
            this.lblTipo.TabIndex = 14;
            this.lblTipo.Text = "Tipo";
            // 
            // FrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 334);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtConjuge);
            this.Controls.Add(this.lblConjuge);
            this.Controls.Add(this.lblCpfCnpj);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtCpfCnpj);
            this.Controls.Add(this.txtSobrenome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSobrenome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblCodigo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FrmCadastro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Cliente";
            this.Load += new System.EventHandler(this.FrmCadastro_load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblSobrenome;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtSobrenome;
        private System.Windows.Forms.TextBox txtCpfCnpj;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCpfCnpj;
        private System.Windows.Forms.Label lblConjuge;
        private System.Windows.Forms.TextBox txtConjuge;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblTipo;
    }
}