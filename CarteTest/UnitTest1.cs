using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testsUnitaires
{
    [TestClass]
    class testCreationCarte
    {
        [TestMethod]
        public void testCarte()
        {
            string[] toSend = new string[11];
            CreateurConcret cc = new CreateurConcret();
            Carte testcard = cc.Manufacturecarte(toSend);

            Assert.IsNotNull(testcard);

        }
    }
}