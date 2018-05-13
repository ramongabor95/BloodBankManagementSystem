using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly BloodBankWSSoapClient _client;
        public ForgotPasswordForm()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

        private void resultLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            Hide();
            login.Show();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                errorLabel.Text = @"Please insert a username!";
                return;
            }
            if (textBox2.Text == string.Empty)
            {
                errorLabel.Text = @"Please insert your security answer";
                return;
            }
            try
            {
                var fp = new ForgotPassword
                {
                    Username = textBox1.Text,
                    SecAnswer = textBox2.Text
                };
                
                var res = _client.ForgotYourPassword(fp, "", "");
                switch (res)
                {
                    case 1:
                        errorLabel.Text = @"Username not found";
                        return;
                    case 2:
                        errorLabel.Text = @"That is not your security answer";
                        return;
                    case 0:
                        resultLabel.Text = "Your temporary password is: tempPass\n";
                        resultLabel.Text += @"You will be redirected in 30 seconds";
                        break;
                    default:
                        throw new Exception("Something went wrong");
                }

                await Task.Delay(3000);

                var login = new ChangePasswordForm();
                Hide();
                login.Show();
            }
            catch
            {
                errorLabel.Text = @"Something went wrong!";
            }
        }
    }
}
