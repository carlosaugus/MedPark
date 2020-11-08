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
    public partial class BaixaVeiculos : Form
    {
        CultureInfo culture = new CultureInfo("pt-BR");
        DAOVeiculo DaoVeiculo = new DAOVeiculo();
        DAOCupom DaoCupom = new DAOCupom();
        Cupom cupom = new Cupom();
        DateTime datahora;
        bool adm, maisdetres = false;
        double valorrecebido, valortotal;
        int codFun;

        public void notadm()
        {
            funcionaáiosToolStripMenuItem.Enabled = false;
            dadosDaEmpresaToolStripMenuItem.Enabled = false;
        }

        public void preencheList()
        {
            DataTable dtCupom = DaoCupom.consultarCupom().Tables["cupom"];
            this.listView.Items.Clear();

            if (dtCupom.Rows.Count >= 0)
            {
                for (int i = 0; i < dtCupom.Rows.Count; i++)
                {
                    DataRow linha = dtCupom.Rows[i];
                    ListViewItem lvi = new ListViewItem(linha["placa"].ToString());
                    lvi.SubItems.Add(linha["data"].ToString());
                    if (Convert.ToBoolean(linha["situacao"].ToString()))
                    {
                        lvi.SubItems.Add("Estacionado");
                    }
                    else
                    {
                        lvi.SubItems.Add("Deu Saida");
                        lvi.BackColor = Color.Red;
                    }
                    lvi.SubItems.Add(linha["cpf"].ToString());
                    listView.Items.Add(lvi);
                }
            }
        }

        public BaixaVeiculos(int op, bool admin, int codfuncionario)
        {
            InitializeComponent();
            preencheList();
            cboVeiculo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPermanencia.DropDownStyle = ComboBoxStyle.DropDownList;

            if (!admin)
            {
                notadm();
            }

            codFun = codfuncionario;
            adm = admin;

            if (op != 1)
            {
                groupBox4.Height = 311;
                listView.Height = 256;

                groupBox1.Enabled = false;

                gboxPagamento.Visible = false;
                gboxPagamento.Enabled = false;

                gboxFazerSaida.Visible = false;
                gboxGerarCompro.Visible = false;

                gboxDataSaidaDeVeiculo.Visible = true;
                gboxGerarCupom.Visible = true;

                dtpData.Enabled = false;
                dtpData.BackColor = Color.Silver;
            }
            else
            {
                gboxDataSaidaDeVeiculo.Visible = false;
                gboxGerarCupom.Visible = false;
            }
            
        }
        
        private void mskCPF_TextChanged(object sender, EventArgs e)
        {
            if (mskCPF.Text.Length >= 14)
            {
                DataTable dtCupom = DaoCupom.consultarCliente(mskCPF.Text).Tables["cliente"];

                if (dtCupom.Rows.Count >= 1)
                {
                    for (int i = 0; i < dtCupom.Rows.Count; i++)
                    {
                        DataRow linha = dtCupom.Rows[0];
                        txtNome.Text = linha["nome"].ToString();
                        txtCodCliente.Text = linha["codigoCliente"].ToString();
                        if (Convert.ToBoolean(linha["mensalista"]))
                        {
                            rbMensalista.Checked = true;
                            rbAvulso.Checked = false;
                            cboPermanencia.Items.Clear();
                            cboPermanencia.Items.Add("1 mês");
                            cboPermanencia.Items.Add("2 mês");
                            cboPermanencia.Items.Add("3 mês");
                        }
                        else
                        {
                            rbMensalista.Checked = false;
                            rbAvulso.Checked = true;
                            cboPermanencia.Items.Clear();
                            cboPermanencia.Items.Add("1 hora");
                            cboPermanencia.Items.Add("2 hora");
                            cboPermanencia.Items.Add("3 hora");
                            cboPermanencia.Items.Add("Mais que 3 horas");
                        }
                    }
                }

                cboVeiculo.DataSource = DaoCupom.consultarPlaca(txtCodCliente.Text);
                cboVeiculo.DisplayMember = "placa";
                /*DataTable source = (DataTable)this.cboVeiculo.DataSource;
                DataRow row = source.NewRow();
                //row[1] = "---";
                source.Rows.InsertAt(row, 0);*/
                cboVeiculo.SelectedIndex = -1;
            }
            else
            {
                txtNome.Text = "Cliente não encontrado";
            }
        }

        private void cboVeiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboVeiculo.SelectedIndex >= 0)
            {
                DataTable dtCupom = DaoCupom.consultarVeiculo(cboVeiculo.Text).Tables["veiculo"];

                if (dtCupom.Rows.Count >= 1)
                {
                    for (int i = 0; i < dtCupom.Rows.Count; i++)
                    {
                        DataRow linha = dtCupom.Rows[0];
                        txtModelo.Text = linha["modelo"].ToString();
                        txtFabricante.Text = linha["fabricante"].ToString();
                        txtCor.Text = linha["cor"].ToString();
                        txtPorte.Text = linha["porte"].ToString();
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            datahora = DateTime.Now;
            toolStriptxtData.Text = "Data: " + datahora.ToString("d", culture);
            toolStriptxtHora.Text = "Hora: " + datahora.ToShortTimeString();
            txtHoraAtualDeEntrada.Text = datahora.ToShortTimeString();
            txtHoraAtualDeSaida.Text = datahora.ToShortTimeString();
        }

        
        private void cboPermanencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPermanencia.SelectedItem.ToString() == "1 mês")
            {
                cupom.HoraSaida = datahora.AddDays(30);
                txtValorTotal.Text = "160,00";
            }
            else if (cboPermanencia.SelectedItem.ToString() == "2 mês")
            {
                cupom.HoraSaida = datahora.AddDays(60);
                txtValorTotal.Text = "300,00";
            }
            else if (cboPermanencia.SelectedItem.ToString() == "3 mês")
            {
                cupom.HoraSaida = datahora.AddDays(90);
                txtValorTotal.Text = "420,00";
            }
            else if (cboPermanencia.SelectedItem.ToString() == "1 hora")
            {
                cupom.HoraSaida = datahora.AddHours(1);
                txtValorTotal.Text = "6,00";
            }
            else if (cboPermanencia.SelectedItem.ToString() == "2 hora")
            {
                cupom.HoraSaida = datahora.AddHours(2);
                txtValorTotal.Text = "11,00";
            }
            else if (cboPermanencia.SelectedItem.ToString() == "3 hora")
            {
                cupom.HoraSaida = datahora.AddHours(3);
                txtValorTotal.Text = "20,00";
            }
            else if (cboPermanencia.SelectedItem.ToString() == "Mais que 3 horas")
            {
                label15.Visible = true;
                numhoras.Visible = true;
                txtValorTotal.Text = Convert.ToString((4 * 5.90).ToString("#,##0.00"));
                cupom.HoraSaida = datahora.AddHours(4);
                maisdetres = true;
            }
        }

        private void numhoras_ValueChanged(object sender, EventArgs e)
        {
            if (maisdetres)
            {
                cupom.HoraSaida = datahora.AddHours(Convert.ToInt32(numhoras.Value));
                txtValorTotal.Text = Convert.ToString((Convert.ToInt32(numhoras.Value) * (5.90)).ToString("#,##0.00"));
            }
        }

        public static void AllowNumber(object sender, KeyPressEventArgs e, char cSymbol)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != cSymbol)
            {
                e.Handled = true;
            }

            if (e.KeyChar == cSymbol && (sender as TextBox).Text.IndexOf(cSymbol) > -1)
            {
                e.Handled = true;
            }
        }

        private void txtValorRecebido_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumber(sender, e, ',');
            if (Convert.ToDouble(char.IsLetter(e.KeyChar)) < valortotal)
            {
                e.Handled = false;
            }
        }

        private void txtmaishoras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
            else if (Convert.ToDouble(char.IsLetter(e.KeyChar)) <= 3)
            {
                e.Handled = false;
            }
        }

        private void txtValorRecebido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                valorrecebido = (Convert.ToDouble(txtValorRecebido.Text));
                valortotal = (Convert.ToDouble(txtValorTotal.Text));

                double troco = valorrecebido - valortotal;

                if (valorrecebido >= valortotal)
                {
                    txtTroco.Text = troco.ToString("#,##0.00");
                    gboxGerarCompro.Enabled = true;
                    txtValorRecebido.BackColor = Color.White;
                }
                else
                {
                    txtTroco.Text = "Valor invalido";
                    gboxGerarCompro.Enabled = false;
                }
            }
            catch (Exception)
            {
                txtTroco.Text = "Valor invalido";
                gboxGerarCompro.Enabled = false;
            }
        }

        private void btnFazerSaida_Click(object sender, EventArgs e)
        {
            groupBox4.Height = 311;
            listView.Height = 256;

            groupBox1.Enabled = false;

            gboxPagamento.Visible = false;
            gboxPagamento.Enabled = false;

            gboxFazerSaida.Visible = false;
            gboxGerarCompro.Visible = false;

            gboxDataSaidaDeVeiculo.Visible = true;
            gboxGerarCupom.Visible = true;

            dtpData.Enabled = false;
            dtpData.BackColor = Color.Silver;
        }

        private void btnGerarCupom_Click(object sender, EventArgs e)
        {
            DAOEmpresa DaoEmpresa = new DAOEmpresa();
            Veiculo veiculo = new Veiculo();

            cupom.HoraSaida = datahora;
            cupom.Situacao = false;
            veiculo.Placa = listView.Items[listView.FocusedItem.Index].Text;
            cupom.Automovel = veiculo;

            DaoCupom.alteracao(cupom);
            //this.Hide();
            ModeloCupom modCupom = new ModeloCupom(2, veiculo.Placa, codFun);
            modCupom.ShowDialog();
            preencheList();
        }

        private void btnGerarCompro_Click(object sender, EventArgs e)
        {
            if (txtValorRecebido.Text == "")
            {
                txtValorRecebido.BackColor = Color.Red;
                txtValorRecebido.Focus();
            }
            else
            {
                DAOEmpresa DaoEmpresa = new DAOEmpresa();
                DadosEmpresa empresa = DaoEmpresa.atualizar();
                Veiculo veiculo = new Veiculo();
                Funcionario func = new Funcionario();

                func.CodigoFuncionario = Convert.ToUInt32(codFun);

                veiculo.Placa = cboVeiculo.Text;
                veiculo.Modelo = txtModelo.Text;
                veiculo.Fabricante = txtFabricante.Text;
                veiculo.Cor = txtCor.Text;
                veiculo.Porte = txtPorte.Text;

                cupom.HoraEntrada = datahora;
                //cupom.HoraSaida.ToString();
                cupom.Data = datahora;
                cupom.Situacao = true;
                cupom.Total = Convert.ToDouble(txtValorTotal.Text);
                cupom.Automovel = veiculo;
                cupom.Empregado = func;
                cupom.Empresa = empresa;

                DaoCupom.cadastrar(cupom);

                //this.Hide();
                ModeloCupom modCupom = new ModeloCupom(1, veiculo.Placa, codFun);
                modCupom.ShowDialog();
                preencheList();
            }
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            mskCPF.Text = listView.Items[listView.FocusedItem.Index].SubItems[3].Text;
            cboVeiculo.Text = listView.Items[listView.FocusedItem.Index].Text;
            btnFazerSaida_Click(sender, e);
            btnGerarCupom.Enabled = true;
        }

        private void dadosDaEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Hide();
            CadastroEmpresa cadEmpresa = new CadastroEmpresa(adm, codFun);
            cadEmpresa.ShowDialog();
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

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Hide();
            CadastroCliente cadCliente = new CadastroCliente(adm, codFun);
            cadCliente.ShowDialog();
        }

        private void veículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            this.Hide();
            CadastroVeiculo cadVeiculo = new CadastroVeiculo(adm, codFun);
            cadVeiculo.ShowDialog();
        }

        private void BaixaVeiculos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    if (adm)
                    {
                        dadosDaEmpresaToolStripMenuItem_Click(sender, e);
                    }
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

        private void BaixaVeiculos_FormClosed(object sender, FormClosedEventArgs e)
        {
            sairToolStripMenuItem_Click(sender, e);
        }

    }
}
