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
using System.Drawing;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            int antallEtasjer = 3;
            InitializeComponent();
            genererEtasjer(antallEtasjer);
            genererRom();
        }

        private void registrerGjestOk_Click(object sender, RoutedEventArgs e)
        {
            gjesteListeListBox.Items.Add(nyGjestTextBox.Text);
        }

        //genererer etasjer
        private void genererEtasjer(int antallEtasjer)
        {
            System.Console.Write("Genererte etasjer: ");
            for (int i = 0; i < antallEtasjer; i++)
            {
                string tittel = ((romOversikt.Items.Count + 1).ToString() + ". etg");
                TabItem etasje = new TabItem();
                etasje.Header=tittel;
                romOversikt.Items.Add(etasje);
                System.Console.Write((i+1) + " ");
            }
            System.Console.WriteLine();
        }

        //genererer rom i hver etasje
        private void genererRom()
        {
            int antallTabs = romOversikt.Items.Count;
            foreach (var tab in romOversikt.Items)
            {
                Rectangle room = new Rectangle(); 
                
            }
            
        }
    }
}
