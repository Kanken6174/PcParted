using System.Collections.Generic;
using logicPC.CardData;

namespace logicPC.CardFactory
{
    public abstract class CreateurTemplate
    {
        public abstract Dictionary<int, Card> MakeCard(Dictionary<int, List<string>> dico);
    }
}