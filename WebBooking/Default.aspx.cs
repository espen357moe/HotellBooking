using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HotellBooking;

namespace WebBooking
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public DateTime innsjekkDato;
        public DateTime utsjekkDato;
        public string gjesteNavn;
        public Hotell hotell;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GodkjennKnapp_Click(object sender, EventArgs e)
        {
            gjesteNavn = NavnInputTextBox.Text;
            innsjekkDato = InnsjekkDatoCalendar.SelectedDate;
            utsjekkDato = UtsjekkDatoCalendar.SelectedDate;
            XmlHåndterer xh = new XmlHåndterer();
            hotell = XmlHåndterer.LesHotell();
            var gjest = XmlHåndterer.LeggTilNyGjest(hotell, gjesteNavn, innsjekkDato, utsjekkDato);           

            Response.Redirect(Request.RawUrl);
        }

        protected void InnsjekkDatoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            innsjekkDato = InnsjekkDatoCalendar.SelectedDate;
        }

        protected void UtsjekkDatoCalendar_SelectionChanged(object sender, EventArgs e)
        {
            utsjekkDato = UtsjekkDatoCalendar.SelectedDate;
        }

        protected void InnsjekkDatoCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now)
            {
                e.Day.IsSelectable = false;
                e.Cell.Enabled = false;
            }
        }

        protected void UtsjekkDatoCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now)
            {
                e.Day.IsSelectable = false;
                e.Cell.Enabled = false;
            }
        }
    }
}