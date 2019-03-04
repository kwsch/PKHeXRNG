using System.Collections.Generic;
using PKHeX.Core;

namespace PKHeXRNG
{
    public static class GameOffsets
    {
        public static Dictionary<string, int> SMOffsets = new Dictionary<string, int>
        {
            ["Party1"] = 0x34195E10 + (0 * 0x1E4),
            ["Party2"] = 0x34195E10 + (1 * 0x1E4),
            ["Party3"] = 0x34195E10 + (2 * 0x1E4),
            ["Party4"] = 0x34195E10 + (3 * 0x1E4),
            ["Party5"] = 0x34195E10 + (4 * 0x1E4),
            ["Party6"] = 0x34195E10 + (5 * 0x1E4),

            ["Wild"] = 0x3254F4AC,
            ["SOS"] = 0x3002F7B8,
            ["Parent1"] = 0x3313EC01,
            ["Parent2"] = 0x3313ECEA,
        };

        public static Dictionary<string, int> USUMOffsets = new Dictionary<string, int>
        {
            ["Party1"] = 0x33F7FA44 + (0 * 0x1E4),
            ["Party2"] = 0x33F7FA44 + (1 * 0x1E4),
            ["Party3"] = 0x33F7FA44 + (2 * 0x1E4),
            ["Party4"] = 0x33F7FA44 + (3 * 0x1E4),
            ["Party5"] = 0x33F7FA44 + (4 * 0x1E4),
            ["Party6"] = 0x33F7FA44 + (5 * 0x1E4),

            ["Wild"] = 0x3002f9a0,
            ["SOS"] = 0x3002F9A0,
            ["Parent1"] = 0x3307B011,
            ["Parent2"] = 0x3307B0FA,
        };

        public static Dictionary<string, int> GetPKMOffsets(GameVersion game)
        {
            if (GameVersion.SN == game || GameVersion.MN == game)
                return SMOffsets;
            if (GameVersion.US == game || GameVersion.UM == game)
                return USUMOffsets;
            return new Dictionary<string, int>();
        }
    }
}