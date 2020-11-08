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
using Estacionamento.Model;

namespace Estacionamento.Dialog
{
    public partial class RedefinirSenha : Form
    {
        DAOFuncionario daof = new DAOFuncionario();
        Funcionario modelf = new Funcionario();
        string criterioUsuario;

        public RedefinirSenha(string cpf, string login)
        {
            InitializeComponent();
            modelf.Cpf = cpf;
            modelf.Login = login;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                string criterioSenha = mtxtSenhaAntiga.Text;
                criterioUsuario = modelf.Login;
                DataTable dtFuncionario = daof.consultar(criterioUsuario, criterioSenha).Tables["funcionario"];

                // Valida o Login
                if (dtFuncionario.Rows.Count >= 1)
                {
                    lblErroLogin.Visible = false;
                    if (mtxtSenhaAntiga.Text == string.Empty || mtxtNovaSenha.Text == string.Empty)
                    {
                        MessageBox.Show("Nenhum campo pode ficar em branco", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        if (mtxtSenhaAntiga.Text == string.Empty)
                        {
                            mtxtSenhaAntiga.BackColor = Color.Red;
                            mtxtSenhaAntiga.Focus();
                        }
                        else if (mtxtNovaSenha.Text == string.Empty)
                        {
                            mtxtNovaSenha.BackColor = Color.Red;
                            mtxtNovaSenha.Focus();
                        }
                    }
                    else if (!mtxtNovaSenha.Text.Equals(mtxtCNovaSenha.Text))
                    {
                        MessageBox.Show("Senhas Diferentes", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //mtxtNovaSenha.Clear();
                        mtxtCNovaSenha.Clear();
                        mtxtCNovaSenha.Focus();
                    }
                    else
                    {
                        modelf.Senha = mtxtNovaSenha.Text;
                        daof.alteracaoSenha(modelf);
                        if (MessageBox.Show("Senha Alterada com Sucesso", "Senha Alterada", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            this.Visible = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Senha Antiga Invalida", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mtxtSenhaAntiga.Clear();
                    mtxtSenhaAntiga.Focus();
                    lblErroLogin.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mtxtSenhaAntiga_TextChanged(object sender, EventArgs e)
        {
            if (mtxtSenhaAntiga.Text != string.Empty)
            {
                mtxtSenhaAntiga.BackColor = Color.White;
            }
        }

        private void mtxtNovaSenha_TextChanged(object sender, EventArgs e)
        {
            if (mtxtNovaSenha.Text != string.Empty)
            {
                mtxtNovaSenha.BackColor = Color.White;
            }
        }

        private void mtxtCNovaSenha_TextChanged(object sender, EventArgs e)
        {
            if (!mtxtNovaSenha.Text.Equals(mtxtCNovaSenha.Text))
            {
                mtxtCNovaSenha.BackColor = Color.Red;
            }
            else
            {
                mtxtCNovaSenha.BackColor = Color.White;
            }
        }

    }
}
