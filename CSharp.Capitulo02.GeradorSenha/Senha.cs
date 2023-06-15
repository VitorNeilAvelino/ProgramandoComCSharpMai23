using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha
{
    public class Senha
    {
        public const int TamanhoMinimo = 4;

        public Senha()
        {
            Valor = Gerar();
        }

        public int Tamanho { get; set; } = TamanhoMinimo;
        public string Valor { get; set; }

        public string Gerar()
        {
            var senha = "";
            var randomico = new Random();

            for (int i = 1; i <= Tamanho; i++)
            {
                var algarismo = randomico.Next(10);

                senha += algarismo;
            }

            return senha;
        }
    }
}
