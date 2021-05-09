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
            Dictionary<int, Card> deckTemp = new();
            Dictionary<string, Card> MainDataset = new();

            for (int i = 0; i < 2; i++)
            {
                deckTemp = ImporterManager.ImportSet(path, fileName[i] + ".pnm", fileName[i] + ".pem", null);

                foreach (KeyValuePair<int, Card> carte in deckTemp)
                    MainDataset.Add(fileName[i] + carte.Key, carte.Value);
            }
            MainDataset = Lookup.SearchModel("gtx", MainDataset);
            Assert.AreNotEqual(MainDataset, null);

            foreach (KeyValuePair<string, Card> carte in MainDataset)
            {
                Assert.IsTrue(carte.Value.Model.Contains("GtX", StringComparison.InvariantCultureIgnoreCase));
                Console.WriteLine(carte.Value.ToString());
            }
        }
    }
}