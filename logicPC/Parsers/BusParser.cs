using logicPC.enums;
using System;

namespace logicPC.Parsers
{
    public static class BusParser
    {
        public static int ParseBus(string bus)
        {
            bool succes = Enum.TryParse(typeof(EBusTypes), bus, out object Fabricant);

            if (!succes)
                return -1;

            return (int)Fabricant;
        }
    }
}