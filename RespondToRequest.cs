using System;
using System.ServiceModel;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class RespondToRequest : Form
    {
        private readonly BloodBankWSSoapClient _client;

        public RespondToRequest()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var reqId = int.Parse(textBox1.Text);
                _client.RespondToRequest(reqId, "", "");
                label6.Text = @"You have successfully responded to this request!";
            }
            catch
            {
                label6.Text = @"Invalid responseId";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var bId = int.Parse(textBox2.Text);
                var add = _client.GetAddress(bId, "", "");

                var result = "City: " + add.City + "\n"
                             + "Country: " + add.Country + "\n"
                             + "PostalCode: " + add.PostalCode + "\n"
                             + "Phone:" + add.Phone + '\n'
                             + "Email: " + add.Email;

                label5.Text = result;
            }
            catch (FormatException fex)
            {
                label5.Text = fex.Message;
            }
            catch
            {
                label5.Text = @"Invalid bankId";
            }
        }
    }
}
