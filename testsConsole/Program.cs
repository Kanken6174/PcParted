using System;
using logicPC;
using System.Collections.Generic;
using System.Diagnostics;

namespace testsConsole
{
    class Program
    {
        static void Main()
        {
            FileImporter fI = new();
            CreateurConcret Cardfactory = new();

            Dictionary<int, string[]> dico = (Dictionary<int, string[]>)fI.Import(@"Y:\cs\PcParted\datasets\names.AMD.pnm");

            foreach (KeyValuePair<int, string[]> page in dico)
            {
                Console.Write(page.Key + " ");
                foreach (string str in page.Value)
                {
                    Console.Write(str + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Console.WriteLine();

            Dictionary<int, ICarte> deck = Cardfactory.CreerCarte(dico);

            foreach(KeyValuePair<int, ICarte> carte in deck)
            {
               Console.WriteLine(carte.Value.ToString());
            }
        }
    }
}
