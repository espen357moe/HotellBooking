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

        public EtasjeGenerator(Hotell hotell)
        {
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
                }
            }
        }

        private void NyRomOnDragOver(object sender, DragEventArgs e)
        {
            e.Effects=DragDropEffects.Copy;
        }

        private void NyRomOnDrop(object sender, DragEventArgs e)
        {
            var rom = (HotellRom)((Rom) sender).DataContext;
            var gjest = (Gjest) e.Data.GetData(typeof (Gjest));
            gjest.Etasje = rom.Etasje;
            gjest.RomNummer = rom.Nummer;
            XmlHåndterer.LagreHotell(_hotell);
        }
    }
}
