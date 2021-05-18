﻿using System;
using logicPC.Interfaces;

namespace logicPC.CardData
{
    public class Theorics : ITheoric
    {
        public float PixelFillrate;
        public readonly float TextureFillrate;
        public float FP32GFLOPS;    // 1 milion floating point operations per second, FP32
        public double Hashrate;
        public float TempLoad;
        public int EnergyConsumption;
        public float Price;

        private float DateFactor;
        private float ManufacturerFactor;
        private float BusFactor;
        private bool MayBeMobile;

        public Theorics(Specs specs, Info info)
        {
            if (specs != null && info != null)
            {
                float GHZ = specs.GpuFrequency / 1000;
                PixelFillrate = GHZ * specs.RopUnits;
                TextureFillrate = GHZ * specs.TmuUnits;
                MayBeMobile = false;

                ProcessFactors(info);

                FP32GFLOPS = GHZ * 64;
            }
        }

        public void ProcessFactors(Info info)
        {
            if(info == null)
            {
                DateFactor = 1;
                ManufacturerFactor = 1;
                BusFactor = 1;
                return;
            }

            DateTime oldestDt = new(2000, 1, 1);
            int nY;
            nY = info.ReleaseDate.Year - oldestDt.Year;

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
                    MayBeMobile = true;
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
            return $"{PixelFillrate} {TextureFillrate} {FP32GFLOPS} {Hashrate} {TempLoad} {EnergyConsumption}";
        }
    }
}
