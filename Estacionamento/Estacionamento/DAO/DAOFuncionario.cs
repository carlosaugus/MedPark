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
    class DAOFuncionario
    {
        private MySqlConnection conexao = ConnectionFactory.getInstancia().getConexao();
        DataSet dsFuncionario = new DataSet();
        DataTable dtFuncionario = new DataTable();
        MySqlDataAdapter adapter;

        Funcionario funcionario = new Funcionario();
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

        #region CRUDFuncionario
        // CREATE   (INSERT - CADASTRO)
        public void cadastrar(Endereco endereco, Funcionario funcionario)
        {
            try
            {
                string sqlFun, sqlEnd;
                MySqlCommand CDFun, CDEnd;

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

                sqlFun = "INSERT INTO `funcionario` (`cpf`, `nome`, `telefone`, `email`, `login`, `senha`, `nivel`, `codigoEndereco`) VALUES(@cpf, @nome, @telefone, @email, @login, MD5(@senha), @nivel, @codEndereco)";
                CDFun = new MySqlCommand(sqlFun, conexao);

                CDFun.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                CDFun.Parameters.AddWithValue("@nome", funcionario.Nome);
                CDFun.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                CDFun.Parameters.AddWithValue("@email", funcionario.Email);
                CDFun.Parameters.AddWithValue("@login", funcionario.Login);
                CDFun.Parameters.AddWithValue("@senha", funcionario.Senha);
                CDFun.Parameters.AddWithValue("@nivel", funcionario.Nivel);
                CDFun.Parameters.AddWithValue("@codEndereco", CDEnd.LastInsertedId);
                CDFun.ExecuteNonQuery();

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

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELO LOGIN
        public DataSet consultar(string critUsuario, string critSenha)
        {
            dsFuncionario.Clear();

            try
            {
                this.conectar();
                MySqlCommand sql = new MySqlCommand();
                sql.Connection = conexao;
                sql.CommandText = "SELECT `codigoFuncionario`, `nome`, `nivel` FROM `funcionario` WHERE `login` = '" + critUsuario + "' AND `senha` = MD5('" + critSenha + "')";
                adapter = new MySqlDataAdapter(sql.CommandText, sql.Connection);
                adapter.Fill(dsFuncionario, "funcionario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsFuncionario;
        }

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA LISTVIEW
        public DataSet consultarFunc()
        {
            // Zerar o Data Set
            dsFuncionario.Clear();

            try
            {
                this.conectar();

                string sql = "SELECT `cpf`, `nome`, `login` FROM `funcionario`";
                adapter = new MySqlDataAdapter(sql, conexao);
                adapter.Fill(dsFuncionario, "funcionario");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsFuncionario;
        }

        // SEARCH   (SEARCH - PESQUISAR)
        public DataSet pesquisar(string por, string texto)
        {
            // Zerar o Data Set
            dsFuncionario.Clear();
            string sql;

            try
            {
                this.conectar();

                sql = "SELECT `cpf`, `nome`, `login` FROM `funcionario` WHERE " + por + " LIKE @texto";
                adapter = new MySqlDataAdapter(sql, conexao);
                adapter.SelectCommand.Parameters.AddWithValue("@texto", "%" + texto + "%");
                adapter.Fill(dsFuncionario, "funcionario");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsFuncionario;
        }

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELO PREENCHIMENTO
        public Model.Funcionario atualizar(string cpf)
        {           
            Funcionario funcionario = new Funcionario();
            Endereco endereco = new Endereco();

            string atualizar;
            MySqlCommand cmdAtualizar;
            MySqlDataReader func;

            try
            {
                this.conectar();
               
                atualizar = "SELECT  `cpf`, `nome`, `telefone`, `email`, `login`, `senha`, `nivel`, `cep`, `logradouro`, `numero`, `complemento`, `bairro`, `cidade`, `estado` FROM `funcionario` AS `f`, `endereco` AS `e` WHERE `e`.`codigoEndereco` = `f`.`codigoEndereco` AND `cpf` = '" + cpf + "'";
                cmdAtualizar = new MySqlCommand(atualizar, conexao);

                func = cmdAtualizar.ExecuteReader();
                func.Read();

                endereco.Cep = func.GetString("cep");
                endereco.Logradouro = func.GetString("logradouro");
                endereco.Numero = func.GetUInt32("numero");
                try
                {
                    endereco.Complemento = func.GetString("complemento");
                }
                catch (Exception)
                {
                }
                endereco.Bairro = func.GetString("bairro");
                endereco.Cidade = func.GetString("cidade");
                endereco.Estado = func.GetString("estado");

                funcionario.Cpf = func.GetString("cpf");
                funcionario.Nome = func.GetString("nome");
                funcionario.Telefone = func.GetString("telefone");
                funcionario.Email = func.GetString("email");
                funcionario.Login = func.GetString("login");
                funcionario.Senha = func.GetString("senha");
                funcionario.Nivel = func.GetBoolean("nivel");
                funcionario.EnderecoPessoa = endereco;
                
                
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
            return funcionario;
        }

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELA ALTERAÇÃO
        public void alteracao(Endereco endereco, Funcionario funcionario, string cpf)
        {
            try
            {
                string sqlFun, sqlEnd;
                MySqlCommand CDFun, CDEnd;

                this.conectar();

                sqlEnd = "UPDATE `endereco` SET `cep` = @cep, `logradouro` = @logradouro, `numero` = @numero, `complemento` = @complemento, `bairro` = @bairro, `cidade` = @cidade, `estado` = @estado WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `funcionario` WHERE `cpf` = @cpf)";
                CDEnd = new MySqlCommand(sqlEnd, conexao);

                CDEnd.Parameters.AddWithValue("@cep", endereco.Cep);
                CDEnd.Parameters.AddWithValue("@logradouro", endereco.Logradouro);
                CDEnd.Parameters.AddWithValue("@numero", endereco.Numero);
                CDEnd.Parameters.AddWithValue("@complemento", endereco.Complemento);
                CDEnd.Parameters.AddWithValue("@bairro", endereco.Bairro);
                CDEnd.Parameters.AddWithValue("@cidade", endereco.Cidade);
                CDEnd.Parameters.AddWithValue("@estado", endereco.Estado);
                CDEnd.Parameters.AddWithValue("@cpf", cpf);

                CDEnd.ExecuteNonQuery();

                // sqlFun = "UPDATE `funcionario` SET `cpf` = @cpf, `nome` = @nome, `telefone` = @telefone, `email` = @email, `login` = @login, `senha` = md5(@senha), `nivel` = @nivel WHERE `cpf` = @cpf";
                sqlFun = "UPDATE `funcionario` SET `cpf` = @cpf, `nome` = @nome, `telefone` = @telefone, `email` = @email, `login` = @login, `nivel` = @nivel WHERE `cpf` = '" + cpf + "'"; 
                CDFun = new MySqlCommand(sqlFun, conexao);

                CDFun.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                CDFun.Parameters.AddWithValue("@nome", funcionario.Nome);
                CDFun.Parameters.AddWithValue("@telefone", funcionario.Telefone);
                CDFun.Parameters.AddWithValue("@email", funcionario.Email);
                CDFun.Parameters.AddWithValue("@login", funcionario.Login);
                // CDFun.Parameters.AddWithValue("@senha", funcionario.Senha);
                CDFun.Parameters.AddWithValue("@nivel", funcionario.Nivel);
                // CDFun.Parameters.AddWithValue("@codEndereco", CDEnd.LastInsertedId);
                CDFun.ExecuteNonQuery();

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

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELA ALTERAÇÃO DA SENHA
        public void alteracaoSenha(Funcionario funcionario)
        {
            try
            {
                string sqlFun;
                MySqlCommand CDFun;

                this.conectar();

                sqlFun = "UPDATE `funcionario` SET `senha` = md5(@senha) WHERE `cpf` = @cpf";
                CDFun = new MySqlCommand(sqlFun, conexao);
                
                CDFun.Parameters.AddWithValue("@cpf", funcionario.Cpf);
                CDFun.Parameters.AddWithValue("@senha", funcionario.Senha);

                CDFun.ExecuteNonQuery();

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
        public void excluir(string cpf)
        {
            string excluirEnd, excluirFun;
            MySqlCommand excEnd, exFun;

            try
            {
                this.conectar();
                
                excluirFun = "DELETE FROM `endereco` WHERE `codigoEndereco` = (SELECT `codigoEndereco` FROM `funcionario` WHERE `cpf` = '" + cpf + "')";
                excEnd = new MySqlCommand(excluirFun, conexao);
                excEnd.ExecuteNonQuery();

                excluirEnd = "DELETE FROM `funcionario` WHERE `cpf` = '" + cpf + "'";
                exFun = new MySqlCommand(excluirEnd, conexao);

                exFun.ExecuteNonQuery();

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