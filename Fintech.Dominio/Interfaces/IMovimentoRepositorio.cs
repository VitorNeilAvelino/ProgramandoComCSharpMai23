using Fintech.Dominio.Entidades;

namespace Fintech.Dominio.Interfaces
{
    public interface IMovimentoRepositorio
    {
        void Inserir(Movimento movimento);
        Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta);
    }
}