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

        public MainWindow()
        {
            leituraArquivo();
            InitializeComponent();
        }

        #region Controle
        private void leituraArquivo()
        {
            if(!File.Exists(arquivoLeitura)) //caso o arquivo não exista, ele será criado
            {
                StreamWriter criarArquivo = new StreamWriter(arquivoLeitura);
                criarArquivo.Close();
            }

            StreamReader arquivo = new StreamReader(arquivoLeitura);
            
            //fazer a leitura


            arquivo.Close();
        }
        #endregion
    }
}
