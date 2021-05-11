using System.Collections.Generic;

namespace logicPC
{
    public abstract class ACreateur
    {
        public abstract Dictionary<int, Card> MakeCard(Dictionary<int, List<string>> dico);
    }
}