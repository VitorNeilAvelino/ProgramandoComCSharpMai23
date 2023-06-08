namespace Fintech.Dominio.Entidades
{
    public class Agencia
    {
        public Banco Banco { get; set; }
        public int Numero { get; set; }
        public int DigitoVerificador { get; set; }
    }
}