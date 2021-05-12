using System;
using logicPC.CardData;
using logicPC.Templates;

namespace logicPC
{
    /// <summary>
    /// classe d'une card standard qui implémente l'interface ICard
    /// </summary>
    public class Card : DataEntry, ICard
    {
        public Info Informations;
        public Specs Specifications;
        public Theorics Theorics;

        public Card(Info informations, Specs specifications)
        {
            Informations = informations;
            Specifications = specifications;
            Theorics = new(specifications, informations);

            Theorics.processFactors(informations);
        }

        public override string ToString()
        {
            return $"{Informations.ToString()} {Specifications.ToString()} {Theorics.ToString()}";
        }
    }
}