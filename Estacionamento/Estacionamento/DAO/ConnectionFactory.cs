using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Estacionamento.DAO
{
    class ConnectionFactory
    {
        private static readonly ConnectionFactory connectionProvider = new ConnectionFactory();

        private ConnectionFactory()
        {

        }

        // Método que instancia um ConnectionFactory
        public static ConnectionFactory getInstancia()
        {
            return connectionProvider;
        }

        // Cria a conexão com o Banco de Dados
        public MySqlConnection getConexao()
        {
            MySqlConnectionStringBuilder stringConexao = new MySqlConnectionStringBuilder();
            /*stringConexao.Server = "10.190.39.78";
            stringConexao.Database = "dbCarlos";
            stringConexao.UserID = "carlos.nasciment";
            stringConexao.Password = "tec@13215641";*/

            stringConexao.Server = "localhost";
            stringConexao.Database = "dbCarlos";
            stringConexao.UserID = "root";
            stringConexao.Password = "root";

            return new MySqlConnection(stringConexao.ToString());
        }
    }
}
