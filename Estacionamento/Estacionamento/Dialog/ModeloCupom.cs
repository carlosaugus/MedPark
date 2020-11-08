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

namespace Estacionamento.Dialog
{
    public partial class ModeloCupom : Form
    {
        string placa;
        int codFunc;

        public ModeloCupom(int op, string pl, int cod)
        {
            InitializeComponent();
            placa = pl;
            codFunc = cod;

            preenche();
            
            switch (op)
            {
                case 1: groupEntrada.Visible = true; break;
                case 2: groupSaida.Visible = true; break;
            }
        }

        public void preenche()
        {
            DAOEmpresa DaoEmpresa = new DAOEmpresa();
            DAOCupom DaoCupom = new DAOCupom();
            DadosEmpresa empresa = DaoEmpresa.atualizar();
            Endereco endereco = new Endereco();
            endereco = empresa.EnderecoEmpresa;

            lblNomeEstacionamento.Text = empresa.NomeFantasia;
            lblEnderecoEmpresa.Text = endereco.Logradouro + " nº " + endereco.Numero + " / " + endereco.Estado;
            lblTelefone.Text = empresa.Telefone;
            lblCNPJ.Text = empresa.Cnpj;
            lblIE.Text = empresa.Ie;

            DataTable dtCupom = DaoCupom.consultarCupom(placa).Tables["cupom"];

            if (dtCupom.Rows.Count >= 1)
            {
                for (int i = 0; i < dtCupom.Rows.Count; i++)
                {
                    DataRow linha = dtCupom.Rows[0];
                    lblCodCupom.Text = linha["codigoCupom"].ToString();
                    lblEntrada.Text = linha["horaEntrada"].ToString();
                    lblSaida.Text = linha["data"].ToString();
                    lblPlaca.Text = linha["placa"].ToString();
                    lblValor.Text = "R$ " + linha["total"].ToString();
                    lblAprensetar.Text = linha["horaSaida"].ToString();

                    lblData.Text = linha["data"].ToString();
                    lblPlacaE.Text = linha["placa"].ToString();
                    lblPagoEm.Text = linha["data"].ToString();
                    lblPermanencia.Text = "R$ " + linha["total"].ToString();
                    lblTotal.Text = "R$ " + linha["total"].ToString();
                    /*troco += Convert.ToDouble(linha["total"].ToString());
                    lblRecebido.Text = "R$ " + Convert.ToString(troco);
                    lblTroco.Text = "R$ " + Convert.ToString(troco - Convert.ToDouble(linha["total"].ToString()));*/
                }
            }

        }

    }
}
