using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Estacionamento.DAO;

namespace Estacionamento.Dialog
{
    public partial class Home : Form
    {
        DAOEmpresa daoe = new DAOEmpresa();
        DateTime datahora;
        CultureInfo culture = new CultureInfo("pt-BR");
        bool adm;
        int codFun;

        public void notadm()
        {
            funcionaáiosToolStripMenuItem.Enabled = false;
            dadosDaEmpresaToolStripMenuItem.Enabled = false;
            picCadFun.Enabled = false;
        }

        public Home(bool admin, int codfuncionario)
        {
            InitializeComponent();

            if (!admin)
            {
                notadm();
            }

            codFun = codfuncionario;
            adm = admin;
        }

        private void dadosDaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            CadastroEmpresa cadEmpresa = new CadastroEmpresa(adm, codFun);
            cadEmpresa.ShowDialog();
        }

        private void entradaDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            BaixaVeiculos entradaveiculos = new BaixaVeiculos(1, adm, codFun);
            entradaveiculos.ShowDialog();
        }

        private void saidaDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            BaixaVeiculos saidaveiculos = new BaixaVeiculos(2, adm, codFun);
            saidaveiculos.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Encerrar?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Application.Exit();
                this.Hide();
                Login telaLogin = new Login();
                telaLogin.ShowDialog();
            }
        }

        private void funcionaáiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            CadastroFuncionario cadFuncionario = new CadastroFuncionario(adm, codFun);
            cadFuncionario.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            CadastroCliente cadCliente = new CadastroCliente(adm, codFun);
            cadCliente.ShowDialog();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            CadastroVeiculo cadVeiculo = new CadastroVeiculo(adm, codFun);
            cadVeiculo.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datahora = DateTime.Now;
            toolStriptxtData.Text = "Data: " + datahora.ToString("d", culture);
            toolStriptxtHora.Text = "Hora: " + datahora.ToShortTimeString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (adm)
            {
                DataTable dtEmpresa = daoe.consultar().Tables["dadosempresa"];
                if (dtEmpresa.Rows.Count == 0)
                {
                    timer2.Enabled = false;
                    CadastroEmpresa cadEmpresa = new CadastroEmpresa(adm, codFun);
                    cadEmpresa.ShowDialog();
                    //this.Load += new System.EventHandler(this.dadosDaEmpresaToolStripMenuItem_Click);
                }
            }
            timer2.Enabled = false;
        }

        private void picEntradaVeic_Click(object sender, EventArgs e)
        {
            entradaDeVeiculosToolStripMenuItem_Click(sender, e);
        }

        private void picSaidaVeic_Click(object sender, EventArgs e)
        {
            saidaDeVeiculosToolStripMenuItem_Click(sender, e);
        }

        private void picCadVeiculo_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            veículoToolStripMenuItem_Click(sender, e);
        }

        private void picCadFun_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            funcionaáiosToolStripMenuItem_Click(sender, e);
        }

        private void picCadClie_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //this.Hide();
            clientesToolStripMenuItem_Click(sender, e);
        }

        private void Home_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1: 
                    if (adm)
                    {
                        dadosDaEmpresaToolStripMenuItem_Click(sender, e);  
                    }
                    break; 

                case Keys.F2: 
                    entradaDeVeiculosToolStripMenuItem_Click(sender, e); 
                    break;

                case Keys.F3:
                    saidaDeVeiculosToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.F4:
                    if (adm)
                    {
                        funcionaáiosToolStripMenuItem_Click(sender, e);
                    }
                    break;

                case Keys.F5:
                    clientesToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.F6:
                    veículoToolStripMenuItem_Click(sender, e);
                    break;

                case Keys.Escape:
                    sairToolStripMenuItem_Click(sender, e);
                    break;

            }
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (MessageBox.Show("Deseja Realmente Encerrar?", "Encerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Application.Exit();
                this.Hide();
                Login telaLogin = new Login();
                telaLogin.ShowDialog();
            }
        }

    }
}
