using Fintech.Dominio.Entidades;
using Fintech.Dominio.Interfaces;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private const string DiretorioBase = "Dados";

        public string Caminho { get; private set; }

        public MovimentoRepositorio(string caminho)
        {
            Caminho = caminho;
        }

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

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            //Thread.Sleep(5000);

            var movimentos = new List<Movimento>();

            foreach (var linha in File.ReadAllLines(Caminho))
            {
                if (linha == "") continue;

                var propriedades = linha.Split("|");

                var guid = new Guid(propriedades[0]);
                var propriedadeNumeroAgencia = Convert.ToInt32(propriedades[1]);
                var propriedadeNumeroConta = Convert.ToInt32(propriedades[2]);
                var data = Convert.ToDateTime(propriedades[3]);
                var operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                var valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == propriedadeNumeroAgencia &&
                    numeroConta == propriedadeNumeroConta)
                {
                    var movimento = new Movimento(operacao, valor, null);
                    movimento.Data = data;
                    movimento.Guid = guid;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }

        public async Task<List<Movimento>> SelecionarAsync(int numeroAgencia, int numeroConta)
        {
            //Thread.Sleep(5000);
            //await Task.Delay(5000);

            var movimentos = new List<Movimento>();

            foreach (var linha in await File.ReadAllLinesAsync(Caminho))
            {
                if (linha == "") continue;

                var propriedades = linha.Split("|");

                var guid = new Guid(propriedades[0]);
                var propriedadeNumeroAgencia = Convert.ToInt32(propriedades[1]);
                var propriedadeNumeroConta = Convert.ToInt32(propriedades[2]);
                var data = Convert.ToDateTime(propriedades[3]);
                var operacao = (Operacao)Convert.ToInt32(propriedades[4]);
                var valor = Convert.ToDecimal(propriedades[5]);

                if (numeroAgencia == propriedadeNumeroAgencia &&
                    numeroConta == propriedadeNumeroConta)
                {
                    var movimento = new Movimento(operacao, valor, null);
                    movimento.Data = data;
                    movimento.Guid = guid;

                    movimentos.Add(movimento);
                }
            }

            return movimentos;
        }
    }
}