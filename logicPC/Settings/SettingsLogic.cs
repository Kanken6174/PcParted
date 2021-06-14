using System;
using System.IO;

namespace logicPC.Settings
{
    public static class SettingsLogic
    {
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static string PATH = $@"{Directory.GetCurrentDirectory()}\..\datasets\";
        public static string CachePATH = $@"{Directory.GetParent((Directory.GetParent(PATH).ToString()))}\cache\";
        public static Uri DummyPic = new(@"https://www.techpowerup.com/gpudb/placeholder_nvidia.jpg");
        public static float Difficulty = 1;
        public static float BitcoinPrice = 49814.19F;
        public static float KWHPrice = 0.1765F;
        public static float Currency = 1F;
        public static int PoolingMax = 1;
        public static float DepreciationFactor = 0.95F;
        public static int GraphIncrement = 10;
        public static int GraphAnimationDelay = 30;
        public static int gflopPrice = 12;
        public static float powerInflationFactor = 0.99F;
#pragma warning restore CA2211 // Non-constant fields should not be visible
    }
}