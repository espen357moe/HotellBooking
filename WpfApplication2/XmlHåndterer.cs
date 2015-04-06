using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace HotellBooking
{
    public class XmlHåndterer
    {
        //Instansierer XmlSerializer for å lette XML-håndtering
        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(Hotell));                    

        //Setter filsti til XML-filen til C:\ProgramData\HotellBooking-mappen på lokal maskin
        public static readonly string XmlFilSti = System.IO.Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "HotellBooking") + "\\booking.xml";

        //Metode som oppretter nytt hotell
        private static Hotell OpprettHotell(int antallEtasjer, int antallRomPerEtasje)
        {
            var hotell = new Hotell()
            {
                Gjester = new List<Gjest>(), 
                Rom = new List<HotellRom>()
            };
            
            for (int i = 0; i < antallEtasjer; i++)
            {
                for (int j = 0; j < antallRomPerEtasje; j++)
                {
                    var rom = new HotellRom
                    {
                        Nummer = j + 1,
                        Etasje = i + 1
                    };
                    hotell.Rom.Add(rom);
                }
            }
            return hotell;
        }

        //Skriver gjeldende hotell til XML
        public static void LagreHotell(Hotell hotell)
        {
            string XmlMappeSti = (System.IO.Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "HotellBooking"));

            if (!Directory.Exists(XmlMappeSti))
            {
                System.IO.Directory.CreateDirectory(XmlMappeSti);
            }

            else
            {
                using (var xmlFil = File.Open(XmlFilSti, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(xmlFil, hotell);
                }
            }
        }

        //Leser gjeldende hotell fra XML
        public static Hotell LesHotell()
        {
            if (!File.Exists(XmlFilSti))
            {
                var hotell = OpprettHotell(3, 14);
                LagreHotell(hotell);
                return hotell;
            }
            
            using (var xmlFil = File.Open(XmlFilSti, FileMode.Open, FileAccess.Read))
            {
                return(Hotell)serializer.Deserialize(xmlFil);
            }
        }
      
        //Legger ny gjest til XML
        public static Gjest LeggTilNyGjest(Hotell hotell, string gjesteNavn, DateTime? innsjekkDato, DateTime? utsjekkDato)
        {
            var gjest = new Gjest();
            gjest.Navn = gjesteNavn;
            gjest.Innsjekk = innsjekkDato;
            gjest.Utsjekk = utsjekkDato;
            hotell.Gjester.Add(gjest);
            LagreHotell(hotell);
            return gjest;
        }       
    }
}