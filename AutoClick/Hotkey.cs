using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AutoClick
{
    #region Hotkey
    /// <summary>
    /// グローバルホットキーの登録と解除機能を提供します。
    /// </summary>
    [ToolboxBitmap(typeof(FileSystemWatcher))]
    [DefaultEvent("HotkeyPress")]
    public class Hotkey : Component, IDisposable
    {
        class NativeMethods
        {
            [DllImport("user32.dll")]
            public extern static int RegisterHotKey(IntPtr HWnd, int ID, int MOD_KEY, int KEY);
            [DllImport("user32.dll")]
            public extern static int UnregisterHotKey(IntPtr HWnd, int ID);
        }

        private HotkeyHostForm _HostForm;

        /// <summary>登録したホットキーが押下された時に発生します。</summary>
        public event EventHandler<HotkeyEventArgs> HotkeyPress;

        /// <summary>
        /// 修飾ホットキー(Ctrl,Alt,Shift)を取得または設定します。
        /// </summary>
        [Description("修飾ホットキー(Ctrl,Alt,Shift)を指定します。")]
        [Browsable(true)]
        public ModiferKey ModiferKey
        {
            get
            {
                return _HostForm.ModiferKey;
            }
            set
            {
                _HostForm.Register(value, HotKey);
            }
        }

        /// <summary>
        /// ホットキーを取得または設定します。
        /// </summary>
        [Description("ホットキーを指定します。")]
        [Browsable(true)]
        public Keys HotKey
        {
            get
            {
                return _HostForm.HotKey;
            }
            set
            {
                _HostForm.Register(ModiferKey, value);
            }
        }

        /// <summary>
        /// <see cref="Hotkey"/>クラスインスタンスを初期化します。
        /// </summary>
        public Hotkey(IContainer container)
        {
            container.Add(this);
            _HostForm = new HotkeyHostForm(ModiferKey.None, Keys.None, OnHotkeyPress);
        }

        /// <summary>
        /// <see cref="Hotkey"/>クラスインスタンスを初期化します。
        /// </summary>
        /// <param name="modifer">修飾ホットキー(Ctrl,Alt,Shift)。</param>
        /// <param name="keys">ホットキー。</param>
        public Hotkey(ModiferKey modifer, Keys keys)
        {
            _HostForm = new HotkeyHostForm(modifer, keys, OnHotkeyPress);
        }

        /// <summary>
        /// 登録されているホットキー押下イベントを発行します。
        /// </summary>
        private void OnHotkeyPress()
        {
            HotkeyPress?.Invoke(this, new HotkeyEventArgs(_HostForm.ID, ModiferKey, HotKey));
        }

        /// <summary>
        /// グローバルホットキーを紐づけるホストフォーム。
        /// </summary>
        private class HotkeyHostForm : Form
        {
            const int WM_HOTKEY = 0x0312;
            const int NOT_REGISTER = -1;

            /// <summary>
            /// 修飾ホットキー(Ctrl,Alt,Shift)を取得または設定します。
            /// </summary>
            public ModiferKey ModiferKey { get; private set; }
            /// <summary>
            /// ホットキーを取得または設定します。
            /// </summary>
            public Keys HotKey { get; private set; }
            /// <summary>
            /// ホットキーIDを取得または設定します。
            /// </summary>
            public int ID { get; private set; } = -1;

            private Action HotkeyPressAction;

            /// <summary>
            /// グローバルホットキーを紐づけるホストフォームクラスを初期化します。
            /// </summary>
            /// <param name="modiferKey">修飾ホットキー(Ctrl,Alt,Shift)。</param>
            /// <param name="keys">ホットキー。</param>
            /// <param name="act">ホットキー押下時処理。</param>
            public HotkeyHostForm(ModiferKey modiferKey, Keys keys, Action act)
            {
                HotkeyPressAction = act;

                Register(modiferKey, keys);
            }

            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_HOTKEY)
                {
                    if ((int)m.WParam == ID)
                    {
                        HotkeyPressAction();
                    }
                }

                base.WndProc(ref m);
            }

            /// <summary>
            /// グローバルホットキーを登録します。
            /// </summary>
            /// <param name="modiferKey">修飾ホットキー(Ctrl,Alt,Shift)。</param>
            /// <param name="keys">ホットキー。</param>
            public void Register(ModiferKey modiferKey, Keys keys)
            {
                Unregister();

                if (modiferKey == ModiferKey.None && keys == Keys.None) return;

                for (int id = 0; id < 0xbfff; id++)
                {
                    if (NativeMethods.RegisterHotKey(Handle, id, (int)modiferKey, (int)keys) != 0)
                    {
                        ModiferKey = modiferKey;
                        HotKey = keys;
                        ID = id;
                    }
                }
            }

            /// <summary>
            /// グローバルホットキーを解除します。
            /// </summary>
            public void Unregister()
            {
                if (ID != NOT_REGISTER)
                {
                    NativeMethods.UnregisterHotKey(Handle, ID);
                    ID = NOT_REGISTER;
                }
            }

            /// <summary>
            /// グローバルホットキーを解除してリソースを破棄します。
            /// </summary>
            /// <param name="disposing"></param>
            protected override void Dispose(bool disposing)
            {
                Unregister();
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// グローバルホットキーを登録します。
        /// </summary>
        /// <param name="modiferKey">修飾ホットキー(Ctrl,Alt,Shift)。</param>
        /// <param name="keys">ホットキー。</param>
        public void Register(ModiferKey modiferKey, Keys keys)
        {
            _HostForm?.Register(modiferKey, keys);
        }

        /// <summary>
        /// グローバルホットキーを解除します。
        /// </summary>
        public void Unregister()
        {
            _HostForm?.Unregister();
        }

        /// <summary>
        /// グローバルホットキーを解除してリソースを破棄します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            _HostForm.Dispose();
            base.Dispose(disposing);
        }
    }
    #endregion

    #region ModiferKey
    /// <summary>
    /// 修飾ホットキーを指定します。
    /// </summary>
    public enum ModiferKey : uint
    {
        /// <summary>修飾ホットキーは無しです。</summary>
        None = 0,
        /// <summary>修飾ホットキーはAltキーです。</summary>
        Alt = 1,
        /// <summary>修飾ホットキーはControlキーです。</summary>
        Control = 2,
        /// <summary>修飾ホットキーはShiftキーです。</summary>
        Shift = 4,
        /// <summary>修飾ホットキーはAlt+Controlキーです。</summary>
        AltControl = 3,
        /// <summary>修飾ホットキーはAlt+Shiftキーです。</summary>
        AltShift = 5,
        /// <summary>修飾ホットキーはControl+Shiftキーです。</summary>
        ControlShift = 6,
        /// <summary>修飾ホットキーはAlt+Control+Shiftキーです。</summary>
        AltControlShift = 7
    }
    #endregion

    #region HotkeyEventArgs
    /// <summary>
    /// HotkeyPressのイベントデータを提供します。
    /// </summary>
    public class HotkeyEventArgs : EventArgs
    {
        /// <summary>ホットキーIDを取得します。</summary>
        public int HotkeyID { get; private set; }

        /// <summary>修飾ホットキー(Ctrl,Alt,Shift)を取得します。</summary>
        public ModiferKey ModiferKey { get; private set; }

        /// <summary>ホットキーを取得します。</summary>
        public Keys HotKey { get; private set; }

        /// <summary>
        /// <see cref="HotkeyEventArgs"/>クラスインスタンスを初期化します。
        /// </summary>
        /// <param name="id">ホットキーID。</param>
        /// <param name="modiferKey">修飾ホットキー(Ctrl,Alt,Shift)。</param>
        /// <param name="key">ホットキー。</param>
        public HotkeyEventArgs(int id, ModiferKey modiferKey, Keys key)
        {
            HotkeyID = id;
            ModiferKey = modiferKey;
            HotKey = key;
        }
    }
    #endregion

}
