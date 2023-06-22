using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            //Inserir();
            //MovimentoRepositorio.Inserir();
            var movimentoRepositorio = new MovimentoRepositorio();
            Agencia agencia = new() { Numero = 1 };
            var conta = new ContaCorrente(agencia, 1, "X");
            var movimento = new Movimento(Operacao.Deposito, 100, conta);

            movimentoRepositorio.Inserir(movimento);
        }
    }
}