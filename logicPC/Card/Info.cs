using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicPC.CardData
{
    public class Info : IInfo
    {
        public string Model { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        public string Architecture { get; private set; }
        public string Bus { get; private set; }
        public string Manufacturer;
        public Uri PictureURL { get; set; }

        public Info(string model, DateTime dateOfRelease, string architecture, string bus, string manufacturer="", Uri pictureURL=null)
        {
            Model = model;
            ReleaseDate = dateOfRelease;
            Architecture = architecture;
            Bus = bus;
            Manufacturer = manufacturer;
            PictureURL = pictureURL;
        }

        public override string ToString()
        {
            return $"{Model} {ReleaseDate} {Architecture} {Bus} {Manufacturer}";
        }

    }
}
