using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo10.DelegateLambda.Testes
{
    public delegate int EfetuarOperacao(int valor1, int valor2);

    public static class Calculadora
    {
        private static int Somar(int x, int y)
        {
            return x + y;
        }

        private static int Subtrair(int x, int y)
        {
            return x - y;
        }

        public static EfetuarOperacao ObterOperacao(TipoOperacao tipoOperacao)
        {
            switch (tipoOperacao)
            {
                case TipoOperacao.Soma:
                    return Somar;
                case TipoOperacao.Subtracao:
                    return Subtrair;
                case TipoOperacao.Multiplicacao:
                    break;
                case TipoOperacao.Divisao:
                    break;
            }

            throw new ArgumentOutOfRangeException();
        }
    }
}
