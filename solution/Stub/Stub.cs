using System;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using Swordfish.NET.Collections;
using System.IO;


namespace persisantce.Stub
{
    public class Stub : IPersistanceManager
    {
        
        public string PATH { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//stub");
        public string FileName { get; set; } = "stub.USF";
        ConcurrentObservableSortedDictionary<string, UserList> IPersistanceManager.Load()
        {
            ConcurrentObservableSortedDictionary<string, UserList> toReturn = new();
            toReturn.Add("une liste vide du stub", new());
            toReturn.Add("et une autre", new());
            toReturn.Add("et encore une autre!", new());
            
            return toReturn??new();
        }

        void IPersistanceManager.Save(ConcurrentObservableSortedDictionary<string, UserList> toSave)
        {
            //rien du tout, c'est un stub!
        }
    }
}
