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
        /// <param name="contructeur">Le nom du construceur, case ignorée</param>
        /// <param name="deck">Le dictionnaire à traiter</param>
        /// <returns>Le dictionnaire traité</returns>
        public Dictionary<string, Carte> ConstructorFilter(string contructeur, Dictionary<string, Carte> deck) =>
            deck.Where(carte => carte.Value.Constructeur.Equals(ParseConstructeur.StringToInt(contructeur)))
                .ToDictionary(carte => carte.Key, carte => carte.Value);

        /// <summary>
        /// Prend un nom d'architecture, utilise LINQ pour rendre un dictionnaire contenant seulement les entrées
        /// Correspondantes (carte graphique ayant telle architecture).
        /// </summary>
        /// <param name="contructeur">Le nom du construceur, case ignorée</param>
        /// <param name="deck">Le dictionnaire à traiter</param>
        /// <returns>Le dictionnaire traité</returns>
        public Dictionary<string, Carte> ArchitectureFilter(string contructeur, Dictionary<string, Carte> deck) =>
            deck.Where(carte => carte.Value.Constructeur.Equals(ParseConstructeur.StringToInt(contructeur)))
                .ToDictionary(carte => carte.Key, carte => carte.Value);

        public Dictionary<string, Carte> GflopsSlider(int min, int max, Dictionary<string, Carte> deck) =>
            deck.Where(carte => carte.Value.IndicateurPuissance > min && carte.Value.IndicateurPuissance < max)
                .ToDictionary(carte => carte.Key, carte => carte.Value);
    }
}