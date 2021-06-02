using logicPC.Interfaces;
using logicPC.Templates;
using System.Runtime.Serialization;

namespace logicPC.CardData
{
    /// <summary>
    /// classe d'une card standard qui implémente l'interface ICard
    /// </summary>
    [DataContract]
    public class Card : DataEntry, ICard
    {
        [DataMember]
        public Info Informations { get; set; }
        [DataMember]
        public Specs Specifications { get; set; }
        
        public Theorics Theorics { get; set; }

        public Card(Info informations, Specs specifications)
        {
            Informations = informations;
            Specifications = specifications;
            Theorics = new(specifications, informations);

            Theorics.ProcessFactors(informations);
        }

        public override string ToString()
        {
            return $"{Informations} {Specifications} {Theorics}";
        }
    }
}