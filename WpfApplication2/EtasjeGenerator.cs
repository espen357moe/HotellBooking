using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Linq.Expressions;
using System.Windows.Forms;
using Control = System.Windows.Controls.Control;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using TabControl = System.Windows.Controls.TabControl;

namespace HotellBooking
{
    class EtasjeGenerator
    {
        private readonly Hotell _hotell;
        private readonly List<Rom> _rom; 

        public EtasjeGenerator(Hotell hotell)
        {
            _rom = new List<Rom>();
            _hotell = hotell;
        }
        
        //lager først etasjene som tabs i TabControl'en
        public void genererEtasjer(Hotell hotell, TabControl romOversikt)
        {
            int romNr = 0;
            foreach (var etasje in hotell.Rom.GroupBy(rom => rom.Etasje))
            {
                TabItem nyEtasje = new TabItem();
                romOversikt.Items.Add(nyEtasje);
                nyEtasje.Header = etasje.Key.ToString();
                nyEtasje.DataContext = etasje;

                WrapPanel etasjePanel = new WrapPanel();

                nyEtasje.Content = etasjePanel;

                //hver etasjes wrappanel populeres med rom
                foreach (var rom in etasje)
                {
                    var nyRom = new Rom(rom.Nummer);
                    nyRom.DataContext = rom;
                    nyRom.Drop += NyRomOnDrop;

                    etasjePanel.Children.Add(nyRom);
                    etasjePanel.VerticalAlignment = VerticalAlignment.Center;
                    nyRom.AllowDrop = true;
                    //nyRom.DragOver+= NyRomOnDragOver;
                    nyRom.DragEnter += NyRomOnDragOver;

                    _rom.Add(nyRom);
                }
            }
        }

        //Finner hvilket rom som er tildelt en spesifikk gjest
        public Rom FinnRomForHotellGjest(Gjest gjest)
        {
            if (gjest.RomNummer == null || gjest.Etasje == null)
            {
                return null;
            }
            return _rom.SingleOrDefault(r => ((HotellRom)r.DataContext).Etasje == gjest.Etasje && ((HotellRom)r.DataContext).Nummer == gjest.RomNummer);
        }

        private void NyRomOnDragOver(object sender, DragEventArgs e)
        {
            e.Effects=DragDropEffects.Copy;
        }

        //Henter ut data for en gitt gjest som droppes på et rom
        private void NyRomOnDrop(object sender, DragEventArgs e)
        {
            var rom = (HotellRom)((Rom) sender).DataContext;
            var gjest = (Gjest) e.Data.GetData(typeof (Gjest));
            SettRomLedig(gjest);
            gjest.Etasje = rom.Etasje;
            gjest.RomNummer = rom.Nummer;
            XmlHåndterer.LagreHotell(_hotell);
            SetRomData(gjest);
        }

        public void SetRomData(Gjest gjest)
        {
            var rom = FinnRomForHotellGjest(gjest);
            if (rom != null)
            {
                rom.Content = string.Format("{0}\nOPPTATT\n{1}\nInn:{2}\nUt:{3}", gjest.RomNummer, gjest.Navn,
                    gjest.Innsjekk != null ? gjest.Innsjekk.Value.ToShortDateString() : "???",
                    gjest.Utsjekk != null ? gjest.Utsjekk.Value.ToShortDateString() : "???");
                rom.Background = Brushes.Red;
            }
        }

        public void SettRomLedig(Gjest gjest)
        {
            var rom = FinnRomForHotellGjest(gjest);
            if (rom != null)
            {
                rom.Content = string.Format("{0}\nLEDIG", gjest.RomNummer);
                rom.Background = Brushes.Green;
            }
        }
    }
}
