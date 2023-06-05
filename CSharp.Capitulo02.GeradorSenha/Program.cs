namespace CSharp.Capitulo02.GeradorSenha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var quantidadeDigitos = 0;

            //Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10): ");

            //while (quantidadeDigitos == 0)
            //{
            //    quantidadeDigitos = ObterQuantidadeDigitos();
            //}

            int quantidadeDigitos;

            do
            {
                Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10): ");
                quantidadeDigitos = ObterQuantidadeDigitos();
            } while (quantidadeDigitos == 0);

            var senha = "";// string.Empty;
            var randomico = new Random();

            for (int i = 1; i <= quantidadeDigitos; i++)
            {
                //var algarismo = randomico.Next(0, 10);
                //var algarismo = randomico.Next(1, 61);
                var algarismo = randomico.Next(10);

                //senha = senha + algarismo;
                senha += algarismo;
            }

            Console.WriteLine($"Senha: {senha}");
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