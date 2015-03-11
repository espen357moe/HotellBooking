using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace HotellBooking
{
    class EtasjeGenerator
    {
        public void genererEtasjer(int antallEtasjer, int antallRomPerEtasje, TabControl romOversikt)
        {
            int romNr = 0;
            for (int etasjeNr = 1; etasjeNr <= antallEtasjer; etasjeNr++)
            {
                TabItem etasje = new TabItem();
                romOversikt.Items.Add(etasje);
                etasje.Header = etasjeNr.ToString();
            }

            foreach (TabItem tab in romOversikt.Items)
            {

                WrapPanel etasjePanel = new WrapPanel();
                tab.Content = etasjePanel;

                for (int i = 0; i < antallRomPerEtasje; i++)
                {
                    Rom rom = new Rom(romNr + 1);
                    etasjePanel.Children.Add(rom);
                    etasjePanel.VerticalAlignment = VerticalAlignment.Center;
                    romNr++;
                }
            }
        }       
    }
}
