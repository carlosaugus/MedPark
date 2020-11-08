using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class Funcionario : Pessoa
    {
        private uint codigoFuncionario;

        public uint CodigoFuncionario
        {
            get { return codigoFuncionario; }
            set { codigoFuncionario = value; }
        }

        private bool nivel;

        public bool Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}