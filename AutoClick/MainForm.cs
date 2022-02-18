using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace AutoClick
{
    public partial class MainForm : Form
    {
        enum MouseEventMsg
        {
            MOUSEEVENTF_LEFTDOWN = 2,
            MOUSEEVENTF_LEFTUP = 4,
            MOUSEEVENTF_RIGHTTDOWN = 8,
            MOUSEEVENTF_RIGHTUP = 16
        }

        private class NativeMethods
        {
            [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

            [DllImport("USER32.dll", CallingConvention = CallingConvention.StdCall)]
            public static extern void SetCursorPos(int X, int Y);
        }

        private const string SETTING_FILENAME = "Settings.config";
        private static readonly string SETTING_FILEDIR = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), Application.ProductName);
        private static readonly string SETTING_FIILEPATH = Path.Combine(SETTING_FILEDIR, SETTING_FILENAME);

        private bool IsRunning { get; set; }
        private Point ClickPoint { get; set; }
        private Settings Settings { get; set; }
        private Regex Regex { get; } = new Regex("^[a-zA-Z]{1}$");

        public MainForm()
        {
            InitializeComponent();

            LoadSettings();
            SetSettingsTpProperty();

            rdoLeft.CheckedChanged += ValueChanged;
            rdoRight.CheckedChanged += ValueChanged;
            nmInterval.ValueChanged += ValueChanged;
            chkHotkeyCtrl.CheckedChanged += ValueChanged;
            chkHotkeyAlt.CheckedChanged += ValueChanged;
            chkHotkeyShift.CheckedChanged += ValueChanged;
            chkRunStartup.CheckedChanged += ValueChanged;

            hotkey.Register(Settings.GetModKey(), Settings.GetHotKey());

            WindowState = FormWindowState.Minimized;
        }

        private void hotkey_HotkeyPress(object sender, HotkeyEventArgs e)
        {
            if (IsRunning)
            {
                nfIcon.Icon = Properties.Resources.icon;
                clickTimer.Stop();
            }
            else
            {
                nfIcon.Icon = Properties.Resources.icon_on;
                ClickPoint = MousePosition;
                clickTimer.Interval = ((int)nmInterval.Value) * 1000;
                clickTimer.Start();
            }

            IsRunning = !IsRunning;

            foreach (Control ctrl in Controls)
            {
                ctrl.Enabled = !IsRunning;
            }
        }

        private void txtHotkey_TextChanged(object sender, EventArgs e)
        {
            var text = txtHotkey.Text;

            if (string.IsNullOrWhiteSpace(text)) return;

            if (Regex.IsMatch(text))
            {
                txtHotkey.Text = text.ToUpper();
                ValueChanged(null, EventArgs.Empty);
            }
            else
            {
                txtHotkey.Text = "L";
            }

            txtHotkey.Select(1, 0);
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Application.DoEvents();
                ShowInTaskbar = false;
                Hide();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nfIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NativeMethods.SetCursorPos(ClickPoint.X, ClickPoint.Y);

            if (rdoLeft.Checked)
            {
                NativeMethods.mouse_event((int)MouseEventMsg.MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                NativeMethods.mouse_event((int)MouseEventMsg.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }
            else
            {
                NativeMethods.mouse_event((int)MouseEventMsg.MOUSEEVENTF_RIGHTTDOWN, 0, 0, 0, 0);
                NativeMethods.mouse_event((int)MouseEventMsg.MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }
        }

        private void ValueChanged(object sender, EventArgs e)
        {
            Settings.Buttons = rdoLeft.Checked ? TargetButtons.Left : TargetButtons.Right;
            Settings.Interval = (int)nmInterval.Value;
            Settings.HotkeyCtrl = chkHotkeyCtrl.Checked;
            Settings.HotkeyAlt = chkHotkeyAlt.Checked;
            Settings.HotkeyShift = chkHotkeyShift.Checked;
            Settings.Hotkey = txtHotkey.Text;
            Settings.RunAtStartup = chkRunStartup.Checked;
            SetCurrentVersionRun(chkRunStartup.Checked);

            SaveSettings();

            hotkey?.Register(Settings.GetModKey(), Settings.GetHotKey());
        }

        private void SetSettingsTpProperty()
        {
            if (Settings.Buttons == TargetButtons.Left)
            {
                rdoLeft.Checked = true;
            }
            else
            {
                rdoRight.Checked = true;
            }

            nmInterval.Value = Settings.Interval;
            chkHotkeyCtrl.Checked = Settings.HotkeyCtrl;
            chkHotkeyAlt.Checked = Settings.HotkeyAlt;
            chkHotkeyShift.Checked = Settings.HotkeyShift;
            txtHotkey.Text = Settings.Hotkey;
            chkRunStartup.Checked = Settings.RunAtStartup;
            SetCurrentVersionRun(Settings.RunAtStartup);
        }

        private void LoadSettings()
        {
            try
            {
                if (File.Exists(SETTING_FIILEPATH))
                {
                    Settings = LoadXml<Settings>(SETTING_FIILEPATH);
                }
                else
                {
                    Settings = new Settings();
                }
            }
            catch (Exception) { }
        }

        private void SaveSettings()
        {
            if (!Directory.Exists(SETTING_FILEDIR))
            {
                Directory.CreateDirectory(SETTING_FILEDIR);
            }

            SaveXml(Settings, SETTING_FIILEPATH);
        }

        private void SetCurrentVersionRun(bool register)
        {
            try
            {
                var regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

                if (register)
                {
                    regkey.SetValue(Application.ProductName, Application.ExecutablePath);
                }
                else
                {
                    regkey.DeleteValue(Application.ProductName);
                }

                regkey.Close();
            }
            catch(Exception) { }
        }

        private T LoadXml<T>(string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = File.OpenRead(path))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        private void SaveXml<T>(T source, string path)
        {
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = File.Open(path, FileMode.Create))
            {
                serializer.Serialize(stream, source);
            }
        }
    }
}