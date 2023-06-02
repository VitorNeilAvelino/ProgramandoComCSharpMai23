namespace CSharp.Capitulo02.GeradorSenha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Informe a quantidade de dígitos da senha (entre 4 e 10): ");
            var quantidadeDigitos = Convert.ToInt32(Console.ReadLine());

            if (quantidadeDigitos < 4 || quantidadeDigitos > 10 || quantidadeDigitos % 2 != 0 )
            {
                Console.WriteLine($"O valor {quantidadeDigitos} é inválido de acordo com as regras.");
                Console.ReadKey();
                return;
            }

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
    }
}