using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicPC
{

    /// <summary>
    /// classe d'une carte standard qui implémente l'interface ICarte
    /// </summary>
    public class Carte : ICarte
    {
        public string nomModele { get; private set; }
        public DateTime dateSortie { get; private set; }

        public string architecture { get; private set; }
        public int bus { get; private set; }
        public int constructeur { get; private set; }

        public int tailleMemoire { get; private set; }
        public int frequenceGpu { get; private set; }
        public int frequenceMemoire { get; private set; }
        public int shaderUnits { get; private set; }
        public int tmuUnits { get; private set; }
        public int ropUnits { get; private set; }
        public int wattage { get; private set; }
        public float prix { get; private set; }
        public float hashrate { get; private set; }
        public float indicateurPuissance { get; private set; }

        public bool wattageEstExtrapole { get; private set; }
        public bool prixEstExtrapole { get; private set; }

        public Uri urlVersImage { get; private set; }
        public int line { get; private set; }

        public Carte(string nomModele, DateTime dateSortie, string architecture, int bus, int constructeur, int tailleMemoire, int frequenceGpu, int frequenceMemoire, int shaderUnits, int tmuUnits, int ropUnits, int wattage, float prix, float hashrate, float indicateurPuissance, bool wattageEstExtrapole, bool prixEstExtrapole, Uri urlVersImage, int line)
        {
            this.nomModele = nomModele ?? throw new ArgumentNullException(nameof(nomModele));
            this.dateSortie = dateSortie;
            this.architecture = architecture ?? throw new ArgumentNullException(nameof(architecture));
            this.bus = bus;
            this.constructeur = constructeur;
            this.tailleMemoire = tailleMemoire;
            this.frequenceGpu = frequenceGpu;
            this.frequenceMemoire = frequenceMemoire;
            this.shaderUnits = shaderUnits;
            this.tmuUnits = tmuUnits;
            this.ropUnits = ropUnits;
            this.wattage = wattage;
            this.prix = prix;
            this.hashrate = hashrate;
            this.indicateurPuissance = indicateurPuissance;
            this.wattageEstExtrapole = wattageEstExtrapole;
            this.prixEstExtrapole = prixEstExtrapole;
            this.urlVersImage = urlVersImage;
            this.line = line;
        }

        public override string ToString()
        {
            string toReturn = "";
            toReturn = $"{nomModele} {dateSortie} {architecture} {bus} {constructeur} {frequenceGpu} {frequenceMemoire} {shaderUnits}/{tmuUnits}/{ropUnits} " +
                $"{wattage} {prix} {hashrate} {indicateurPuissance} {wattageEstExtrapole} {prixEstExtrapole} {urlVersImage} {line} ";
            return toReturn;
        }
    }
}
