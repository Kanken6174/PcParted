using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logicPC.Templates;
using System.Drawing;
using logicPC.CardData;

namespace logicPC.Plotters
{
    public static class HashPlotter
    {
        public static List<PointF> plot(Dictionary<string, Card> dico, Dictionary<string, int> quantities, float end, float increment, float depreciationFactor)
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

            while(incremented < increment)
            {
                hashpoint *= depreciationFactor;
                X.Add(hashpoint);
            }

            List<PointF> ret = GeneratePoints(X, 0, increment);
            return ret;
        }

        public static List<PointF> GeneratePoints(List<float> X, float YStart, float Yincrement)
        {
            List<PointF> toReturn = new();
            float CurrentY = YStart;
            foreach (float x in X)
            {
                PointF newPoint = new(x, CurrentY);
                CurrentY += Yincrement;
            }
            return toReturn;
        }
    }
}
