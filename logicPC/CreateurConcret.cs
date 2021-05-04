using System;

namespace logicPC
{
    class CreateurConcret : ACreateur
    {
        /// <summary>
        /// Ceci est la factory pour créer des cartes à partir d'une ligne lue dans un fichier.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="lineNum"></param>
        /// <returns></returns>
        public override ICarte CreerCarte(string input, int lineNum)
        {
            string nomModele = "", architecture = "";
            DateTime dateSortie = default;
            int bus = -1, constructeur = -1, tailleMemoire = -1, frequenceGpu = -1, frequenceMemoire = -1, shaderUnits = -1, tmuUnits = -1, ropUnits = -1, wattage = -1;
            float prix = -1, hashrate = -1, indicateurPuissance = -1;
            bool wattageEstExtrapole = false, prixEstExtrapole = false;
            Uri urlVersImage = default;
            int line = -1;

            string[] splitted = input.Split('\t');

            nomModele = splitted[0];

            Carte uneNouvelleCarte = new Carte(nomModele, dateSortie, architecture, bus, constructeur, tailleMemoire, frequenceGpu, frequenceMemoire, shaderUnits, tmuUnits, ropUnits, wattage, prix, hashrate, indicateurPuissance, wattageEstExtrapole, prixEstExtrapole, urlVersImage, line);
            return uneNouvelleCarte;
        }
    }
}
