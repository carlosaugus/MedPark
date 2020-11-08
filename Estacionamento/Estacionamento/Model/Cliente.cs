using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class Cliente : Pessoa
    {
        private uint codigoCliente;

        public uint CodigoCliente
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }

        private bool mensalista;

        public bool Mensalista
        {
            get { return mensalista; }
            set { mensalista = value; }
        }
    }
}
