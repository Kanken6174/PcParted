using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testImportUnitaire
{
    [TestClass]
    public class TestImportUnit
    {
        [TestMethod]
        public void Executetestimport()
        {
            FileImporter fI = new();
            Assert.IsNotNull(fI);
            Dictionary<int, string[]> dico = (Dictionary<int, string[]>)fI.Import(@"Y:\cs\PcParted\datasets\names.AMD.pnm");

            foreach (KeyValuePair<int, string[]> page in dico)
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
        }
    }
}
