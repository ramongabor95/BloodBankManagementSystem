using System;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class ChangePasswordForm : Form
    {
        private readonly BloodBankWSSoapClient _client;
        public ChangePasswordForm()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            Hide();
            login.Show();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorLabel.Text = @"Please insert a username!";
                return;
            }
            if (oldPasswordBox.Text == string.Empty)
            {
                errorLabel.Text = @"Please insert your old password!";
                return;
            }
            if (newPasswordBox.Text == string.Empty)
            {
                errorLabel.Text = @"Please insert your new password!";
                return;
            }
            if (confirmPasswordBox.Text == string.Empty)
            {
                errorLabel.Text = @"Please confirm your new password!";
                return;
            }
            if (!newPasswordBox.Text.Equals(confirmPasswordBox.Text))
            {
                errorLabel.Text = @"New Password / Confirm Password mismatch";
                return;
            }

            var chCl = new ChangePassCredentials
            {
                Username = textBox1.Text,
                OldPass = oldPasswordBox.Text,
                NewPass = newPasswordBox.Text
            };

            var resp = _client.ChangePassword(chCl,"","");
            switch (resp)
            {
                case 4:
                    errorLabel.Text = @"Username not found!";
                    break;
                case 3:
                    errorLabel.Text = @"That is not your old password";
                    break;
                case 2:
                    errorLabel.Text = @"New password can't be old password";
                    break;
                case 0:
                    var login = new LoginForm();
                    Hide();
                    login.Show();
                    break;
                default:
                    throw new Exception("Something went wrong");
            }
        }
    }
}
