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
using Estacionamento.DAO;
using System.Globalization;

namespace Estacionamento.Dialog
{
    public partial class CadastroCliente : Form
    {

        DAOCliente DaoCliente = new DAOCliente();
        Pessoa modelPessoa = new Pessoa();
        Endereco modelEndereco = new Endereco();
        Cliente modelCliente = new Cliente();
        DateTime datahora;
        CultureInfo culture = new CultureInfo("pt-BR");
        string telval, cepval, strModelo;
        bool adm;
        int codFun;

        public void notadm()
        {
            funcionaáiosToolStripMenuItem.Enabled = false;
        }

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
            DataTable dtCliente = DaoCliente.consultarCliente().Tables["cliente"];
            this.listView.Items.Clear();

            if (dtCliente.Rows.Count >= 0)
            {
                for (int i = 0; i < dtCliente.Rows.Count; i++)
                {
                    DataRow linha = dtCliente.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["codigoCliente"].ToString());
                    lvi.SubItems.Add(linha["Nome"].ToString());
                    lvi.SubItems.Add(linha["CPF"].ToString());
                    lvi.SubItems.Add(linha["Telefone"].ToString());
                    listView.Items.Add(lvi);
                }
            }
        }

        public void preencheForm(string cpf)
        {
            Model.Cliente cliente = DaoCliente.atualizar(cpf);
            Model.Endereco endereco = cliente.EnderecoPessoa;

            txtNome.Text = cliente.Nome;
            maskCPF.Text = cliente.Cpf;
            maskTelefone.Text = cliente.Telefone;
            txtEmail.Text = cliente.Email;
            if (cliente.Mensalista)
            {
                rbMensalista.Checked = true;
                rbAvulso.Checked = false;
            }
            else
            {
                rbMensalista.Checked = false;
                rbAvulso.Checked = true;
            }

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

            rbMensalista.Checked = false;
            rbAvulso.Checked = false;
        }

        public CadastroCliente(bool admin, int codfuncionario)
        {
            InitializeComponent();
            preencheCombo();
            preencheList();

            if (!admin)
            {
                notadm();
            }
            codFun = codfuncionario;
            adm = admin;
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
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

                modelCliente.Nome = txtNome.Text;
                modelCliente.Cpf = maskCPF.Text;
                modelCliente.Telefone = maskTelefone.Text;
                modelCliente.Email = txtEmail.Text;

                if (rbMensalista.Checked)
                {
                    modelCliente.Mensalista = true;
                }
                else
                {
                    modelCliente.Mensalista = false;
                }

                DaoCliente.cadastrar(modelEndereco, modelCliente);

                limpaform();
                preencheList();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string codigo = listView.Items[listView.FocusedItem.Index].Text;
                DaoCliente.excluir(codigo);
                preencheList();
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            btnLimpar.Visible = true;
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

                    modelCliente.CodigoCliente = Convert.ToUInt32(listView.Items[listView.FocusedItem.Index].Text);
                    modelCliente.Nome = txtNome.Text;
                    modelCliente.Cpf = maskCPF.Text;
                    modelCliente.Telefone = maskTelefone.Text;
                    modelCliente.Email = txtEmail.Text;

                    if (rbMensalista.Checked)
                    {
                        modelCliente.Mensalista = true;
                    }
                    else
                    {
                        modelCliente.Mensalista = false;
                    }

                    DaoCliente.alteracao(modelEndereco, modelCliente);

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
            btnLimpar.Visible = false;
            limpaform();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtNome, true);
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

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtBairro, true);
        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtCidade, true);
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataTable dtC;

            if (rbCodigo.Checked)
            {
                dtC = DaoCliente.pesquisar("codigoCliente", txtPesquisar.Text).Tables["cliente"];
            }
            else if (rbNome.Checked)
            {
                dtC = DaoCliente.pesquisar(rbNome.Text, txtPesquisar.Text).Tables["cliente"];
            }
            else if (rbCPF.Checked)
            {
                dtC = DaoCliente.pesquisar(rbCPF.Text, txtPesquisar.Text).Tables["cliente"];
            }
            else if (rbTelefone.Checked)
            {
                dtC = DaoCliente.pesquisar(rbTelefone.Text, txtPesquisar.Text).Tables["cliente"];
            }
            else
            {
                dtC = DaoCliente.pesquisar(rbNome.Text, txtPesquisar.Text).Tables["cliente"];
            }

            this.listView.Items.Clear();

            if (dtC.Rows.Count >= 1)
            {
                for (int i = 0; i < dtC.Rows.Count; i++)
                {
                    DataRow linha = dtC.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["codigoCliente"].ToString());
                    lvi.SubItems.Add(linha["Nome"].ToString());
                    lvi.SubItems.Add(linha["CPF"].ToString());
                    lvi.SubItems.Add(linha["Telefone"].ToString());
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

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void funcionaáiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Hide();
            CadastroFuncionario cadFuncionario = new CadastroFuncionario(adm, codFun);
            cadFuncionario.ShowDialog();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Hide();
            CadastroVeiculo cadVeiculo = new CadastroVeiculo(adm, codFun);
            cadVeiculo.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datahora = DateTime.Now;
            toolStriptxtData.Text = "Data: " + datahora.ToString("d", culture);
            toolStriptxtHora.Text = "Hora: " + datahora.ToShortTimeString();
        }

        private void CadastroCliente_KeyDown(object sender, KeyEventArgs e)
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
