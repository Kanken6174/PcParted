using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using logicPC.Parsers;

namespace testsCreationCarteUnitaires
{
    [TestClass]
    public class TestCreationCarte
    {
        [TestMethod]
        public void TestCarte()
        {

            string[] toSplit = "GeForce RTX 2070 SUPER	TU104	Jul 9th, 2019	PCIe 3.0 x16	8 GB, GDDR6, 256 bit	1605 MHz	1750 MHz	2560 / 160 / 64".Split('\t');
            string[] toSend = Parser.DeepSplit(toSplit);
            Console.WriteLine(toSend);
            _ = new CreateurConcret();
            Carte testcard = CreateurConcret.Manufacturecarte(toSend);

            Assert.IsNotNull(testcard);
            Console.WriteLine(testcard.ToString());

        }
    }
}
