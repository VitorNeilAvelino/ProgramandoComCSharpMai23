using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Dominio.Entidades
{
    public class ContaCorrente
    {
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }

        public void EfetuarOperacao(decimal valor, Operacao operacao)
        {

        }
    }
}
