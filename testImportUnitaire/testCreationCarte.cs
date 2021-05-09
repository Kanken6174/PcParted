using logicPC;
using logicPC.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace testsCreationCardUnitaires
{
    [TestClass]
    public class TestCreationCard
    {
        [TestMethod]
        public void TestCard()
        {
            string[] toSplit = "GeForce RTX 2070 SUPER	TU104	Jul 9th, 2019	PCIe 3.0 x16	8 GB, GDDR6, 256 bit	1605 MHz	1750 MHz	2560 / 160 / 64".Split('\t');
            string[] toSend = Parser.DeepSplit(toSplit);
            Console.WriteLine(toSend);
            List<string> toSendList = new List<string>(toSend);
            Card testcard = CreateurConcret.ManufactureCard(toSendList);

            Assert.IsNotNull(testcard);
            Console.WriteLine(testcard.ToString());
        }
    }
}