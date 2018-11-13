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
using System.IO;

namespace SistemaBanco
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        static int contadorMes = 1;
        static string arquivoLeitura = "contas.txt";
        List<Conta> Dados = new List<Conta>();

        public MainWindow()
        {
            Ler_Dados_Arquivos();
            InitializeComponent();
            atualizarDados();
        }

        #region Controle
        private void atualizaSaldo()
        {
            for (int pos = 0; pos < Dados.Count; pos++)
                Dados[pos].Saldo();
        }
        private void Ler_Dados_Arquivos()
        {
            if(!File.Exists(arquivoLeitura)) //caso o arquivo não exista, ele será criado
            {
                StreamWriter criarArquivo = new StreamWriter(arquivoLeitura);
                criarArquivo.Close();
            }

            StreamReader arquivo = new StreamReader(arquivoLeitura);
            int dadosPorLinha = 4;

            //fazer a leitura
            while(!arquivo.EndOfStream)
            {
                string[] data = arquivo.ReadLine().Split(';');
                if(data.Length == dadosPorLinha)
                {
                    Conta p;

                    if (data[2] == "10")
                        p = new ContaCorrente(data[0], data[1], Convert.ToDouble(data[3]));
                    else if (data[2] == "20")
                        p = new ContaPoupanca(data[0], data[1], Convert.ToDouble(data[3]));
                    else // if (data[2] == "30")
                        p = new ContaInvestimento(data[0], data[1], Convert.ToDouble(data[3]));

                    Dados.Add(p);
                }
            }

            arquivo.Close();
        }
        private void Gravar_Dados_Arquivos()
        {
            StreamWriter arquivo = new StreamWriter("teste.txt");

            for (int pos = 0; pos < Dados.Count; pos++)
            {
                arquivo.WriteLine(Dados[pos].Saldo() + " ");
            }

            arquivo.WriteLine("Numero de contas: " + Conta.contador);
            arquivo.Close();
        }
        #endregion

        #region Botão Sair
        //gera evento "sair"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gravar_Dados_Arquivos();
            MessageBox.Show("Integrantes: Gustavo Sena, João Vítor Soares, Lorena Aguilar, Nathan Ribeiro", "Programadores", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        #endregion

        #region Corrente
        //gera evento "depositar" em conta corrente
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nConta = "1";
            try
            {
                depositar(Convert.ToDouble(textBoxCorrente.Text), nConta);
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: O valor informado é inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxCorrente.Clear();
        }

        //gera evento "sacar" em conta corrente

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string nConta = "1";
            try
            {
                saque(Convert.ToDouble(textBoxCorrente.Text), nConta);
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: O valor informado é inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxCorrente.Clear();
        }

        //gera evento "extrato" em conta corrente
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            atualizaSaldo();
            contadorMes++;
            MessageBox.Show("Seu saldo é: " + Dados[0].saldo);
            atualizarDados();
        }
        #endregion

        #region Poupança
        //gera evento "depositar" em conta poupança
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string nConta = "2";
            try
            {
                depositar(Convert.ToDouble(textBoxPoupanca.Text), nConta);
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: O valor informado é inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxPoupanca.Clear();
        }

        //gera evento "sacar" em conta poupança
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            string nConta = "2";
            try
            {
                depositar(Convert.ToDouble(textBoxPoupanca.Text), nConta);
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: O valor informado é inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxPoupanca.Clear();
        }
        
        //gera evento "extrato" em conta poupança
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            atualizaSaldo();
            contadorMes++;
            MessageBox.Show("Seu saldo é: " + Dados[1].saldo);
            atualizarDados();
        }
        #endregion

        #region Investimento
        //gera evento "depositar" em conta investimento
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string nConta = "3";
            try
            {
                depositar(Convert.ToDouble(textBoxInvestimento.Text), nConta);
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: O valor informado é inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxInvestimento.Clear();
        }

        //gera evento "sacar" em conta investimento
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string nConta = "3";
            try
            {
                depositar(Convert.ToDouble(textBoxInvestimento.Text), nConta);
            }
            catch (FormatException)
            {
                MessageBox.Show("Erro: O valor informado é inválido.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            textBoxInvestimento.Clear();
        }

        //gera evento "extrato" em conta investimento
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            atualizaSaldo();
            contadorMes++;
            MessageBox.Show("Seu saldo é: " + Dados[1].saldo);
            atualizarDados();
        }
        #endregion

        #region Métodos complementares
        private void saque(double valor, string nConta)
        {
            int ondeRetirar = procuraNumeroConta(nConta);
            if (ondeRetirar == -1)
            {
                MessageBox.Show("Não foi possível encontrar a conta informada.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (valor > 0 && valor <= Dados[ondeRetirar].saldo)
            {
                Dados[ondeRetirar].Saque(valor);
                MessageBox.Show("Saque feito com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível retirar esse valor.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void depositar(double valor, string NConta)
        {
            int ondeDepositar = procuraNumeroConta(NConta);
            if (ondeDepositar == -1)
            {
                MessageBox.Show("Não foi possível encontrar a conta informada.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (valor > 0)
            {
                Dados[ondeDepositar].Depositar(valor);
                MessageBox.Show("Deposito feito com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível depositar esse valor.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private int procuraNumeroConta(string Nconta)
        {
            for (int pos = 0; pos < Dados.Count; pos++)
            {
                if (Dados[pos].NConta == Nconta)
                {
                    return pos;
                }
            }
            return -1;
        }
        private void atualizarDados()
        {
            labelContaMes.Content = contadorMes + " ";
            labelNumContaCorrente.Content = Dados[0].nome;
            labelNumContaPoupanca.Content = Dados[1].nome;
            labelNumContaInvestimento.Content = Dados[2].nome;
        }
        #endregion
    }
}
