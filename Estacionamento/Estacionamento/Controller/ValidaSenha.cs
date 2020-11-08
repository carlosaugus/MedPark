using System;
using System.Text.RegularExpressions;

namespace Estacionamento.Controller
{
    public enum ForcaDaSenha
    {
        Fraca,
        Aceitavel,
        Forte,
        Segura
    }

    public class ValidaSenha
    {
        public int geraPontosSenha(string senha)
        {
            if (senha == null) return 0;
            int pTamanho = GetPontoPorTamanho(senha);
            int pMinusculas = GetPontoPorMinusculas(senha);
            int pMaiusculas = GetPontoPorMaiusculas(senha);
            int pDigitos = GetPontoPorDigitos(senha);
            int pSimbolos = GetPontoPorSimbolos(senha);
            int pRepeticao = GetPontoPorRepeticao(senha);
            return pTamanho + pMinusculas + pMaiusculas + pDigitos + pSimbolos - pRepeticao;
        }

        private int GetPontoPorTamanho(string senha)
        {
            return Math.Min(10, senha.Length) * 3;
        }

        private int GetPontoPorMinusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[a-z]", "").Length;
            return Math.Min(2, rawplacar) * 1;
        }

        private int GetPontoPorMaiusculas(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[A-Z]", "").Length;
            return Math.Min(2, rawplacar) * 3;
        }

        private int GetPontoPorDigitos(string senha)
        {
            int rawplacar = senha.Length - Regex.Replace(senha, "[0-9]", "").Length;
            return Math.Min(2, rawplacar) * 2;
        }

        private int GetPontoPorSimbolos(string senha)
        {
            int rawplacar = Regex.Replace(senha, "[a-zA-Z0-9]", "").Length;
            return Math.Min(2, rawplacar) * 4;
        }

        private int GetPontoPorRepeticao(string senha)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"(\w)*.*\1");
            bool repete = regex.IsMatch(senha);
            if (repete)
            {
                return 30;
            }
            else
            {
                return 0;
            }
        }

        public ForcaDaSenha GetForcaDaSenha(string senha)
        {
            int placar = geraPontosSenha(senha);

            if (placar < 30)
                return ForcaDaSenha.Fraca;
            else if (placar < 40)
                return ForcaDaSenha.Aceitavel;
            else if (placar < 80)
                return ForcaDaSenha.Forte;
            else
                return ForcaDaSenha.Segura;
        }
    }
}
