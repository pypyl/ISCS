using System;
using System.IO;
using System.Windows.Forms;

namespace TestProject
{
    /// <summary>
    /// 비밀번호 저장 폼
    /// </summary>
    public partial class SavePasswordForm : Form
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - SavePasswordForm()

        /// <summary>
        /// 생성자
        /// </summary>
        public SavePasswordForm()
        {
            InitializeComponent();

            this.saveButton.Click += saveButton_Click;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region 저장 버튼 클릭시 처리하기 - saveButton_Click(sender, e)

        /// <summary>
        /// 저장 버튼 클릭시 처리하기
        /// </summary>
        /// <param name="sender">이벤트 발생자</param>
        /// <param name="e">이벤트 인자</param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(this.passwordTextBox.Text) && string.IsNullOrWhiteSpace(this.confirmationTextBox.Text))
            {
                if(this.passwordTextBox.Text != this.confirmationTextBox.Text)
                {
                    this.messageLabel.Text = "비밀번호가 다릅니다.";
                    
                    return;
                }
                else
                {
                    StreamWriter streamWriter = File.CreateText(@"config.ini");

                    string password = this.passwordTextBox.Text;

                    streamWriter.WriteLine(password);

                    streamWriter.Close();

                    MessageBox.Show("비밀번호가 저장되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;

                    Close();
                }
            }
            else
            {
                this.messageLabel.Text = "비밀번호를 입력하세요";
                
                return;
            }
        }

        #endregion
    }
}