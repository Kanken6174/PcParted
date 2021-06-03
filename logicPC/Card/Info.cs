using logicPC.Interfaces;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace logicPC.CardData
{
    [DataContract]
    public class Info : IInfo
    {
        [DataMember]
        public string Model { get; private set; }
        [DataMember]
        public DateTime ReleaseDate { get; private set; }
        [DataMember]
        public string Architecture { get; private set; }
        [DataMember]
        public string Bus { get; private set; }
        [DataMember]
        public string Manufacturer { get; set; }
        [DataMember]
        public Uri PictureURL { get; set; }

        public Stream CarteMin { get; set; }


        public Info(string model, DateTime dateOfRelease, string architecture, string bus, string manufacturer = "", Uri pictureURL = null)
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