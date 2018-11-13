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
        static string arquivoLeitura = "contas.txt";
        List<Conta> Dados = new List<Conta>();

        public MainWindow()
        {
            Ler_Dados_Arquivos();
            InitializeComponent();
            Gravar_Dados_Arquivos();
        }

        #region Controle
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
        
        //gera evento "sair"
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "depositar" em conta corrente
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "sacar" em conta corrente
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "extrato" em conta corrente
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "depositar" em conta poupança
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "sacar" em conta poupança
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
        
        //gera evento "extrato" em conta poupança
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "depositar" em conta investimento
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "sacar" em conta investimento
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {

        }

        //gera evento "extrato" em conta investimento
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {

        }
    }
}
