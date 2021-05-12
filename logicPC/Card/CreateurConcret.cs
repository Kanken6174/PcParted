﻿using System;
using System.Collections.Generic;
using logicPC.CardData;

namespace logicPC
{
    public class CreateurConcret : ACreateur
    {

        /// <summary>
        /// Factory responsable de la création de cards à partir d'un dictionnaire de string.
        /// </summary>
        /// <param name="dico"></param>
        /// <returns></returns>
        public override Dictionary<int, Card> MakeCard(Dictionary<int, List<string>> dico)
        {
            Dictionary<int, Card> MainSet = new();

            foreach (KeyValuePair<int, List<string>> pair in dico)
            {
                Card uneNouvelleCard = ManufactureCard(pair.Value);
                MainSet.Add(pair.Key, uneNouvelleCard);
            }

            return MainSet;
        }

        public static Card ManufactureCard(List<string> toProcess)
        {
            int frequenceGpu = -1, frequenceMemoire = -1, shaderUnits = -1, tmuUnits = -1, ropUnits = -1, MemoryType = -1, BitRate = -1;

            string nomModele = toProcess[0];
            string architecture = toProcess[1];
            DateTime dateSortie = Parsers.Parser.StringToDate(toProcess[2]);
            string bus = toProcess[3];
            int tailleMemoire;

            if (toProcess[4] == "System Shared")
            {
                tailleMemoire = 0;
            }

            else
            {
                string[] strTemp = toProcess[4].Split(',');   ///les données sont sous la forme [XXX GB, GDDRX, XXX bit], on veut [XXX][X] et [XXX] (plus de lettres)
                int[] intTemp = new int[strTemp.Length];

                for (int i = 0; i < 3; i++)
                {
                    intTemp[i] = Parsers.Parser.ParseToIntNoSpace(strTemp[i]);
                }
                tailleMemoire = intTemp[0];
                MemoryType = intTemp[1];
                BitRate = intTemp[2];
                frequenceGpu = Parsers.Parser.ParseToIntNoSpace(toProcess[5]);
                frequenceMemoire = Parsers.Parser.ParseToIntNoSpace(toProcess[6]);
                shaderUnits = Parsers.Parser.ParseToIntNoSpace(toProcess[7]);
                tmuUnits = Parsers.Parser.ParseToIntNoSpace(toProcess[8]);
                ropUnits = Parsers.Parser.ParseToIntNoSpace(toProcess[9]);
            }

            Info info = new(nomModele, dateSortie, architecture, bus);
            Specs specs = new(MemoryType, BitRate, tailleMemoire, frequenceMemoire, frequenceGpu, shaderUnits, tmuUnits, ropUnits);
            Card uneNouvelleCard = new(info, specs);

            return uneNouvelleCard;
        }
    }
}