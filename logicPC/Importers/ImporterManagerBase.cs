using logicPC.CardData;
using logicPC.CardFactory;
using logicPC.ImportStrategies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace logicPC.Importers
{
    internal class ImporterManagerBase
    {
        internal static Dictionary<int, Card> ImportSet(string path, string PnmName, string PemName)
        {
            string constructeur = PemName.Split('.').FirstOrDefault();

            CreateurConcretCarte Cardfactory = new();

            if (path.Last() != '/')
                path += @"/";

            Dictionary<int, List<String>> dicoRaws = SImporterDataSets<List<string>>.FileImportOP(path + PnmName);
            Dictionary<int, Card> deck = Cardfactory.MakeCard(dicoRaws);

            Dictionary<int, Uri> UriDico = SImporterPictureLink.FileImportOP(path + PemName);

            int i = 0;
            foreach (KeyValuePair<int, Uri> page in UriDico)
            {
                if (!deck.ContainsKey(page.Key)) // seul cas possible: le fichier .pem est trop long, peut-être érronné
                    break;

                Card temp = deck[page.Key];

                temp.Informations.PictureURL = page.Value;
                temp.Informations.Manufacturer = constructeur;
                temp.fullOriginPath = path + PnmName;
                temp.line = i;
                deck[page.Key] = temp;
                i++;
            }

            return deck;
        }
    }
}