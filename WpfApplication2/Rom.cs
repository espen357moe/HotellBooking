using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace HotellBooking
{
    class Rom : Label
    {
        public int      romNummer { get; set; }
        public bool     opptatt { get; set; }
        public string   gjesteNavn { get; set; }
        public string   innsjekkDato { get; set; }
        public string   utsjekkDato { get; set; }
        
        Thickness       rammeTykkelse = new Thickness(2);        

        public Rom(int romNummer)
        {
            opptatt         = false;
            BorderBrush     = Brushes.White;
            BorderThickness = rammeTykkelse;
            MinWidth        = 100;
            MinHeight       = 100;
            Content         = romNummer + " \nLEDIG";
            Background      = Brushes.DarkGreen;
        }

        public Rom(int romNummer, string gjesteNavn, string innsjekkDato, string utsjekkDato, bool opptatt = true)
        {
            MinWidth        = 100;
            MinHeight       = 100;
            romNummer       = this.romNummer;
            opptatt         = this.opptatt;
            gjesteNavn      = this.gjesteNavn;
            innsjekkDato    = this.innsjekkDato;
            utsjekkDato     = this.utsjekkDato;
        }
    }
}
