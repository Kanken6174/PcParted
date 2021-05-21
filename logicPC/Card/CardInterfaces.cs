using System;

namespace logicPC.Interfaces
{
    /// <summary>
    /// Interface d'une card
    /// </summary>

    public interface ICard : IInfo, ISpecs
    {

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