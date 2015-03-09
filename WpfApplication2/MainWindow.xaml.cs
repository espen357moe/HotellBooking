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
using System.Windows.Media.Animation;

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

        //genererer etasjer (tabs i tab-control'en)
        private void genererEtasjer(int antallEtasjer)
        {
            int etasjeNr;
            etasjeNr = 0;
           
            for(int i =0; i<antallEtasjer; i++)
            {
                
                TabItem etasje = new TabItem();
                etasje.Header = ((etasjeNr + 1) + "etg.");
                romOversikt.Items.Add(etasje);
            }

        }

        //genererer rom i hver etasje
        private void genererRom()
        {
            int etasjeNr = 0;
            int romNr = 0;

            foreach (var tab in romOversikt.Items)
            {                
                etasjeNr++;
                System.Console.Write("Genererer rom i etasje " + etasjeNr + ": ");

                for (int i = 0; i < 14; i++)
                {
                    
                    Rom rom = new Rom();  
                    System.Console.Write((romNr+1) + " ");
                    romNr++;
                }
                System.Console.WriteLine();               
            }           
        }
    }
}
