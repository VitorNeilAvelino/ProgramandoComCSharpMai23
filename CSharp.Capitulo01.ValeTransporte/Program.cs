namespace CSharp.Capitulo01.ValeTransporte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inicio:

            Console.Write("Nome: ");
            var nome = Console.ReadLine();

            Console.Write("Salário: ");
            var salario = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Transporte: ");
            var gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

            var descontoMaximo = salario * 6 / 100;

            //decimal descontoVT = 0;
            //var descontoVT = 0m;

            //if (gastoComTransporte > descontoMaximo)
            //{
            //    descontoVT = descontoMaximo;
            //}
            //else
            //{
            //    descontoVT = gastoComTransporte;
            //}

            var descontoVT = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

            //var resultado = "Nome: " + nome + " Salário: ";
            var resultado = $"\nNome: {nome}\n" +
                $"Salário: {salario:c}\n" +
                $"Desconto VT: {descontoVT:c}";

            Console.WriteLine(resultado);

            Console.WriteLine("\nPressione Enter para novo cálculo ou Esc para sair.");

            var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.Clear();

            goto Inicio;

            //string Nome = "nome";
            //int idade = 52;
            //bool alunoAprovado = false;
            //var bimestre1 = 2.5m;
            //string nomeCanção = "Release";
            //var sobrenome = "Avelino";
            //var dataNascimento = new DateTime(1970, 12, 25);
            //nome = false;

        }
    }
}