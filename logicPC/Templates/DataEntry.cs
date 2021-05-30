using System.Collections.Generic;

namespace logicPC.Templates
{
    public abstract class DataEntry
    {
        public List<string> RawData;
        public string fullOriginPath;
        public int line;
    }
}