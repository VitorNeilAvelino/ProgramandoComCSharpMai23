using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio movimentoRepositorio = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True");

        [TestMethod()]
        public void InserirTest()
        {
            //stub
            //mock

            var conta = new ContaCorrente(new Agencia { Numero = 1 }, 456, "X");
            var movimento = new Movimento(Operacao.Deposito, 100, conta);

            movimentoRepositorio.Inserir(movimento);
        }

        [TestMethod()]
        public void SelecionarAsyncTest()
        {
            var movimentos = movimentoRepositorio.SelecionarAsync(0, 456).Result;

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data} - {movimento.Operacao} - {movimento.Valor}");
            }
        }
    }
}