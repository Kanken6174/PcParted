using logicPC.CardData;
using Swordfish.NET.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace logicPC.Conteneurs
{
    /// <summary>
    /// Class d'une UserList.
    /// </summary>
    [DataContract]
    public class UserList
    {
        [DataMember]
        public Dictionary<string, Card> Cards { get; private set; }
        [DataMember]
        public Dictionary<string, int> QuantityCards { get; private set; }
        private float PrixTotal;
        private double HashrateTotale;
        private double ConsommationTot;
        public string PrixTotalStr { get { return PrixTotal.ToString("#0.00"); } private set { } }
        public string HashrateTotaleStr { get { return HashrateTotale.ToString("#0.0000"); } private set { } }
        public string ConsommationTotStr { get { return ConsommationTot.ToString("#0"); } private set { } }
        public Card CardActive { get; private set; }
        public string IntID { get; private set; }

        public UserList()
        {
            Cards = new();
            QuantityCards = new();
        }

        private void UserList_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ProcessTot();
        }

        public void ProcessTot()
        {
            HashrateTotale = 0;
            PrixTotal = 0;
            ConsommationTot = 0;
            foreach (KeyValuePair<string, Card> card in Cards)
            {
                PrixTotal += card.Value.Theorics.Price * QuantityCards[card.Key];
                HashrateTotale += card.Value.Theorics.Hashrate * QuantityCards[card.Key];
                ConsommationTot += card.Value.Theorics.EnergyConsumption * QuantityCards[card.Key];
            }
        }
    }
}