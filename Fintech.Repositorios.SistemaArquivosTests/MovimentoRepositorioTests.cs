using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Dominio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        MovimentoRepositorio movimentoRepositorio = new("Dados\\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            //Inserir();
            //MovimentoRepositorio.Inserir();

            Agencia agencia = new() { Numero = 1 };
            var conta = new ContaCorrente(agencia, 1, "X");
            var movimento = new Movimento(Operacao.Saque, 50, conta);

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

        [TestMethod]
        public void DelegatePredicateTeste()
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1);

            var depositos = movimentos.FindAll(EncontrarMovimentoDeposito);

            Predicate<Movimento> obterDepositos = m => m.Operacao == Operacao.Deposito;
            depositos = movimentos.FindAll(obterDepositos);

            depositos = movimentos.FindAll(mov => mov.Operacao == Operacao.Deposito);

            depositos.ForEach(d => Console.WriteLine(d.Data));
        }

        private bool EncontrarMovimentoDeposito(Movimento m)
        {
            return m.Operacao == Operacao.Deposito;
        }

        [TestMethod]
        public void DelegateFuncTeste()
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1);

            var totalDepositos = movimentos
                .Where(m => m.Operacao == Operacao.Deposito)
                .Sum(RetornarCampoSoma);

            Func<Movimento, decimal> obterCampoValor = m => m.Valor;

            totalDepositos = movimentos
                            .Where(m => m.Operacao == Operacao.Deposito)
                            .Sum(obterCampoValor);

            totalDepositos = movimentos
                .Where(m => m.Operacao == Operacao.Deposito)
                .Sum(m => m.Valor);

            Console.WriteLine(totalDepositos);
        }

        private decimal RetornarCampoSoma(Movimento movimento)
        {
            return movimento.Valor;
        }

        [TestMethod]
        public void OrderByTeste()
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1)
                .OrderBy(m => m.Data.Date)
                .ThenBy(m => m.Operacao)
                .ThenByDescending(m => m.Valor)
                .ToList();

            var primeiro = movimentos.First();
            var ultimo = movimentos.Last();

            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor}"));
        }

        [TestMethod]
        public void LikeTeste()
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1)
                .Where(m => m.Data.ToString().Contains("22/06/2023"))
                .ToList();

            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor}"));
        }

        [TestMethod]
        [DataRow(1, 5)]
        [DataRow(2, 5)]
        public void SkipTakeTeste(int numeroPagina, int registrosPorPagina)
        {
            var movimentos = movimentoRepositorio.Selecionar(1, 1)
                .Skip((numeroPagina - 1) * registrosPorPagina)
                .Take(registrosPorPagina)
                .ToList();

            movimentos.ForEach(m => Console.WriteLine($"{m.Data} - {m.Operacao} - {m.Valor}"));
        }

        [TestMethod]
        public void GroupByTeste()
        {
            /*
             SELECT Operacao, Sum(Valor) as Total
            from Movimento
            group by Operacao
           */

            var agrupamento = movimentoRepositorio.Selecionar(1, 1)
                .GroupBy(m => m.Operacao)
                .Select(g => new { Operacao = g.Key, Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao}: {item.Total}");
            }
        }
    }
}