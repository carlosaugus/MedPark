using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Controller
{
    class ValidaCNPJ
    {
        public static bool validaCnpj(string cnpj)
		{
			int[] m1 = new int[12] {5,4,3,2,9,8,7,6,5,4,3,2};
			int[] m2 = new int[13] {6,5,4,3,2,9,8,7,6,5,4,3,2};
			int soma;
			int resto;
			string digito;
			string tempCnpj;

			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

			if (cnpj.Length != 14)
			{
                return false;
            }

            switch (cnpj)
            {
                case "00000000000000":
                case "11111111111111":
                case "22222222222222":
                case "33333333333333":
                case "44444444444444":
                case "55555555555555":
                case "66666666666666":
                case "77777777777777":
                case "88888888888888":
                case "99999999999999":
                    return false;
            }

			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;

			for(int i=0; i<12; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * m1[i];
            }
			   
            resto = (soma % 11);

			if ( resto < 2)
            {
                resto = 0;
            }			   
			else
            {
                resto = 11 - resto;
            }
			   
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			
            for (int i = 0; i < 13; i++)
            {
                soma += int.Parse(tempCnpj[i].ToString()) * m2[i];
            }
			   
			resto = (soma % 11);

			if (resto < 2)
            {
                resto = 0;
            }
			else
            {
                resto = 11 - resto;
            }
			   
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}
	}
}
