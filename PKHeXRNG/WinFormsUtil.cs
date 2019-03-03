using System;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace PKHeXRNG
{
    public static class WinFormsUtil
    {
        public static T FirstFormOfType<T>() where T : Form => (T)Application.OpenForms.Cast<Form>().FirstOrDefault(form => form is T);

        internal static void CenterToForm(this Control child, Control parent)
        {
            int x = parent.Location.X + ((parent.Width - child.Width) / 2);
            int y = parent.Location.Y + ((parent.Height - child.Height) / 2);
            child.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
        }

        internal static DialogResult Error(params string[] lines)
        {
            SystemSounds.Hand.Play();
            var msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, nameof(Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        internal static DialogResult Alert(params string[] lines)
        {
            SystemSounds.Asterisk.Play();
            var msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, nameof(Alert), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        internal static DialogResult Prompt(MessageBoxButtons btn, params string[] lines)
        {
            SystemSounds.Question.Play();
            var msg = string.Join(Environment.NewLine + Environment.NewLine, lines);
            return MessageBox.Show(msg, nameof(Prompt), btn, MessageBoxIcon.Asterisk);
        }
    }
}