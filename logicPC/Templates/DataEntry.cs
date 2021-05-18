using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicPC.Templates
{
    public abstract class DataEntry
    {
        public List<string> RawData;
        public string fullOriginPath;
        public int line;
    }
}
