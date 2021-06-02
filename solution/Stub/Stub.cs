using System;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using Swordfish.NET.Collections;
using System.IO;
using System.Collections.Generic;


namespace persisantce.Stub
{
    public class Stub : IPersistanceManager
    {
        
        public string PATH { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//stub");
        public string FileName { get; set; } = "stub.USF";
        ConcurrentObservableDictionary<string, UserList> IPersistanceManager.Load()
        {
            ConcurrentObservableDictionary<string, UserList> toReturn = new();
            toReturn.Add("une liste vide du stub", new());
            toReturn.Add("et une autre", new());
            toReturn.Add("et encore une autre!", new());
            
            return toReturn??new();
        }

        void IPersistanceManager.Save(ConcurrentObservableDictionary<string, UserList> toSave)
        {
            //rien du tout, c'est un stub!
        }
    }
}
