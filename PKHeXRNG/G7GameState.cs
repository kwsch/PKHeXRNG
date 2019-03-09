using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Magnetosphere;
using PKHeX.Core;

namespace PKHeXRNG
{
    public abstract class G7GameState
    {
        protected readonly IDeviceRW Device;
        protected G7GameState(IDeviceRW device) => Device = device;

        public abstract Dictionary<string, ulong> PokeOffsets { get; }

        public abstract ulong EggSeedOffset { get; }
        public abstract ulong EggReadyOffset { get; }

        public RNGState Main { get; } = new RNGState();

        public bool EggReady { get; private set; }
        public string EggSeed { get; private set; }

        public virtual void Update()
        {
            UpdateEgg();
            Main.UpdateFrame();
        }

        private void UpdateEgg()
        {
            EggReady = Device.ReadInt32(EggReadyOffset) != 0;
            EggSeed = string.Concat(Device.Read(EggSeedOffset, 0x10).Reverse().Select(z => $"{z:X2}"));
        }

        public abstract void LoadTrainerData(SaveFile SAV);

        public static G7GameState GetState(GameVersion savVersion, CitraTranslator citra)
        {
            if (savVersion == GameVersion.SN || savVersion == GameVersion.MN)
                return new G7GameStateSM(citra);
            if (savVersion == GameVersion.US || savVersion == GameVersion.UM)
                return new G7GameStateUSUM(citra);
            throw new Exception();
        }
    }

    public class G7GameStateSM : G7GameState
    {
        public G7GameStateSM(IDeviceRW device) : base(device)
        {
            Main.SFMTAddressSeed = 0x325A3878; // [1.2: 0x325A3878] [1.1: 0x325A3838] [1.0: 0x325A3878]

            //
            Main.SFMTAddressStart = 0x33195B7C; // [1.2: 0x33195B88] [1.1: ???] [1.0 0x33195B7C]
            Main.Initialize(Device);

            SOS.SFMTAddressSeed = 0x30038C44;
            SOS.SFMTAddressStart = 0x30038C44;
            SOS.Initialize(Device);
        }

        public override ulong EggReadyOffset { get; } = 0x3313EDD8;
        public override ulong EggSeedOffset { get; } = 0x3313EDDC;

        public override Dictionary<string, ulong> PokeOffsets => GameOffsets.SM;

        public RNGState SOS { get; } = new RNGState();

        public readonly ulong SOSChainLength = 0x3003D379; // wrong
        public const ulong TrainerOffset = 0x330D67D0;

        public override void LoadTrainerData(SaveFile SAV)
        {
            Device.Read(TrainerOffset, 0xC0).CopyTo(SAV.Data, 0x01200);
        }
    }

    public class G7GameStateUSUM : G7GameState
    {
        public G7GameStateUSUM(IDeviceRW device) : base(device)
        {
            Main.SFMTAddressSeed = 0x32663BF0;
            Main.SFMTAddressStart = 0x330D35D8;
            Main.Initialize(Device);
        }

        public override ulong EggReadyOffset { get; } = 0x3307B1E8;
        public override ulong EggSeedOffset { get; } = 0x3307B1EC;

        public override Dictionary<string, ulong> PokeOffsets => GameOffsets.USUM;
        public const ulong TrainerOffset = 0x33012818;

        public override void LoadTrainerData(SaveFile SAV)
        {
            Device.Read(TrainerOffset, 0xC0).CopyTo(SAV.Data, SAV.Exportable ? 0x01400 : 0x1200);
        }
    }
}