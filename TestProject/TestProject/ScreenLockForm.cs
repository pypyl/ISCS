using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestProject
{
    /// <summary>
    /// ScreenLock 폼
    /// </summary>
    public partial class ScreenLockForm : Form
    {
        #region Field

        /// <summary>
        /// 키보드 후킹 처리 대리자
        /// </summary>
        private static ProcessKeyboardHookDelegate _processKeyboardHookDelegate = ProcessKeyboardHook;

        /// <summary>
        /// 후킹 ID
        /// </summary>
        private static int _hookID = 0;


        /// <summary>
        /// WH_KEYBOARD_LL
        /// </summary>
        private const int WH_KEYBOARD_LL = 13;

        /// <summary>
        /// WM_KEYDOWN
        /// </summary>
        private const int WM_KEYDOWN = 0x0100;

        /// <summary>
        /// WM_KEYUP
        /// </summary>
        private const int WM_KEYUP = 0x0101;

        /// <summary>
        /// WM_SYSKEYDOWN
        /// </summary>
        private const int WM_SYSKEYDOWN = 0x0104;

        /// <summary>
        /// WM_SYSKEYUP
        /// </summary>
        private const int WM_SYSKEYUP = 0x0105;


        /// <summary>
        /// 화면 사각형
        /// </summary>
        private Rectangle screenRectangle = Screen.PrimaryScreen.Bounds;

        /// <summary>
        /// 마우스 X 좌표
        /// </summary>
        private int mouseX = 0;

        /// <summary>
        /// 마우스 Y 좌표
        /// </summary>
        private int mouseY = 0;

        /// <summary>
        /// 스크린 세이버 중단 가능 여부
        /// </summary>
        private bool canStopScreenSaver = true;

        /// <summary>
        /// 난수 발생기
        /// </summary>
        private Random random = new Random();


        #endregion

        #region 키보드 저수준 후킹 구조체 - KBDLLHOOKSTRUCT

        /// <summary>
        /// 키보드 저수준 후킹 구조체
        /// </summary>
        public struct KBDLLHOOKSTRUCT
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////// Field
            ////////////////////////////////////////////////////////////////////////////////////////// Public

            #region Field

            /// <summary>
            /// 가상 키 코드
            /// </summary>
            public int VirtualKeyCode;

            /// <summary>
            /// 스캔 코드
            /// </summary>
            public int ScanCode;

            /// <summary>
            /// 플래그
            /// </summary>
            public int Flags;

            /// <summary>
            /// 부가 정보
            /// </summary>
            public int ExtraInfo;

            #endregion
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Delegate
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region 키보드 후킹 처리 대리자 - ProcessKeyboardHookDelegate(code, wordParameter, longParameter)

        /// <summary>
        /// 키보드 후킹 처리 대리자
        /// </summary>
        /// <param name="code">코드</param>
        /// <param name="wordParameter">WORD 매개 변수</param>
        /// <param name="longParameter">LONG 매개 변수</param>
        /// <returns>처리 결과</returns>
        private delegate int ProcessKeyboardHookDelegate(int code, int wordParameter, ref KBDLLHOOKSTRUCT longParameter);

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Import
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Private

        #region 윈도우 후킹 설정하기 - SetWindowsHookEx(hookID, processKeyboardHookDelegate, moduleHandle, threadID)

        /// <summary>
        /// 윈도우 후킹 설정하기
        /// </summary>
        /// <param name="hookID">후킹 ID</param>
        /// <param name="processKeyboardHookDelegate">키보드 후킹 처리 대리자</param>
        /// <param name="moduleHandle">모듈 핸들</param>
        /// <param name="threadID">스레드 ID</param>
        /// <returns>처리 결과</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int SetWindowsHookEx(int hookID, ProcessKeyboardHookDelegate processKeyboardHookDelegate, IntPtr moduleHandle, uint threadID);

        #endregion
        #region 윈도우 후킹 해제하기 - UnhookWindowsHookEx(hookHandle)

        /// <summary>
        /// 윈도우 후킹 해제하기
        /// </summary>
        /// <param name="hookHandle">후킹 핸들</param>
        /// <returns>처리 결과</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(int hookHandle);

        #endregion
        #region 다음 후킹 호출하기 - CallNextHookEx(hookHandle, code, wordParameter, longParameter)

        /// <summary>
        /// 다음 후킹 호출하기
        /// </summary>
        /// <param name="hookHandle">후킹 핸들</param>
        /// <param name="code">코드</param>
        /// <param name="wordParameter">WORD 매개 변수</param>
        /// <param name="longParameter">LONG 매개 변수</param>
        /// <returns>처리 결과</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int CallNextHookEx(int hookHandle, int code, int wordParameter, ref KBDLLHOOKSTRUCT longParameter);

        #endregion
        #region 모듈 핸들 구하기 - GetModuleHandle(modulName)

        /// <summary>
        /// 모듈 핸들 구하기
        /// </summary>
        /// <param name="modulName">모듈명</param>
        /// <returns>모듈 핸들</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string modulName);

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Private

        #region 생성자 - MainForm()

        /// <summary>
        /// 생성자
        /// </summary>
        public ScreenLockForm()  
        {
            InitializeComponent();

            Load                += Form_Load;
            Click               += Form_Click;
            MouseDown           += Form_MouseDown;
            MouseMove           += Form_MouseMove;
            MouseClick          += Form_MouseClick;
        }

        #endregion
                
        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Private
        ////////////////////////////////////////////////////////////////////// Function

        #region 키보드 후킹 처리하기 - ProcessKeyboardHook(code, wordParameter, longParameter)

        /// <summary>
        /// 키보드 후킹 처리하기
        /// </summary>
        /// <param name="code">코드</param>
        /// <param name="wordParameter">WORD 매개 변수</param>
        /// <param name="longParameter">LONG 매개 변수</param>
        /// <returns>처리 결과</returns>
        private static int ProcessKeyboardHook(int code, int wordParameter, ref KBDLLHOOKSTRUCT longParameter)
        {
            bool result = false;

            switch(wordParameter)
            {
                case WM_KEYDOWN    :
                case WM_KEYUP      :
                case WM_SYSKEYDOWN :
                case WM_SYSKEYUP   :

                    result = ((longParameter.VirtualKeyCode == 0x09) && (longParameter.Flags == 0x20)) || // Alt + Tab
                             ((longParameter.VirtualKeyCode == 0x1B) && (longParameter.Flags == 0x20)) || // Alt + Esc
                             ((longParameter.VirtualKeyCode == 0x1B) && (longParameter.Flags == 0x00)) || // Ctrl + Esc
                             ((longParameter.VirtualKeyCode == 0x5B) && (longParameter.Flags == 0x01)) || // Left Windows Key
                             ((longParameter.VirtualKeyCode == 0x5C) && (longParameter.Flags == 0x01)) || // Right Windows Key
                             ((longParameter.VirtualKeyCode == 0x73) && (longParameter.Flags == 0x20));   // Alt + F4

                    break;
            }

            if(result == true)
            {
                return 1;
            }
            else
            {
                return CallNextHookEx(0, code, wordParameter, ref longParameter);
            }
        }

        #endregion

        #region 폼 로드시 처리하기 - Form_Load(sender, e)

        /// <summary>
        /// 폼 로드시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        public void Form_Load(object sender, EventArgs e)
        {
            this.canStopScreenSaver = false;

            DisableTaskManager();
            _hookID = SetHook(_processKeyboardHookDelegate);

            StopScreenSaver();
        }

        #endregion
        #region 폼 클릭시 처리하기 - Form_Click(sender, e)

        /// <summary>
        /// 폼 클릭시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void Form_Click(object sender, EventArgs e)
        {
            StopScreenSaver();
        }

        #endregion
        #region 폼 마우스 DOWN 처리하기 - Form_MouseDown(sender, e)

        /// <summary>
        /// 폼 마우스 DOWN 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            StopScreenSaver();
        }

        #endregion
        #region 폼 마우스 이동시 처리하기 - Form_MouseMove(sender, e)

        /// <summary>
        /// 폼 마우스 이동시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if((this.mouseX == 0) && (this.mouseY == 0))
            {
                this.mouseX = e.X;
                this.mouseY = e.Y;

                return;
            }
            else if((e.X != this.mouseX) || (e.Y != this.mouseY))
            {
                StopScreenSaver();
            }
        }

        #endregion
        #region 폼 마우스 클릭시 처리하기 - Form_MouseClick(sender, e)

        /// <summary>
        /// 폼 마우스 클릭시 처리하기
        /// </summary>
        private void Form_MouseClick(object sender, MouseEventArgs e)
        {
             StopScreenSaver();
        }

        #endregion

        ////////////////////////////////////////////////////////////////////// Function

        #region 태스크 관리자 비활성화 하기 - DisableTaskManager()

        /// <summary>
        /// 태스크 관리자 비활성화 하기
        /// </summary>
        /// <remarks>Ctrl + Alt + Delete 키 입력을 거부한다.</remarks>
        public static void DisableTaskManager()
        {
            RegistryKey registryKey;
            string      keyValue = "1";
            string      subKey   = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";

            try
            {
                registryKey = Registry.CurrentUser.CreateSubKey(subKey);
                registryKey.SetValue("DisableTaskMgr", keyValue);
                registryKey.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion
        #region 태스크 관리자 활성화 하기 - EnableTaskManager()

        /// <summary>
        /// 태스크 관리자 활성화 하기
        /// </summary>
        /// <remarks>Ctrl + Alt + Delete 키 입력을 허용한다.</remarks>
        public static void EnableTaskManager()
        {
            try
            {
                RegistryKey currentUserRegistryKey = Registry.CurrentUser;
                string      subKey                 = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
                RegistryKey registryKey            = currentUserRegistryKey.OpenSubKey(subKey);

                if(registryKey != null)
                {
                    currentUserRegistryKey.DeleteSubKeyTree(subKey);
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        #endregion
        #region 후킹 설정하기 - SetHook(processKeyboardHookDelegate)

        /// <summary>
        /// 후킹 설정하기
        /// </summary>
        /// <param name="processKeyboardHookDelegate">키보드 후킹 처리 대리자</param>
        /// <returns>처리 결과</returns>
        private static int SetHook(ProcessKeyboardHookDelegate processKeyboardHookDelegate)
        {
            using(Process process = Process.GetCurrentProcess())
            {
                using(ProcessModule processModule = process.MainModule)
                {
                    return SetWindowsHookEx(WH_KEYBOARD_LL, processKeyboardHookDelegate, GetModuleHandle(processModule.ModuleName), 0);
                }
            }
        }

        #endregion
        #region 스크린 세이버 중단하기 - StopScreenSaver()

        /// <summary>
        /// 스크린 세이버 중단하기
        /// </summary>
        private void StopScreenSaver()
        {
            if(this.canStopScreenSaver == true)
            {
                Cursor.Show();
                UnhookWindowsHookEx(_hookID);
                EnableTaskManager();
                Application.Exit();
            }
            else
            {
                Cursor.Show();
                InputPasswordForm popup = new InputPasswordForm();
    
                if(popup.ShowDialog() == DialogResult.OK)
                {
                    UnhookWindowsHookEx(_hookID);
                    EnableTaskManager();
                    this.Close();
                    //Application.ExitThread();
                    //popup.Close();
                    //this.Close();
                }
                else
                { 
                    Cursor.Hide();

                    this.mouseX = 0;
                    this.mouseY = 0;
                }
            }
        }

        #endregion
    }
}