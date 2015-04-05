using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace HotellBooking
{
    [XmlRoot()]

    public class Hotell
    {
        [XmlArray("HotellRom", IsNullable = false)]
        [XmlArrayItem("Rom")]
        public List<HotellRom> Rom { get; set; }

        public List<Gjest> Gjester { get; set; }

    }


}
