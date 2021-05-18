using System.Collections.Generic;

namespace logicPC
{
    public abstract class CreateurTemplate
    {
        public abstract Dictionary<int, Card> MakeCard(Dictionary<int, List<string>> dico);
    }
}