using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        //[TestMethod()]
        //public void GerarTest()
        //{
        //    //Senha.Gerar();

        //    var senha = new Senha();

        //    senha.Tamanho = 4;

        //    var valor = senha.Gerar();

        //    Assert.AreEqual(senha.Tamanho, valor.Length);

        //    Console.WriteLine(valor);
        //}

        [TestMethod]
        public void ConstrutorSemParametroDeveRetornarSenhaMinima()
        {
            var senha = new Senha();

            Assert.AreEqual(senha.Valor.Length, Senha.TamanhoMinimo);

            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(10)]
        public void ConstrutorParametrizadoDeveRetornarSenhaComTamanhoEspecifico(int tamanho)
        {
            var senha = new Senha(tamanho);

            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        public void ValorPadraoTeste()
        {
            var valorPadrao = new ValorPadrao();

            Assert.IsTrue(valorPadrao.Inteiro == 0);
            Assert.IsTrue(valorPadrao.Decimal == 0);
            Assert.IsTrue(valorPadrao.Nome == null);
            Assert.IsTrue(valorPadrao.Booleano == false);
            Assert.IsTrue(valorPadrao.Data == DateTime.MinValue);
            Assert.IsTrue(valorPadrao.Senha == null);
            Assert.IsTrue(valorPadrao.Nota == null);

            Console.WriteLine(DateTime.MinValue);
            Console.WriteLine(default(long));

            //valorPadrao.Inteiro = null;
            valorPadrao.Nota = null;

            Console.WriteLine(valorPadrao.Nome?.Length);
        }
    }
}