using System.ComponentModel;
using Magnetosphere;

namespace PKHeXRNG
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class RNGState
    {
        public ulong SeedAddress { private get; set; }
        public ulong SFMTStart { private get; set; }
        public ulong SFMTIndex { private get; set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public uint InitialSeedOffset { get; private set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ulong CurrentSeedOffset { get; private set; }

        [TypeConverter(typeof(ExpandableObjectConverter))]
        public int FrameCount { get; private set; } = -1;

        private SFMT SFMT { get; set; }
        private IDeviceRW Device { get; set; }

        public void Initialize(IDeviceRW device)
        {
            Device = device;
            InitialSeedOffset = Device.ReadUInt32(SeedAddress);
            SFMT = new SFMT(InitialSeedOffset);
            CurrentSeedOffset = InitialSeedOffset;
            FrameCount = 0;
        }

        public void UpdateFrame()
        {
            var game = GetCurrentSeed();
            var seed = CurrentSeedOffset;
            var consumed = 0;

            while (game != seed && consumed < 100000)
            {
                seed = SFMT.Next64();
                consumed++;
            }

            FrameCount += consumed;
            CurrentSeedOffset = seed;
        }

        public ulong GetCurrentSeed()
        {
            var index = Device.ReadUInt32(SFMTIndex);
            var pointer = GetSFMTPointer(index);
            var seed1 = Device.ReadUInt32(pointer);
            var seed2 = Device.ReadUInt32(pointer + 4);

            return (ulong)(seed2 << 32) | seed1;
        }

        private ulong GetSFMTPointer(uint index)
        {
            ulong pointer;
            if (index == 624)
                pointer = SFMTStart;
            else
                pointer = SFMTStart + (index * 4);
            return pointer;
        }
    }
}