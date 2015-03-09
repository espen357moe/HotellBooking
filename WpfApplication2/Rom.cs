using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication2
{
    class Rom : Label
    {
        int romNummer;
        bool opptatt;
        string gjesteNavn;
        string innsjekkDato;
        string utsjekkDato;

        public Rom(int clientWidth, int romNummer)
        {
            MinWidth = (clientWidth/7);
            Content = romNummer + " \nLEDIG";
            Background=Brushes.DarkGreen;
        }

        public Rom(int clientWidth, int romNummer, bool opptatt, string gjesteNavn, string innsjekkDato, string utsjekkDato)
        {
            Width = (clientWidth / 7);
            romNummer = this.romNummer;
            opptatt = this.opptatt;
            gjesteNavn = this.gjesteNavn;
            innsjekkDato = this.innsjekkDato;
            utsjekkDato = this.utsjekkDato;
        }
    }
}
