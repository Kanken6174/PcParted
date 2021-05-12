using logicPC;
using logicPC.FiltersAndSearch;
using logicPC.ImportStrategies;
using System;
using System.Collections.Generic;
using System.IO;


namespace testsConsole
{
    internal class Program
    {
        private static void Main()
        {
            string path = @"Y:\cs\datacrawler";

            if (!Directory.Exists(path))
            {
                throw new IOException("This directory does not exist!");
            }

            string[] fileName = Directory.GetFiles(path, "*.pnm");

            for (int i = 0; i < fileName.Length; i++)
            {
               fileName[i]=Path.GetFileNameWithoutExtension(fileName[i]);
            }


            Dictionary<int, Card> deckTemp = new Dictionary<int, Card>();
            Dictionary<string, Card> MainDataset = new();

            for (int i = 0; i < fileName.Length; i++)
            {
                deckTemp = ImporterManager.ImportSet(path, fileName[i]+".pnm", fileName[i] + ".pem", null);

                foreach (KeyValuePair<int, Card> carte in deckTemp)
                {
                    Console.WriteLine(carte.ToString());
                    MainDataset.Add(fileName[i] + carte.Key, carte.Value);
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();

            foreach (KeyValuePair<string, Card> carte in MainDataset)
            {
                Console.WriteLine($"{carte.Key}|{carte.Value.ToString()}");
            }
            MainDataset = Lookup.SearchModel("RtX", MainDataset);
            foreach (KeyValuePair<string, Card> carte in MainDataset)
            {
                Console.WriteLine(carte.Value.ToString());
            }
        }
    }
}