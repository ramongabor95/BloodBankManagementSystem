using System;
using System.ServiceModel;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class LoginForm : Form
    {
        private static int _bankId;
        private readonly BloodBankWSSoapClient _client;

        public static int GetBankId()
        {
            return _bankId;
        }
        public LoginForm()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (userNameBox.Text == "")
            {
                errorLabel.Text = @"*Username can't be empty";
            }
            else
            if (passwordBox.Text == "")
            {
                errorLabel.Text = @"*Password can't be empty";
            }
            else
            {
                var user = new Credentials
                {
                    UserName = userNameBox.Text,
                    Password = passwordBox.Text
                };
                try
                {
                    var response = _client.Login(user,"","");
                    if (response == 2)
                    {
                        errorLabel.Text = @"Username not found";
                    }
                    else if (response == 1)
                    {
                        errorLabel.Text = @"Username/Password mismatch";
                    }
                    else
                    {
                        _bankId = _client.GetBankIdByUsername(user.UserName, "", "");
                        if (user.UserName.Contains("MAIN"))
                        {
                            var mainform = new SelectDoctorForm();
                            Hide();
                            mainform.Show();
                        }
                        else
                        {
                            var reqform = new RequestsForm();
                            Hide();
                            reqform.Show();
                        }
                    }
                }
                catch (FaultException ex)
                {
                    errorLabel.Text = ex.Message;
                }
            }
        }

        private void changePasswordButton_Click(object sender, EventArgs e)
        {
            var chp = new ChangePasswordForm();
            Hide();
            chp.Show();
        }

        private void forgotPasswordButton_Click(object sender, EventArgs e)
        {
            var fgp = new ForgotPasswordForm();
            Hide();
            fgp.Show();
        }
        
    }
}
