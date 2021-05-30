﻿using logicPC.Interfaces;
using logicPC.Settings;
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
                float GHZ = specs.GpuFrequency / 1000F;
                PixelFillrate = GHZ * specs.RopUnits;
                TextureFillrate = GHZ * specs.TmuUnits;
                MayBeMobile = false;

                ProcessFactors(info);

                FP32GFLOPS = GHZ * 64;
                Hashrate = FP32GFLOPS / SettingsLogic.Difficulty;

                ProcessResults(info);
            }
        }

        /// <summary>
        /// Extrapole les facteurs de calcul à partir d'une classe Info
        /// </summary>
        /// <param name="info">la classe Info source d'informations de constructeur entre-autres</param>
        public void ProcessFactors(Info info)
        {
            if (info == null)
            {
                DateFactor = 1;
                ManufacturerFactor = 1;
                BusFactor = 1;
                return;
            }

            DateTime oldestDt = new(2000, 1, 1);
            int nY;
            nY = info.ReleaseDate.Year - oldestDt.Year;

            if (nY < -90)
                nY = 21;
            DateFactor = (DateTime.Now.Year - 2000);
            DateFactor /= nY;
            DateFactor *= (2 / DateFactor);

            ManufacturerFactor = info.Manufacturer.ToLowerInvariant() switch
            {
                "nvidia" => 0.8F,
                "amd" => 1.2F,
                "intel" => 0.5F,
                _ => 1F,
            };
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
                    BusFactor = 0.85F;
                    break;

                case "pcie3x8":
                    BusFactor = 0.75F;
                    break;

                default:
                    BusFactor = 1F;
                    break;
            }
        }

        public void ProcessResults(Info info)
        {
            Price = (DateFactor * FP32GFLOPS * 3F);
            EnergyConsumption = (int)((DateFactor * (FP32GFLOPS / SettingsLogic.gflopPrice) * ManufacturerFactor * BusFactor) * 100);
        }

        public override string ToString()
        {
            return $"{PixelFillrate} {TextureFillrate} {FP32GFLOPS} {Hashrate} {TempLoad} {EnergyConsumption}";
        }
    }
}