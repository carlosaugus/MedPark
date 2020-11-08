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
    class DAOCliente
    {
        private MySqlConnection conexao = ConnectionFactory.getInstancia().getConexao();
        DataSet dsCliente = new DataSet();
        DataTable dtCliente = new DataTable();
        MySqlDataAdapter adapter;

        Cliente cliente = new Cliente();
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
        
        #region CRUDCliente
        // CREATE   (INSERT - CADASTRO)
        public void cadastrar(Endereco endereco, Cliente cliente)
        {
            try
            {
                string sqlCli, sqlEnd;
                MySqlCommand CDCli, CDEnd;

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

                sqlCli = "INSERT INTO `cliente` (`cpf`, `nome`, `email`, `telefone`, `mensalista`, `codigoEndereco`) VALUES (@cpf, @nome, @email, @telefone, @mensalista, @codEndereco)";
                CDCli = new MySqlCommand(sqlCli, conexao);

                CDCli.Parameters.AddWithValue("@cpf", cliente.Cpf);
                CDCli.Parameters.AddWithValue("@nome", cliente.Nome);
                CDCli.Parameters.AddWithValue("@email", cliente.Email);
                CDCli.Parameters.AddWithValue("@telefone", cliente.Telefone);
                CDCli.Parameters.AddWithValue("@mensalista", cliente.Mensalista);
                CDCli.Parameters.AddWithValue("@codEndereco", CDEnd.LastInsertedId);
                CDCli.ExecuteNonQuery();

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
        
        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA LISTVIEW
        public DataSet consultarCliente()
        {
            // Zerar o Data Set
            dsCliente.Clear();

            try
            {
                this.conectar();

                string sql = "SELECT `codigoCliente`, `nome`, `cpf`, `telefone` FROM `cliente`";
                adapter = new MySqlDataAdapter(sql, conexao);
                adapter.Fill(dsCliente, "cliente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsCliente;
        }

        // SEARCH   (SEARCH - PESQUISAR)
        public DataSet pesquisar(string por, string texto)
        {
            // Zerar o Data Set
            dsCliente.Clear();
            string sql;

            try
            {
                this.conectar();

                sql = "SELECT `codigoCliente`, `cpf`, `nome`, `telefone` FROM `cliente` WHERE " + por + " LIKE @texto";
                adapter = new MySqlDataAdapter(sql, conexao);
                adapter.SelectCommand.Parameters.AddWithValue("@texto", "%" + texto + "%");
                adapter.Fill(dsCliente, "cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsCliente;
        }

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELO PREENCHIMENTO
        public Model.Cliente atualizar(string codigo)
        {
            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();

            string atualizar;
            MySqlCommand cmdAtualizar;
            MySqlDataReader clie;

            try
            {
                this.conectar();

                atualizar = "SELECT  `cpf`, `nome`, `telefone`, `email`, `mensalista`, `cep`, `logradouro`, `numero`, `complemento`, `bairro`, `cidade`, `estado` FROM `cliente` AS `c`, `endereco` AS `e` WHERE `e`.`codigoEndereco` = `c`.`codigoEndereco` AND `codigoCliente` = '" + codigo + "'";
                cmdAtualizar = new MySqlCommand(atualizar, conexao);

                clie = cmdAtualizar.ExecuteReader();
                clie.Read();

                endereco.Cep = clie.GetString("cep");
                endereco.Logradouro = clie.GetString("logradouro");
                endereco.Numero = clie.GetUInt32("numero");
                try
                {
                    endereco.Complemento = clie.GetString("complemento");
                }
                catch (Exception)
                {
                }
                endereco.Bairro = clie.GetString("bairro");
                endereco.Cidade = clie.GetString("cidade");
                endereco.Estado = clie.GetString("estado");

                cliente.Cpf = clie.GetString("cpf");
                cliente.Nome = clie.GetString("nome");
                cliente.Telefone = clie.GetString("telefone");
                cliente.Email = clie.GetString("email");
                cliente.Mensalista = clie.GetBoolean("mensalista");
                cliente.EnderecoPessoa = endereco;


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
            return cliente;
        }

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELA ALTERAÇÃO
        public void alteracao(Endereco endereco, Cliente cliente)
        {
            try
            {
                string sqlClie, sqlEnd;
                MySqlCommand CDClie, CDEnd;

                this.conectar();

                sqlEnd = "UPDATE `endereco` SET `cep` = @cep, `logradouro` = @logradouro, `numero` = @numero, `complemento` = @complemento, `bairro` = @bairro, `cidade` = @cidade, `estado` = @estado WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `cliente` WHERE `codigoCliente` = @codigoCliente)";
                CDEnd = new MySqlCommand(sqlEnd, conexao);

                CDEnd.Parameters.AddWithValue("@cep", endereco.Cep);
                CDEnd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                CDEnd.Parameters.AddWithValue("@numero", endereco.Numero);
                CDEnd.Parameters.AddWithValue("@complemento", endereco.Complemento);
                CDEnd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                CDEnd.Parameters.AddWithValue("@cidade", endereco.Cidade);
                CDEnd.Parameters.AddWithValue("@estado", endereco.Estado);
                CDEnd.Parameters.AddWithValue("@codigoCliente", cliente.CodigoCliente);

                CDEnd.ExecuteNonQuery();

                sqlClie = "UPDATE `cliente` SET `cpf` = @cpf, `nome` = @nome, `telefone` = @telefone, `email` = @email, `mensalista` = @mensalista WHERE `codigoCliente` = @codigoCliente";
                CDClie = new MySqlCommand(sqlClie, conexao);

                CDClie.Parameters.AddWithValue("@cpf", cliente.Cpf);
                CDClie.Parameters.AddWithValue("@nome", cliente.Nome);
                CDClie.Parameters.AddWithValue("@telefone", cliente.Telefone);
                CDClie.Parameters.AddWithValue("@email", cliente.Email);
                CDClie.Parameters.AddWithValue("@mensalista", cliente.Mensalista);
                CDClie.Parameters.AddWithValue("@codigoCliente", cliente.CodigoCliente);
                // CDClie.Parameters.AddWithValue("@codEndereco", CDEnd.LastInsertedId);
                CDClie.ExecuteNonQuery();

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

        // DELETE   (DELETE - EXCLUSAO)
        public void excluir(string codigo)
        {
            string excluirEnd, excluirClie;
            MySqlCommand excEnd, exClie;

            try
            {
                this.conectar();

                excluirClie = "DELETE FROM `endereco` WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `cliente` WHERE `codigoCliente` = '" + codigo + "')";
                excEnd = new MySqlCommand(excluirClie, conexao);
                excEnd.ExecuteNonQuery();

                excluirEnd = "DELETE FROM `cliente` WHERE `codigoCliente` = '" + codigo + "'";
                exClie = new MySqlCommand(excluirEnd, conexao);

                exClie.ExecuteNonQuery();

                //MessageBox.Show("Excluido com Sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Excluir do Banco de Dados\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }
        }

        #endregion
        
    }
}
