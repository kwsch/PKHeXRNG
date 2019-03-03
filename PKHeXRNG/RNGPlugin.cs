using System;
using System.Windows.Forms;
using PKHeX.Core;

namespace PKHeXRNG
{
    public class RNGPlugin : IPlugin
    {
        public string Name => nameof(RNGPlugin);
        public int Priority => 1; // Loading order, lowest is first.
        public ISaveFileProvider SaveFileEditor { get; private set; }
        public IPKMView PKMEditor { get; private set; }

        private Form parent;

        public void Initialize(params object[] args)
        {
            Console.WriteLine($"Loading {Name}...");
            if (args == null)
                return;
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            parent = menu.FindForm();
            LoadMenuStrip(menu);
        }

        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            var tools = items.Find("Menu_Tools", false)[0] as ToolStripDropDownItem;
            AddPluginControl(tools);
        }

        private void AddPluginControl(ToolStripDropDownItem tools)
        {
            var ctrl = new ToolStripMenuItem(Name);
            tools.DropDownItems.Add(ctrl);

            var c2 = new ToolStripMenuItem($"{Name} Citra");
            c2.Click += (s, e) => ShowCitra();
            ctrl.DropDownItems.Add(c2);
            Console.WriteLine($"{Name} added menu items.");
        }

        private void ShowCitra()
        {
            if (!OpenWindowExists<CitraRNG>())
                new CitraRNG(this).Show();
        }

        public void NotifySaveLoaded()
        {
            Console.WriteLine($"{Name} was notified that a Save File was just loaded.");
        }
        public bool TryLoadFile(string filePath)
        {
            Console.WriteLine($"{Name} was provided with the file path, but chose to do nothing with it.");
            return false; // no action taken
        }

        private bool OpenWindowExists<T>() where T : Form
        {
            var form = WinFormsUtil.FirstFormOfType<T>();
            if (form == null)
                return false;

            form.CenterToForm(parent);
            form.BringToFront();
            return true;
        }
    }
}
