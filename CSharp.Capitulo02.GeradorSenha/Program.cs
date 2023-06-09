﻿namespace CSharp.Capitulo02.GeradorSenha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantidadeDigitos;

            do
            {
                Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10): ");
                quantidadeDigitos = ObterQuantidadeDigitos();
            } while (quantidadeDigitos == 0);

            var senha = new Senha(quantidadeDigitos);

            Console.WriteLine($"Senha: {senha.Valor}");
        }

        private static int ObterQuantidadeDigitos()
        {
            //int quantidadeDigitos = 0;

            int.TryParse(Console.ReadLine(), out int quantidadeDigitos);

            //if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0)
            if (quantidadeDigitos is < 4 or > 10 || quantidadeDigitos % 2 != 0)
            {
                Console.WriteLine($"O valor {quantidadeDigitos} é inválido de acordo com as regras.");
                quantidadeDigitos = 0;
            }

            return quantidadeDigitos;
        }
    }
}