using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estacionamento.DAO;
//using System.Data;

namespace Estacionamento.Dialog
{
    public partial class Login : Form
    {
        DAOFuncionario daof = new DAOFuncionario();
        string nome;
        bool adm;
        int codFun;

        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try 
	        {	        
		        string criterioSenha = txtSenha.Text;
                string criterioUsuario = txtUsuario.Text;
                DataTable dtFuncionario = daof.consultar(criterioUsuario, criterioSenha).Tables["funcionario"];

                // Valida o Login
                if (dtFuncionario.Rows.Count >= 1)
	            {
                    for (int i = 0; i < dtFuncionario.Rows.Count; i++)
                    {
                        DataRow linha = dtFuncionario.Rows[0];
                        codFun = Convert.ToInt32(linha["codigoFuncionario"].ToString());
                        nome = linha["nome"].ToString();
                        adm = Convert.ToBoolean(linha["nivel"].ToString());
                    }

                    NotMedPark.ShowBalloonTip(5, "Bem Vindo!", "Seja Bem Vindo ao MedPark " + nome + ", Software para gestão de Estacionamento.", NotMedPark.BalloonTipIcon);
 
		            // Autentica
                    this.Hide();
                    this.Visible = false;
                    Home telaHome = new Home(adm, codFun);
                    telaHome.ShowDialog();

                }
                // Usuario Padrão - Para primeiro acesso (Caso não tenha funcionario cadastrado)
                else if (criterioUsuario == "admin" && criterioSenha == "admin")
	            {
                    this.Hide();
                    this.Visible = false;
                    Home telaHome = new Home(true, 0);
                    telaHome.ShowDialog();
	            }
	            else
                {
                    // Erro Login
                    lblErroLogin.Visible = true;
                    txtUsuario.Clear();
                    txtSenha.Clear();
                    // txtUsuario.BackColor = Color.FromArgb(255, 121, 121);
                    txtUsuario.BackColor = Color.Red;
                    // txtSenha.BackColor = Color.FromArgb(255, 121, 121);
                    txtSenha.BackColor = Color.Red;
                    txtUsuario.Focus();
                }
	        }
	        catch (Exception ex)
	        {
		        MessageBox.Show("Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.White;
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            txtSenha.BackColor = Color.White;
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
            Close();
        }
    }
}
