using System;
using System.Globalization;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class ViewAnalysisDetails : Form
    {
        private readonly string _ssn;
        private readonly string _bbid;
        private readonly BloodBankWSSoapClient _client;

        public ViewAnalysisDetails(string ssn, string bbid)
        {
            _ssn = ssn;
            _bbid = bbid;
            _client = new BloodBankWSSoapClient();
            InitializeComponent();
        }

        private void ViewAnalysisDetails_Load(object sender, EventArgs e)
        {
            var bloodBag = _client.GetBloodBagById(_bbid);

            label20.Text = SelectDoctorForm.BankName;
            label21.Text = _bbid;
            label22.Text = _ssn;
            label23.Text = bloodBag.Rbc.ToString(CultureInfo.InvariantCulture);
            label24.Text = bloodBag.Hgb.ToString(CultureInfo.InvariantCulture);
            label25.Text = bloodBag.Hct.ToString(CultureInfo.InvariantCulture);
            label26.Text = bloodBag.Vsh.ToString(CultureInfo.InvariantCulture);
            label27.Text = bloodBag.Group;
            label28.Text = bloodBag.Mcv.ToString(CultureInfo.InvariantCulture);
            label29.Text = bloodBag.Mchc.ToString(CultureInfo.InvariantCulture);
            label30.Text = bloodBag.Wbc.ToString(CultureInfo.InvariantCulture);
            label31.Text = bloodBag.Plt.ToString(CultureInfo.InvariantCulture);
            label32.Text = bloodBag.Tgp.ToString(CultureInfo.InvariantCulture);
            label33.Text = bloodBag.Rh;
            label34.Text = bloodBag.AnticorpsHeC.ToString();
            label35.Text = bloodBag.AnticoprsHeB.ToString();
            label36.Text = bloodBag.AnticorpsLec.ToString();
            label37.Text = bloodBag.AnticorpsSif.ToString();
            label38.Text = bloodBag.AnticorpsHiv.ToString();
        }
    }
}
