using System;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class ThrowBag : Form
    {
        private static BloodBankWSSoapClient _client;
        public ThrowBag()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var bbbid = int.Parse(textBox1.Text);
                _client.ThrowBag(bbbid, "", "");
                label3.Text = @"Done!";
            }
            catch (FormatException fex)
            {
                label3.Text = fex.Message;
            }
            catch
            {
                label3.Text = @"Invalid BagId";
            }


        }
    }
}
