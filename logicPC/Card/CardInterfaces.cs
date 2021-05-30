using logicPC.CardData;

namespace logicPC.Interfaces
{
    /// <summary>
    /// Interface d'une card
    /// </summary>

    internal interface ICard : IInfo, ISpecs
    {
        public Info Informations { get; set; }
        public Specs Specifications { get; set; }
        public Theorics Theorics { get; set; }
    }

    internal interface IInfo : IStringable
    {
    }

    internal interface ISpecs : IStringable
    {
    }

    internal interface ITheoric : IInfo, ISpecs
    {
        public void ProcessFactors(CardData.Info info);
    }

    internal interface IStringable
    {
        public string ToString();
    }
}