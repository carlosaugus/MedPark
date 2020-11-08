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
    class DAOVeiculo
    {
        private MySqlConnection conexao = ConnectionFactory.getInstancia().getConexao();
        DataSet dsVeiculo = new DataSet();
        DataTable dtVeiculo = new DataTable();
        MySqlDataAdapter adapter;

        Veiculo cliente = new Veiculo();

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

        #region CRUDVeiculo
        // CREATE   (INSERT - CADASTRO)
        public void cadastrar(Veiculo veiculo, Cliente cliente)
        {
            try
            {
                string sqlVei;
                MySqlCommand CDVei;

                this.conectar();

                sqlVei = "INSERT INTO `veiculo` (`placa`, `cor`, `fabricante`, `porte`, `modelo`, `codigoCliente`) VALUES (@placa, @cor, @fabricante, @porte, @modelo, @codigoCliente)";
                CDVei = new MySqlCommand(sqlVei, conexao);

                CDVei.Parameters.AddWithValue("@placa", veiculo.Placa);
                CDVei.Parameters.AddWithValue("@cor", veiculo.Cor);
                CDVei.Parameters.AddWithValue("@fabricante", veiculo.Fabricante);
                CDVei.Parameters.AddWithValue("@porte", veiculo.Porte);
                CDVei.Parameters.AddWithValue("@modelo", veiculo.Modelo);
                CDVei.Parameters.AddWithValue("@codigoCliente", cliente.CodigoCliente);
                CDVei.ExecuteNonQuery();

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

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELAS LISTVIEWS
        public DataSet consultarVeiculo(int Switch)
        {
            // Zerar o Data Set
            dsVeiculo.Clear();

            try
            {
                this.conectar();
                string sql;

                switch (Switch)
                {
                    case 1:
                        sql = "SELECT `codigoCliente`, `nome`, `cpf` FROM `cliente`";
                        adapter = new MySqlDataAdapter(sql, conexao);
                        adapter.Fill(dsVeiculo, "cliente");
                        break;
                    
                    case 2:
                        sql = "SELECT `placa`, `modelo`, `fabricante`, `cor`, `codigoCliente` FROM `veiculo`";
                        adapter = new MySqlDataAdapter(sql, conexao);
                        adapter.Fill(dsVeiculo, "veiculo");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsVeiculo;
        }
        
        // SEARCH   (SEARCH - PESQUISAR)
        public DataSet pesquisar(int Switch, string por, string texto)
        {
            // Zerar o Data Set
            dsVeiculo.Clear();
            string sql;

            try
            {
                this.conectar();

                switch (Switch)
                {
                    case 1:
                        sql = "SELECT `codigoCliente`, `nome`, `cpf` FROM `cliente` WHERE " + por + " LIKE @texto";
                        adapter = new MySqlDataAdapter(sql, conexao);
                        adapter.SelectCommand.Parameters.AddWithValue("@texto", "%" + texto + "%");
                        adapter.Fill(dsVeiculo, "cliente");
                
                        break;

                    case 2:
                        sql = "SELECT `placa`, `modelo`, `fabricante`, `cor`, `codigoCliente` FROM `veiculo` WHERE " + por + " LIKE @texto";
                        adapter = new MySqlDataAdapter(sql, conexao);
                        adapter.SelectCommand.Parameters.AddWithValue("@texto", "%" + texto + "%");
                        adapter.Fill(dsVeiculo, "veiculo");
                
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsVeiculo;
        }
        
        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELO PREENCHIMENTO
        public Model.Veiculo atualizar(string placa)
        {
            Cliente cliente = new Cliente();
            Veiculo veiculo = new Veiculo();

            string atualizar;
            MySqlCommand cmdAtualizar;
            MySqlDataReader vei;

            try
            {
                this.conectar();

                atualizar = "SELECT `nome`, `cpf`, `placa`, `modelo`, `fabricante`, `cor`, `porte` FROM `cliente` AS `c`, `veiculo` AS `v` WHERE `c`.`codigoCliente` = `v`.`codigoCliente` AND `placa` = '" + placa + "'";
                cmdAtualizar = new MySqlCommand(atualizar, conexao);

                vei = cmdAtualizar.ExecuteReader();
                vei.Read();

                cliente.Nome = vei.GetString("nome");
                cliente.Cpf = vei.GetString("cpf");

                veiculo.Placa = vei.GetString("placa");
                veiculo.Modelo = vei.GetString("modelo");
                veiculo.Fabricante = vei.GetString("fabricante");
                veiculo.Cor = vei.GetString("cor");
                veiculo.Porte = vei.GetString("porte");
                veiculo.Proprietario = cliente;

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
            return veiculo;
        }
        
        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELA ALTERAÇÃO
        public void alteracao(Veiculo veiculo, Cliente cliente)
        {
            try
            {
                string sqlVei;
                MySqlCommand CDVei;

                this.conectar();

                sqlVei = "UPDATE `veiculo` SET `placa` = @placa, `cor` = @cor, `fabricante` = @fabricante, `porte` = @porte, `modelo` = @modelo WHERE `codigoCliente` = @codigoCliente";
                CDVei = new MySqlCommand(sqlVei, conexao);

                CDVei.Parameters.AddWithValue("@placa", veiculo.Placa);
                CDVei.Parameters.AddWithValue("@cor", veiculo.Cor);
                CDVei.Parameters.AddWithValue("@fabricante", veiculo.Fabricante);
                CDVei.Parameters.AddWithValue("@porte", veiculo.Porte);
                CDVei.Parameters.AddWithValue("@modelo", veiculo.Modelo);
                CDVei.Parameters.AddWithValue("@codigoCliente", cliente.CodigoCliente);

                CDVei.ExecuteNonQuery();

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
        public void excluir(string placa)
        {
            string excluirVei;
            MySqlCommand excVei;

            try
            {
                this.conectar();

                excluirVei = "DELETE FROM `veiculo` WHERE `placa` = '" + placa + "'";
                excVei = new MySqlCommand(excluirVei, conexao);

                excVei.ExecuteNonQuery();

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
