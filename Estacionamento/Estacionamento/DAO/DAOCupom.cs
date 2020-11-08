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
    class DAOCupom
    {
        private MySqlConnection conexao = ConnectionFactory.getInstancia().getConexao();
        DataSet dsCupom = new DataSet();
        DataTable dtCupom = new DataTable();
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

        #region CRUDCupom
        // CREATE   (INSERT - CADASTRO)
        public void cadastrar(Cupom cupom)
        {
            try
            {
                DadosEmpresa empresa = new DadosEmpresa();
                Funcionario func = new Funcionario();
                Veiculo veiculo = new Veiculo();
                empresa = cupom.Empresa;
                func = cupom.Empregado;
                veiculo = cupom.Automovel;

                string sql;
                MySqlCommand CDCupom;

                this.conectar();

                sql = "INSERT INTO `cupom` (`horaEntrada`, `horaSaida`, `data`, `situacao`, `total`, `placa`, `codigoFuncionario`, `cnpj`) VALUES (@horaEntrada, @horaSaida, @data, @situacao, @total, @placa, @codigoFuncionario, @cnpj)";
                CDCupom = new MySqlCommand(sql, conexao);

                CDCupom.Parameters.AddWithValue("@horaEntrada", cupom.HoraEntrada);
                CDCupom.Parameters.AddWithValue("@horaSaida", cupom.HoraSaida);
                CDCupom.Parameters.AddWithValue("@data", cupom.Data);
                CDCupom.Parameters.AddWithValue("@situacao", cupom.Situacao);
                CDCupom.Parameters.AddWithValue("@total", cupom.Total);
                CDCupom.Parameters.AddWithValue("@placa", veiculo.Placa);
                CDCupom.Parameters.AddWithValue("@codigoFuncionario", func.CodigoFuncionario);
                CDCupom.Parameters.AddWithValue("@cnpj", empresa.Cnpj);
                CDCupom.ExecuteNonQuery();
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

        // UPDATE   (UPDATE - ATUALIZACAO) - RESPOSAVEL PELA SAIDA
        public void alteracao(Cupom cupom)
        {
            try
            {
                string sql;
                MySqlCommand CDCupom;

                Veiculo veiculo = new Veiculo();
                veiculo = cupom.Automovel;

                this.conectar();

                sql = "UPDATE `cupom` SET `horaSaida` = @horaSaida, `situacao` = @situacao WHERE `placa` = @placa";
                CDCupom = new MySqlCommand(sql, conexao);

                CDCupom.Parameters.AddWithValue("@horaSaida", cupom.HoraSaida);
                CDCupom.Parameters.AddWithValue("@situacao", cupom.Situacao);
                CDCupom.Parameters.AddWithValue("@placa", veiculo.Placa);
                CDCupom.ExecuteNonQuery();

                MessageBox.Show("Saida de veículo realizada", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        public DataSet consultarCupom()
        {
            // Zerar o Data Set
            dsCupom.Clear();

            try
            {
                this.conectar();

                string sql = "SELECT `c`.`placa`, `data`, `situacao`, `cpf` FROM `cupom` AS `c`, `cliente` AS `p`, `veiculo` AS `v` WHERE `c`.`placa` = `v`.`placa` AND `v`.`codigoCliente` = `p`.`codigoCliente`";
                adapter = new MySqlDataAdapter(sql, conexao);
                adapter.Fill(dsCupom, "cupom");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro\n" + ex.ToString(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsCupom;
        }

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA PROCURA DO CLIENTE
        public DataSet consultarCliente(string cpf)
        {
            dsCupom.Clear();

            try
            {
                this.conectar();
                MySqlCommand sql = new MySqlCommand();
                sql.Connection = conexao;
                sql.CommandText = "SELECT `nome`, `codigoCliente`, `mensalista` FROM `cliente` WHERE `cpf` = '" + cpf + "'";
                adapter = new MySqlDataAdapter(sql.CommandText, sql.Connection);
                adapter.Fill(dsCupom, "cliente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsCupom;
        }

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA PROCURA DOS VEICULOS DO CLIENTE
        public DataTable consultarPlaca(string codCliente)
        {
            dtCupom.Clear();

            try
            {
                this.conectar();
                string sql = "SELECT `placa` FROM `veiculo` WHERE `codigoCliente` = '" + codCliente + "'";
                adapter = new MySqlDataAdapter(sql, conexao);
                adapter.Fill(dtCupom);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao consultar: \n" + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
            return dtCupom;
        }

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA PROCURA DO VEICULO
        public DataSet consultarVeiculo(string placa)
        {
            dsCupom.Clear();

            try
            {
                this.conectar();
                MySqlCommand sql = new MySqlCommand();
                sql.Connection = conexao;
                sql.CommandText = "SELECT `cor`, `fabricante`, `porte`, `modelo` FROM `veiculo` WHERE `placa` = '" + placa + "'";
                adapter = new MySqlDataAdapter(sql.CommandText, sql.Connection);
                adapter.Fill(dsCupom, "veiculo");
            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsCupom;
        }

        // READ     (SELECT - CONSULTA) - RESPOSAVEL PELA CONSULTA NO CUPOM
        public DataSet consultarCupom(string placa)
        {
            dsCupom.Clear();

            try
            {
                this.conectar();
                MySqlCommand sql = new MySqlCommand();
                sql.Connection = conexao;
                sql.CommandText = "SELECT * FROM `cupom` WHERE `placa` = '" + placa + "'";
                adapter = new MySqlDataAdapter(sql.CommandText, sql.Connection);
                adapter.Fill(dsCupom, "cupom");
            }
            catch (Exception ex)
            {
                MessageBox.Show("O Erro é\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexao.Close();
            }

            return dsCupom;
        }

        #endregion

    }
}
