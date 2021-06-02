using System.Collections.Generic;
using System.Runtime.Serialization;
namespace logicPC.Templates
{
    [DataContract]
    public abstract class DataEntry
    {
        [DataMember]
        public List<string> RawData;
        [DataMember]
        public string fullOriginPath;
        [DataMember]
        public int line;
    }
}