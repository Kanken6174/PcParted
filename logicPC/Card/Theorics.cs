using System;

namespace logicPC.CardData
{
    public class Theorics : ITheoric
    {
        public float PixelFillrate;
        public readonly float TextureFillrate;
        public float FP32GFLOPS;    // 1 milion floating point operations per second, FP32
        public double Hashrate;
        public float TempLoad;
        public int energyConsumption;
        public float price;

        private float DateFactor;
        private float ManufacturerFactor;
        private float BusFactor;
        private bool mayBeMobile;

        public Theorics(Specs specs, Info info)
        {
            if (specs != null && info != null)
            {
                float GHZ = specs.GpuFrequency / 1000;
                PixelFillrate = GHZ * specs.RopUnits;
                TextureFillrate = GHZ * specs.TmuUnits;
                mayBeMobile = false;

                processFactors(info);

                FP32GFLOPS = GHZ * 64;
            }
        }

        public void processFactors(Info info)
        {
            DateTime oldestDt = new(2000, 1, 1);
            int nY = info.ReleaseDate.Year - oldestDt.Year;
            DateFactor = nY / (DateTime.Now.Year - 2000);

            switch (info.Manufacturer.ToLowerInvariant())
            {
                case "nvidia":
                    ManufacturerFactor = 0.8F;
                    break;
                case "amd":
                    ManufacturerFactor = 1.2F;
                    break;
                case "intel":
                    ManufacturerFactor = 0.5F;
                    break;
                default:
                    ManufacturerFactor = 1F;
                    break;
            }

            switch (info.Bus.ToLowerInvariant())
            {
                case "igp":
                    BusFactor = 0.5F;
                    mayBeMobile = true;
                    break;
                case "pcie4x16":
                    BusFactor = 1F;
                    break;
                case "pcie4x8":
                    BusFactor = 0.95F;
                    break;
                case "pcie3x16":
                    BusFactor = 0.8F;
                    break;
                case "pcie3x8":
                    BusFactor = 0.75F;
                    break;

                default:
                    BusFactor = 1F;
                    break;
            }
        }

        public override string ToString()
        {
            return $"{PixelFillrate} {TextureFillrate} {FP32GFLOPS} {Hashrate} {TempLoad} {energyConsumption}";
        }
    }
}
