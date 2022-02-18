namespace AutoClick
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rdoLeft = new System.Windows.Forms.RadioButton();
            this.rdoRight = new System.Windows.Forms.RadioButton();
            this.nmInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.clickTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkRunStartup = new System.Windows.Forms.CheckBox();
            this.chkHotkeyCtrl = new System.Windows.Forms.CheckBox();
            this.chkHotkeyAlt = new System.Windows.Forms.CheckBox();
            this.chkHotkeyShift = new System.Windows.Forms.CheckBox();
            this.txtHotkey = new System.Windows.Forms.TextBox();
            this.nfIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.終了ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.hotkey = new AutoClick.Hotkey(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nmInterval)).BeginInit();
            this.cmMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoLeft
            // 
            this.rdoLeft.AutoSize = true;
            this.rdoLeft.Checked = true;
            this.rdoLeft.Location = new System.Drawing.Point(79, 13);
            this.rdoLeft.Margin = new System.Windows.Forms.Padding(4);
            this.rdoLeft.Name = "rdoLeft";
            this.rdoLeft.Size = new System.Drawing.Size(70, 19);
            this.rdoLeft.TabIndex = 0;
            this.rdoLeft.TabStop = true;
            this.rdoLeft.Text = "LeftClick";
            this.toolTip.SetToolTip(this.rdoLeft, "クリック動作を左クリックに設定します。");
            this.rdoLeft.UseVisualStyleBackColor = true;
            // 
            // rdoRight
            // 
            this.rdoRight.AutoSize = true;
            this.rdoRight.Location = new System.Drawing.Point(167, 13);
            this.rdoRight.Margin = new System.Windows.Forms.Padding(4);
            this.rdoRight.Name = "rdoRight";
            this.rdoRight.Size = new System.Drawing.Size(78, 19);
            this.rdoRight.TabIndex = 0;
            this.rdoRight.Text = "RightClick";
            this.toolTip.SetToolTip(this.rdoRight, "クリック動作を右クリックに設定します。");
            this.rdoRight.UseVisualStyleBackColor = true;
            // 
            // nmInterval
            // 
            this.nmInterval.Location = new System.Drawing.Point(79, 40);
            this.nmInterval.Margin = new System.Windows.Forms.Padding(4);
            this.nmInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nmInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmInterval.Name = "nmInterval";
            this.nmInterval.Size = new System.Drawing.Size(54, 23);
            this.nmInterval.TabIndex = 3;
            this.nmInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip.SetToolTip(this.nmInterval, "クリック動作の間隔を秒単位で指定します。");
            this.nmInterval.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Interval ：";
            // 
            // clickTimer
            // 
            this.clickTimer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "sec";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "HotKey ：";
            // 
            // chkRunStartup
            // 
            this.chkRunStartup.AutoSize = true;
            this.chkRunStartup.Checked = true;
            this.chkRunStartup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRunStartup.Location = new System.Drawing.Point(13, 101);
            this.chkRunStartup.Margin = new System.Windows.Forms.Padding(4);
            this.chkRunStartup.Name = "chkRunStartup";
            this.chkRunStartup.Size = new System.Drawing.Size(100, 19);
            this.chkRunStartup.TabIndex = 11;
            this.chkRunStartup.Text = "Run at startup";
            this.toolTip.SetToolTip(this.chkRunStartup, "PC起動時にアプリを起動するかどうかを指定します。");
            this.chkRunStartup.UseVisualStyleBackColor = true;
            // 
            // chkHotkeyCtrl
            // 
            this.chkHotkeyCtrl.AutoSize = true;
            this.chkHotkeyCtrl.Checked = true;
            this.chkHotkeyCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHotkeyCtrl.Location = new System.Drawing.Point(78, 74);
            this.chkHotkeyCtrl.Margin = new System.Windows.Forms.Padding(4);
            this.chkHotkeyCtrl.Name = "chkHotkeyCtrl";
            this.chkHotkeyCtrl.Size = new System.Drawing.Size(55, 19);
            this.chkHotkeyCtrl.TabIndex = 12;
            this.chkHotkeyCtrl.Text = "Ctrl +";
            this.toolTip.SetToolTip(this.chkHotkeyCtrl, "ホットキーにCtrlキーを使用するかを指定します。");
            this.chkHotkeyCtrl.UseVisualStyleBackColor = true;
            // 
            // chkHotkeyAlt
            // 
            this.chkHotkeyAlt.AutoSize = true;
            this.chkHotkeyAlt.Checked = true;
            this.chkHotkeyAlt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHotkeyAlt.Location = new System.Drawing.Point(135, 74);
            this.chkHotkeyAlt.Margin = new System.Windows.Forms.Padding(4);
            this.chkHotkeyAlt.Name = "chkHotkeyAlt";
            this.chkHotkeyAlt.Size = new System.Drawing.Size(52, 19);
            this.chkHotkeyAlt.TabIndex = 13;
            this.chkHotkeyAlt.Text = "Alt +";
            this.toolTip.SetToolTip(this.chkHotkeyAlt, "ホットキーにAltlキーを使用するかを指定します。");
            this.chkHotkeyAlt.UseVisualStyleBackColor = true;
            // 
            // chkHotkeyShift
            // 
            this.chkHotkeyShift.AutoSize = true;
            this.chkHotkeyShift.Location = new System.Drawing.Point(191, 74);
            this.chkHotkeyShift.Margin = new System.Windows.Forms.Padding(4);
            this.chkHotkeyShift.Name = "chkHotkeyShift";
            this.chkHotkeyShift.Size = new System.Drawing.Size(61, 19);
            this.chkHotkeyShift.TabIndex = 14;
            this.chkHotkeyShift.Text = "Shift +";
            this.toolTip.SetToolTip(this.chkHotkeyShift, "ホットキーにShiftキーを使用するかを指定します。");
            this.chkHotkeyShift.UseVisualStyleBackColor = true;
            // 
            // txtHotkey
            // 
            this.txtHotkey.Location = new System.Drawing.Point(256, 71);
            this.txtHotkey.Margin = new System.Windows.Forms.Padding(4);
            this.txtHotkey.MaxLength = 1;
            this.txtHotkey.Name = "txtHotkey";
            this.txtHotkey.Size = new System.Drawing.Size(21, 23);
            this.txtHotkey.TabIndex = 15;
            this.txtHotkey.Text = "L";
            this.toolTip.SetToolTip(this.txtHotkey, "ホットキーに使用するキーを指定します。");
            this.txtHotkey.TextChanged += new System.EventHandler(this.txtHotkey_TextChanged);
            // 
            // nfIcon
            // 
            this.nfIcon.ContextMenuStrip = this.cmMenu;
            this.nfIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("nfIcon.Icon")));
            this.nfIcon.Text = "AutoClick";
            this.nfIcon.Visible = true;
            this.nfIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.nfIcon_MouseDoubleClick);
            // 
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.終了ToolStripMenuItem});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(99, 26);
            // 
            // 終了ToolStripMenuItem
            // 
            this.終了ToolStripMenuItem.Name = "終了ToolStripMenuItem";
            this.終了ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.終了ToolStripMenuItem.Text = "終了";
            this.終了ToolStripMenuItem.Click += new System.EventHandler(this.終了ToolStripMenuItem_Click);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 16;
            this.label1.Text = "Button  ：";
            // 
            // hotkey
            // 
            this.hotkey.HotKey = System.Windows.Forms.Keys.None;
            this.hotkey.ModiferKey = AutoClick.ModiferKey.None;
            this.hotkey.HotkeyPress += new System.EventHandler<AutoClick.HotkeyEventArgs>(this.hotkey_HotkeyPress);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 132);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHotkey);
            this.Controls.Add(this.chkHotkeyShift);
            this.Controls.Add(this.chkHotkeyAlt);
            this.Controls.Add(this.chkHotkeyCtrl);
            this.Controls.Add(this.chkRunStartup);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmInterval);
            this.Controls.Add(this.rdoRight);
            this.Controls.Add(this.rdoLeft);
            this.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AutoClick";
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nmInterval)).EndInit();
            this.cmMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoLeft;
        private System.Windows.Forms.RadioButton rdoRight;
        private System.Windows.Forms.NumericUpDown nmInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer clickTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkRunStartup;
        private System.Windows.Forms.CheckBox chkHotkeyCtrl;
        private System.Windows.Forms.CheckBox chkHotkeyAlt;
        private System.Windows.Forms.CheckBox chkHotkeyShift;
        private System.Windows.Forms.TextBox txtHotkey;
        private System.Windows.Forms.NotifyIcon nfIcon;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem 終了ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private Hotkey hotkey;
        private System.Windows.Forms.Label label1;
    }
}

