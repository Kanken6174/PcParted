using System.Runtime.Serialization;
using Swordfish.NET.Collections;
using logicPC.Conteneurs;
using logicPC.CardData;
using System;

namespace DataContract.Persistors
{
    [DataContract]
    public class ULPersister
    {
        [DataMember]
        public ConcurrentObservableDictionary<string, UserList> UserListsStorage { get; set; }

        public ULPersister()
        {
            UserListsStorage = new();
        }
    }
}
