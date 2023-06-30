namespace Fintech.Dominio.Entidades
{
    // ToDo - OO: Classe ou abstração.
    public abstract class Conta
    {
        public Agencia Agencia { get; set; }
        public Cliente Cliente { get; set; }
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        
        // ToDo - OO: Encapsulamento.
        public decimal Saldo
        {
            get { return TotalDeposito - TotalSaque; }
            private set { }
        }

        public decimal TotalDeposito
        {
            get
            {
                return Movimentos
                    .Where(m => m.Operacao == Operacao.Deposito)
                    .Sum(m => m.Valor);
            }
            //set; 
        }

        public decimal TotalSaque => Movimentos
                    .Where(m => m.Operacao == Operacao.Saque)
                    .Sum(m => m.Valor);

        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();

        public virtual Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + limite >= valor)
                    {
                        Saldo -= valor;
                    }
                    else
                    {
                        throw new SaldoInsuficienteException("Saldo insuficiente.");
                    }
                    break;
            }

            Movimento movimento = new(operacao, valor, this);
            Movimentos.Add(movimento);

            return movimento;
        }
    }
}
