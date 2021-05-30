using System.Collections.Generic;
using System.IO;

namespace logicPC.ImportStrategies
{
    /// <summary>
    /// Classe d'importation de sets de données
    /// </summary>
    public class SImporterDataSets<T> where T : List<string>, new()
    {
        /// <summary>
        /// Méthode d'importation de sets de données
        /// </summary>
        /// <param name="filePath">Le chemin vers le fichier .pnm, absolu.</param>
        /// <returns></returns>
        public static Dictionary<int, T> FileImportOP(string filePath)
        {
            int b = 0;
            Dictionary<int, T> dico = new();
            IEnumerable<string> lines = File.ReadLines(filePath);       //on récupères les lignes du fichier
            foreach (string str in lines)
            {
                string[] strTab = str.Split('\t'); // on les sépare(délémité par des tabs ici)
                string[] strTabSplit = Parsers.MainParser.DeepSplit(strTab); //sépare également les TMU/ROP/... séparés par des /
                List<string> strList = new(strTabSplit);
                dico.Add(b, strList as T);
                b++;
            }

            return dico;
        }
    }
}