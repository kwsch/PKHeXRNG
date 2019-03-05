using System.Collections.Generic;
using PKHeX.Core;

namespace PKHeXRNG
{
    public static class GameOffsets
    {
        public static Dictionary<string, int> SMOffsets = new Dictionary<string, int>
        {
            ["TeamA1"] = 0x3002E070, // Player 1
            ["TeamA2"] = 0x3002E070 + (1 * 0x1E4),
            ["TeamA3"] = 0x3002E070 + (2 * 0x1E4),
            ["TeamA4"] = 0x3002E070 + (3 * 0x1E4),
            ["TeamA5"] = 0x3002E070 + (4 * 0x1E4),
            ["TeamA6"] = 0x3002E070 + (5 * 0x1E4), // 0x3002E9E4

            ["TeamA1c"] = 0x3002EC14, // Player 1 (Copy)
            ["TeamA2c"] = 0x3002EC14 + (1 * 0x1E4),
            ["TeamA3c"] = 0x3002EC14 + (2 * 0x1E4),
            ["TeamA4c"] = 0x3002EC14 + (3 * 0x1E4),
            ["TeamA5c"] = 0x3002EC14 + (4 * 0x1E4),
            ["TeamA6c"] = 0x3002EC14 + (5 * 0x1E4),

            ["TeamB1"] = 0x3002F7B8, // Player 2
            ["TeamB2"] = 0x3002F7B8 + (1 * 0x1E4),
            ["TeamB3"] = 0x3002F7B8 + (2 * 0x1E4),
            ["TeamB4"] = 0x3002F7B8 + (3 * 0x1E4),
            ["TeamB5"] = 0x3002F7B8 + (4 * 0x1E4),
            ["TeamB6"] = 0x3002F7B8 + (5 * 0x1E4),

            ["TeamB1c"] = 0x3003035C, // Player 2 (Copy)
            ["TeamB2c"] = 0x3003035C + (1 * 0x1E4),
            ["TeamB3c"] = 0x3003035C + (2 * 0x1E4),
            ["TeamB4c"] = 0x3003035C + (3 * 0x1E4),
            ["TeamB5c"] = 0x3003035C + (4 * 0x1E4),
            ["TeamB6c"] = 0x3003035C + (5 * 0x1E4),

            ["TeamC1"] = 0x30030F00, // Player 3
            ["TeamC2"] = 0x30030F00 + (1 * 0x1E4),
            ["TeamC3"] = 0x30030F00 + (2 * 0x1E4),
            ["TeamC4"] = 0x30030F00 + (3 * 0x1E4),
            ["TeamC5"] = 0x30030F00 + (4 * 0x1E4),
            ["TeamC6"] = 0x30030F00 + (5 * 0x1E4),

            ["TeamC1c"] = 0x30031AA4, // Player 3 (Copy)
            ["TeamC2c"] = 0x30031AA4 + (1 * 0x1E4),
            ["TeamC3c"] = 0x30031AA4 + (2 * 0x1E4),
            ["TeamC4c"] = 0x30031AA4 + (3 * 0x1E4),
            ["TeamC5c"] = 0x30031AA4 + (4 * 0x1E4),
            ["TeamC6c"] = 0x30031AA4 + (5 * 0x1E4),

            ["TeamD1"] = 0x30032648, // Player 4
            ["TeamD2"] = 0x30032648 + (1 * 0x1E4),
            ["TeamD3"] = 0x30032648 + (2 * 0x1E4),
            ["TeamD4"] = 0x30032648 + (3 * 0x1E4),
            ["TeamD5"] = 0x30032648 + (4 * 0x1E4),
            ["TeamD6"] = 0x30032648 + (5 * 0x1E4),

            ["TeamD1c"] = 0x300331EC, // Player 4 (Copy)
            ["TeamD2c"] = 0x300331EC + (1 * 0x1E4),
            ["TeamD3c"] = 0x300331EC + (2 * 0x1E4),
            ["TeamD4c"] = 0x300331EC + (3 * 0x1E4),
            ["TeamD5c"] = 0x300331EC + (4 * 0x1E4),
            ["TeamD6c"] = 0x300331EC + (5 * 0x1E4),

            ["Team1Player"] = 0x300348E8, // String Trainer Name (0x1C bytes); class +0x8C
            ["Team2Player"] = 0x30034A74, // String Trainer Name (0x1C bytes); class +0x8C
            ["Team3Player"] = 0x3003657C, // String Trainer Name (0x1C bytes); class +0x8C
            ["Team4Player"] = 0x30038084, // String Trainer Name (0x1C bytes); class +0x8C

            ["Wild"] = 0x3254F4AC,
            ["Parent1"] = 0x3313EC01,
            ["Parent2"] = 0x3313ECEA,

            ["Party1"] = 0x34195E10 + (0 * 0x1E4),
            ["Party2"] = 0x34195E10 + (1 * 0x1E4),
            ["Party3"] = 0x34195E10 + (2 * 0x1E4),
            ["Party4"] = 0x34195E10 + (3 * 0x1E4),
            ["Party5"] = 0x34195E10 + (4 * 0x1E4),
            ["Party6"] = 0x34195E10 + (5 * 0x1E4),

        };

        public static Dictionary<string, int> USUMOffsets = new Dictionary<string, int>
        {
            ["SOS"] = 0x3002F9A0,
            ["Parent1"] = 0x3307B011,
            ["Parent2"] = 0x3307B0FA,

            ["Party1"] = 0x33F7FA44 + (0 * 0x1E4),
            ["Party2"] = 0x33F7FA44 + (1 * 0x1E4),
            ["Party3"] = 0x33F7FA44 + (2 * 0x1E4),
            ["Party4"] = 0x33F7FA44 + (3 * 0x1E4),
            ["Party5"] = 0x33F7FA44 + (4 * 0x1E4),
            ["Party6"] = 0x33F7FA44 + (5 * 0x1E4),
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