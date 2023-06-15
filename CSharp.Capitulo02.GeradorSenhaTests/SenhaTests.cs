using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Capitulo02.GeradorSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        [TestMethod()]
        public void GerarTest()
        {
            //Senha.Gerar();

            var senha = new Senha();
            
            senha.Tamanho = 4;

            var valor = senha.Gerar();

            Assert.AreEqual(senha.Tamanho, valor.Length);

            Console.WriteLine(valor);
        }

        [TestMethod]
        public void ConstrutorSemParametroDeveRetornarSenhaMinima()
        {
            var senha = new Senha();

            Assert.AreEqual(senha.Valor.Length, Senha.TamanhoMinimo);

            Console.WriteLine(senha.Valor);
        }
    }
}