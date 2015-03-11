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
            int romOversiktBredde;

            InitializeComponent();

            genererEtasjer(antallEtasjer);
        }

        private void registrerGjestOk_Click(object sender, RoutedEventArgs e)
        {
            gjesteListeListBox.Items.Add(nyGjestTextBox.Text);
        }

        //genererer etasjer (i.e. tabs i tab-control'en) og 14 rom pr. etasje
        private void genererEtasjer(int antallEtasjer)
        {
            int romNr = 0;        
            for (int etasjeNr = 1; etasjeNr <= antallEtasjer; etasjeNr++)
            {
                TabItem etasje = new TabItem();                
                romOversikt.Items.Add(etasje);
                etasje.Header = etasjeNr.ToString();
            }

            foreach (TabItem tab in romOversikt.Items)
            {
                
                WrapPanel etasjePanel = new WrapPanel();
                tab.Content = etasjePanel;

                for (int i = 0; i < 16; i++)
                {
                    Rom rom = new Rom(700, romNr + 1);
                    etasjePanel.Children.Add(rom);
                    etasjePanel.VerticalAlignment = VerticalAlignment.Center;
                    romNr++;
                }
            }      
        }       
    }
}
