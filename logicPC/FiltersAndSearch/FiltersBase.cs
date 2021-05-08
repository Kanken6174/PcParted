namespace logicPC.FiltersAndSearch
{
    public class FiltersBase
    {

        public Dictionary<string, Carte> GflopsSlider(int min, int max, Dictionary<string, Carte> deck) =>
            deck.Where(carte => carte.Value.IndicateurPuissance > min && carte.Value.IndicateurPuissance < max)
                .ToDictionary(carte => carte.Key, carte => carte.Value);
    }
}