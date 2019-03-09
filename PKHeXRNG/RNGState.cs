using System.ComponentModel;
using Magnetosphere;

namespace PKHeXRNG
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RNGState
    {
        internal ulong SFMTAddressSeed { private get; set; }
        internal ulong SFMTAddressStart { private get; set; }
        private ulong SFMTAddressIndex { get; set; }

        public uint InitialSeed { get; private set; }
        public ulong CurrentSeed { get; private set; }
        public int FrameCount { get; private set; } = -1;

        private SFMT SFMT { get; set; }
        private IDeviceRW Device { get; set; }

        public void Initialize(IDeviceRW device)
        {
            Device = device;
            InitialSeed = Device.ReadUInt32(SFMTAddressSeed);
            SFMTAddressIndex = SFMTAddressStart + 0x9C0;
            SFMT = new SFMT(InitialSeed);
            CurrentSeed = InitialSeed;
            FrameCount = 0;
        }

        public void UpdateFrame()
        {
            var game = CalcCurrentSeed();
            var seed = CurrentSeed;
            var consumed = 0;

            while (game != seed && consumed < 10000)
            {
                seed = SFMT.Next64();
                consumed++;
            }

            FrameCount += consumed;
            CurrentSeed = seed;
        }

        public ulong CalcCurrentSeed()
        {
            var index = Device.ReadUInt32(SFMTAddressIndex);
            var pointer = GetSFMTPointer(index);
            var seed1 = Device.ReadUInt32(pointer);
            var seed2 = Device.ReadUInt32(pointer + 4);

            return (ulong)(seed2 << 32) | seed1;
        }

        private ulong GetSFMTPointer(uint index)
        {
            ulong pointer;
            if (index == 624)
                pointer = SFMTAddressStart;
            else
                pointer = SFMTAddressStart + (index * 4);
            return pointer;
        }
    }
}