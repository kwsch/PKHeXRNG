using System;
using System.Linq;
using System.Windows.Forms;

using Magnetosphere;
using PKHeX.Core;
using Timer = System.Timers.Timer;

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

            var source = pkmOffsets.Select(z => new ComboItem {Text = z.Key, Value = (int)z.Value}).ToList();
            CB_PKMOffsets.DisplayMember = nameof(ComboItem.Text);
            CB_PKMOffsets.ValueMember = nameof(ComboItem.Value);
            CB_PKMOffsets.DataSource = source;
            CB_PKMOffsets.SelectedIndexChanged += (s, e) => NUD_Read.Value = source[CB_PKMOffsets.SelectedIndex].Value;
            CB_PKMOffsets.SelectedIndex = 0;
            NUD_Read.Value = source[0].Value;
            NUD_ReadOffset.Value = NUD_SearchOffset.Value = source[0].Value;
        }

        private readonly Timer StateMonitor = new Timer(500);

        private void B_Disconnect_Click(object sender, EventArgs e)
        {
            ToggleConnection(false);
            StateMonitor.Stop();
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            CitraWindow = BotConfig.Citra.CreateBot();
            CitraWindow.Connect();
            Citra = (CitraTranslator) CitraWindow.Translator;
            ToggleConnection(true);

            var sav = Plugin.SaveFileEditor.SAV;
            var state = G7GameState.GetState(sav.Version, Citra);
            PG_State.SelectedObject = state;
            LoadRNGStateView(state);

            state.LoadTrainerData(sav);
            Text = $"Current Trainer Details: {sav.OT} {sav.Version} {sav.TrainerID7}";
        }

        private void LoadRNGStateView(G7GameState state)
        {
            StateMonitor.Elapsed += (s, e) =>
            {
                state.Update();
                PG_State.Invalidate();
            };
            StateMonitor.Start();
        }

        private void ToggleConnection(bool conn)
        {
            TC_Interactions.Enabled = B_Disconnect.Enabled = conn;
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
            L_LastViewed.Text = "Last Viewed:" + Environment.NewLine + Environment.NewLine + ShowdownSet.GetShowdownText(pkm);
            L_LastViewed.Visible = true;
        }

        public bool GetPKM(uint offset, out PKM pkm)
        {
            var data = Citra.ReadMemory(offset, 0xE8);
            pkm = PKMConverter.GetPKMfromBytes(data);
            return pkm.ChecksumValid && pkm.Species != 0;
        }

        private void B_ReadMemory_Click(object sender, EventArgs e)
        {
            uint ofs = (uint)NUD_ReadOffset.Value;
            uint len = (uint)NUD_ReadLength.Value;
            var data = Citra.ReadMemory(ofs, len);

            RTB_MemDump.Text = DumpUtil.HexDump(data);
        }

        private void B_Search_Click(object sender, EventArgs e)
        {
            uint ofs = (uint)NUD_SearchOffset.Value;
            uint len = (uint)NUD_SearchLength.Value;
            var data = DumpUtil.ReadHex(RTB_Sequence.Text);

            var offsets = Citra.FindSequences(data, ofs, len, 0x8000);
            var lines = string.Join(Environment.NewLine, offsets.Select(z => z.ToString("X8")));
            RTB_Offsets.Text = lines;
        }

        private void CitraRNG_FormClosing(object sender, FormClosingEventArgs e)
        {
            StateMonitor.Stop();
            StateMonitor.Dispose();
        }

        private void NUD_SearchLength_ValueChanged(object sender, EventArgs e) => NUD_SearchOffset.Increment = NUD_SearchLength.Value;
    }
}
