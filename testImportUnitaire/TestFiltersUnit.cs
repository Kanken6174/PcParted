using logicPC;
using logicPC.FiltersAndSearch;
using logicPC.ImportStrategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace FilterTesting
{
    [TestClass]
    public class TestFiltersUnit
    {
        [TestMethod]
        public void ExecutetestImportAndFilter()
        {
            string path = @"Y:\cs\datacrawler";
            string[] fileName = { "AMD", "NVIDIA" };
            Dictionary<int, Carte> deckTemp = new();
            Dictionary<string, Carte> MainDataset = new();

            for (int i = 0; i < 2; i++)
            {
                deckTemp = ImporterManager.ImportAll(path, fileName[i] + ".pnm", fileName[i] + ".pem", null);

                foreach (KeyValuePair<int, Carte> carte in deckTemp)
                    MainDataset.Add(fileName[i] + carte.Key, carte.Value);
            }
            MainDataset = Lookup.SearchModel("gtx", MainDataset);
            Assert.AreNotEqual(MainDataset, null);

            foreach (KeyValuePair<string, Carte> carte in MainDataset)
            {
                Assert.IsTrue(carte.Value.NomModele.Contains("GtX", StringComparison.InvariantCultureIgnoreCase));
                Console.WriteLine(carte.Value.ToString());
            }
        }
    }
}