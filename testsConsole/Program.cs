using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;
using logicPC.FiltersAndSearch;
using logicPC.ImportStrategies;
using logicPC.Extrapolation;

namespace testsConsole
{
    class Program
    {
        static void Main()
        {
            string path = @"Y:\cs\datacrawler";
            string[] fileName = { "AMD", "NVIDIA" };

            ImporterManager Im = new();
            Dictionary<int, Carte> deckTemp = new();
            Dictionary<string, Carte> MainDataset = new();


            for (int i = 1; i < 2; i++)
            {
                deckTemp = ImporterManager.ImportAll(path, fileName[i]+".pnm", fileName[i]+".pem", null);

                foreach (KeyValuePair<int, Carte> carte in deckTemp)
                {
                    Console.WriteLine(carte.ToString());
                    MainDataset.Add(fileName[i]+carte.Key, carte.Value);
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();

            foreach (KeyValuePair<string, Carte> carte in MainDataset)
            {
                MainDataset[carte.Key] = Extrapolator.ExtrapolateCardData(carte.Value, 0);
                Console.WriteLine($"{carte.Key}|{carte.Value.ToStringNameAndPower()}");
            }
            MainDataset = Lookup.SearchModel("RtX", MainDataset);
            foreach (KeyValuePair<string, Carte> carte in MainDataset)
            {
                Console.WriteLine(carte.Value.ToString());
            }

        }
    }
}
