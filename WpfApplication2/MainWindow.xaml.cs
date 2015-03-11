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

namespace HotellBooking
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

            EtasjeGenerator eg = new EtasjeGenerator();
            eg.genererEtasjer(antallEtasjer, romOversikt);
        }

        private void registrerGjestOk_Click(object sender, RoutedEventArgs e)
        {
            gjesteListeListBox.Items.Add(nyGjestTextBox.Text);
        }
    }
}
