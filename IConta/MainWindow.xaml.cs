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
        static string arquivoConta = "contas.txt";
        List<Conta> Dados = new List<Conta>();
        bool[] mostraSaldos = { false, false, false };

        public MainWindow()
        {
            Ler_Dados_Arquivos();
            InitializeComponent();
            atualizaDadosJanela();

            //adiciona nomes
            labelNumContaCorrenteNome.Content += Dados[0].nome;
            labelNumContaPoupancaNome.Content += Dados[1].nome;
            labelNumContaInvestimentoNome.Content += Dados[2].nome;
        }

        #region Controle
        private void atualizaRendimentos()
        {
            for (int pos = 0; pos < Dados.Count; pos++)
                Dados[pos].calculaRendimento();
        }
        private void Ler_Dados_Arquivos()
        {
            if(!File.Exists(arquivoConta)) //caso o arquivo não exista, ele será criado
            {
                StreamWriter criarArquivo = new StreamWriter(arquivoConta);
                criarArquivo.Close();
            }

            StreamReader arquivo = new StreamReader(arquivoConta);
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
                if(data.Length == 1)
                {
                    Conta.contaMes = Convert.ToInt32(data[0]);
                }
            }

            arquivo.Close();
        }
        private void Gravar_Dados_Arquivos()
        {
            StreamWriter arquivo = new StreamWriter(arquivoConta);

            for (int pos = 0; pos < Dados.Count; pos++)
            {
                arquivo.WriteLine("{0};{1};{2};{3}", Dados[pos].nome, Dados[pos].NConta, Dados[pos].tipo, Dados[pos].Saldo);
            }

            arquivo.WriteLine(Conta.contaMes);
            arquivo.Close();
        }
        #endregion

        #region Botão Sair
        //gera evento "sair"
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Gravar_Dados_Arquivos();
            string programadores = "Integrantes: ";
            programadores += "\n\tGustavo Sena";
            programadores += "\n\tJoão Víctor Soares";
            programadores += "\n\tLorena Aguilar";
            programadores += "\n\tNathan Ribeiro";
            MessageBox.Show(programadores, "Programadores", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
        #endregion

        #region Corrente
        //gera evento "depositar" em conta corrente
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nConta = "1";
            try
            {
                chamaDepositar(Convert.ToDouble(textBoxCorrente.Text), 0);
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
                chamaSaque(Convert.ToDouble(textBoxCorrente.Text), 0);
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
            atualizaRendimentos();
            chamaExtrato(Dados[0]);
        }
        #endregion

        #region Poupança
        //gera evento "depositar" em conta poupança
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string nConta = "2";
            try
            {
                chamaDepositar(Convert.ToDouble(textBoxPoupanca.Text), 1);
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
                chamaSaque(Convert.ToDouble(textBoxPoupanca.Text), 1);
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
            atualizaRendimentos();
            chamaExtrato(Dados[1]);
        }
        #endregion

        #region Investimento
        //gera evento "depositar" em conta investimento
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            string nConta = "3";
            try
            {
                chamaDepositar(Convert.ToDouble(textBoxInvestimento.Text), 2);
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
                chamaSaque(Convert.ToDouble(textBoxInvestimento.Text), 2);
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
            atualizaRendimentos();
            chamaExtrato(Dados[2]);
        }
        #endregion

        #region Métodos complementares
        private void chamaSaque(double valor, int posicao)
        {
            if (valor > 0 && valor <= Dados[posicao].Saldo)
            {
                Dados[posicao].Saque(valor);
                MessageBox.Show("Saque feito com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível retirar esse valor.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            atualizaDadosJanela();
        }
        private void chamaDepositar(double valor, int posicao)
        {
            if (valor > 0)
            {
                Dados[posicao].Depositar(valor);
                MessageBox.Show("Deposito feito com sucesso.", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não é possível depositar esse valor.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            atualizaDadosJanela();
        }
        private void chamaExtrato(Conta conta)
        {
            GeradorExtrato extrato = new GeradorExtrato();
            MessageBox.Show(extrato.GeraExtrato(conta), "Extrato", MessageBoxButton.OK);
            Conta.contaMes++;
            atualizaDadosJanela();
        }
        private void atualizaDadosJanela()
        {
            labelContaMes.Content = Conta.contaMes;
            if (mostraSaldos[0])
                labelNumContaCorrenteSaldo.Content = "Saldo: R$ " + Dados[0].Saldo;
            else
                labelNumContaCorrenteSaldo.Content = "Saldo: R$ ****";

            if (mostraSaldos[1])
                labelNumContaPoupancaSaldo.Content = "Saldo: R$ " + Dados[1].Saldo;
            else
                labelNumContaPoupancaSaldo.Content = "Saldo: R$ ****";

            if (mostraSaldos[2])
                labelNumContaInvestimentoSaldo.Content = "Saldo: R$ " + Dados[2].Saldo;
            else
                labelNumContaInvestimentoSaldo.Content = "Saldo: R$ ****";
        }
        #endregion

        private void mostrarSaldoCorrente(object sender, RoutedEventArgs e)
        {
            mostraSaldos[0] = !mostraSaldos[0];
            atualizaDadosJanela();
        }
        private void mostrarSaldoPoupanca(object sender, RoutedEventArgs e)
        {
            mostraSaldos[1] = !mostraSaldos[1];
            atualizaDadosJanela();
        }
        private void mostrarSaldoInvestimento(object sender, RoutedEventArgs e)
        {
            mostraSaldos[2] = !mostraSaldos[2];
            atualizaDadosJanela();
        }
        
    }
}
