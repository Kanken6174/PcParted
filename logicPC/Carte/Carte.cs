using System;

namespace logicPC
{
    /// <summary>
    /// classe d'une carte standard qui implémente l'interface ICarte
    /// </summary>
    public class Carte : ICarte
    {
        public string NomModele { get; private set; }
        public DateTime DateSortie { get; private set; }

        public string Architecture { get; private set; }
        public int Bus { get; private set; }
        public int Constructeur { get; private set; }

        public int TailleMemoire { get; private set; }
        public int FrequenceGpu { get; private set; }
        public int FrequenceMemoire { get; private set; }
        public int ShaderUnits { get; private set; }
        public int TmuUnits { get; private set; }
        public int RopUnits { get; private set; }
        public int IPC { get; private set; }
        public int Wattage { get; private set; }
        public float Prix { get; private set; }
        public double Hashrate { get; private set; }
        public float IndicateurPuissance { get; private set; }
        public bool WattageEstExtrapole { get; private set; }
        public bool PrixEstExtrapole { get; private set; }

        public Uri UrlVersImage { get; private set; }
        public int Line { get; private set; }

        public Carte(string nomModele, DateTime dateSortie, string architecture, int bus, int constructeur, int tailleMemoire, int frequenceGpu, int frequenceMemoire, int shaderUnits, int tmuUnits, int ropUnits, int wattage, float prix, float hashrate, float indicateurPuissance, bool wattageEstExtrapole, bool prixEstExtrapole, Uri urlVersImage, int line)
        {
            NomModele = nomModele ?? throw new ArgumentNullException(nameof(nomModele));
            DateSortie = dateSortie;
            Architecture = architecture ?? throw new ArgumentNullException(nameof(architecture));
            Bus = bus;
            Constructeur = constructeur;
            TailleMemoire = tailleMemoire;
            FrequenceGpu = frequenceGpu;
            FrequenceMemoire = frequenceMemoire;
            ShaderUnits = shaderUnits;
            TmuUnits = tmuUnits;
            RopUnits = ropUnits;
            Wattage = wattage;
            Prix = prix;
            Hashrate = hashrate;
            IndicateurPuissance = indicateurPuissance;
            WattageEstExtrapole = wattageEstExtrapole;
            PrixEstExtrapole = prixEstExtrapole;
            UrlVersImage = urlVersImage;
            Line = line;
        }

        public override string ToString()
        {
            string toReturn = $"{NomModele} {DateSortie} {Architecture} {BusToString()} {ConstructeurToString()} {FrequenceGpu} {FrequenceMemoire} {ShaderUnits}/{TmuUnits}/{RopUnits} " +
    $"{Wattage} {Prix} {Hashrate} {IndicateurPuissance} {WattageEstExtrapole} {PrixEstExtrapole} {UrlVersImage} {Line} ";
            return toReturn;
        }

        public string ToStringNameAndPower()
        {
            return $"{NomModele} : {IndicateurPuissance}";
        }

        public string ConstructeurToString()
        {
            var enumDisplayStatus = (EFabricant)Constructeur;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }

        public string BusToString()
        {
            var enumDisplayStatus = (EBusTypes)Constructeur;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }

        public void acceptExtrapolatedData(double hashrate, float IndicateurPuissance)
        {
            Hashrate = hashrate;
            this.IndicateurPuissance = IndicateurPuissance;
        }

        public void SetUri(Uri toSet)
        {
            UrlVersImage = toSet;
        }

        public void SetConstructeur(int toSet)
        {
            Constructeur = toSet;
        }
    }
}