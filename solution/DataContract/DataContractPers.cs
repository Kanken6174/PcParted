using System.IO;
using System.Runtime.Serialization;
using logicPC.Gestionnaires;
using logicPC.Conteneurs;
using Swordfish.NET.Collections;

namespace DataContract
{
    public class DataContractPers : IPersistanceManager
    {
        public string PATH { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "..//XML");
        public string FileName { get; set; } = "XML.USF";
        ConcurrentObservableSortedDictionary<string, UserList> IPersistanceManager.Load()
        {
            ConcurrentObservableSortedDictionary<string, UserList> toReturn = new();

            return toReturn ?? new();
        }

        void IPersistanceManager.Save(ConcurrentObservableSortedDictionary<string, UserList> toSave)
        {
            var serializer = new DataContractSerializer(typeof(UserList));
            if (Directory.Exists(PATH))
                Directory.CreateDirectory(PATH);

            using (Stream s = File.Create(Path.Combine(PATH, FileName)))
                serializer.WriteObject(s, toSave);
        }
    }
}
