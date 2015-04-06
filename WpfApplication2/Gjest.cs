using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotellBooking
{
    public class Gjest
    {
        public string Navn { get; set; }
        public int? Etasje { get; set; }
        public int? RomNummer { get; set; }
        public DateTime? Innsjekk { get; set; }
        public DateTime? Utsjekk { get; set; }

        public override string ToString()
        {
            if (RomNummer == null)
            {
                return ("*" + Navn);
            }
            else return Navn;                       
        }
    }
}
