﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logicPC.Settings
{
    public static class SettingsLogic
    {
        public static string PATH = @"C:\PcParted\datasets";
        public static Uri DummyPic = new Uri(@"https://www.techpowerup.com/gpudb/placeholder_nvidia.jpg");
        public static float Difficulty = 1;
        public static float BitcoinPrice = 49814.19F;
        public static float KWHPrice = 0.1765F;
        public static float Currency = 1F;
        public static int PoolingMax = 1;
        public static float DepreciationFactor = 0.95F;
        public static int GraphIncrement = 10;
        public static int GraphAnimationDelay = 30;
        public static int gflopPrice = 12;
        public static float powerInflationFactor = 0.98F;
    }
}