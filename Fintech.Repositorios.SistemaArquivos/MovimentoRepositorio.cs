using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio
    {
        private const string DiretorioBase = "Dados";

        public void Inserir(Movimento movimento)
        {
            var registro = $"{movimento.Guid}|{movimento.Conta.Agencia.Numero}|{movimento.Conta.Numero}|" +
                $"{movimento.Data}|{(int)movimento.Operacao}|{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText(@$"{DiretorioBase}\Movimento.txt", registro + Environment.NewLine);
        }
    }
}