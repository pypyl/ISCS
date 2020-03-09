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

namespace TestProject
{
    public partial class TestForm : Form
    {
        private bool flag_TaskManager;

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
        }
    }
}
