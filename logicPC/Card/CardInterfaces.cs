using System;

namespace logicPC
{
    /// <summary>
    /// Interface d'une card
    /// </summary>

    public interface ICard : IInfo, ISpecs, CardInterfaces
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
        public void processFactors(logicPC.CardData.Info info);
    }
    public interface CardInterfaces : ISpecs
    {

    }
    public interface IStringable
    {
        public string ToString();
    }
}