using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicPC
{
    class FileImporter
    {
        private IManagerImportation _strategy;  //représente la stratégie actuelle, peut être changé
        private string filePath;

        public FileImporter()
        { }

        ///
        public FileImporter(string filePath)
        {
            IManagerImportation strategy = new ImporterDataSets();
            this._strategy = strategy;
        }

        public void SetStrategy(IManagerImportation strategy)   //remplace la stratégie utilisée
        {
            this._strategy = strategy;
        }

    }

    // The Strategy interface declares operations common to all supported
    // versions of some algorithm.
    //
    // The Context uses this interface to call the algorithm defined by Concrete
    // Strategies.
    public interface IManagerImportation
    {
        object FileImportOP(object data);
    }

    // Concrete Strategies implement the algorithm while following the base
    // Strategy interface. The interface makes them interchangeable in the
    // Context.
    class ImporterPictureLink : IManagerImportation
    {
        public object FileImportOP(object filePath)
        {
            var FP = filePath as string;
            var FA = StringToUri(FP);

            return "";
        }
        private Uri StringToUri(string filepath)
        {
            Uri fileUri = new Uri("file:///" + filepath);
            return fileUri;
        }
    }

    class ImporterUserLists : IManagerImportation
    {
        public object FileImportOP(object filePath)
        {
            var FP = filePath as string;
            var FA = StringToUri(FP);

            return "";
        }

        private Uri StringToUri(string filepath)
        {
            Uri fileUri = new Uri("file:///" + filepath);
            return fileUri;
        }
    }
    class ImporterDataSets : IManagerImportation
    {
        public object FileImportOP(object filePath)
        {
            var FP = filePath as string;
            var FA = StringToUri(FP);

            return "";
        }

        private Uri StringToUri(string filepath)
        {
            Uri fileUri = new Uri("file:///" + filepath);
            return fileUri;
        }
    }

}
