using System;

namespace logicPC.Parsers
{
    public static class BusParser
    {
        public static int ParseBus(string bus)
        {
            object Fabricant = new();
            bool succes = false;
            succes = Enum.TryParse(typeof(EBusTypes), bus, out Fabricant);

            if (!succes)
                return -1;

            return (int)Fabricant;
        }
    }
}