using System;
using logicPC;
using System.Collections.Generic;

namespace TestImport
{
    class importTest
    {
        static void Main(string[] args)
        {
            FileImporter fI = new FileImporter();
            Dictionary<int, string[]> dico = (Dictionary<int, string[]>)fI.Import(@"Y:\cs\PcParted\datasets\names.AMD.pnm");

            foreach (KeyValuePair<int, string[]> page in dico)
            {
                foreach(string str in page.Value)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
