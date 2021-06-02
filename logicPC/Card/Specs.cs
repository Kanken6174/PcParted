using logicPC.Interfaces;
using System.Runtime.Serialization;

namespace logicPC.CardData
{
    [DataContract]
    public class Specs : ISpecs
    {
        [DataMember]
        public int MemoryType { get; private set; }
        [DataMember]
        public int BitRate { get; private set; }
        [DataMember]
        public int MemorySize { get; private set; }
        [DataMember]
        public int MemoryFrequency { get; private set; }
        [DataMember]
        public int GpuFrequency { get; private set; }
        [DataMember]
        public int ShaderUnits { get; private set; }
        [DataMember]
        public int TmuUnits { get; private set; }
        [DataMember]
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