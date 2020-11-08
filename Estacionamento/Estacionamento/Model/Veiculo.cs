using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class Veiculo
    {

        private string placa;

        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }

        private string modelo;

        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        private string cor;

        public string Cor
        {
            get { return cor; }
            set { cor = value; }
        }

        private string fabricante;

        public string Fabricante
        {
            get { return fabricante; }
            set { fabricante = value; }
        }

        private string porte;

        public string Porte
        {
            get { return porte; }
            set { porte = value; }
        }

        private Cliente proprietario;

        public Cliente Proprietario
        {
            get { return proprietario; }
            set { proprietario = value; }
        }
    }
}
