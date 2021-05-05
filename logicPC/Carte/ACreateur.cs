using System.Collections.Generic;

namespace logicPC
{
    public abstract class ACreateur
    {
        public abstract Dictionary<int, ICarte> CreerCarte(Dictionary<int, string[]> dico);

    }
}
