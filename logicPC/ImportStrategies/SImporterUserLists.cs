using System;

namespace logicPC
{

    class SImporterUserLists : IManagerImportation
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath">Chemin vers le fichier .usl, absolu.</param>
        /// <returns></returns>
        public object FileImportOP(string filePath)
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
