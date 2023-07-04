using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        MovimentoRepositorio movimentoRepositorio = new ("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            //Inserir();
            //MovimentoRepositorio.Inserir();
            
            Agencia agencia = new() { Numero = 1 };
            var conta = new ContaCorrente(agencia, 1, "X");
            var movimento = new Movimento(Operacao.Deposito, 200, conta);

            movimentoRepositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor}");
            }
        }

        [TestMethod]
        public void DelegateActionTeste()
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1);

            movimentos.ForEach(EscreverMovimento);
            
            Action<Movimento> writeLine = m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor}");

            movimentos.ForEach(writeLine);

            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor}"));
        }

        private void EscreverMovimento(Movimento movimento)
        {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor}");
        }
    }
}