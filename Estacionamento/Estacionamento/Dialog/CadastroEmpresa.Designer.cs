namespace Estacionamento.Dialog
{
    partial class CadastroEmpresa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroEmpresa));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.maskCep = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCidade = new System.Windows.Forms.TextBox();
            this.txtBairro = new System.Windows.Forms.TextBox();
            this.txtComplemento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNomeLogradouro = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRedefinir = new System.Windows.Forms.Button();
            this.btnCadastrarUsuario = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskCNPJ = new System.Windows.Forms.MaskedTextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.maskTelefone = new System.Windows.Forms.MaskedTextBox();
            this.maskIE = new System.Windows.Forms.MaskedTextBox();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.txtNomeFantasia = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblCPF = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradaDeVeiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saidaDeVeiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionaáiosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veículoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suporteTécnicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStriptxtHora = new System.Windows.Forms.ToolStripTextBox();
            this.toolStriptxtData = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.maskCep);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCidade);
            this.groupBox2.Controls.Add(this.txtBairro);
            this.groupBox2.Controls.Add(this.txtComplemento);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtNumero);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboEstado);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtNomeLogradouro);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(272, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 219);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Endereço";
            // 
            // maskCep
            // 
            this.maskCep.Location = new System.Drawing.Point(9, 135);
            this.maskCep.Mask = "00000-999";
            this.maskCep.Name = "maskCep";
            this.maskCep.Size = new System.Drawing.Size(89, 20);
            this.maskCep.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Cep:";
            // 
            // txtCidade
            // 
            this.txtCidade.Location = new System.Drawing.Point(9, 184);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(100, 20);
            this.txtCidade.TabIndex = 12;
            // 
            // txtBairro
            // 
            this.txtBairro.Location = new System.Drawing.Point(104, 135);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(100, 20);
            this.txtBairro.TabIndex = 11;
            // 
            // txtComplemento
            // 
            this.txtComplemento.Location = new System.Drawing.Point(73, 91);
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(108, 20);
            this.txtComplemento.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(70, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Complemento:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(9, 91);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(58, 20);
            this.txtNumero.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Numero:";
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(114, 184);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(100, 21);
            this.cboEstado.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(111, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Estado:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cidade:";
            // 
            // txtNomeLogradouro
            // 
            this.txtNomeLogradouro.Location = new System.Drawing.Point(9, 42);
            this.txtNomeLogradouro.Name = "txtNomeLogradouro";
            this.txtNomeLogradouro.Size = new System.Drawing.Size(231, 20);
            this.txtNomeLogradouro.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(101, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Bairro:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Logradouro:";
            // 
            // btnRedefinir
            // 
            this.btnRedefinir.BackColor = System.Drawing.Color.Transparent;
            this.btnRedefinir.Image = ((System.Drawing.Image)(resources.GetObject("btnRedefinir.Image")));
            this.btnRedefinir.Location = new System.Drawing.Point(414, 252);
            this.btnRedefinir.Name = "btnRedefinir";
            this.btnRedefinir.Size = new System.Drawing.Size(114, 38);
            this.btnRedefinir.TabIndex = 24;
            this.btnRedefinir.UseVisualStyleBackColor = false;
            this.btnRedefinir.Click += new System.EventHandler(this.btnRedefinir_Click);
            // 
            // btnCadastrarUsuario
            // 
            this.btnCadastrarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnCadastrarUsuario.Image = ((System.Drawing.Image)(resources.GetObject("btnCadastrarUsuario.Image")));
            this.btnCadastrarUsuario.Location = new System.Drawing.Point(294, 252);
            this.btnCadastrarUsuario.Name = "btnCadastrarUsuario";
            this.btnCadastrarUsuario.Size = new System.Drawing.Size(114, 38);
            this.btnCadastrarUsuario.TabIndex = 23;
            this.btnCadastrarUsuario.UseVisualStyleBackColor = false;
            this.btnCadastrarUsuario.Click += new System.EventHandler(this.btnCadastrarUsuario_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskCNPJ);
            this.groupBox1.Controls.Add(this.lblEmail);
            this.groupBox1.Controls.Add(this.maskTelefone);
            this.groupBox1.Controls.Add(this.maskIE);
            this.groupBox1.Controls.Add(this.lblTelefone);
            this.groupBox1.Controls.Add(this.txtNomeFantasia);
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.lblCPF);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 219);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Empresa";
            // 
            // maskCNPJ
            // 
            this.maskCNPJ.Location = new System.Drawing.Point(9, 185);
            this.maskCNPJ.Mask = "00.000.000/9999-99";
            this.maskCNPJ.Name = "maskCNPJ";
            this.maskCNPJ.Size = new System.Drawing.Size(123, 20);
            this.maskCNPJ.TabIndex = 20;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(6, 168);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "CNPJ:";
            // 
            // maskTelefone
            // 
            this.maskTelefone.Location = new System.Drawing.Point(9, 135);
            this.maskTelefone.Mask = "(99) 9000-0000";
            this.maskTelefone.Name = "maskTelefone";
            this.maskTelefone.Size = new System.Drawing.Size(100, 20);
            this.maskTelefone.TabIndex = 3;
            // 
            // maskIE
            // 
            this.maskIE.Location = new System.Drawing.Point(9, 91);
            this.maskIE.Mask = "000.000.999";
            this.maskIE.Name = "maskIE";
            this.maskIE.Size = new System.Drawing.Size(100, 20);
            this.maskIE.TabIndex = 2;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Location = new System.Drawing.Point(6, 119);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(55, 13);
            this.lblTelefone.TabIndex = 12;
            this.lblTelefone.Text = "Telefone: ";
            // 
            // txtNomeFantasia
            // 
            this.txtNomeFantasia.Location = new System.Drawing.Point(9, 42);
            this.txtNomeFantasia.Name = "txtNomeFantasia";
            this.txtNomeFantasia.Size = new System.Drawing.Size(167, 20);
            this.txtNomeFantasia.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(6, 26);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(81, 13);
            this.lblNome.TabIndex = 10;
            this.lblNome.Text = "Nome Fantasia:";
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(6, 75);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(97, 13);
            this.lblCPF.TabIndex = 8;
            this.lblCPF.Text = "Inscrição Estadual:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arquivoToolStripMenuItem,
            this.cadastrosToolStripMenuItem,
            this.ajudaToolStripMenuItem,
            this.toolStriptxtHora,
            this.toolStriptxtData});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(537, 24);
            this.menu.TabIndex = 28;
            this.menu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradaDeVeiculosToolStripMenuItem,
            this.saidaDeVeiculosToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // entradaDeVeiculosToolStripMenuItem
            // 
            this.entradaDeVeiculosToolStripMenuItem.Name = "entradaDeVeiculosToolStripMenuItem";
            this.entradaDeVeiculosToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.entradaDeVeiculosToolStripMenuItem.Text = "Entrada de Veículos             F2";
            this.entradaDeVeiculosToolStripMenuItem.Click += new System.EventHandler(this.entradaDeVeiculosToolStripMenuItem_Click);
            // 
            // saidaDeVeiculosToolStripMenuItem
            // 
            this.saidaDeVeiculosToolStripMenuItem.Name = "saidaDeVeiculosToolStripMenuItem";
            this.saidaDeVeiculosToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.saidaDeVeiculosToolStripMenuItem.Text = "Saida de Veículos                 F3";
            this.saidaDeVeiculosToolStripMenuItem.Click += new System.EventHandler(this.saidaDeVeiculosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(230, 6);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.sairToolStripMenuItem.Text = "Sair                                         Esc";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionaáiosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.veículoToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "Cadastros";
            // 
            // funcionaáiosToolStripMenuItem
            // 
            this.funcionaáiosToolStripMenuItem.Name = "funcionaáiosToolStripMenuItem";
            this.funcionaáiosToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.funcionaáiosToolStripMenuItem.Text = "Funcionários              F4";
            this.funcionaáiosToolStripMenuItem.Click += new System.EventHandler(this.funcionaáiosToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.clientesToolStripMenuItem.Text = "Clientes                       F5";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // veículoToolStripMenuItem
            // 
            this.veículoToolStripMenuItem.Name = "veículoToolStripMenuItem";
            this.veículoToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.veículoToolStripMenuItem.Text = "Veículo                        F6";
            this.veículoToolStripMenuItem.Click += new System.EventHandler(this.veículoToolStripMenuItem_Click);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.versãoToolStripMenuItem,
            this.sobreToolStripMenuItem,
            this.suporteTécnicoToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // versãoToolStripMenuItem
            // 
            this.versãoToolStripMenuItem.Name = "versãoToolStripMenuItem";
            this.versãoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.versãoToolStripMenuItem.Text = "Versão";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // suporteTécnicoToolStripMenuItem
            // 
            this.suporteTécnicoToolStripMenuItem.Name = "suporteTécnicoToolStripMenuItem";
            this.suporteTécnicoToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.suporteTécnicoToolStripMenuItem.Text = "Suporte Técnico";
            // 
            // toolStriptxtHora
            // 
            this.toolStriptxtHora.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStriptxtHora.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStriptxtHora.Enabled = false;
            this.toolStriptxtHora.ForeColor = System.Drawing.Color.Transparent;
            this.toolStriptxtHora.Name = "toolStriptxtHora";
            this.toolStriptxtHora.Size = new System.Drawing.Size(100, 20);
            // 
            // toolStriptxtData
            // 
            this.toolStriptxtData.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStriptxtData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStriptxtData.Enabled = false;
            this.toolStriptxtData.ForeColor = System.Drawing.Color.Transparent;
            this.toolStriptxtData.Name = "toolStriptxtData";
            this.toolStriptxtData.Size = new System.Drawing.Size(100, 20);
            // 
            // CadastroEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 299);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRedefinir);
            this.Controls.Add(this.btnCadastrarUsuario);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CadastroEmpresa";
            this.Text = "Dados da Empresa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CadastroEmpresa_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MaskedTextBox maskCep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCidade;
        private System.Windows.Forms.TextBox txtBairro;
        private System.Windows.Forms.TextBox txtComplemento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNomeLogradouro;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRedefinir;
        private System.Windows.Forms.Button btnCadastrarUsuario;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.MaskedTextBox maskTelefone;
        private System.Windows.Forms.MaskedTextBox maskIE;
        private System.Windows.Forms.Label lblTelefone;
        private System.Windows.Forms.TextBox txtNomeFantasia;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.MaskedTextBox maskCNPJ;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradaDeVeiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saidaDeVeiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionaáiosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veículoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suporteTécnicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtHora;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtData;
    }
}