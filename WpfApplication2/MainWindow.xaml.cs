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
using HotellBooking;
using Brushes = System.Windows.Media.Brushes;

namespace HotellBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string GjesteNavn;
        public DateTime? InnsjekkDato;
        public DateTime? UtsjekkDato;
        private readonly Hotell hotell;
        
        public MainWindow()
        {
            int antallEtasjer = 3;
            int antallRomPerEtasje = 14;
                     
            InitializeComponent();
           
            hotell = XmlHåndterer.LesHotell();
            EtasjeGenerator eg = new EtasjeGenerator(hotell);
            eg.genererEtasjer(hotell, romOversikt);
            
            //Henter gjester fra de leste XML-dataene og skriver disse til listeboksen
            foreach (var gjest in hotell.Gjester)
            {
                eg.SetRomData(gjest);
                gjesteListeListBox.Items.Add(gjest);                            
            }
        }
        
        //Registrerer ny gjest når brukeren trykker på registrer-knappen
        private void registrerGjestOk_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(nyGjestTextBox.Text.ToString()))
            {
                ValideringsVarsel.Content = "Navnefeltet kan ikke være tomt";               
            }
            
            else 
            {
                ValideringsVarsel.Content = ""; 
                 GjesteNavn = nyGjestTextBox.Text;
                 var gjest=XmlHåndterer.LeggTilNyGjest(hotell, GjesteNavn, InnsjekkDato, UtsjekkDato);
                 gjesteListeListBox.Items.Add(gjest);
            }
        }

        private void InnsjekkDatoDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            InnsjekkDato = InnsjekkDatoDatePicker.SelectedDate;
        }

        private void UtsjekkDatoDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UtsjekkDato = UtsjekkDatoDatePicker.SelectedDate;
        }

        //Drag & drop-funksjonalitet
        private bool isDragging;
       
        private void gjesteListeListBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging && gjesteListeListBox.SelectedItem != null && e.LeftButton == MouseButtonState.Pressed)
            {
                isDragging = true;
                DragDrop.DoDragDrop(gjesteListeListBox, gjesteListeListBox.SelectedItem, DragDropEffects.All);                
            }
        }

        private void gjesteListeListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }             

        //Gjør så det ikke går an å velge datoer tilbake i tid    
        private void InnsjekkDatoDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            Calendar calendar = sender as Calendar;
            calendar.BlackoutDates.AddDatesInPast();
        }
        
        private void UtsjekkDatoDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            Calendar calendar = sender as Calendar;
            calendar.BlackoutDates.AddDatesInPast();
        }

        
       
    }
}
