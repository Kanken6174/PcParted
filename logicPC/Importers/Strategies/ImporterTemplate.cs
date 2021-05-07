using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace logicPC
{
    public abstract class ImporterTemplate<T>
    {
        public abstract Dictionary<int, T> FileImportOP(string filePath);

    }
}
