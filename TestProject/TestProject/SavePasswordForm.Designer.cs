namespace TestProject
{
    partial class SavePasswordForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.confirmationLabel = new System.Windows.Forms.Label();
            this.confirmationTextBox = new System.Windows.Forms.TextBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(120, 20);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(130, 23);
            this.passwordTextBox.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.Location = new System.Drawing.Point(20, 20);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(100, 23);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "비밀번호";
            this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // confirmationLabel
            // 
            this.confirmationLabel.Location = new System.Drawing.Point(20, 50);
            this.confirmationLabel.Name = "confirmationLabel";
            this.confirmationLabel.Size = new System.Drawing.Size(100, 23);
            this.confirmationLabel.TabIndex = 3;
            this.confirmationLabel.Text = "확인";
            this.confirmationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // confirmationTextBox
            // 
            this.confirmationTextBox.Location = new System.Drawing.Point(120, 50);
            this.confirmationTextBox.Name = "confirmationTextBox";
            this.confirmationTextBox.PasswordChar = '*';
            this.confirmationTextBox.Size = new System.Drawing.Size(130, 23);
            this.confirmationTextBox.TabIndex = 2;
            // 
            // messageLabel
            // 
            this.messageLabel.ForeColor = System.Drawing.Color.Red;
            this.messageLabel.Location = new System.Drawing.Point(20, 85);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(230, 23);
            this.messageLabel.TabIndex = 4;
            this.messageLabel.Text = "결과";
            this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(260, 20);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 53);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "저장";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // SavePasswordForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(379, 122);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.confirmationLabel);
            this.Controls.Add(this.confirmationTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Font = new System.Drawing.Font("나눔고딕코딩", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SavePasswordForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "비밀번호 저장";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmationLabel;
        private System.Windows.Forms.TextBox confirmationTextBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button saveButton;
    }
}