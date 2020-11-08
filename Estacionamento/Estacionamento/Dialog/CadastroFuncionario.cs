using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Estacionamento.Model;
using Estacionamento.Controller;
using Estacionamento.DAO;
using System.Globalization;

namespace Estacionamento.Dialog
{
    public partial class CadastroFuncionario : Form
    {

        DAOFuncionario DaoFuncionario = new DAOFuncionario();
        Pessoa modelPessoa = new Pessoa();
        Endereco modelEndereco = new Endereco();
        Funcionario modelFuncionario = new Funcionario();
        Administrador modelAdministrador = new Administrador();
        DateTime datahora;
        CultureInfo culture = new CultureInfo("pt-BR");
        string cpfAntigo, telval, cepval, strModelo;
        bool adm;
        int codFun;

        public void preencheCombo()
        {
            cboEstado.Items.Add("São Paulo");
            cboEstado.Items.Add("Acre");
            cboEstado.Items.Add("Alagoas");
            cboEstado.Items.Add("Amapá");
            cboEstado.Items.Add("Amazonas");
            cboEstado.Items.Add("Bahia");
            cboEstado.Items.Add("Ceará");
            cboEstado.Items.Add("Distrito Federal");
            cboEstado.Items.Add("Espirito Santo");
            cboEstado.Items.Add("Goiás");
            cboEstado.Items.Add("Maranha");
            cboEstado.Items.Add("Mato Grosso");
            cboEstado.Items.Add("Mato Grosso do Sul");
            cboEstado.Items.Add("Minas Gerais");
            cboEstado.Items.Add("Para");
            cboEstado.Items.Add("Paraiba");
            cboEstado.Items.Add("Parana");
            cboEstado.Items.Add("Pernambuco");
            cboEstado.Items.Add("Piaui");
            cboEstado.Items.Add("Rio de Janeiro");
            cboEstado.Items.Add("Rio Grande do Norte");
            cboEstado.Items.Add("Rio Grande do Sul");
            cboEstado.Items.Add("Rondonia");
            cboEstado.Items.Add("Roraima");
            cboEstado.Items.Add("Santa Catarina");
            cboEstado.Items.Add("Sergipe");
            cboEstado.Items.Add("Tocantins");
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void preencheList()
        {
            DataTable dtFuncionario = DaoFuncionario.consultarFunc().Tables["funcionario"];
            this.listView.Items.Clear();

            if (dtFuncionario.Rows.Count >= 0)
            {
                for (int i = 0; i < dtFuncionario.Rows.Count; i++)
                {
                    DataRow linha = dtFuncionario.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["CPF"].ToString());
                    lvi.SubItems.Add(linha["Nome"].ToString());
                    lvi.SubItems.Add(linha["Login"].ToString());
                    listView.Items.Add(lvi);
                }
            }
        }

        public void preencheForm(string cpf)
        {
            Model.Funcionario funcionario = DaoFuncionario.atualizar(cpf);
            Model.Endereco endereco = funcionario.EnderecoPessoa;

            txtNome.Text = funcionario.Nome;
            maskCPF.Text = funcionario.Cpf;
            maskTelefone.Text = funcionario.Telefone;
            txtEmail.Text = funcionario.Email;
            if (funcionario.Nivel)
            {
                ckAdmin.Checked = true;
            }
            else
            {
                ckAdmin.Checked = false;
            }
            txtUsuario.Text = funcionario.Login;
            txtNomeLogradouro.Text = endereco.Logradouro;
            txtNumero.Text = Convert.ToString(endereco.Numero);
            txtComplemento.Text = endereco.Complemento;
            maskCep.Text = endereco.Cep;
            txtBairro.Text = endereco.Bairro;
            txtCidade.Text = endereco.Cidade;
            cboEstado.Text = endereco.Estado;
        }

        public void validaCampos(TextBox tb, bool bl)
        {
            if (!bl)
            {
                tb.BackColor = Color.Red;
                tb.Focus();
            }
            else
            {
                tb.BackColor = Color.White;
            }
        }

        public bool validaform() 
        {
            strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            telval = maskTelefone.Text;
            cepval = maskCep.Text;

            telval.Trim();
            cepval.Trim();
            telval = telval.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            cepval = cepval.Replace(" ", "").Replace("-", "");

            if (txtNome.Text == string.Empty)
            {
                validaCampos(txtNome, false);
            }
            else if (!Controller.ValidaCPF.validaCpf(maskCPF.Text))
            {
                lblCPF.Text = "CPF Invalido:";
                maskCPF.BackColor = Color.Red;
                maskCPF.Focus();
            }
            else if (telval == string.Empty && telval.Length < 10)
            {
                maskTelefone.BackColor = Color.Red;
                maskTelefone.Focus();
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, strModelo))
            {
                lblEmail.Text = "Email Invalido:";
                validaCampos(txtEmail, false);
            }
            else if (txtNomeLogradouro.Text == string.Empty)
            {
                validaCampos(txtNomeLogradouro, false);
            }
            else if (txtNumero.Text == string.Empty)
            {
                validaCampos(txtNumero, false);
            }
            else if (cepval == string.Empty && cepval.Length < 8)
            {
                maskCep.BackColor = Color.Red;
                maskCep.Focus();
            }
            else if (txtBairro.Text == string.Empty)
            {
                validaCampos(txtBairro, false);
            }
            else if (txtCidade.Text == string.Empty)
            {
                validaCampos(txtCidade, false);
            }
            else if (cboEstado.Text == string.Empty)
            {
                MessageBox.Show("Escola uma opção de Estado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (txtUsuario.Text == string.Empty)
            {
                validaCampos(txtUsuario, false);
            }
            else
            {
                return true; 
            }

            return false;
        }

        public void limpaform()
        {
            txtNomeLogradouro.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtComplemento.Text = string.Empty;
            maskCep.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            cboEstado.SelectedIndex = -1;

            txtNome.Text = string.Empty;
            maskCPF.Text = string.Empty;
            maskTelefone.Text = string.Empty;
            txtEmail.Text = string.Empty;

            txtUsuario.Text = string.Empty;
            mtxtSenha.Text = string.Empty;
            mtxtConfirmeaSenha.Text = string.Empty;
            ckAdmin.Checked = false;
        }

        public CadastroFuncionario(bool admin, int codfuncionario)
        {
            InitializeComponent();
            preencheCombo();
            preencheList();

            if (!admin)
            {
                MessageBox.Show("Você não tem acesso!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Visible = false;
                this.Hide();
                Home home = new Home(admin, 1);
                home.ShowDialog();
            }
            codFun = codfuncionario;
            adm = admin;
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (!validaform())
            {
            }
            else
            {
                modelEndereco.Logradouro = txtNomeLogradouro.Text;
                modelEndereco.Numero = Convert.ToUInt32(txtNumero.Text);
                modelEndereco.Complemento = txtComplemento.Text;
                modelEndereco.Cep = maskCep.Text;
                modelEndereco.Bairro = txtBairro.Text;
                modelEndereco.Cidade = txtCidade.Text;
                modelEndereco.Estado = cboEstado.Text;

                modelFuncionario.Nome = txtNome.Text;
                modelFuncionario.Cpf = maskCPF.Text;
                modelFuncionario.Telefone = maskTelefone.Text;
                modelFuncionario.Email = txtEmail.Text;
                modelFuncionario.Login = txtUsuario.Text;
                
                if (ckAdmin.Checked)
                {
                    modelFuncionario.Nivel = true;
                }
                else
                {
                    modelFuncionario.Nivel = false;
                }

                if (!mtxtSenha.Text.Equals(mtxtConfirmeaSenha.Text))
                {
                    mtxtSenha.BackColor = Color.Red;
                    MessageBox.Show("A senha precisa ter mais de 6 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (mtxtSenha.TextLength < 6)
                {
                    MessageBox.Show("Senhas Diferentes", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // mtxtSenha.Clear();
                    mtxtConfirmeaSenha.Clear();
                    mtxtConfirmeaSenha.BackColor = Color.Red;
                    mtxtConfirmeaSenha.Focus();
                }
                else
                {
                    modelFuncionario.Senha = mtxtSenha.Text;
                }

                DaoFuncionario.cadastrar(modelEndereco, modelFuncionario);

                limpaform();
                preencheList();
            }

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string cpf = listView.Items[listView.FocusedItem.Index].Text;
                DaoFuncionario.excluir(cpf);
                preencheList();
            }
            
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            linklblRedefinir.Visible = true;

            mtxtSenha.Enabled = false;
            mtxtSenha.BackColor = Color.Silver;

            mtxtConfirmeaSenha.Enabled = false;
            mtxtConfirmeaSenha.BackColor = Color.Silver;

            btnLimpar.Visible = true;
            cpfAntigo = listView.Items[listView.FocusedItem.Index].Text;
            preencheForm(listView.Items[listView.FocusedItem.Index].Text);
            txtNome.Focus();
        }

        private void btnRedefinir_Click(object sender, EventArgs e)
        {
            if (!validaform())
            {
            }
            else
            {
                if (MessageBox.Show("Tem certeza que deseja alterar?", "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    modelEndereco.Logradouro = txtNomeLogradouro.Text;
                    modelEndereco.Numero = Convert.ToUInt32(txtNumero.Text);
                    modelEndereco.Complemento = txtComplemento.Text;
                    modelEndereco.Cep = maskCep.Text;
                    modelEndereco.Bairro = txtBairro.Text;
                    modelEndereco.Cidade = txtCidade.Text;
                    modelEndereco.Estado = cboEstado.Text;

                    modelFuncionario.Nome = txtNome.Text;
                    modelFuncionario.Cpf = maskCPF.Text;
                    modelFuncionario.Telefone = maskTelefone.Text;
                    modelFuncionario.Email = txtEmail.Text;
                    modelFuncionario.Login = txtUsuario.Text;

                    if (ckAdmin.Checked)
                    {
                        modelFuncionario.Nivel = true;
                    }
                    else
                    {
                        modelFuncionario.Nivel = false;
                    }

                    DaoFuncionario.alteracao(modelEndereco, modelFuncionario, cpfAntigo);

                    btnLimpar.Visible = true;
                    preencheList();
                }
                else if (MessageBox.Show("Tem certeza que deseja alterar?", "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    limpaform();
                    btnLimpar.Visible = false;
                }
                else
                {

                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            linklblRedefinir.Visible = false;
            mtxtSenha.Enabled = true;
            mtxtSenha.BackColor = Color.White;

            mtxtConfirmeaSenha.Enabled = true;
            mtxtConfirmeaSenha.BackColor = Color.White;

            btnLimpar.Visible = false;
            limpaform();
        }

        private void linklblRedefinir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*modelFuncionario.Cpf = maskCPF.Text;
            modelFuncionario.Login = txtUsuario.Text;*/
            RedefinirSenha redefinir = new RedefinirSenha(maskCPF.Text, txtUsuario.Text);
            redefinir.ShowDialog();
            //this.Visible = false;
            //Application.Exit();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtNome, true);
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskCPF_TextChanged(object sender, EventArgs e)
        {
            if (Controller.ValidaCPF.validaCpf(maskCPF.Text))
            {
                lblCPF.Text = "CPF Valido:";
                maskCPF.BackColor = Color.White;
                maskCPF.Focus();
            }
        }

        private void maskCPF_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskTelefone_TextChanged(object sender, EventArgs e)
        {
            telval = maskTelefone.Text;

            telval.Trim();
            telval = telval.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            if (telval != string.Empty && telval.Length >= 10)
            {
                maskTelefone.BackColor = Color.White;
                maskTelefone.Focus();
            }
        }

        private void maskTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

            if (System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, strModelo))
            {
                lblEmail.Text = "Email Valido:";
                validaCampos(txtEmail, true);
            }
        }

        private void txtNomeLogradouro_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtNomeLogradouro, true);
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtNumero, true);
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void maskCep_TextChanged(object sender, EventArgs e)
        {
            cepval = maskCep.Text;

            cepval.Trim();
            cepval = cepval.Replace(" ", "").Replace("-", "");

            if (cepval != string.Empty && cepval.Length >= 8)
            {
                maskCep.BackColor = Color.White;
                maskCep.Focus();
            }
        }

        private void maskCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtBairro, true);
        }

        private void txtBairro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtCidade, true);
        }

        private void txtCidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtUsuario, true);
        }

        private void mtxtSenha_TextChanged(object sender, EventArgs e)
        {
                mtxtSenha.BackColor = Color.White;
        }

        private void mtxtConfirmeaSenha_TextChanged(object sender, EventArgs e)
        {
            if (mtxtSenha.Text.Equals(mtxtConfirmeaSenha.Text))
            {
                mtxtConfirmeaSenha.BackColor = Color.White;
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataTable dtC;
        
            if (rbNome.Checked)
            {
                dtC = DaoFuncionario.pesquisar(rbNome.Text ,txtPesquisar.Text).Tables["funcionario"];
            }
            else if (rbUsuario.Checked)
            {
                dtC = DaoFuncionario.pesquisar("Login", txtPesquisar.Text).Tables["funcionario"];
            }
            else if (rbCPF.Checked)
            {
                dtC = DaoFuncionario.pesquisar(rbCPF.Text, txtPesquisar.Text).Tables["funcionario"];
            }
            else
            {
                dtC = DaoFuncionario.pesquisar(rbNome.Text, txtPesquisar.Text).Tables["funcionario"];
            }

            this.listView.Items.Clear();

            if (dtC.Rows.Count >= 1)
            {
                for (int i = 0; i < dtC.Rows.Count; i++)
                {
                    DataRow linha = dtC.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["CPF"].ToString());
                    lvi.SubItems.Add(linha["Nome"].ToString());
                    lvi.SubItems.Add(linha["Login"].ToString());
                    listView.Items.Add(lvi);
                }
            }
        }

        private void dadosDaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Hide();
            CadastroEmpresa cadEmpresa = new CadastroEmpresa(adm, codFun);
            cadEmpresa.ShowDialog();
        }

        private void entradaDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaixaVeiculos entradaveiculos = new BaixaVeiculos(1, adm, codFun);
            entradaveiculos.ShowDialog();
        }

        private void saidaDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaixaVeiculos entradaveiculos = new BaixaVeiculos(2, adm, codFun);
            entradaveiculos.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            CadastroCliente cadCliente = new CadastroCliente(adm, codFun);
            cadCliente.ShowDialog();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            CadastroVeiculo cadVeiculo = new CadastroVeiculo(adm, codFun);
            cadVeiculo.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            Home home = new Home(adm, codFun);
            home.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datahora = DateTime.Now;
            toolStriptxtData.Text = "Data: " + datahora.ToString("d", culture);
            toolStriptxtHora.Text = "Hora: " + datahora.ToShortTimeString();
        }

        private void CadastroFuncionario_KeyDown(object sender, KeyEventArgs e)
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
    }
}
