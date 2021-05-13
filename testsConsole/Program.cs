using logicPC;
using logicPC.FiltersAndSearch;
using logicPC.ImportStrategies;
using System;
using System.Collections.Generic;
using System.IO;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;


namespace testsConsole
{
    internal class Program
    {
        private static void Main()
        {
            GestionnaireListes gest = new();
            string path = @"Y:\cs\datacrawler";
            

            if (!Directory.Exists(path))
            {
                throw new IOException("This directory does not exist!");
            }

            string[] fileName = Directory.GetFiles(path, "*.pnm");

            for (int i = 0; i < fileName.Length; i++)
            {
               fileName[i]=Path.GetFileNameWithoutExtension(fileName[i]);
            }


            Dictionary<int, Card> deckTemp = new Dictionary<int, Card>();
            Dictionary<string, Card> MainDataset = new();

            for (int i = 0; i < fileName.Length; i++)
            {
                deckTemp = ImporterManager.ImportSet(path, fileName[i]+".pnm", fileName[i] + ".pem", null);

                foreach (KeyValuePair<int, Card> carte in deckTemp)
                {
                    Console.WriteLine(carte.ToString());
                    MainDataset.Add(fileName[i] + carte.Key, carte.Value);
                }
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();
            gest.Data = MainDataset;
            foreach (KeyValuePair<string, Card> carte in MainDataset)
            {
                Console.WriteLine($"{carte.Key}|{carte.Value.ToString()}");
            }
            MainDataset = Lookup.SearchModel( MainDataset, "RtX");
            foreach (KeyValuePair<string, Card> carte in MainDataset)
            {
                Console.WriteLine(carte.Value.ToString());
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
                gest.AjouterListe("exemple", new());

            Console.WriteLine(gest.MesListesUtilisateur.Count);

            foreach(KeyValuePair<string, UserList> keypair in gest.MesListesUtilisateur)
            {
                Console.WriteLine($"{keypair.Key} {keypair.Value}");
            }
        }
    }
}