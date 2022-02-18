using System;
using System.Text;
using System.Windows.Forms;

namespace AutoClick
{
    public enum TargetButtons : int
    {
        Left = 0,
        Right
    }

    [Serializable]
    public class Settings
    {
        public TargetButtons Buttons { get; set; } = TargetButtons.Left;
        public int Interval { get; set; } = 3;
        public bool HotkeyCtrl { get; set; } = true;
        public bool HotkeyAlt { get; set; } = true;
        public bool HotkeyShift { get; set; } = false;
        public string Hotkey { get; set; } = "L";
        public bool RunAtStartup { get; set; } = true;

        public Settings() { }

        public ModiferKey GetModKey()
        {
            var key = ModiferKey.None;
            if (HotkeyCtrl) key |= ModiferKey.Control;
            if (HotkeyAlt) key |= ModiferKey.Alt;
            if (HotkeyShift) key |= ModiferKey.Shift;

            return key;
        }

        public Keys GetHotKey()
        {
            var bytes = Encoding.ASCII.GetBytes(Hotkey);
            return (Keys)bytes[0];
        }
    }
}
