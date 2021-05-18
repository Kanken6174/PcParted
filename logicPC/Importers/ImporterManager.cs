using logicPC.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace logicPC.ImportStrategies
{
    public class ImporterManager : ImporterManagerBase
    {
        public static Dictionary<string, Card> ImportAll()
        {
            string path = @"Y:\cs\datacrawler";

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