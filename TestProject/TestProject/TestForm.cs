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

namespace TestProject
{
    public partial class TestForm : Form
    {
        private bool flag_TaskManager;
        private bool flag_Usb;

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
            MainForm popup = new MainForm();

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
            }
            else if (flag_Usb == true)
            {
                flag_Usb = false;
                registryKey.SetValue("Start", 4);
                this.label_Usb.ForeColor = Color.Red;
                this.label_Usb.Text = "OFF";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
