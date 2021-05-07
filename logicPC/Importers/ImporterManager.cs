using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logicPC.Parsers;

namespace logicPC.ImportStrategies
{
    public class ImporterManager
    {
        public static Dictionary<int, Carte> ImportAll(string path, string PnmName, string PemName, string UslName)
        {
            int constructeur = ParseConstructeur.StringToInt(PemName.Split('.').FirstOrDefault());

            CreateurConcret Cardfactory = new();

            if (path.Last() != '/')
                path += @"/";

            Dictionary<int, List<String>> dico = SImporterDataSets<List<string>>.FileImportOP(path+PnmName);
            Dictionary<int, Carte> deck = Cardfactory.CreerCarte(dico);

            Dictionary<int, Uri> UriDico = SImporterPictureLink.FileImportOP(path+PemName);
            
            foreach(KeyValuePair<int, Uri> page in UriDico)
            {
                if (!deck.ContainsKey(page.Key)) // seul cas possible: le fichier .pem est trop long, peut-être érronné
                    break;

                Carte temp = deck[page.Key];
                temp.SetUri(page.Value);

                temp.SetConstructeur(constructeur);
                deck[page.Key] = temp;
            }

            return deck;
        }
    }
}
