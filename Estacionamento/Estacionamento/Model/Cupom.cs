using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Model
{
    class Cupom
    {
        private DadosEmpresa empresa;

        public DadosEmpresa Empresa
        {
            get { return empresa; }
            set { empresa = value; }
        }

        private Funcionario empregado;

        internal Funcionario Empregado
        {
            get { return empregado; }
            set { empregado = value; }
        }

        private Veiculo automovel;

        public Veiculo Automovel
        {
            get { return automovel; }
            set { automovel = value; }
        }  

        private Cliente client;

        internal Cliente Client
        {
            get { return client; }
            set { client = value; }
        }

        private DateTime horaEntrada;

        public DateTime HoraEntrada
        {
            get { return horaEntrada; }
            set { horaEntrada = value; }
        }

        private DateTime horaSaida;

        public DateTime HoraSaida
        {
            get { return horaSaida; }
            set { horaSaida = value; }
        }

        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }

        private double total;

        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        private bool situacao;

        public bool Situacao
        {
            get { return situacao; }
            set { situacao = value; }
        }
    }
}
