using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestProject
{
    /// <summary>
    /// 패스워드 입력 폼
    /// </summary>
    public partial class InputPasswordForm : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Import
        ////////////////////////////////////////////////////////////////////////////////////////// Static
        //////////////////////////////////////////////////////////////////////////////// Private

        #region 윈도우 후킹 해제하기 - UnhookWindowsHookEx(hookHandle)

        /// <summary>
        /// 윈도우 후킹 해제하기
        /// </summary>
        /// <param name="hookHandle">후킹 핸들</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(int hookHandle);

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 패스워드
        /// </summary>
        private string password = null;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - InputPasswordForm()

        /// <summary>
        /// 생성자
        /// </summary>
        public InputPasswordForm()
        {
            InitializeComponent();

            Load                    += Form_Load;
            this.okButton.Click     += okButton_Click;
            this.cancelButton.Click += cancelButton_Click;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region 폼 로드시 처리하기 - Form_Load(sender, e)

        /// <summary>
        /// 폼 로드시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void Form_Load(object sender, EventArgs e)
        {
            FileInfo fileInfo = new FileInfo(@"config.ini");

            if(fileInfo.Exists == true)
            {
                StreamReader streamReader = File.OpenText(@"config.ini");

                if(streamReader != null)
                {
                    this.password = streamReader.ReadLine();
                }

                streamReader.Close();

                this.passwordTextBox.Focus();
            }
            else
            {
                Hide();

                SavePasswordForm frm3 = new SavePasswordForm();

                frm3.ShowDialog();
            }
        }

        #endregion

        #region OK 버튼 클릭시 처리하기 - okButton_Click(sender, e)

        /// <summary>
        /// OK 버튼 클릭시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if(password != this.passwordTextBox.Text.Trim())
            {
                this.messageLabel.Text = "인증 실패";

                return;
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        #endregion
        #region 취소 버튼 클릭시 처리하기 - cancelButton_Click(sender, e)

        /// <summary>
        /// 취소 버튼 클릭시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }

        #endregion
    }
}