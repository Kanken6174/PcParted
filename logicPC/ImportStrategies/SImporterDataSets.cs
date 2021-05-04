using System;
using System.Collections.Generic;
using System.IO;

namespace logicPC
{
    /// <summary>
    /// Classe d'importation de sets de données
    /// </summary>
    class SImporterDataSets : IManagerImportation
    {
        /// <summary>
        /// Méthode d'importation de sets de données
        /// </summary>
        /// <param name="filePath">Le chemin vers le fichier .pnm, absolu.</param>
        /// <returns></returns>
        public object FileImportOP(string filePath)
        {
            int b = 0;

            Dictionary<int, string[]> dico = new Dictionary<int, string[]>();
            IEnumerable<string> lines = File.ReadLines(filePath);       //on récupères les lignes du fichier
            foreach (string str in lines)
            {
                string[] strTab = str.Split('\t'); // on les sépare(délémité par des tabs ici)
                dico.Add(b, strTab);
                b++;
            }

            return dico;
        }

        private Uri StringToUri(string filepath)
        {
            Uri fileUri = new Uri("file:///" + filepath);
            return fileUri;
        }
    }

}
