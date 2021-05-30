using logicPC.Interfaces;

namespace logicPC.CardData
{
    public class Specs : ISpecs
    {
        public int MemoryType { get; private set; }
        public int BitRate { get; private set; }
        public int MemorySize { get; private set; }
        public int MemoryFrequency { get; private set; }
        public int GpuFrequency { get; private set; }
        public int ShaderUnits { get; private set; }
        public int TmuUnits { get; private set; }
        public int RopUnits { get; private set; }

        public Specs(int memoryType, int bitRate, int memorySize, int memoryFrequency, int gpuFrequency, int shaderUnits, int tmuUnits, int ropUnits)
        {
            MemoryType = memoryType;
            BitRate = bitRate;
            MemorySize = memorySize;
            MemoryFrequency = memoryFrequency;
            GpuFrequency = gpuFrequency;
            ShaderUnits = shaderUnits;
            TmuUnits = tmuUnits;
            RopUnits = ropUnits;
        }

        public override string ToString()
        {
            return $"{MemorySize} GDDR{MemoryType}, {BitRate}bits {MemoryFrequency}MHZ {GpuFrequency}MHZ {ShaderUnits}/{TmuUnits}/{RopUnits}";
        }
    }
}