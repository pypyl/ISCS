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
using Microsoft.Win32;
using System.Threading;
using System.IO;

namespace TestProject
{
    /// <summary>
    /// 메인폼
    /// </summary>
    public partial class MainForm : Form
    {
        #region field

        /// <summary>
        /// 작업관리자 Flag
        /// </summary>
        private bool flag_TaskManager;

        /// <summary>
        /// USB 제어 Flag
        /// </summary>
        private bool flag_Usb;

        /// <summary>
        /// 레지스트리 편집기 감지 스레드
        /// </summary>
        private Thread thread_Regedit = null;

        /// <summary>
        /// USB 감지 스레드
        /// </summary>
        private Thread thread_USB = null;

        /// <summary>
        /// 레지스트리 편집기 감지 스레드에 사용되는 bool 변수
        /// </summary>
        private bool threadDoWork_Regedit = true;

        /// <summary>
        /// USB 감지 스레드에 사용되는 bool 변수
        /// </summary>
        private bool threadDoWork_USB = true;

        /// <summary>
        /// USB 제어하는 레지스터키
        /// </summary>
        RegistryKey registryKey_USB = Registry.LocalMachine.OpenSubKey(@"SYSTEM\CurrentControlSet\services\USBSTOR", true);

        /// <summary>
        /// Image.cs 로드하기 위한 카운터 변수
        /// </summary>
        private int count_Img = 0;

        #endregion field

        #region 생성자 - MainForm()

        /// <summary>
        /// 생성자
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            #region 레지스트리 편집기 활성화 유무 판단
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

            #endregion 레지스트리 편집기 활성화 유무 판단
            #region USB 제어 활성화 유무 판단

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

            #endregion USB 제어 활성화 유무 판단
        }

        #endregion MainForm()

        #region 딜레이 함수 - Delay(int MS)

        /// <summary>
        /// 딜레이 함수 (Sleep 함수와 기능 같음)
        /// </summary>
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

        #endregion

        #region 스크린 락 버튼 클릭 시 처리하기 - btn_ScreenLock_Click(object sender, EventArgs e)

        /// <summary>
        /// 스크린 락 버튼 클릭 시 처리하기
        /// </summary>
        private void btn_ScreenLock_Click(object sender, EventArgs e)
        {
            ScreenLockForm popup = new ScreenLockForm();

            popup.ShowDialog();
        }

        #endregion 스크린 락 버튼 클릭 시 처리하기 - btn_ScreenLock_Click(object sender, EventArgs e)
        #region 작업관리자 버튼 클릭 시 처리하기 - btn_TaskManager_Click(object sender, EventArgs e)

        /// <summary>
        /// 작업관리자 버튼 클릭 시 처리하기
        /// </summary>
        private void btn_TaskManager_Click(object sender, EventArgs e)
        {
            if (flag_TaskManager == false)          // 활성화하기
            {
                try
                {
                    RegistryKey currentUserRegistryKey = Registry.CurrentUser;
                    string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                    RegistryKey registryKey = currentUserRegistryKey.OpenSubKey(subKey);

                    if (registryKey != null)
                    {
                        currentUserRegistryKey.DeleteSubKeyTree(subKey);    //  비활성화 시키는 키를 제거
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
            else if (flag_TaskManager == true)      // 비활성화하기
            {
                RegistryKey registryKey;
                string keyValue = "1";
                string subKey = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                try
                {
                    registryKey = Registry.CurrentUser.CreateSubKey(subKey);
                    registryKey.SetValue("DisableTaskMgr", keyValue);       // 비활성화 시키는 키 생성
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

        #endregion 작업관리자 버튼 클릭 시 처리하기 - btn_TaskManager_Click(object sender, EventArgs e)
        #region 클립보드 제거 버튼 - btn_RemoveCb_Click(object sender, EventArgs e)

        /// <summary>
        /// 클립보드 제거 버튼
        /// </summary>
        private void btn_RemoveCb_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
            this.label_RemoveCb.Text = "제거완료";
            Delay(5000);                            // Sleep 함수와 기능이 같고 5000ms 지연시킨다, 지연하는 동안 동작이 가능하다
            this.label_RemoveCb.Text = " ";
        }

        #endregion 클립보드 제거 버튼 - btn_RemoveCb_Click(object sender, EventArgs e)
        #region 텍스트박스 비우는 버튼 - btn_RemoveTb_Click(object sender, EventArgs e)

        /// <summary>
        /// 텍스트박스 비우는 버튼
        /// </summary>
        private void btn_RemoveTb_Click(object sender, EventArgs e)
        {
            this.textBox_Cb.Clear();
        }

        #endregion
        #region USB 제어 버튼 클릭 시 처리하기 - btn_Usb_Click(object sender, EventArgs e)

        /// <summary>
        /// USB 제어 버튼 클릭 시 처리하기
        /// </summary>
        private void btn_Usb_Click(object sender, EventArgs e)
        {
            if (flag_Usb == false)                          // 활성화하기
            {
                registryKey_USB.SetValue("Start", 3);       // 레지스터 수정

                this.label_Usb.ForeColor = Color.Green;
                this.label_Usb.Text = "ON";

                flag_Usb = true;
                this.checkBox_Usb.Enabled = true;
            }
            else if (flag_Usb == true)                      // 비활성화하기
            {
                registryKey_USB.SetValue("Start", 4);       // 레지스터 수정
                this.label_Usb.ForeColor = Color.Red;
                this.label_Usb.Text = "OFF";

                flag_Usb = false;
                this.checkBox_Usb.Enabled = false;
                this.checkBox_Usb.Checked = false;

                if (this.checkBox_Usb.Checked == true)      // 실시간 감지 중지
                {
                    threadDoWork_USB = true;
                    thread_USB.Interrupt();
                    thread_USB.Join();
                }
            }
        }

        #endregion USB 제어 버튼 클릭 시 처리하기 - btn_Usb_Click(object sender, EventArgs e)
        #region 레지스트리 편집기 제어 버튼 클릭 시 처리하기 - btn_Regedit_Click(object sender, EventArgs e)

        /// <summary>
        /// 레지스트리 편집기 제어 버튼 클릭 시 처리하기
        /// </summary>
        private void btn_Regedit_Click(object sender, EventArgs e)
        {
            if (threadDoWork_Regedit == true)                           // 비활성화 하기
            {
                threadDoWork_Regedit = false;

                this.label_Regedit.ForeColor = Color.Red;
                this.label_Regedit.Text = "OFF";

                thread_Regedit = new Thread(ProcessThread_Regedit);
                thread_Regedit.IsBackground = true;                     // 프로그램 종료 시 스레드 종료 옵션
                thread_Regedit.Start();                                 // 스레드 실행
            }
            else if (threadDoWork_Regedit == false)                     // 활성화 하기
            {
                threadDoWork_Regedit = true;

                this.label_Regedit.ForeColor = Color.Green;
                this.label_Regedit.Text = "ON";

                thread_Regedit.Interrupt();                             // Interrupt와 Join 둘 다 스레드 종료 함수
                thread_Regedit.Join();
            }
        }

        #endregion 레지스트리 편집기 제어 버튼 클릭 시 처리하기 - btn_Regedit_Click(object sender, EventArgs e)

        #region USB 실시간 감지 체크박스 - checkBox_Usb_CheckedChanged(object sender, EventArgs e)

        /// <summary>
        /// USB 실시간 감지 체크박스
        /// </summary>
        private void checkBox_Usb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox_Usb.Checked == true)              // 체크할 경우 실시간감지를 한다
            {
                threadDoWork_USB = false;

                thread_USB = new Thread(ProcessThread_USB);
                thread_USB.IsBackground = true; // 프로그램 종료 시 스레드 종료하는 옵션
                thread_USB.Start();
            }
            else if (this.checkBox_Usb.Checked == false)        // 체크를 취소할 경우 실시간 감지 스레드 중지
            {
                threadDoWork_USB = true;

                thread_USB.Interrupt();                         // 스레드를 중지하는 함수 (Interrupt, Join)
                thread_USB.Join();
            }
        }

        #endregion USB 실시간 감지 체크박스 - checkBox_Usb_CheckedChanged(object sender, EventArgs e)

        #region 레지스트리 편집기 프로세스를 찾는 스레드 - ProcessThread_Regedit()

        /// <summary>
        /// 레지스트리 편집기 프로세스를 찾는 스레드
        /// </summary>
        private void ProcessThread_Regedit()
        {
            while (!threadDoWork_Regedit)
            {
                Process[] processList = Process.GetProcessesByName("regedit");  // regedit 프로세스 발견 시 processList 배열에 넣는다
                if (processList.Length > 0)                                     // processList 배열에 하나라도 값 입력되면 프로세스 Kill
                {
                    processList[0].Kill();
                    MessageBox.Show("관리자가 레지스트리 편집기를 사용하지 못하도록 했습니다.", "레지스트리 편집기", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                Delay(1500);
            }
        }

        #endregion 레지스트리 편집기 프로세스를 찾는 스레드 - ProcessThread_Regedit()
        #region USB 실시간 감지하는 스레드 - ProcessThread_USB()

        /// <summary>
        /// USB 실시간 감지하는 스레드
        /// </summary>
        private void ProcessThread_USB()
        {
            while (!threadDoWork_USB)
            {
                DriveInfo[] diArray = DriveInfo.GetDrives();            // 장치 정보들을 diArray 배열에 넣는다
                foreach (DriveInfo di in diArray)                       // 장치 정보들이 있는 diArray 배열에 USB가 있을 경우 
                {
                    if (di.IsReady == true && di.DriveType == DriveType.Removable)
                    {
                        MessageBox.Show("USB 연결 확인 넌 ㅈ됐음", "헌병 출동", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Delay(1500);
            }
        }

        #endregion USB 실시간 감지하는 스레드 - ProcessThread_USB()

        #region 이스터에그 - label1_Click(object sender, EventArgs e)

        /// <summary>
        /// Internal Security Controls System 문구 5번 클릭시 처리
        /// </summary>
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

        #endregion 이스터에그 - label1_Click(object sender, EventArgs e)

        #region 트레이 아이콘 메뉴들

        /// <summary>
        /// 프로그램 종료
        /// </summary>
        private void 메뉴3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Image.cs
        /// </summary>
        private void 메뉴2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Image popup = new Image();
            popup.Show();
        }

        /// <summary>
        /// ScreenLock
        /// </summary>
        private void 메뉴1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenLockForm popup = new ScreenLockForm();

            popup.ShowDialog();
        }

        #endregion 트레이 아이콘 메뉴들
    }
}
