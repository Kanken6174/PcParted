using logicPC;
using logicPC.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace testImportUnitaire
{
    [TestClass]
    public class TestImportUnit
    {
        [TestMethod]
        public void Executetestimport()
        {
            Dictionary<int, List<string>> dico = (Dictionary<int, List<string>>)SImporterDataSets<List<string>>.FileImportOP(@"Y:\cs\datacrawler\AMD.pnm");

            foreach (KeyValuePair<int, List<string>> page in dico)
            {
                Console.Write(page.Key + " ");
                foreach (string str in page.Value)
                {
                    Assert.AreNotEqual(str, "");
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void TestSplit()
        {
            string[] toSplit = "GeForce RTX 2070 SUPER	TU104	Jul 9th, 2019	PCIe 3.0 x16	8 GB, GDDR6, 256 bit	1605 MHz	1750 MHz	2560 / 160 / 64".Split('\t');
            Assert.IsNotNull(toSplit);
            string[] splitted = Parser.DeepSplit(toSplit);
            Assert.IsNotNull(splitted);
            Assert.AreNotEqual(toSplit, splitted);
        }
    }
}