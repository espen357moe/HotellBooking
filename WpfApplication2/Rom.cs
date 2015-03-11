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
        int         romNummer;
        bool        opptatt;
        string      gjesteNavn;
        string      innsjekkDato;
        string      utsjekkDato;
        Thickness   rammeTykkelse = new Thickness(2);        

        public Rom(double clientWidth, int romNummer)
        {
            opptatt         = false;
            BorderBrush     = Brushes.White;
            BorderThickness = rammeTykkelse;
            MinWidth        = (clientWidth/7);
            MinHeight       = 150;
            Content         = romNummer + " \nLEDIG";
            Background      = Brushes.DarkGreen;
        }

        public Rom(double clientWidth, int romNummer, bool opptatt, string gjesteNavn, string innsjekkDato, string utsjekkDato)
        {
            Width           = (clientWidth / 7);
            romNummer       = this.romNummer;
            opptatt         = this.opptatt;
            gjesteNavn      = this.gjesteNavn;
            innsjekkDato    = this.innsjekkDato;
            utsjekkDato     = this.utsjekkDato;
        }
    }
}
