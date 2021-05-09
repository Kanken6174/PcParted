using logicPC.Parsers;
using System.Collections.Generic;
using System.Linq;

namespace logicPC.FiltersAndSearch
{
    /// <summary>
    /// Cette classe contient toutes les méthodes liées aux filtres du panneau de gauche sur la GUI
    /// </summary>
    public class Filters
    {
        /// <summary>
        /// Prend un nom de constructeur, utilise LINQ pour rendre un dictionnaire contenant seulement les entrées
        /// Correspondantes.
        /// </summary>
        /// <param name="Manufacturer">Le nom du construceur, case ignorée</param>
        /// <param name="deck">Le dictionnaire à traiter</param>
        /// <returns>Le dictionnaire traité</returns>
        public static Dictionary<string, Card> ConstructorFilter(string Manufacturer, Dictionary<string, Card> deck) =>
            deck.Where(card => card.Value.Manufacturer.Equals(ParseConstructeur.StringToInt(Manufacturer)))
                .ToDictionary(card => card.Key, card => card.Value);

        /// <summary>
        /// Prend un nom d'architecture, utilise LINQ pour rendre un dictionnaire contenant seulement les entrées
        /// Correspondantes (card graphique ayant telle architecture).
        /// </summary>
        /// <param name="Architecture">Le nom du construceur, case ignorée</param>
        /// <param name="deck">Le dictionnaire à traiter</param>
        /// <returns>Le dictionnaire traité</returns>
        public static Dictionary<string, Card> ArchitectureFilter(string Architecture, Dictionary<string, Card> deck) =>
            deck.Where(card => card.Value.Architecture.Equals(ParseConstructeur.StringToInt(Architecture)))
                .ToDictionary(card => card.Key, card => card.Value);

        /// <summary>
        /// Filtre pour la puissance en gigaFlops.
        /// </summary>
        /// <param name="min">puissance minimale</param>
        /// <param name="max">puissance maximale</param>
        /// <param name="deck">dictionnaire à traiter</param>
        /// <returns>dictionnaire traité</returns>
        public static Dictionary<string, Card> GflopsSlider(int min, int max, Dictionary<string, Card> deck) =>
            deck.Where(card => card.Value.RPI > min && card.Value.RPI < max)
                .ToDictionary(card => card.Key, card => card.Value);

        /// <summary>
        /// Filtre de prix
        /// </summary>
        /// <param name="min">prix maximal</param>
        /// <param name="max">prix minimal</param>
        /// <param name="deck">dictionnaire à traiter</param>
        /// <returns>dictionnaire traité</returns>
        public static Dictionary<string, Card> PriceSlider(int min, int max, Dictionary<string, Card> deck) =>
            deck.Where(card => card.Value.PriceMSRP > min && card.Value.RPI < max)
                .ToDictionary(card => card.Key, card => card.Value);
    }
}