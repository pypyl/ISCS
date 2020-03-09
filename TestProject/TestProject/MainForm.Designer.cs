namespace TestProject
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_ScreenLock = new System.Windows.Forms.Button();
            this.btn_TaskManager = new System.Windows.Forms.Button();
            this.btn_Regedit = new System.Windows.Forms.Button();
            this.btn_Usb = new System.Windows.Forms.Button();
            this.btn_Cb = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_TaskManager = new System.Windows.Forms.Label();
            this.label_Regedit = new System.Windows.Forms.Label();
            this.label_Usb = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.메뉴1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.메뉴2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.메뉴3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Cb = new System.Windows.Forms.TextBox();
            this.label_RemoveCb = new System.Windows.Forms.Label();
            this.btn_RemoveTb = new System.Windows.Forms.Button();
            this.checkBox_Usb = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_ScreenLock
            // 
            this.btn_ScreenLock.Location = new System.Drawing.Point(43, 53);
            this.btn_ScreenLock.Name = "btn_ScreenLock";
            this.btn_ScreenLock.Size = new System.Drawing.Size(144, 43);
            this.btn_ScreenLock.TabIndex = 0;
            this.btn_ScreenLock.Text = "Screen Lock";
            this.btn_ScreenLock.UseVisualStyleBackColor = true;
            this.btn_ScreenLock.Click += new System.EventHandler(this.btn_ScreenLock_Click);
            // 
            // btn_TaskManager
            // 
            this.btn_TaskManager.Location = new System.Drawing.Point(43, 213);
            this.btn_TaskManager.Name = "btn_TaskManager";
            this.btn_TaskManager.Size = new System.Drawing.Size(144, 43);
            this.btn_TaskManager.TabIndex = 0;
            this.btn_TaskManager.Text = "Task Manager";
            this.btn_TaskManager.UseVisualStyleBackColor = true;
            this.btn_TaskManager.Click += new System.EventHandler(this.btn_TaskManager_Click);
            // 
            // btn_Regedit
            // 
            this.btn_Regedit.Location = new System.Drawing.Point(43, 262);
            this.btn_Regedit.Name = "btn_Regedit";
            this.btn_Regedit.Size = new System.Drawing.Size(144, 43);
            this.btn_Regedit.TabIndex = 0;
            this.btn_Regedit.Text = "Regedit";
            this.btn_Regedit.UseVisualStyleBackColor = true;
            this.btn_Regedit.Click += new System.EventHandler(this.btn_Regedit_Click);
            // 
            // btn_Usb
            // 
            this.btn_Usb.Location = new System.Drawing.Point(43, 311);
            this.btn_Usb.Name = "btn_Usb";
            this.btn_Usb.Size = new System.Drawing.Size(144, 43);
            this.btn_Usb.TabIndex = 0;
            this.btn_Usb.Text = "USB Control";
            this.btn_Usb.UseVisualStyleBackColor = true;
            this.btn_Usb.Click += new System.EventHandler(this.btn_Usb_Click);
            // 
            // btn_Cb
            // 
            this.btn_Cb.Location = new System.Drawing.Point(43, 102);
            this.btn_Cb.Name = "btn_Cb";
            this.btn_Cb.Size = new System.Drawing.Size(144, 43);
            this.btn_Cb.TabIndex = 0;
            this.btn_Cb.Text = "Remove Clipboard";
            this.btn_Cb.UseVisualStyleBackColor = true;
            this.btn_Cb.Click += new System.EventHandler(this.btn_RemoveCb_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(43, 410);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 43);
            this.button6.TabIndex = 0;
            this.button6.Text = "Folder Access";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(43, 459);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(144, 43);
            this.button8.TabIndex = 0;
            this.button8.Text = "Public Folder";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Internal Security Controls System";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_TaskManager
            // 
            this.label_TaskManager.AutoSize = true;
            this.label_TaskManager.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_TaskManager.ForeColor = System.Drawing.Color.Red;
            this.label_TaskManager.Location = new System.Drawing.Point(193, 228);
            this.label_TaskManager.Name = "label_TaskManager";
            this.label_TaskManager.Size = new System.Drawing.Size(31, 12);
            this.label_TaskManager.TabIndex = 2;
            this.label_TaskManager.Text = "OFF";
            // 
            // label_Regedit
            // 
            this.label_Regedit.AutoSize = true;
            this.label_Regedit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Regedit.ForeColor = System.Drawing.Color.Green;
            this.label_Regedit.Location = new System.Drawing.Point(193, 277);
            this.label_Regedit.Name = "label_Regedit";
            this.label_Regedit.Size = new System.Drawing.Size(25, 12);
            this.label_Regedit.TabIndex = 2;
            this.label_Regedit.Text = "ON";
            // 
            // label_Usb
            // 
            this.label_Usb.AutoSize = true;
            this.label_Usb.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Usb.ForeColor = System.Drawing.Color.Red;
            this.label_Usb.Location = new System.Drawing.Point(193, 326);
            this.label_Usb.Name = "label_Usb";
            this.label_Usb.Size = new System.Drawing.Size(31, 12);
            this.label_Usb.TabIndex = 2;
            this.label_Usb.Text = "OFF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(193, 474);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "미완성";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴1ToolStripMenuItem,
            this.메뉴2ToolStripMenuItem,
            this.메뉴3ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 70);
            // 
            // 메뉴1ToolStripMenuItem
            // 
            this.메뉴1ToolStripMenuItem.Name = "메뉴1ToolStripMenuItem";
            this.메뉴1ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.메뉴1ToolStripMenuItem.Text = "화면 잠금";
            this.메뉴1ToolStripMenuItem.Click += new System.EventHandler(this.메뉴1ToolStripMenuItem_Click);
            // 
            // 메뉴2ToolStripMenuItem
            // 
            this.메뉴2ToolStripMenuItem.Name = "메뉴2ToolStripMenuItem";
            this.메뉴2ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.메뉴2ToolStripMenuItem.Text = "정보";
            this.메뉴2ToolStripMenuItem.Click += new System.EventHandler(this.메뉴2ToolStripMenuItem_Click);
            // 
            // 메뉴3ToolStripMenuItem
            // 
            this.메뉴3ToolStripMenuItem.Name = "메뉴3ToolStripMenuItem";
            this.메뉴3ToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.메뉴3ToolStripMenuItem.Text = "종료";
            this.메뉴3ToolStripMenuItem.Click += new System.EventHandler(this.메뉴3ToolStripMenuItem_Click);
            // 
            // textBox_Cb
            // 
            this.textBox_Cb.Font = new System.Drawing.Font("굴림", 9F);
            this.textBox_Cb.Location = new System.Drawing.Point(43, 152);
            this.textBox_Cb.Name = "textBox_Cb";
            this.textBox_Cb.Size = new System.Drawing.Size(144, 21);
            this.textBox_Cb.TabIndex = 3;
            this.textBox_Cb.Text = "테스트 영역";
            // 
            // label_RemoveCb
            // 
            this.label_RemoveCb.AutoSize = true;
            this.label_RemoveCb.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_RemoveCb.ForeColor = System.Drawing.Color.Black;
            this.label_RemoveCb.Location = new System.Drawing.Point(193, 117);
            this.label_RemoveCb.Name = "label_RemoveCb";
            this.label_RemoveCb.Size = new System.Drawing.Size(0, 12);
            this.label_RemoveCb.TabIndex = 2;
            // 
            // btn_RemoveTb
            // 
            this.btn_RemoveTb.Location = new System.Drawing.Point(193, 152);
            this.btn_RemoveTb.Name = "btn_RemoveTb";
            this.btn_RemoveTb.Size = new System.Drawing.Size(47, 22);
            this.btn_RemoveTb.TabIndex = 4;
            this.btn_RemoveTb.Text = "Clear";
            this.btn_RemoveTb.UseVisualStyleBackColor = true;
            this.btn_RemoveTb.Click += new System.EventHandler(this.btn_RemoveTb_Click);
            // 
            // checkBox_Usb
            // 
            this.checkBox_Usb.AutoSize = true;
            this.checkBox_Usb.Location = new System.Drawing.Point(67, 360);
            this.checkBox_Usb.Name = "checkBox_Usb";
            this.checkBox_Usb.Size = new System.Drawing.Size(92, 16);
            this.checkBox_Usb.TabIndex = 5;
            this.checkBox_Usb.Text = " 실시간 검사";
            this.checkBox_Usb.UseVisualStyleBackColor = true;
            this.checkBox_Usb.CheckedChanged += new System.EventHandler(this.checkBox_Usb_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(193, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "미완성";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(262, 542);
            this.Controls.Add(this.checkBox_Usb);
            this.Controls.Add(this.btn_RemoveTb);
            this.Controls.Add(this.textBox_Cb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Usb);
            this.Controls.Add(this.label_RemoveCb);
            this.Controls.Add(this.label_Regedit);
            this.Controls.Add(this.label_TaskManager);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btn_Cb);
            this.Controls.Add(this.btn_Usb);
            this.Controls.Add(this.btn_Regedit);
            this.Controls.Add(this.btn_TaskManager);
            this.Controls.Add(this.btn_ScreenLock);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ISCS";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ScreenLock;
        private System.Windows.Forms.Button btn_TaskManager;
        private System.Windows.Forms.Button btn_Regedit;
        private System.Windows.Forms.Button btn_Usb;
        private System.Windows.Forms.Button btn_Cb;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_TaskManager;
        private System.Windows.Forms.Label label_Regedit;
        private System.Windows.Forms.Label label_Usb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메뉴2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 메뉴3ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_Cb;
        private System.Windows.Forms.Label label_RemoveCb;
        private System.Windows.Forms.Button btn_RemoveTb;
        private System.Windows.Forms.CheckBox checkBox_Usb;
        private System.Windows.Forms.Label label3;
    }
}