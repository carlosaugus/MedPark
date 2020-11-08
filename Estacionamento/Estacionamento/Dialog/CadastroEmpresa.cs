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
    public partial class CadastroEmpresa : Form
    {
        DAOEmpresa DaoEmpresa = new DAOEmpresa();
        Endereco modelEndereco = new Endereco();
        DadosEmpresa modelEmpresa = new DadosEmpresa();
        DateTime datahora;
        CultureInfo culture = new CultureInfo("pt-BR");
        string telval, cepval, ieval, cnpj;
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

        public void preencheForm()
        {
            DadosEmpresa empresa = DaoEmpresa.atualizar();
            Endereco endereco = empresa.EnderecoEmpresa;

            txtNomeFantasia.Text = empresa.NomeFantasia;
            maskIE.Text = empresa.Ie;
            maskTelefone.Text = empresa.Telefone;
            maskCNPJ.Text = empresa.Cnpj;

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
            telval = maskTelefone.Text;
            cepval = maskCep.Text;
            ieval = maskIE.Text;

            telval.Trim();
            cepval.Trim();
            ieval.Trim();
            telval = telval.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
            cepval = cepval.Replace(" ", "").Replace("-", "");
            ieval = ieval.Replace(".", "");

            if (txtNomeFantasia.Text == string.Empty)
            {
                validaCampos(txtNomeFantasia, false);
            }
            else if (ieval == string.Empty)
            {
                maskIE.BackColor = Color.Red;
                maskIE.Focus();
            }
            /*else if (!Controller.ValidaCNPJ.validaCnpj(maskCNPJ.Text))
            {
                lblCPF.Text = "CNPJ Invalido:";
                maskCNPJ.BackColor = Color.Red;
                maskCNPJ.Focus();
            }*/
            else if (telval == string.Empty && telval.Length < 10)
            {
                maskTelefone.BackColor = Color.Red;
                maskTelefone.Focus();
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

        public CadastroEmpresa(bool admin, int codfuncionario)
        {
            InitializeComponent();
            preencheCombo();

            if (!admin)
            {
                MessageBox.Show("Você não tem acesso!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.Visible = false;
                this.Hide();
                Home home = new Home(admin, 1);
                home.ShowDialog();
            }
            else
            {
                DataTable dtEmpresa = DaoEmpresa.consultar().Tables["dadosempresa"];
                if (dtEmpresa.Rows.Count >= 1)
                {
                    preencheForm();

                    for (int i = 0; i < dtEmpresa.Rows.Count; i++)
                    {
                        DataRow linha = dtEmpresa.Rows[0];
                        cnpj = linha["cnpj"].ToString();
                    }

                    btnCadastrarUsuario.Visible = false;
                }
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

                modelEmpresa.NomeFantasia = txtNomeFantasia.Text;
                modelEmpresa.Ie = maskIE.Text;
                modelEmpresa.Telefone = maskTelefone.Text;
                modelEmpresa.Cnpj = maskCNPJ.Text;

                DaoEmpresa.cadastrar(modelEndereco, modelEmpresa);

                btnCadastrarUsuario.Visible = false;
                if (MessageBox.Show("Dados Cadastrados", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Visible = false;
                    this.Hide();
                }
            }
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

                    modelEmpresa.NomeFantasia = txtNomeFantasia.Text;
                    modelEmpresa.Ie = maskIE.Text;
                    modelEmpresa.Telefone = maskTelefone.Text;
                    modelEmpresa.Cnpj = maskCNPJ.Text;

                    DaoEmpresa.alteracao(modelEndereco, modelEmpresa, cnpj);

                    btnCadastrarUsuario.Visible = false;
                }
                else
                {

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datahora = DateTime.Now;
            toolStriptxtData.Text = "Data: " + datahora.ToString("d", culture);
            toolStriptxtHora.Text = "Hora: " + datahora.ToShortTimeString();
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
            this.Hide();
            CadastroFuncionario cadFuncionario = new CadastroFuncionario(adm, codFun);
            cadFuncionario.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroCliente cadCliente = new CadastroCliente(adm, codFun);
            cadCliente.ShowDialog();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroVeiculo cadVeiculo = new CadastroVeiculo(adm, codFun);
            cadVeiculo.ShowDialog();
        }

        private void CadastroEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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

    }
}
