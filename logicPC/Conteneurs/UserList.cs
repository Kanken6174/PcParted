using System.Collections.Generic;

namespace logicPC.Conteneurs
{
    public class UserList
    {
        public Dictionary<int, Carte> LesCartes { get; private set; }
        public Dictionary<int, int> QuantiteCartes { get; private set; }
        public float PrixTotal { get; private set; }
        public float HashrateTotale { get; private set; }
        public float IndicateurPuissance { get; private set; }
        public Carte CarteActive { get; private set; }
        public int IntID { get; private set; }
    }
}