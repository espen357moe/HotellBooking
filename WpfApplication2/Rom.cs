using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApplication2
{
    class Rom : Label
    {
        int romNummer;
        bool opptatt;
        string gjesteNavn;
        string innsjekkDato;
        string utsjekkDato;

        public Rom()
        {
            Content = "LEDIG";
        }

        public Rom(int romNummer, bool opptatt, string gjesteNavn, string innsjekkDato, string utsjekkDato)
        {
            romNummer = this.romNummer;
            opptatt = this.opptatt;
            gjesteNavn = this.gjesteNavn;
            innsjekkDato = this.innsjekkDato;
            utsjekkDato = this.utsjekkDato;
        }
    }
}
