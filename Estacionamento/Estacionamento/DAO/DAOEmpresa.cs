using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using Estacionamento.Model;
using System.Windows.Forms;

namespace Estacionamento.DAO
{
    class DAOEmpresa
    {
        private MySqlConnection conexao = ConnectionFactory.getInstancia().getConexao();
        DataSet dsEmpresa = new DataSet();
        DataTable dtEmpresa = new DataTable();
        MySqlDataAdapter adapter;

        DadosEmpresa empresa = new DadosEmpresa();
        Endereco endereco = new Endereco();


        // Método para conectar ao Banco de Dados
        private void conectar()
        {
            try
            {
                conexao = ConnectionFactory.getInstancia().getConexao();
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region CRUDEmpresa
        // CREATE   (INSERT - CADASTRO)
        public void cadastrar(Endereco endereco, DadosEmpresa empresa)
        {
            try
            {
                string sqlEmp, sqlEnd;
                MySqlCommand CDEmp, CDEnd;

                this.conectar();

                sqlEnd = "INSERT INTO `endereco` (`cep`, `logradouro`, `numero`, `complemento`, `bairro`, `cidade`, `estado`) VALUES (@cep, @logradouro, @numero, @complemento, @bairro, @cidade, @estado)";
                CDEnd = new MySqlCommand(sqlEnd, conexao);

                CDEnd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                CDEnd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                CDEnd.Parameters.AddWithValue("@cidade", endereco.Cidade);
                CDEnd.Parameters.AddWithValue("@estado", endereco.Estado);
                CDEnd.Parameters.AddWithValue("@numero", endereco.Numero);
                CDEnd.Parameters.AddWithValue("@complemento", endereco.Complemento);
                CDEnd.Parameters.AddWithValue("@cep", endereco.Cep);
                CDEnd.ExecuteNonQuery();

                sqlEmp = "INSERT INTO `dadosempresa` (`cnpj`, `telefone`, `ie`, `nomeFantasia`, `codigoEndereco`) VALUES (@cnpj, @telefone, @ie, @nomeFantasia, @codigoEndereco)";
                CDEmp = new MySqlCommand(sqlEmp, conexao);

                CDEmp.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                CDEmp.Parameters.AddWithValue("@telefone", empresa.Telefone);
                CDEmp.Parameters.AddWithValue("@ie", empresa.Ie);
                CDEmp.Parameters.AddWithValue("@nomeFantasia", empresa.NomeFantasia);
                CDEmp.Parameters.AddWithValue("@codigoEndereco", CDEnd.LastInsertedId);
                CDEmp.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA VERIFICAÇÃO DE DADOS
        public DataSet consultar()
        {
            dsEmpresa.Clear();

            try
            {
                this.conectar();
                MySqlCommand sql = new MySqlCommand();
                sql.Connection = conexao;
                sql.CommandText = "SELECT * FROM consuempresa";
                adapter = new MySqlDataAdapter(sql.CommandText, sql.Connection);
                adapter.Fill(dsEmpresa, "dadosempresa");
            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsEmpresa;
        }

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELO PREENCHIMENTO
        public DadosEmpresa atualizar()
        {
            DadosEmpresa empresa = new DadosEmpresa();
            Endereco endereco = new Endereco();

            string atualizar;
            MySqlCommand cmdAtualizar;
            MySqlDataReader emp;

            try
            {
                this.conectar();

                atualizar = "SELECT * FROM preeempresa";
                cmdAtualizar = new MySqlCommand(atualizar, conexao);

                emp = cmdAtualizar.ExecuteReader();
                emp.Read();

                endereco.Cep = emp.GetString("cep");
                endereco.Logradouro = emp.GetString("logradouro");
                endereco.Numero = emp.GetUInt32("numero");
                try
                {
                    endereco.Complemento = emp.GetString("complemento");
                }
                catch (Exception)
                {
                }
                endereco.Bairro = emp.GetString("bairro");
                endereco.Cidade = emp.GetString("cidade");
                endereco.Estado = emp.GetString("estado");

                empresa.NomeFantasia = emp.GetString("nomeFantasia");
                empresa.Ie = emp.GetString("ie");
                empresa.Telefone = emp.GetString("telefone");
                empresa.Cnpj = emp.GetString("cnpj");
                empresa.EnderecoEmpresa = endereco;


                //MessageBox.Show("Excluido com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
            return empresa;
        }

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELA ALTERAÇÃO
        public void alteracao(Endereco endereco, DadosEmpresa empresa, string cnpj)
        {
            try
            {
                string sqlEmp, sqlEnd;
                MySqlCommand CDEmp, CDEnd;

                this.conectar();

                sqlEnd = "UPDATE `endereco` SET `cep` = @cep, `logradouro` = @logradouro, `numero` = @numero, `complemento` = @complemento, `bairro` = @bairro, `cidade` = @cidade, `estado` = @estado WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `dadosempresa` WHERE `cnpj` = @cnpj)";
                CDEnd = new MySqlCommand(sqlEnd, conexao);

                CDEnd.Parameters.AddWithValue("@cep", endereco.Cep);
                CDEnd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                CDEnd.Parameters.AddWithValue("@numero", endereco.Numero);
                CDEnd.Parameters.AddWithValue("@complemento", endereco.Complemento);
                CDEnd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                CDEnd.Parameters.AddWithValue("@cidade", endereco.Cidade);
                CDEnd.Parameters.AddWithValue("@estado", endereco.Estado);
                CDEnd.Parameters.AddWithValue("@cnpj", cnpj);
                CDEnd.ExecuteNonQuery();

                sqlEmp = "UPDATE `dadosempresa` SET `cnpj` = @cnpj, `telefone` = @telefone, `ie` = @ie, `nomeFantasia` = @nomeFantasia WHERE `cnpj` = @cnpjAntigo";
                CDEmp = new MySqlCommand(sqlEmp, conexao);

                CDEmp.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                CDEmp.Parameters.AddWithValue("@telefone", empresa.Telefone);
                CDEmp.Parameters.AddWithValue("@ie", empresa.Ie);
                CDEmp.Parameters.AddWithValue("@nomeFantasia", empresa.NomeFantasia);
                CDEmp.Parameters.AddWithValue("@cnpjAntigo", cnpj);
                CDEmp.ExecuteNonQuery();

                MessageBox.Show("Alterado com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        #endregion
    }
}
