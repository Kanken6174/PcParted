using System;

namespace logicPC.Parsers
{
    internal static class ParseConstructeur
    {
        internal static int StringToInt(string constructeur)
        {
            int toReturn = -1;

            if (constructeur.Equals("Nvidia", StringComparison.InvariantCultureIgnoreCase))
                toReturn = 0;
            else if (constructeur.Equals("AMD", StringComparison.InvariantCultureIgnoreCase))
                toReturn = 1;
            else if (constructeur.Equals("Intel", StringComparison.InvariantCultureIgnoreCase))
                toReturn = 2;

            return toReturn;
        }
    }
}