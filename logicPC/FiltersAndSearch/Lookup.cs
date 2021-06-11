using logicPC.CardData;
using System;
using System.Collections.Generic;
using System.Linq;
using Swordfish.NET.Collections;

namespace logicPC.FiltersAndSearch
{
    public static class Lookup
    {
        /// <summary>
        /// Méthode de recherche par nom de modèle
        /// </summary>
        /// <param name="terms">Recherche de l'utilisateur</param>
        /// <param name="deck">dictionnaire readonly de toutes les cards graphiques, ou autre ditionnaire similaire</param>
        /// <returns>Un dictionnaire ne conetenant que les cards contenant les termes de recherche dans leur nom</returns>
        public static Dictionary<string, Card> SearchModel(this Dictionary<string, Card> deck, string terms)
        {
            Dictionary<string, Card> validForTerms = new();

            //méthode LINQ

            validForTerms = deck.Where(card => card.Value.Informations.Model.Contains(terms, StringComparison.InvariantCultureIgnoreCase))
                                .ToDictionary(card => card.Key, card => card.Value);

            //Version non-LINQ
            /*foreach (KeyValuePair < string, Card> card in deck)
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