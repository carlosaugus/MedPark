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
using System.Globalization;

namespace Estacionamento.Dialog
{
    public partial class CadastroVeiculo : Form
    {

        DAOVeiculo DaoVeiculo = new DAOVeiculo();
        Cliente modelCliente = new Cliente();
        Veiculo modelVeiculo = new Veiculo();
        DateTime datahora;
        CultureInfo culture = new CultureInfo("pt-BR");
        uint codigoCliente, codigoVCliente;
        string placa;
        bool adm;
        int codFunc;

        public void notadm()
        {
            funcionaáiosToolStripMenuItem.Enabled = false;
        }

        public void preencheCombo()
        {
            cboPorte.Items.Add("Pequeno");
            cboPorte.Items.Add("Médio");
            cboPorte.Items.Add("Grande");
            cboPorte.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public void preencheListCliente()
        {
            DataTable dtCliente = DaoVeiculo.consultarVeiculo(1).Tables["cliente"];
            this.listViewCliente.Items.Clear();

            if (dtCliente.Rows.Count >= 0)
            {
                for (int i = 0; i < dtCliente.Rows.Count; i++)
                {
                    DataRow linha = dtCliente.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["codigoCliente"].ToString());
                    lvi.SubItems.Add(linha["Nome"].ToString());
                    lvi.SubItems.Add(linha["CPF"].ToString());
                    listViewCliente.Items.Add(lvi);
                }
            }
        }

        public void preencheListVeiculo()
        {
            DataTable dtVeiculo = DaoVeiculo.consultarVeiculo(2).Tables["veiculo"];
            this.listViewVeiculo.Items.Clear();

            if (dtVeiculo.Rows.Count >= 0)
            {
                for (int i = 0; i < dtVeiculo.Rows.Count; i++)
                {
                    DataRow linha = dtVeiculo.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["Placa"].ToString());
                    lvi.SubItems.Add(linha["Modelo"].ToString());
                    lvi.SubItems.Add(linha["Fabricante"].ToString());
                    lvi.SubItems.Add(linha["Cor"].ToString());
                    lvi.SubItems.Add(linha["codigoCliente"].ToString());
                    listViewVeiculo.Items.Add(lvi);
                }
            }
        }

        public void preencheForm(string placa)
        {
            Model.Veiculo veiculo = DaoVeiculo.atualizar(placa);
            Model.Cliente cliente = veiculo.Proprietario;

            txtProprietario.Text = cliente.Nome;
            maskCPF.Text = cliente.Cpf;
            mskPlaca.Text = veiculo.Placa;
            txtModelo.Text = veiculo.Modelo;
            txtFabricante.Text = veiculo.Fabricante;
            txtCor.Text = veiculo.Cor;
            cboPorte.Text = veiculo.Porte;
            
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
            placa = mskPlaca.Text;


            placa.Trim();
            placa = placa.Replace(" ", "").Replace("-", "");

            if (txtProprietario.Text == string.Empty || maskCPF.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Item.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else if (placa == string.Empty && placa.Length < 7)
            {
                mskPlaca.BackColor = Color.Red;
                mskPlaca.Focus();
            }
            else if (txtModelo.Text == string.Empty)
            {
                validaCampos(txtModelo, false);
            }
            else if (txtFabricante.Text == string.Empty)
            {
                validaCampos(txtFabricante, false);
            }
            else if (txtCor.Text == string.Empty)
            {
                validaCampos(txtCor, false);
            }
            else if (cboPorte.Text == string.Empty)
            {
                MessageBox.Show("Escola uma opção de Porte.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                return true;
            }

            return false;
        }

        public void limpaform()
        {
            txtProprietario.Text = string.Empty;
            maskCPF.Text = string.Empty;
            mskPlaca.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtFabricante.Text = string.Empty;
            txtCor.Text = string.Empty;
            cboPorte.SelectedIndex = -1;
        }

        public CadastroVeiculo(bool admin, int codfuncionario)
        {
            InitializeComponent();
            preencheCombo();
            preencheListCliente();
            preencheListVeiculo();

            if (!admin)
            {
                notadm();
            }
            codFunc = codfuncionario;
            adm = admin;
         }

        private void listViewCliente_DoubleClick(object sender, EventArgs e)
        {
            limpaform();
            txtProprietario.Text = listViewCliente.Items[listViewCliente.FocusedItem.Index].SubItems[1].Text;
            maskCPF.Text = listViewCliente.Items[listViewCliente.FocusedItem.Index].SubItems[2].Text;
            codigoCliente = Convert.ToUInt32(listViewCliente.Items[listViewCliente.FocusedItem.Index].Text);
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            if (!validaform())
            {
            }
            else
            {
                modelCliente.CodigoCliente = codigoCliente;
                modelVeiculo.Placa = mskPlaca.Text.ToUpper();
                modelVeiculo.Modelo = txtModelo.Text;
                modelVeiculo.Fabricante = txtFabricante.Text;
                modelVeiculo.Cor = txtCor.Text;
                modelVeiculo.Porte = cboPorte.Text;
 
                DaoVeiculo.cadastrar(modelVeiculo, modelCliente);

                btnLimpar.Visible = false;
                limpaform();
                preencheListVeiculo();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string codigo = listViewVeiculo.Items[listViewVeiculo.FocusedItem.Index].Text;
                DaoVeiculo.excluir(codigo);
                preencheListVeiculo();
            }
        }

        private void listViewVeiculo_DoubleClick(object sender, EventArgs e)
        {
            btnLimpar.Visible = true;
            codigoVCliente = Convert.ToUInt32(listViewVeiculo.Items[listViewVeiculo.FocusedItem.Index].SubItems[4].Text);
            preencheForm(listViewVeiculo.Items[listViewVeiculo.FocusedItem.Index].Text);
            mskPlaca.Focus();
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
                    modelCliente.CodigoCliente = codigoVCliente;
                    modelVeiculo.Placa = mskPlaca.Text.ToUpper();
                    modelVeiculo.Modelo = txtModelo.Text;
                    modelVeiculo.Fabricante = txtFabricante.Text;
                    modelVeiculo.Cor = txtCor.Text;
                    modelVeiculo.Porte = cboPorte.Text;

                    DaoVeiculo.alteracao(modelVeiculo, modelCliente);

                    btnLimpar.Visible = false;
                    limpaform();
                    preencheListVeiculo();
                }
                else
                {

                }
            }
        }

        private void mskPlaca_TextChanged(object sender, EventArgs e)
        {
            placa = mskPlaca.Text;

            placa.Trim();
            placa = placa.Replace(" ", "").Replace("-", "");

            if (placa != string.Empty && placa.Length >= 7)
            {
                mskPlaca.BackColor = Color.White;
                mskPlaca.Focus();
            }
        }

        private void txtModelo_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtModelo, true);
        }

        private void txtFabricante_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtFabricante, true);
        }

        private void txtCor_TextChanged(object sender, EventArgs e)
        {
            validaCampos(txtCor, true);
        }

        private void txtPesquisarClientes_TextChanged(object sender, EventArgs e)
        {
            DataTable dtCliente;

            if (rbCodigo.Checked)
            {
                dtCliente = DaoVeiculo.pesquisar(1, "codigoCliente", txtPesquisarClientes.Text).Tables["cliente"];
            }
            else if (rbCPF.Checked)
            {
                dtCliente = DaoVeiculo.pesquisar(1, rbCPF.Text, txtPesquisarClientes.Text).Tables["cliente"];
            }
            else if (rbNome.Checked)
            {
                dtCliente = DaoVeiculo.pesquisar(1, rbNome.Text, txtPesquisarClientes.Text).Tables["cliente"];
            }
            else
            {
                dtCliente = DaoVeiculo.pesquisar(1, rbNome.Text, txtPesquisarClientes.Text).Tables["cliente"];
            }

            this.listViewCliente.Items.Clear();

            if (dtCliente.Rows.Count >= 1)
            {
                for (int i = 0; i < dtCliente.Rows.Count; i++)
                {
                    DataRow linha = dtCliente.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["codigoCliente"].ToString());
                    lvi.SubItems.Add(linha["Nome"].ToString());
                    lvi.SubItems.Add(linha["CPF"].ToString());
                    listViewCliente.Items.Add(lvi);
                }
            }
        }

        private void txtPesquisarVeiculos_TextChanged(object sender, EventArgs e)
        {
            DataTable dtVeiculo;

            if (rbPlaca.Checked)
            {
                dtVeiculo = DaoVeiculo.pesquisar(2, rbPlaca.Text, txtPesquisarVeiculos.Text).Tables["veiculo"];
            }
            else if (rbModelo.Checked)
            {
                dtVeiculo = DaoVeiculo.pesquisar(2, rbModelo.Text, txtPesquisarVeiculos.Text).Tables["veiculo"];
            }
            else if (rbFabricante.Checked)
            {
                dtVeiculo = DaoVeiculo.pesquisar(2, rbFabricante.Text, txtPesquisarVeiculos.Text).Tables["veiculo"];
            }
            else if (rbCodCliente.Checked)
            {
                dtVeiculo = DaoVeiculo.pesquisar(2, "codigoCliente", txtPesquisarVeiculos.Text).Tables["veiculo"];
            }
            else
            {
                dtVeiculo = DaoVeiculo.pesquisar(2, rbPlaca.Text, txtPesquisarVeiculos.Text).Tables["veiculo"];
            }

            this.listViewVeiculo.Items.Clear();
            
            if (dtVeiculo.Rows.Count >= 1)
            {
                for (int i = 0; i < dtVeiculo.Rows.Count; i++)
                {
                    DataRow linha = dtVeiculo.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["Placa"].ToString());
                    lvi.SubItems.Add(linha["Modelo"].ToString());
                    lvi.SubItems.Add(linha["Fabricante"].ToString());
                    lvi.SubItems.Add(linha["Cor"].ToString());
                    lvi.SubItems.Add(linha["codigoCliente"].ToString());
                    listViewVeiculo.Items.Add(lvi);
                }
            }
        }

        private void dadosDaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroEmpresa cadEmpresa = new CadastroEmpresa(adm, codFunc);
            cadEmpresa.ShowDialog();
        }

        private void entradaDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaixaVeiculos entradaveiculos = new BaixaVeiculos(1, adm, codFunc);
            entradaveiculos.ShowDialog();
        }

        private void saidaDeVeiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            BaixaVeiculos entradaveiculos = new BaixaVeiculos(2, adm, codFunc);
            entradaveiculos.ShowDialog();
        }

        private void funcionaáiosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            CadastroFuncionario cadFuncionario = new CadastroFuncionario(adm, codFunc);
            cadFuncionario.ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            CadastroCliente cadCliente = new CadastroCliente(adm, codFunc);
            cadCliente.ShowDialog();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Hide();
            Home home = new Home(adm, codFunc);
            home.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaform();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datahora = DateTime.Now;
            toolStriptxtData.Text = "Data: " + datahora.ToString("d", culture);
            toolStriptxtHora.Text = "Hora: " + datahora.ToShortTimeString();
        }

        private void CadastroVeiculo_KeyDown(object sender, KeyEventArgs e)
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

                case Keys.Escape:
                    sairToolStripMenuItem_Click(sender, e);
                    break;
            }
        }
 

    }
}
