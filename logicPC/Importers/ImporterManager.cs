using logicPC.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using logicPC.CardData;
using logicPC.Settings;

namespace logicPC.Importers
{
    public class ImporterManager : ImporterManagerBase
    {
        /// <summary>
        /// Importe toutes les cartes dans le répertoire par défaut indiqué dans logicPC.Settings
        /// </summary>
        /// <returns>Un dictionnaire contenant toutes les cartes issues de ce réprertoire</returns>
        public static Dictionary<string, Card> ImportAll()
        {
            string path = SettingsLogic.PATH;

            if (!Directory.Exists(path))
            {
                throw new IOException("This directory does not exist!");
            }

            string[] fileName = Directory.GetFiles(path, "*.pnm");

            for (int i = 0; i < fileName.Length; i++)
            {
                fileName[i] = Path.GetFileNameWithoutExtension(fileName[i]);
            }

            Dictionary<int, Card> deckTemp = new Dictionary<int, Card>();
            Dictionary<string, Card> MainDataset = new();

            for (int i = 0; i < fileName.Length; i++)
            {
                deckTemp = ImportSet(path, fileName[i] + ".pnm", fileName[i] + ".pem", null);

                foreach (KeyValuePair<int, Card> carte in deckTemp)
                {
                    MainDataset.Add(fileName[i] + carte.Key, carte.Value);
                }
            }

            return MainDataset;
        }
    }
}