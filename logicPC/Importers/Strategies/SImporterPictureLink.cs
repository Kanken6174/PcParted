using System;
using System.Collections.Generic;
using System.IO;

namespace logicPC
{
    /// <summary>
    /// Stratégie d'importation pour les liens d'images
    /// </summary>
    internal class SImporterPictureLink
    {
        /// <summary>
        /// Méthode d'importation de liens d'images
        /// </summary>
        /// <param name="filePath">Chemin vers le fichier .pem (liens d'image), absolu.</param>
        /// <returns></returns>
        public static Dictionary<int, Uri> FileImportOP(string filePath)
        {
            Dictionary<int, Uri> dico = new();
            int i = 0;

            IEnumerable<string> lines = File.ReadLines(filePath);       //on récupères les lignes du fichier
            foreach (string str in lines)
            {
                Uri uriToPic = new(str);       //peut-être about:blank, cela affichera un placeholder à la place.

                dico.Add(i, uriToPic);
                i++;
            }

            return dico;
        }
    }
}