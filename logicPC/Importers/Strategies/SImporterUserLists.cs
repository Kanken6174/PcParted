using System;

namespace logicPC.ImportStrategies
{
    internal class SImporterUserLists
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="filePath">Chemin vers le fichier .usl, absolu.</param>
        /// <returns></returns>
        public T FileImportOP<T>(string filePath)
        {
            //var FP = filePath as string;
            //var FA = StringToUri(FP);

            return (T)Convert.ChangeType("", typeof(T));
        }

        private Uri StringToUri(string filepath)
        {
            Uri fileUri = new Uri("file:///" + filepath);
            return fileUri;
        }
    }
}