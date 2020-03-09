using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//using System.Runtime.InteropServices;
using Microsoft.Win32;  // registry

using System.Threading;
using System.IO;

namespace TestProject
{
    public partial class TestForm : Form
    {
        private bool flag_TaskManager;
        private bool flag_Usb;

        private Thread thread_Regedit = null;
        private Thread thread_USB = null;
        private bool threadDoWork_Regedit = true;
        private bool threadDoWork_USB = true;

        private int count_Img = 0;

        public TestForm()
        {
            InitializeComponent();

            RegistryKey currentUserRegistryKey = Registry.CurrentUser;
            string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
            RegistryKey registryKey = currentUserRegistryKey.OpenSubKey(subKey);
            if (registryKey == null)
            {
                flag_TaskManager = true;
                this.label_TaskManager.ForeColor = Color.Green;
                this.label_TaskManager.Text = "ON";
            }
            else
            {
                flag_TaskManager = false;
                this.label_TaskManager.ForeColor = Color.Red;
                this.label_TaskManager.Text = "OFF";
            }

            RegistryKey registryKey_USB = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\USBSTOR", true);
            if (registryKey_USB.GetValue("Start").ToString() == "3")
            {
                flag_Usb = true;
                this.label_Usb.ForeColor = Color.Green;
                this.label_Usb.Text = "ON";
            }
            else if (registryKey_USB.GetValue("Start").ToString() == "4")
            {
                flag_Usb = false;
                this.label_Usb.ForeColor = Color.Red;
                this.label_Usb.Text = "OFF";
            }

        }

        private void btn_ScreenLock_Click(object sender, EventArgs e)
        {
            ScreenLockForm popup = new ScreenLockForm();

            popup.ShowDialog();
        }

        private void btn_TaskManager_Click(object sender, EventArgs e)
        {
            if (flag_TaskManager == false)          // 활성화
            {
                try
                {
                    RegistryKey currentUserRegistryKey = Registry.CurrentUser;
                    string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                    RegistryKey registryKey = currentUserRegistryKey.OpenSubKey(subKey);

                    if (registryKey != null)
                    {
                        currentUserRegistryKey.DeleteSubKeyTree(subKey);
                    }

                    flag_TaskManager = true;
                    this.label_TaskManager.ForeColor = Color.Green;
                    this.label_TaskManager.Text = "ON";
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
            else if (flag_TaskManager == true)      // 비활성화
            {
                RegistryKey registryKey;
                string keyValue = "1";
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

                try
                {
                    registryKey = Registry.CurrentUser.CreateSubKey(subKey);
                    registryKey.SetValue("DisableTaskMgr", keyValue);
                    registryKey.Close();

                    flag_TaskManager = false;
                    this.label_TaskManager.ForeColor = Color.Red;
                    this.label_TaskManager.Text = "OFF";
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btn_RemoveCb_Click(object sender, EventArgs e)
        {
            this.label_RemoveCb.Text = "제거완료"; 
            Clipboard.Clear();
            Delay(5000);
            this.label_RemoveCb.Text = " ";
        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        private void btn_RemoveTb_Click(object sender, EventArgs e)
        {
            this.textBox_Cb.Clear();
        }

        private void btn_Usb_Click(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\USBSTOR", true);
            if (flag_Usb == false)
            {
                flag_Usb = true;
                registryKey.SetValue("Start", 3);
                this.label_Usb.ForeColor = Color.Green;
                this.label_Usb.Text = "ON";
                this.checkBox_Usb.Enabled = true;

            }
            else if (flag_Usb == true)
            {
                flag_Usb = false;
                registryKey.SetValue("Start", 4);
                this.label_Usb.ForeColor = Color.Red;
                this.label_Usb.Text = "OFF";
                
                this.checkBox_Usb.Enabled = false;
                this.checkBox_Usb.Checked = false;

                if (this.checkBox_Usb.Checked == true)
                {
                    threadDoWork_USB = true;
                    thread_USB.Interrupt();
                    thread_USB.Join();
                }
            }
        }

        private void btn_Regedit_Click(object sender, EventArgs e)
        {
            if (threadDoWork_Regedit == true)
            {
                thread_Regedit = new Thread(ProcessThread_Regedit);
                threadDoWork_Regedit = false;
                this.label_Regedit.ForeColor = Color.Red;
                this.label_Regedit.Text = "OFF";
                thread_Regedit.IsBackground = true; // 프로그램 종료 시 스레드 종료
                thread_Regedit.Start();
            }
            else if (threadDoWork_Regedit == false)
            {
                threadDoWork_Regedit = true;
                this.label_Regedit.ForeColor = Color.Green;
                this.label_Regedit.Text = "ON";

                thread_Regedit.Interrupt();
                thread_Regedit.Join();
            }
        }

        private void ProcessThread_Regedit()
        {
            while (!threadDoWork_Regedit)
            {
                Process[] processList = Process.GetProcessesByName("regedit");
                if (processList.Length > 0)
                {
                    processList[0].Kill();
                    MessageBox.Show("관리자가 레지스트리 편집기를 사용하지 못하도록 했습니다.", "레지스트리 편집기", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                Delay(1500);
            }
        }

        private void checkBox_Usb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Usb.Checked == true)
            {
                thread_USB = new Thread(ProcessThread_USB);
                threadDoWork_USB = false;

                thread_USB.IsBackground = true; // 프로그램 종료 시 스레드 종료
                thread_USB.Start();
            }
            else if (this.checkBox_Usb.Checked == false)
            {
                threadDoWork_USB = true;
                thread_USB.Interrupt();
                thread_USB.Join();
            }
        }

        private void ProcessThread_USB()
        {
            while (!threadDoWork_USB)
            {
                DriveInfo[] diArray = DriveInfo.GetDrives();
                
                foreach (DriveInfo di in diArray)
                {
                    if (di.IsReady == true && di.DriveType == DriveType.Removable)
                    {
                        MessageBox.Show("USB 연결 확인 넌 ㅈ됐음", "헌병 출동", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                Delay(1500);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            count_Img += 1;
            if (count_Img == 4)
            {
                count_Img = 0;
                Image popup = new Image();
                popup.Show();
            }
        }

        private void 메뉴3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 메뉴2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image popup = new Image();
            popup.Show();
        }

        private void 메뉴1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenLockForm popup = new ScreenLockForm();

            popup.ShowDialog();
        }
    }
}
