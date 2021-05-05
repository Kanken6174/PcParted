using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using logicPC.Parsers;

namespace testsParsersUnitaires
{
    [TestClass]
    public class TestParsers
    {
        [TestMethod]
        public void TestDeepSplit()
        {
            string excpected = " 64";   //on s'attend à ce qu'un espace traîne
            string[] toSplit = "GeForce RTX 2070 SUPER	TU104	Jul 9th, 2019	PCIe 3.0 x16	8 GB, GDDR6, 256 bit	1605 MHz	1750 MHz	2560 / 160 / 64".Split('\t');
            string[] toSend = Parser.DeepSplit(toSplit);

            Assert.AreEqual(toSend[^1], excpected);
            Console.WriteLine(toSend[^1]);
            Console.WriteLine(excpected);

        }

        [TestMethod]
        public void TestToDateSimple()
        {
            DateTime dateDeTest = new();
            DateTime dateAComparer = new DateTime(2020, 9, 1, 0, 00, 00);

            dateDeTest = Parser.StringToDate("Sep 1st, 2020");
            Assert.AreEqual(dateAComparer, dateDeTest);
            Console.WriteLine(dateDeTest + "|" + dateAComparer);
        }

        [TestMethod]
        public void TestToDateRaccourci()
        {
            DateTime dateDeTest = new();
            DateTime dateAComparer = new DateTime(2020, 1, 1, 0, 00, 00);

            dateDeTest = Parser.StringToDate("2020");
            Assert.AreEqual(dateAComparer, dateDeTest);
            Console.WriteLine(dateDeTest + "|" + dateAComparer);
        }

        [TestMethod]
        public void TestToDateSale()
        {
            DateTime dateDeTest = new();
            DateTime dateAComparer = new DateTime(0001, 1, 1, 0, 00, 00);

            dateDeTest = Parser.StringToDate("Du charabia absolu");
            Assert.AreEqual(dateAComparer, dateDeTest);
            Console.WriteLine(dateDeTest + "|" + dateAComparer);
        }
    }
}


