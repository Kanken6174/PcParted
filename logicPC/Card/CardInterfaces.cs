using System;
using logicPC.CardData;

namespace logicPC.Interfaces
{
    /// <summary>
    /// Interface d'une card
    /// </summary>

    public interface ICard : IInfo, ISpecs
    {
        public Info Informations { get; set; }
        public Specs Specifications { get; set; }
        public Theorics Theorics { get; set; }
    }
   public interface IInfo : IStringable
    {

    }
    public interface ISpecs : IStringable
    {

    }
    public interface ITheoric : IInfo, ISpecs
    {
        public void ProcessFactors(CardData.Info info);
    }

    public interface IStringable
    {
        public string ToString();
    }
}