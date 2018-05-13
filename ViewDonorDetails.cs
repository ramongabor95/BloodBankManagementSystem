using System;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class ViewDonorDetails : Form
    {
        private readonly string _ssn;
        private static DonorDetails _donor;
        private int _option;
        public ViewDonorDetails(string ssn, int opt)
        {
            InitializeComponent();
            _ssn = ssn;
            _option = opt;
        }

        private void ViewDonorDetails_Load(object sender, EventArgs e)
        {
            _donor = new DonorDetails();
            var source = _option == 1 ? MainForm.ResultsViewdonors : MainForm.ResultsSearchDonors;
            foreach (var dd in source)
            {
                if (dd.SocialSecurityNumber.Trim() == _ssn)
                    _donor = dd;
            }

            label16.Text = SelectDoctorForm.BankName;
            label17.Text = _donor.SocialSecurityNumber;
            label18.Text = _donor.FirstName;
            label19.Text = _donor.LastName;
            label20.Text = _donor.PhoneNumber;
            label21.Text = _donor.City;
            label22.Text = _donor.Country;
            label23.Text = _donor.PostalCode;
            label24.Text = _donor.IsEmergencyDonor.ToString();
            label25.Text = _donor.NumberOfDonations.ToString();
            label26.Text = _donor.Occupation;
            label27.Text = _donor.Industry;
            label28.Text = _donor.BirthDay.ToLongDateString();
            label29.Text = _donor.Age.ToString();
            label30.Text = _donor.Timestamp.ToShortDateString();
            label32.Text = _donor.Gender.ToString();
            label41.Text = _donor.BloodGroup.Trim();
            label42.Text = _donor.BloodRh.Trim();

            if (_donor.MedicalHistory == null)
            {
                label35.Visible = false;
                label36.Visible = false;
                label37.Visible = false;
                label38.Visible = false;
                label34.Text = @"No";
            }
            else
            {
                if (string.IsNullOrEmpty(_donor.MedicalHistory.DiseaseName))
                {
                    label35.Visible = false;
                    label36.Visible = false;
                    label37.Visible = false;
                    label38.Visible = false;
                    label34.Text = @"No";
                }
                else
                {
                    label34.Text = @"Yes";
                    label36.Text = _donor.MedicalHistory.DiseaseName;
                    label38.Text = _donor.MedicalHistory.IsCured.ToString();
                }
            }
        }
    }
}
