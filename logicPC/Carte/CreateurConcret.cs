using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace logicPC
{

    public class CreateurConcret : ACreateur
    {
        /*       public override ICarte CreerCarte(string []input, int lineNum)
               {
                   string nomModele = "", architecture = "";
                   DateTime dateSortie = default;
                   int bus = -1, constructeur = -1, tailleMemoire = -1, frequenceGpu = -1, frequenceMemoire = -1, shaderUnits = -1, tmuUnits = -1, ropUnits = -1, wattage = -1;
                   float prix = -1, hashrate = -1, indicateurPuissance = -1;
                   bool wattageEstExtrapole = false, prixEstExtrapole = false;
                   Uri urlVersImage = default;
                   int line = -1;


                   Carte uneNouvelleCarte = new Carte(nomModele, dateSortie, architecture, bus, constructeur, tailleMemoire, frequenceGpu, frequenceMemoire, shaderUnits, tmuUnits, ropUnits, wattage, prix, hashrate, indicateurPuissance, wattageEstExtrapole, prixEstExtrapole, urlVersImage, line);
                   return uneNouvelleCarte;
               }*/

        /// <summary>
        /// Factory responsable de la création de cartes à partir d'un dictionnaire de string. 
        /// </summary>
        /// <param name="dico"></param>
        /// <returns></returns>
        public override Dictionary<int, ICarte> CreerCarte(Dictionary<int, string[]> dico)
        {
            Dictionary<int, ICarte> MainSet = new Dictionary<int, ICarte>();
            Parsers.Parser parser = new Parsers.Parser();


            foreach (KeyValuePair<int, string[]> pair in dico)
            {
                Carte uneNouvelleCarte = Manufacturecarte(pair.Value);
                MainSet.Add(pair.Key, uneNouvelleCarte);
            }

            return MainSet;
        }

        private Carte Manufacturecarte(string[] toProcess)
        {
            Parsers.Parser parser = new Parsers.Parser();

            string nomModele = "", architecture = "";
            DateTime dateSortie = default;
            int bus = -1, constructeur = -1, tailleMemoire = -1, frequenceGpu = -1, frequenceMemoire = -1, shaderUnits = -1, tmuUnits = -1, ropUnits = -1, wattage = -1;
            float prix = -1, hashrate = -1, indicateurPuissance = -1;
            bool wattageEstExtrapole = false, prixEstExtrapole = false;
            Uri urlVersImage = default;
            int line = -1;

            nomModele = toProcess[0];
            architecture = toProcess[1];
            dateSortie = parser.StringToDate(toProcess[2]);
            //EBusTypes eBusTypes = (EBusTypes)Enum.Parse(typeof(EBusTypes), toProcess[3]);
            if (toProcess[4] == "System Shared")
                tailleMemoire = 0;
            else
            {
                string[] strTemp = toProcess[4].Split(',');   ///les données sont sous la forme [XXX GB, GDDRX, XXX bit], on veut [XXX][X] et [XXX] (plus de lettres) 
                int[] intTemp = new int[strTemp.Length];

                for (int i = 0; i < 3; i++)
                {
                    intTemp[i] = parser.ParseToIntNoSpace(strTemp[i]);
                }
                tailleMemoire = intTemp[0];
                frequenceGpu = parser.ParseToIntNoSpace(toProcess[5]);
                frequenceMemoire = parser.ParseToIntNoSpace(toProcess[6]);
                shaderUnits = parser.ParseToIntNoSpace(toProcess[7]);
                tmuUnits = parser.ParseToIntNoSpace(toProcess[8]);
                ropUnits = parser.ParseToIntNoSpace(toProcess[9]);
            }
            //string strTemp2 = parser.ParseToIntNoSpace(toProcess[5]);

            Carte uneNouvelleCarte = new Carte(nomModele, dateSortie, architecture, bus, constructeur, tailleMemoire, frequenceGpu, frequenceMemoire, shaderUnits, tmuUnits, ropUnits, wattage, prix, hashrate, indicateurPuissance, wattageEstExtrapole, prixEstExtrapole, urlVersImage, line);

            return uneNouvelleCarte;
        }
    }
}
