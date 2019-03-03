using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Magnetosphere;
using PKHeX.Core;

namespace PKHeXRNG
{
    public sealed partial class CitraRNG : Form
    {
        private readonly RNGPlugin Plugin;
        private CitraTranslator Citra;
        private Bot CitraWindow;

        public CitraRNG(RNGPlugin plg)
        {
            Plugin = plg;
            InitializeComponent();
            var game = Plugin.SaveFileEditor.SAV.Version;

            var generation = game.GetGeneration();
            if (generation != 7)
            {
                WinFormsUtil.Alert("Not supported.", game.ToString());
                Close();
            }

            var group = GameUtil.GetMetLocationVersionGroup(game);
            Text = group.ToString();

            var pkmOffsets = GameOffsets.GetPKMOffsets(game);
            if (pkmOffsets.Count == 0)
                return;

            var source = pkmOffsets.Select(z => new ComboItem {Text = z.Key, Value = z.Value}).ToList();
            CB_PKMOffsets.DisplayMember = nameof(ComboItem.Text);
            CB_PKMOffsets.ValueMember = nameof(ComboItem.Value);
            CB_PKMOffsets.DataSource = source;
            CB_PKMOffsets.SelectedIndexChanged += (s, e) => NUD_Read.Value = source[CB_PKMOffsets.SelectedIndex].Value;
            CB_PKMOffsets.SelectedIndex = 0;
            NUD_Read.Value = source[0].Value;
            NUD_ReadOffset.Value = source[0].Value;
        }

        private void B_Disconnect_Click(object sender, EventArgs e)
        {
            ToggleConnection(false);
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            CitraWindow = BotConfig.Citra.CreateBot();
            CitraWindow.Connect();
            Citra = (CitraTranslator) CitraWindow.Translator;
            ToggleConnection(true);
        }

        private void ToggleConnection(bool conn)
        {
            tabControl1.Enabled = B_Disconnect.Enabled = conn;
            NUD_Port.Enabled = B_Connect.Enabled = !conn;
        }

        private void B_ReadPKM_Click(object sender, EventArgs e)
        {
            var offset = (uint) NUD_Read.Value;
            if (!GetPKM(offset, out var pkm))
            {
                WinFormsUtil.Alert("No PKM in slot.");
                return;
            }
            Plugin.PKMEditor.PopulateFields(pkm);
        }

        public bool GetPKM(uint offset, out PKM pkm)
        {
            var data = Citra.ReadMemory(offset, 0xE8);
            pkm = PKMConverter.GetPKMfromBytes(data);
            return pkm.ChecksumValid && pkm.Species != 0;
        }

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

        private void B_ReadMemory_Click(object sender, EventArgs e)
        {
            uint ofs = (uint)NUD_ReadOffset.Value;
            uint len = (uint)NUD_ReadLength.Value;
            var data = Citra.ReadMemory(ofs, len);

            richTextBox1.Text = HexDump(data);
        }

        private static string HexDump(byte[] data)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                if (i != 0)
                {

                    if ((i & 0xF) == 0)
                        sb.Append(Environment.NewLine);
                    else
                        sb.Append(' ');
                }
                sb.Append(data[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
