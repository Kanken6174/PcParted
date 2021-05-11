using System;

namespace logicPC
{
    /// <summary>
    /// classe d'une card standard qui implémente l'interface ICard
    /// </summary>
    public class Card
    {
        public string Model { get; private set; }
        public DateTime ReleaseDate { get; private set; }

        public string Architecture { get; private set; }
        public int Bus { get; private set; }
        public int Manufacturer { get; private set; }

        public int MemorySize { get; private set; }
        public int MemoryFrequency { get; private set; }
        public int GpuFrequency { get; private set; }
        public int ShaderUnits { get; private set; }
        public int TmuUnits { get; private set; }
        public int RopUnits { get; private set; }
        public int IPC { get; private set; }
        public int PowerDraw { get; private set; }
        public float PriceMSRP { get; private set; }
        public double Hashrate { get; private set; }
        public float RPI { get; private set; }
        public bool PowerDrawIsExtrapolated { get; private set; }
        public bool PriceIsExtrapolated { get; private set; }

        public Uri PictureURL { get; set; }
        public float TexelFillRate { get; private set; }

        /// <summary>
        /// Constructeur de base d'une carte, les paramètres parlent d'eux-même...
        /// </summary>
        /// <param name="Model">Modèle de la carte</param>
        /// <param name="ReleaseDate">Date de sortie de la carte</param>
        /// <param name="Architecture">Architetcure utilisée par la carte (différent du type de chipset)</param>
        /// <param name="Bus">Bus système utilisé par la carte</param>
        /// <param name="Manufacturer">Constructeur de la puce (pas de la carte, les constructeurs sont limité à AMD, NVIDIA et INTEL</param>
        /// <param name="MemorySize">Taille de la mémoire VRAM</param>
        /// <param name="GpuFrequency">Fréquence du GPU</param>
        /// <param name="MemoryFrequency">Fréquence de la mémoire</param>
        /// <param name="ShaderUnits">Nombre d'unités de shading</param>
        /// <param name="TmuUnits">nombre de TMUs</param>
        /// <param name="RopUnits">nombre de ROPs</param>
        /// <param name="PowerDraw">Consommation énergétique</param>
        /// <param name="PriceMSRP">Prix conseillé</param>
        /// <param name="Hashrate">Puissance de minage en MH/s</param>
        /// <param name="RawPowerIndicator">Indicateur de Puissance générique, basé sur la puissance de la carte en giga-flops</param>
        /// <param name="PowerDrawIsExtrapolated">Si le wattage (consommation) de la carte a été extrapolé</param>
        /// <param name="PriceIsExtrapolated">Si le prix de la carte est extrapolé</param>
        /// <param name="PictureURL">Lien vers l'url d'une image de la carte (peu fiable)</param>
        /// <param name="TexelFillRate">Vitesse de remplissage de textures en Giga-Texels/S. Quasi-exact (plus fiable que RawPowerIndicator)</param>
        public Card(string Model, DateTime ReleaseDate, string Architecture, int Bus, int Manufacturer, int MemorySize, int GpuFrequency, int MemoryFrequency, int ShaderUnits, int TmuUnits, int RopUnits, Uri PictureURL = default,int PowerDraw = -1, float PriceMSRP = -1, float Hashrate = -1, float RawPowerIndicator = -1, bool PowerDrawIsExtrapolated = false, bool PriceIsExtrapolated = false, float TexelFillRate = -1)
        {
            ///obligatoires
            this.Model = Model ?? throw new ArgumentNullException(nameof(Model));
            this.ReleaseDate = ReleaseDate;
            this.Architecture = Architecture ?? throw new ArgumentNullException(nameof(Architecture));
            this.Bus = Bus;
            this.Manufacturer = Manufacturer;
            this.MemorySize = MemorySize;
            this.GpuFrequency = GpuFrequency;
            this.MemoryFrequency = MemoryFrequency;
            this.ShaderUnits = ShaderUnits;
            this.TmuUnits = TmuUnits;
            this.RopUnits = RopUnits;

            ///Facultatifs
            this.PowerDraw = PowerDraw;
            this.PriceMSRP = PriceMSRP;
            this.Hashrate = Hashrate;
            RPI = RawPowerIndicator;
            this.PowerDrawIsExtrapolated = PowerDrawIsExtrapolated;
            this.PriceIsExtrapolated = PriceIsExtrapolated;
            this.PictureURL = PictureURL;
            this.TexelFillRate = TexelFillRate;
        }

        public override string ToString()
        {
            string toReturn = $"{Model} {ReleaseDate} {Architecture} {BusToString()} {ConstructeurToString()} {GpuFrequency} {MemoryFrequency} {ShaderUnits}/{TmuUnits}/{RopUnits} " +
    $"{PowerDraw} {PriceMSRP} {Hashrate} {RPI} {TexelFillRate} {PowerDrawIsExtrapolated} {PriceIsExtrapolated} {PictureURL} ";
            return toReturn;
        }

        public string ToStringNameAndPower()
        {
            return $"{Model} : {RPI}";
        }

        public string ConstructeurToString()
        {
            var enumDisplayStatus = (EFabricant)Manufacturer;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }

        public string BusToString()
        {
            var enumDisplayStatus = (EBusTypes)Manufacturer;
            string stringValue = enumDisplayStatus.ToString();
            return stringValue;
        }

        public void AcceptExtrapolatedData(double hashrate, float IndicateurPuissance, float fillRate)
        {
            Hashrate = hashrate;
            this.RPI = IndicateurPuissance;
            this.TexelFillRate = fillRate;
        }

        public void SetConstructeur(int toSet)
        {
            Manufacturer = toSet;
        }
    }
}