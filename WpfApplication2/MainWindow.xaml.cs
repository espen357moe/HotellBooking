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
using System.Security.Policy;
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

        //genererer etasjer (i.e. tabs i tab-control'en)
        private void genererEtasjer(int antallEtasjer)
        {
            int etasjeNr;
            etasjeNr = 0;
           
            for(int i = 0; i < antallEtasjer; i++)
            {               
                TabItem etasje = new TabItem();
                etasje.Header = ((etasjeNr + 1) + " etg.");
                romOversikt.Items.Add(etasje);
            }
        }

        //genererer rom i hver etasje
        private void genererRom()
        {
            int etasjeNr = 0;
            int romNr = 0;
            
            foreach(TabItem tab in romOversikt.Items)
            {                
                etasjeNr++;

                WrapPanel etasjePanel = new WrapPanel();                
                tab.Content = etasjePanel;
                

                for (int i = 0; i < 14; i++)
                {                    
                    Rom rom = new Rom(800, romNr);  
                    System.Console.Write((romNr+1) + " ");
                    romNr++;
                    etasjePanel.Children.Add(rom);
                }
                System.Console.WriteLine();               
            }           
        }
    }
}
