using System.IO;
using System.Runtime.Serialization;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using Swordfish.NET.Collections;
using System.Collections.Generic;
using logicPC.CardData;
using DataContract.Persistors;

namespace persistance.DataContract
{
    public class DataContractPers : IPersistanceManager
    {
        public string PATH { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), @"..\XML\");
        public string FileName { get; set; } = "UserLists.XML";


        ConcurrentObservableDictionary<string, UserList> IPersistanceManager.Load()
        {
            var serializer = new DataContractSerializer(typeof(ULPersister));
            ConcurrentObservableDictionary<string, UserList> toReturn = new();

            if (!File.Exists(PATH))
                return null;
            
                using (Stream s = File.OpenRead(PATH))
                {
                    ULPersister ULPR = serializer.ReadObject(s) as ULPersister;
                    foreach (KeyValuePair<string, UserList> UL in ULPR.UserListsStorage)
                        foreach (KeyValuePair<string, Card> card in UL.Value.Cards)
                            card.Value.Theorics = new(card.Value.Specifications, card.Value.Informations);

                toReturn = ULPR.UserListsStorage;
                }

            return toReturn ?? new();
        }

        void IPersistanceManager.Save(ConcurrentObservableDictionary<string, UserList> toSave)
        {
            var serializer = new DataContractSerializer(typeof(ULPersister));
            if (!Directory.Exists(PATH))
                Directory.CreateDirectory(PATH);
            ULPersister ULP = new();
            ULP.UserListsStorage = toSave;

                using (Stream s = File.Create(Path.Combine(PATH, FileName)))
                    serializer.WriteObject(s, ULP);
            }
        }

    }

