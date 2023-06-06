namespace CSharp.Capitulo08.Colecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var inteiros = new int[5];
            inteiros[0] = 21;
            inteiros[1] = -63;
            //inteiros[5] = 11;

            var decimais = new decimal[] { 0.4m, 0.9m, 4, 7.8m };
            decimais[2] = 4.5m;

            string[] nomes = {"Vítor", "Avelino"};

            var caracteres = new[] {'a', 'b', 'c'};

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"O tamanho do vetor {nameof(decimais)} é {decimais.Length}.");
        }
    }
}