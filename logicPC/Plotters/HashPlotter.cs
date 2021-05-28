using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logicPC.Templates;
using System.Drawing;
using logicPC.CardData;
using Swordfish.NET.Collections;
using logicPC.Settings;

namespace logicPC.Plotters
{
    public static class HashPlotter
    {
        public static List<PointF> plot(ConcurrentObservableDictionary<string, Card> dico, ConcurrentObservableDictionary<string, int> quantities, float end, float increment, float depreciationFactor)
        {
            List<float> X = new();
            float hashpoint = 0;
            float incremented = 0;

            foreach (KeyValuePair<string, Card> card in dico)
            {
               hashpoint += (float)card.Value.Theorics.Hashrate * quantities[card.Key];
                incremented += increment;
            }
            X.Add(hashpoint);

            while(incremented < end)
            {
                hashpoint *= depreciationFactor;
                X.Add(hashpoint);
                incremented += increment;
            }

            List<PointF> ret = GeneratePoints(X, 0, increment);
            return ret;
        }

        public static List<PointF> plotPowerCost(ConcurrentObservableDictionary<string, Card> dico, ConcurrentObservableDictionary<string, int> quantities, float end, float increment, float depreciationFactor)
        {
            List<float> X = new();
            float powerDraw = 0;
            float incremented = 0;

            foreach (KeyValuePair<string, Card> card in dico)
            {
                powerDraw += (float)(card.Value.Theorics.EnergyConsumption/10) * quantities[card.Key];
                incremented += increment;
            }
            X.Add(powerDraw);

            while (incremented < end)
            {
                powerDraw /= depreciationFactor;
                X.Add(powerDraw);
                incremented += increment;
            }

            List<PointF> ret = GeneratePoints(X, 0, increment);
            return ret;
        }

        private static List<PointF> GeneratePoints(List<float> X, float YStart, float Yincrement)
        {
            List<PointF> toReturn = new();
            float CurrentY = YStart;
            foreach (float x in X)
            {
                PointF newPoint = new(x, CurrentY);
                CurrentY += Yincrement*SettingsLogic.GraphIncrement;
                toReturn.Add(newPoint);
            }
            return toReturn;
        }
    }
}
