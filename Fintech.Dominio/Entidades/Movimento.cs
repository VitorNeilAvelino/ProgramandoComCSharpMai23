namespace Fintech.Dominio.Entidades
{
    public class Movimento
    {
        /// <summary>
        /// Construtor sem parâmetros - requisito do Dapper - não apagar.
        /// </summary>
        public Movimento()
        {
                
        }

        // ToDo - OO: Polimorfismo por sobrecarga.
        public Movimento(Operacao operacao, decimal valor, Conta conta)
        {
            Operacao = operacao;
            Valor = valor;
            Conta = conta;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public DateTime Data { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}