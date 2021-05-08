using System;
using System.Collections.Generic;
using System.Linq;

namespace logicPC.FiltersAndSearch
{
    public class Lookup
    {
        /// <summary>
        /// Méthode de recherche par nom de modèle
        /// </summary>
        /// <param name="terms">Recherche de l'utilisateur</param>
        /// <param name="deck">dictionnaire readonly de toutes les cartes graphiques, ou autre ditionnaire similaire</param>
        /// <returns>Un dictionnaire ne conetenant que les cartes contenant les termes de recherche dans leur nom</returns>
        public static Dictionary<string, Carte> SearchModel(string terms, Dictionary<string, Carte> deck)
        {
            Dictionary<string, Carte> validForTerms = new();

            //méthode LINQ

            validForTerms = deck.Where(carte => carte.Value.NomModele.Contains(terms, StringComparison.InvariantCultureIgnoreCase))
                                .ToDictionary(carte => carte.Key, carte => carte.Value);

            //Version non-LINQ
            /*foreach (KeyValuePair < string, Carte> card in deck)
            {
                if (card.Value.NomModele.Contains(terms, StringComparison.InvariantCultureIgnoreCase))
                {
                    validForTerms.Add(card.Key, card.Value);
                }
            }*/
            return validForTerms;
        }
    }
}