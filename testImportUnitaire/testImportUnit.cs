using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testImportUnitaire
{
    [TestClass]
    public class testImportUnit
    {
        [TestMethod]
        public void executetestimport()
        {
            FileImporter fI = new FileImporter();
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
    }
}
