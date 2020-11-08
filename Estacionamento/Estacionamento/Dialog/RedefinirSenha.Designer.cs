namespace Estacionamento.Dialog
{
    partial class RedefinirSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedefinirSenha));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtxtCNovaSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblErroLogin = new System.Windows.Forms.Label();
            this.mtxtNovaSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mtxtSenhaAntiga = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtxtCNovaSenha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Controls.Add(this.lblErroLogin);
            this.groupBox1.Controls.Add(this.mtxtNovaSenha);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.mtxtSenhaAntiga);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 245);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login";
            // 
            // mtxtCNovaSenha
            // 
            this.mtxtCNovaSenha.Location = new System.Drawing.Point(28, 164);
            this.mtxtCNovaSenha.Name = "mtxtCNovaSenha";
            this.mtxtCNovaSenha.PasswordChar = '*';
            this.mtxtCNovaSenha.Size = new System.Drawing.Size(149, 20);
            this.mtxtCNovaSenha.TabIndex = 3;
            this.mtxtCNovaSenha.TextChanged += new System.EventHandler(this.mtxtCNovaSenha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Confirme a nova Senha:";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmar.Image")));
            this.btnConfirmar.Location = new System.Drawing.Point(89, 201);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(114, 38);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblErroLogin
            // 
            this.lblErroLogin.AutoSize = true;
            this.lblErroLogin.ForeColor = System.Drawing.Color.Red;
            this.lblErroLogin.Location = new System.Drawing.Point(66, 76);
            this.lblErroLogin.Name = "lblErroLogin";
            this.lblErroLogin.Size = new System.Drawing.Size(111, 13);
            this.lblErroLogin.TabIndex = 4;
            this.lblErroLogin.Text = "Senha Antiga Invalida";
            this.lblErroLogin.Visible = false;
            // 
            // mtxtNovaSenha
            // 
            this.mtxtNovaSenha.Location = new System.Drawing.Point(28, 116);
            this.mtxtNovaSenha.Name = "mtxtNovaSenha";
            this.mtxtNovaSenha.PasswordChar = '*';
            this.mtxtNovaSenha.Size = new System.Drawing.Size(149, 20);
            this.mtxtNovaSenha.TabIndex = 2;
            this.mtxtNovaSenha.TextChanged += new System.EventHandler(this.mtxtNovaSenha_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nova Senha:";
            // 
            // mtxtSenhaAntiga
            // 
            this.mtxtSenhaAntiga.Location = new System.Drawing.Point(28, 53);
            this.mtxtSenhaAntiga.Name = "mtxtSenhaAntiga";
            this.mtxtSenhaAntiga.PasswordChar = '*';
            this.mtxtSenhaAntiga.Size = new System.Drawing.Size(149, 20);
            this.mtxtSenhaAntiga.TabIndex = 1;
            this.mtxtSenhaAntiga.TextChanged += new System.EventHandler(this.mtxtSenhaAntiga_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Senha Antiga:";
            // 
            // RedefinirSenha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 268);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RedefinirSenha";
            this.Text = "Redefinir Senha";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblErroLogin;
        private System.Windows.Forms.TextBox mtxtNovaSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox mtxtSenhaAntiga;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox mtxtCNovaSenha;
    }
}