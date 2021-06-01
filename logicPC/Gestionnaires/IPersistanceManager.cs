using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using logicPC.Conteneurs;
using Swordfish.NET.Collections;
using System.IO;

namespace logicPC.Gestionnaires
{
    public interface IPersistanceManager
    {
        
        ConcurrentObservableSortedDictionary<string, UserList> Load();
        void Save(ConcurrentObservableSortedDictionary<string, UserList> toSave);
    }
}
