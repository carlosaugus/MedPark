namespace Estacionamento.Dialog
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.arquivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dadosDaEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCadFun = new System.Windows.Forms.PictureBox();
            this.picCadClie = new System.Windows.Forms.PictureBox();
            this.picCadVeiculo = new System.Windows.Forms.PictureBox();
            this.picEntradaVeic = new System.Windows.Forms.PictureBox();
            this.picSaidaVeic = new System.Windows.Forms.PictureBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCadFun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCadClie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCadVeiculo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEntradaVeic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaidaVeic)).BeginInit();
            this.SuspendLayout();
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
            this.menu.Size = new System.Drawing.Size(866, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // arquivoToolStripMenuItem
            // 
            this.arquivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dadosDaEmpresaToolStripMenuItem,
            this.toolStripSeparator2,
            this.entradaDeVeiculosToolStripMenuItem,
            this.saidaDeVeiculosToolStripMenuItem,
            this.toolStripSeparator1,
            this.sairToolStripMenuItem});
            this.arquivoToolStripMenuItem.Name = "arquivoToolStripMenuItem";
            this.arquivoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.arquivoToolStripMenuItem.Text = "Arquivo";
            // 
            // dadosDaEmpresaToolStripMenuItem
            // 
            this.dadosDaEmpresaToolStripMenuItem.Name = "dadosDaEmpresaToolStripMenuItem";
            this.dadosDaEmpresaToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.dadosDaEmpresaToolStripMenuItem.Text = "Dados da Empresa               F1";
            this.dadosDaEmpresaToolStripMenuItem.Click += new System.EventHandler(this.dadosDaEmpresaToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(230, 6);
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(866, 610);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // picCadFun
            // 
            this.picCadFun.BackColor = System.Drawing.Color.Transparent;
            this.picCadFun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picCadFun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCadFun.Image = ((System.Drawing.Image)(resources.GetObject("picCadFun.Image")));
            this.picCadFun.Location = new System.Drawing.Point(445, 479);
            this.picCadFun.Name = "picCadFun";
            this.picCadFun.Size = new System.Drawing.Size(301, 62);
            this.picCadFun.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCadFun.TabIndex = 8;
            this.picCadFun.TabStop = false;
            this.picCadFun.Click += new System.EventHandler(this.picCadFun_Click);
            // 
            // picCadClie
            // 
            this.picCadClie.BackColor = System.Drawing.Color.Transparent;
            this.picCadClie.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCadClie.Image = ((System.Drawing.Image)(resources.GetObject("picCadClie.Image")));
            this.picCadClie.Location = new System.Drawing.Point(445, 540);
            this.picCadClie.Name = "picCadClie";
            this.picCadClie.Size = new System.Drawing.Size(301, 62);
            this.picCadClie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCadClie.TabIndex = 9;
            this.picCadClie.TabStop = false;
            this.picCadClie.Click += new System.EventHandler(this.picCadClie_Click);
            // 
            // picCadVeiculo
            // 
            this.picCadVeiculo.BackColor = System.Drawing.Color.Transparent;
            this.picCadVeiculo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCadVeiculo.Image = ((System.Drawing.Image)(resources.GetObject("picCadVeiculo.Image")));
            this.picCadVeiculo.Location = new System.Drawing.Point(114, 467);
            this.picCadVeiculo.Name = "picCadVeiculo";
            this.picCadVeiculo.Size = new System.Drawing.Size(301, 145);
            this.picCadVeiculo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCadVeiculo.TabIndex = 10;
            this.picCadVeiculo.TabStop = false;
            this.picCadVeiculo.Click += new System.EventHandler(this.picCadVeiculo_Click);
            // 
            // picEntradaVeic
            // 
            this.picEntradaVeic.BackColor = System.Drawing.Color.Transparent;
            this.picEntradaVeic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEntradaVeic.Image = ((System.Drawing.Image)(resources.GetObject("picEntradaVeic.Image")));
            this.picEntradaVeic.Location = new System.Drawing.Point(12, 52);
            this.picEntradaVeic.Name = "picEntradaVeic";
            this.picEntradaVeic.Size = new System.Drawing.Size(130, 128);
            this.picEntradaVeic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picEntradaVeic.TabIndex = 11;
            this.picEntradaVeic.TabStop = false;
            this.picEntradaVeic.Click += new System.EventHandler(this.picEntradaVeic_Click);
            // 
            // picSaidaVeic
            // 
            this.picSaidaVeic.BackColor = System.Drawing.Color.Transparent;
            this.picSaidaVeic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSaidaVeic.Image = ((System.Drawing.Image)(resources.GetObject("picSaidaVeic.Image")));
            this.picSaidaVeic.Location = new System.Drawing.Point(146, 52);
            this.picSaidaVeic.Name = "picSaidaVeic";
            this.picSaidaVeic.Size = new System.Drawing.Size(130, 128);
            this.picSaidaVeic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picSaidaVeic.TabIndex = 12;
            this.picSaidaVeic.TabStop = false;
            this.picSaidaVeic.Click += new System.EventHandler(this.picSaidaVeic_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 634);
            this.Controls.Add(this.picSaidaVeic);
            this.Controls.Add(this.picEntradaVeic);
            this.Controls.Add(this.picCadVeiculo);
            this.Controls.Add(this.picCadClie);
            this.Controls.Add(this.picCadFun);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Home_KeyDown);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCadFun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCadClie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCadVeiculo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEntradaVeic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaidaVeic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem arquivoToolStripMenuItem;
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripTextBox toolStriptxtData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem dadosDaEmpresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem entradaDeVeiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saidaDeVeiculosToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picCadFun;
        private System.Windows.Forms.PictureBox picCadClie;
        private System.Windows.Forms.PictureBox picCadVeiculo;
        private System.Windows.Forms.PictureBox picEntradaVeic;
        private System.Windows.Forms.PictureBox picSaidaVeic;
    }
}