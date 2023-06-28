using Fintech.Dominio.Entidades;
using Fintech.Repositorios.SistemaArquivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Fintech.Correntista.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Cliente> clientes = new();
        private Cliente clienteSelecionado;
        private readonly MovimentoRepositorio movimentoRepositorio = new(Properties.Settings.Default.CaminhoArquivoMovimento);

        public MainWindow() // Método construtor.
        {
            InitializeComponent();
            PopularControles();
        }

        private void PopularControles()
        {
            sexoComboBox.Items.Add(Sexo.Feminino);
            sexoComboBox.Items.Add(Sexo.Masculino);
            sexoComboBox.Items.Add(Sexo.Outro);

            clienteDataGrid.ItemsSource = clientes;

            tipoContaComboBox.Items.Add(TipoConta.ContaCorrente);
            tipoContaComboBox.Items.Add(TipoConta.ContaEspecial);
            tipoContaComboBox.Items.Add(TipoConta.Poupanca);

            var banco1 = new Banco();
            banco1.Numero = 123;
            banco1.Nome = "Banco Um";

            bancoComboBox.Items.Add(banco1);
            bancoComboBox.Items.Add(new Banco { Nome = "Banco Dois", Numero = 456 });

            operacaoComboBox.Items.Add(Operacao.Deposito);
            operacaoComboBox.Items.Add(Operacao.Saque);
        }

        private void incluirClienteButton_Click(object sender, RoutedEventArgs e)
        {
            //object meuObjeto = "Vítor";
            //meuObjeto = 42;
            //meuObjeto = false;

            //Cliente cliente = new Cliente();
            //Cliente cliente = new();

            var cliente = new Cliente();

            cliente.Cpf = cpfTextBox.Text;
            cliente.DataNascimento = Convert.ToDateTime(dataNascimentoTextBox.Text);
            cliente.Nome = nomeTextBox.Text;
            cliente.Sexo = (Sexo)sexoComboBox.SelectedItem;

            Endereco endereco = new();
            endereco.Logradouro = logradouroTextBox.Text;
            endereco.Cep = cepTextBox.Text;
            endereco.Numero = numeroLogradouroTextBox.Text;
            endereco.Cidade = cidadeTextBox.Text;

            cliente.EnderecoResidencial = endereco;

            //Gravar(cliente);

            //clienteDataGrid.Items.Add(cliente);

            clientes.Add(cliente);

            clienteDataGrid.Items.Refresh();
            MessageBox.Show("Cliente cadastrado com sucesso.");
            LimparControlesCliente();
            pesquisaClienteTabItem.Focus();
        }

        private void LimparControlesCliente()
        {
            cpfTextBox.Clear();
            nomeTextBox.Text = "";
            dataNascimentoTextBox.Text = null;
            sexoComboBox.SelectedIndex = -1;
            logradouroTextBox.Text = string.Empty;
            numeroLogradouroTextBox.Clear();
            cidadeTextBox.Clear();
            cepTextBox.Clear();
        }

        private void SelecionarClienteButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            clienteTextBox.Text = $"{clienteSelecionado.Nome} - {clienteSelecionado.Cpf}";
            contasTabItem.Focus();
        }

        private void SelecionarCliente(object sender)
        {
            var botaoClicado = (Button)sender;
            clienteSelecionado = (Cliente)botaoClicado.DataContext;
        }

        private void tipoContaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tipoContaComboBox.SelectedItem == null) return;
            //{
            //    return;
            //}

            var tipoConta = (TipoConta)tipoContaComboBox.SelectedItem;

            if (tipoConta == TipoConta.ContaEspecial)
            {
                limiteDockPanel.Visibility = Visibility.Visible;
                limiteTextBox.Focus();
            }
            else
            {
                limiteDockPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void incluirContaButton_Click(object sender, RoutedEventArgs e)
        {
            Conta conta = null;

            var agencia = new Agencia();
            agencia.Banco = (Banco)bancoComboBox.SelectedItem;
            agencia.Numero = Convert.ToInt32(numeroAgenciaTextBox.Text);
            agencia.DigitoVerificador = Convert.ToInt32(dvAgenciaTextBox.Text);

            var numero = Convert.ToInt32(numeroContaTextBox.Text);
            var digitoVerificador = dvContaTextBox.Text;

            switch ((TipoConta)tipoContaComboBox.SelectedItem)
            {
                case TipoConta.ContaCorrente:
                    conta = new ContaCorrente(agencia, numero, digitoVerificador);
                    //conta.Agencia = agencia;
                    break;
                case TipoConta.ContaEspecial:
                    var limite = Convert.ToDecimal(limiteTextBox.Text);
                    conta = new ContaEspecial(agencia, numero, digitoVerificador, limite);
                    //conta.Agencia = agencia;
                    //conta.Limite = limite;
                    break;
                case TipoConta.Poupanca:
                    conta = new Poupanca(agencia, numero, digitoVerificador);
                    break;
                    //default:
                    //    break;
            }

            clienteSelecionado.Contas!.Add(conta!);

            MessageBox.Show("Conta adicionada com sucesso.");
            LimparControlesConta();
            clienteDataGrid.Items.Refresh();
            clienteTabItem.Focus();
        }

        private void LimparControlesConta()
        {
            clienteTextBox.Clear();
            bancoComboBox.SelectedIndex = -1;
            numeroAgenciaTextBox.Clear();
            dvAgenciaTextBox.Clear();
            numeroContaTextBox.Clear();
            dvContaTextBox.Clear();
            tipoContaComboBox.SelectedIndex = -1;
            limiteTextBox.Clear();
        }

        private void SelecionarContaButtonClick(object sender, RoutedEventArgs e)
        {
            SelecionarCliente(sender);

            contaTextBox.Text = $"{clienteSelecionado.Nome} - {clienteSelecionado.Cpf}";

            contaComboBox.ItemsSource = clienteSelecionado.Contas;
            contaComboBox.Items.Refresh();

            LimparControlesOperacao();

            operacaoTabItem.Focus();
        }

        private void LimparControlesOperacao()
        {
            contaComboBox.SelectedIndex = -1;
            operacaoComboBox.SelectedIndex = -1;
            valorTextBox.Clear();
            movimentacaoDataGrid.ItemsSource = null;
            saldoTextBox.Clear();
        }

        private async void contaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contaComboBox.SelectedItem == null) return;

            mainSpinner.Visibility = Visibility.Visible;

            var conta = (Conta)contaComboBox.SelectedItem;

            await AtualizarGridMovimentacao(conta);

            mainSpinner.Visibility = Visibility.Hidden;
        }

        private async void incluirOperacaoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var conta = (Conta)contaComboBox.SelectedItem;
                var operacao = (Operacao)operacaoComboBox.SelectedItem;
                var valor = Convert.ToDecimal(valorTextBox.Text);

                var movimento = conta.EfetuarOperacao(valor, operacao);

                //Inserir();

                movimentoRepositorio.Inserir(movimento);

                await AtualizarGridMovimentacao(conta);
            }
            catch (FileNotFoundException excecao)
            {
                MessageBox.Show($"O arquivo {excecao.FileName} não foi encontrado.");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show($"O diretório {Properties.Settings.Default.CaminhoArquivoMovimento} não foi encontrado.");
            }
            catch (SaldoInsuficienteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception excecao)
            {
                MessageBox.Show("Eita! Algo deu errado e em breve teremos uma solução.");
                //Logar(excecao); // log4net
            }
            finally
            {
                // É chamado sempre, mesmo que haja algum return no código.
            }
        }

        private async Task AtualizarGridMovimentacao(Conta conta)
        {
            conta.Movimentos = await movimentoRepositorio.SelecionarAsync(conta.Agencia.Numero, conta.Numero);

            movimentacaoDataGrid.ItemsSource = conta.Movimentos;
            movimentacaoDataGrid.Items.Refresh();

            //conta.Saldo = 10000000000000000;

            saldoTextBox.Text = conta.Saldo.ToString("c");
        }
    }
}