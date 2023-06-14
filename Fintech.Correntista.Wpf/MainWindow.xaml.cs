using Fintech.Dominio.Entidades;
using System;
using System.Collections.Generic;
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
            //sexoComboBox.Items.Add();
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

            clienteDataGrid.Items.Add(cliente);
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
    }
}
