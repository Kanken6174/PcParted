using logicPC.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace logicPC.ImportStrategies
{
    public class ImporterManager
    {
        public static Dictionary<int, Card> ImportAll(string path, string PnmName, string PemName, string UslName)
        {
            int constructeur = ParseConstructeur.StringToInt(PemName.Split('.').FirstOrDefault());

            CreateurConcret Cardfactory = new();

            if (path.Last() != '/')
                path += @"/";

            Dictionary<int, List<String>> dico = SImporterDataSets<List<string>>.FileImportOP(path + PnmName);
            Dictionary<int, Card> deck = Cardfactory.CreerCard(dico);

            Dictionary<int, Uri> UriDico = SImporterPictureLink.FileImportOP(path + PemName);

            foreach (KeyValuePair<int, Uri> page in UriDico)
            {
                if (!deck.ContainsKey(page.Key)) // seul cas possible: le fichier .pem est trop long, peut-être érronné
                    break;

                Card temp = deck[page.Key];
                temp.PictureURL = page.Value;

                temp.SetConstructeur(constructeur);
                deck[page.Key] = temp;
            }

            return deck;
        }
    }
}