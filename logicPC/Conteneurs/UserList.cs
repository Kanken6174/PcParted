using System.Collections.Generic;

namespace logicPC.Conteneurs
{
    /// <summary>
    /// Class d'une UserList. Cette classe contient 
    /// </summary>
    public class UserList
    {
        public Dictionary<string, Card> Cards { get; private set; } // Même système que pour 
        public Dictionary<string, int> QuantityCards { get; private set; }
        public float PrixTotal { get; private set; }
        public float HashrateTotale { get; private set; }
        public float IndicateurPuissance { get; private set; }
        public Card CardActive { get; private set; }
        public int IntID { get; private set; }

        public UserList()
        {
            Cards = new();
            QuantityCards = new();
        }
        public void ProcessTot()
        {
            HashrateTotale = 0;
            PrixTotal = 0;
            IndicateurPuissance = 0;
        }
    }
}