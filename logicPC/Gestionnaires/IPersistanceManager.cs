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
        public string PATH { get; set; }
        ConcurrentObservableDictionary<string, UserList> Load();
        void Save(ConcurrentObservableDictionary<string, UserList> toSave);
    }
}
