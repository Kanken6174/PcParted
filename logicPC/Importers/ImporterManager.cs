using logicPC.CardData;
using logicPC.Settings;
using System.Collections.Generic;
using System.IO;
using Swordfish.NET.Collections;
using System.Threading.Tasks;

namespace logicPC.Importers
{
    internal class ImporterManager : ImporterManagerBase
    {
        /// <summary>
        /// Importe toutes les cartes dans le répertoire par défaut indiqué dans logicPC.Settings
        /// </summary>
        /// <returns>Un dictionnaire contenant toutes les cartes issues de ce réprertoire</returns>
        internal static async Task<Dictionary<string, Card>> ImportAll()
        {
            string path = SettingsLogic.PATH;

            if (!Directory.Exists(path))
            {
                return new();
            }

            string[] fileName = Directory.GetFiles(path, "*.pnm");

            for (int i = 0; i < fileName.Length; i++)
            {
                fileName[i] = Path.GetFileNameWithoutExtension(fileName[i]);
            }

            Dictionary<string, Card> MainDataset = new();

            for (int i = 0; i < fileName.Length; i++)
            {
                Dictionary<int, Card> deckTemp = ImportSet(path, fileName[i] + ".pnm", fileName[i] + ".pem", null);

                foreach (KeyValuePair<int, Card> carte in deckTemp)
                {
                    MainDataset.Add(fileName[i] + carte.Key, carte.Value);
                }
            }

            return MainDataset;
        }
    }
}