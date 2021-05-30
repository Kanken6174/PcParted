using logicPC.CardData;
using System.Collections.Generic;

namespace logicPC.CardFactory
{
    internal abstract class CreateurTemplate
    {
        internal abstract Dictionary<int, Card> MakeCard(Dictionary<int, List<string>> dico);
    }
}