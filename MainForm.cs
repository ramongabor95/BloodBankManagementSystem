using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BBMS.BBWS;

namespace BBMS
{
    public partial class MainForm : Form
    {
        private readonly BloodBankWSSoapClient _client;
        private static List<Panel> _listOfPanels;
        private bool _isValidSsn;
        private bool _isValidFirstName;
        private bool _isValidLastName;
        private bool _isValidPhoneNr;
        private bool _isValidCity;
        private bool _isValidCountry;
        private bool _isValidOccupation;
        private bool _isValidIndustry;
        private bool _isValidGroup;
        private bool _isValidRh;
        private int currentDonorIndex = 0;
        private int _bankId;

        public static List<DonorDetails> ResultsViewdonors;
        public static List<DonorDetails> ResultsSearchDonors;
        public static int SearchOption = 0;

        public int GetBankId()
        {
            return this._bankId;
        }

        public MainForm()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
            _isValidSsn = true;
            _isValidFirstName = true;
            _isValidLastName = true;
            _isValidPhoneNr = true;
            _isValidCity = true;
            _isValidCountry = true;
            _isValidOccupation = true;
            _isValidIndustry = true;
            _isValidGroup = true;
            _isValidRh = true;

            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;

            panel12.Visible = false;
            panel13.Visible = false;
            panel14.Visible = false;
            panel15.Visible = false;
            panel16.Visible = false;
            panel17.Visible = false;
            panel18.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;
            panel23.Visible = false;
            panel24.Visible = false;

            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            label18.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;

            label29.Visible = false;
            label30.Visible = false;
            groupBox3.Visible = false;
            diseaseNameTextbox_Add.Visible = false;

            comboBox1.Visible = true;
            object[] bloodGroupValues = {"", "0", "A", "B", "AB"};
            comboBox1.Items.AddRange(bloodGroupValues);
            GroupCombobox_An.Items.AddRange(bloodGroupValues);

            comboBox2.Visible = true;
            object[] rhValues = {"", "POZ", "NEG"};
            comboBox2.Items.AddRange(rhValues);
            RHComboBox_An.Items.AddRange(rhValues);

            label27.Text = @"Dr." + SelectDoctorForm.DoctorFullName;

            viewDonorsGrid.AutoGenerateColumns = true;

            viewDonorsGrid.RowsDefaultCellStyle.BackColor = Color.Bisque;
            viewDonorsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            viewDonorsGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;


            viewDonorsGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            viewDonorsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            viewDonorsGrid.AllowUserToResizeColumns = true;
            viewDonorsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            SearchDonorsGrid.AutoGenerateColumns = true;

            SearchDonorsGrid.RowsDefaultCellStyle.BackColor = Color.Bisque;
            SearchDonorsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            SearchDonorsGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;


            SearchDonorsGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            SearchDonorsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SearchDonorsGrid.AllowUserToResizeColumns = true;
            SearchDonorsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            SearchAnalysisGrid.AutoGenerateColumns = true;

            SearchAnalysisGrid.RowsDefaultCellStyle.BackColor = Color.Gray;
            SearchAnalysisGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            SearchAnalysisGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;


            SearchAnalysisGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            SearchAnalysisGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SearchAnalysisGrid.AllowUserToResizeColumns = true;
            SearchAnalysisGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            yourDetailsPanel.Visible = false;

            _listOfPanels = new List<Panel> {homePanel, addDonorPanel, viewDonorPanel, SearchDonorPanel, SearchAnalysisPanel, InsertAnalysisPanel };
                //new List<Panel> {homePanel, addDonorPanel, viewDonorPanel, searchDonorPanel, updateDonorPanel};

            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            homePanel.Visible = true;

            var ms = new MenuStrip();

            var homeButtom = new ToolStripMenuItem("Home", null, homebutton_Click);

            var donorsMenu = new ToolStripMenuItem("Donors");
            var addDonor = new ToolStripMenuItem("Add new donor", null, addDonor_Click);
            var viewDonor = new ToolStripMenuItem("View all donors", null, viewDonor_Click);
            var searchDonor = new ToolStripMenuItem("Search for specific donor", null, searchDonor_Click);
            donorsMenu.DropDownItems.Add(addDonor);
            donorsMenu.DropDownItems.Add(viewDonor);
            donorsMenu.DropDownItems.Add(searchDonor);
            ((ToolStripDropDownMenu)(donorsMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(donorsMenu.DropDown)).ShowCheckMargin = true;

            var analysisMenu = new ToolStripMenuItem("Blood Analysis");
            var newA = new ToolStripMenuItem("New Analysis", null, newAnalysis_Click);
            var viewA = new ToolStripMenuItem("View recent blood analysis", null, viewA_Click);
            var searchA = new ToolStripMenuItem("Search", null, searchAnalysis_Click);
            analysisMenu.DropDownItems.Add(newA);
            analysisMenu.DropDownItems.Add(viewA);
            analysisMenu.DropDownItems.Add(searchA);
            ((ToolStripDropDownMenu)(analysisMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(analysisMenu.DropDown)).ShowCheckMargin = true;

            var raportsMenu = new ToolStripMenuItem("Raports");
            var raportA = new ToolStripMenuItem("Latest analysis raports", null, viewA_Click);
            var raportD = new ToolStripMenuItem("Latest donors raports", null, viewA_Click);
            var raportT = new ToolStripMenuItem("Latest throw raports", null, viewA_Click);
            var raportR = new ToolStripMenuItem("Latest request raports", null, viewA_Click);
            var raportC = new ToolStripMenuItem("Latest request confirmation raports", null, viewA_Click);
            var raportU = new ToolStripMenuItem("Latest usage raports", null, viewA_Click);
            raportsMenu.DropDownItems.Add(raportA);
            raportsMenu.DropDownItems.Add(raportD);
            raportsMenu.DropDownItems.Add(raportT);
            raportsMenu.DropDownItems.Add(raportR);
            raportsMenu.DropDownItems.Add(raportC);
            raportsMenu.DropDownItems.Add(raportU);
            ((ToolStripDropDownMenu)(raportsMenu.DropDown)).ShowImageMargin = false;
            ((ToolStripDropDownMenu)(raportsMenu.DropDown)).ShowCheckMargin = true;

            var yourDetails =
                new ToolStripMenuItem("Your Details", null, viewYourDetails_Click) {Alignment = ToolStripItemAlignment.Right};
            var contact = new ToolStripMenuItem("Contact Us", null, viewA_Click);

            ms.MdiWindowListItem = homeButtom;
            ms.MdiWindowListItem = donorsMenu;
            ms.MdiWindowListItem = analysisMenu;
            ms.MdiWindowListItem = raportsMenu;
            ms.MdiWindowListItem = yourDetails;
            ms.MdiWindowListItem = contact;
            ms.Items.Add(homeButtom);
            ms.Items.Add(donorsMenu);
            ms.Items.Add(analysisMenu);
            ms.Items.Add(raportsMenu);
            ms.Items.Add(yourDetails);
            ms.Items.Add(contact);
            ms.Dock = DockStyle.Top;
            MainMenuStrip = ms;
            Controls.Add(ms);

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = @"dd-MMM-yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = @"dd-MMM-yyyy";

        }
        
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, @"Are you sure you want to close?", @"Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }

        void viewYourDetails_Click(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            homePanel.Visible = true;
            yourDetailsPanel.Visible = true;
            label26.Text = @"Logged as: " + SelectDoctorForm.BankName + "\n";
            label26.Text += @"Dr. " + SelectDoctorForm.DoctorFullName + "\n";
            label26.Text += @"Email: " + SelectDoctorForm.DoctorEmail;
        }

        void homebutton_Click(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            homePanel.Visible = true;
        }

        void addDonor_Click (object sender, EventArgs e)
        {
            foreach(var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            titleLabel.Text = @"Add new donor";
            addDonorButton.Visible = true;
            updateDonorButton.Visible = false;
            addDonorPanel.Enabled = true;
            addDonorPanel.Visible = true;
            Controls.Add(addDonorPanel);
        }

        public List<MinimumDonorDetails> GetMinimumDetailsForDonors(List<DonorDetails> d)
        {
            var toReturn = new List<MinimumDonorDetails>();
            foreach (var dd in d)
            {
                var tmp = new MinimumDonorDetails
                {
                    FirstName = dd.FirstName,
                    LastName = dd.LastName,
                    Phone = dd.PhoneNumber,
                    SocialSecurityNumber = dd.SocialSecurityNumber,
                    Timestamp = dd.Timestamp
                };
                toReturn.Add(tmp);
            }
            return toReturn;
        }

        void viewDonor_Click(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            viewDonorPanel.Enabled = true;
            viewDonorPanel.Visible = true;
            Controls.Add(viewDonorPanel);

            var requestsBinding = new BindingSource();
            ResultsViewdonors = _client.GetDonorsByDoctorId(SelectDoctorForm.DoctorId, "", "").ToList();
            if (ResultsViewdonors.ToList().Count == 0)
            {
                viewDonorsGrid.Visible = false;
            }
            else
            {
                foreach (var result in GetMinimumDetailsForDonors(ResultsViewdonors.ToList()))
                {
                    requestsBinding.Add(result);
                }
                viewDonorsGrid.Visible = true;
                viewDonorsGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in viewDonorsGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                viewDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch { Close(); }
        }

        public void View_more_data(object sender, EventArgs e)
        {
            var moreData = new ViewDonorDetails(viewDonorsGrid.SelectedCells[0].Value.ToString().Trim(), 1);
            moreData.Show();
        }

        public void Delete_donor(object sender, EventArgs e)
        {
            _client.DeleteDonor(viewDonorsGrid.SelectedCells[0].Value.ToString().Trim(),"","");
            var requestsBinding = new BindingSource();
            ResultsViewdonors = _client.GetDonorsByDoctorId(SelectDoctorForm.DoctorId, "", "").ToList();
            if (ResultsViewdonors.ToList().Count == 0)
            {
                viewDonorsGrid.Visible = false;
            }
            else
            {
                foreach (var result in GetMinimumDetailsForDonors(ResultsViewdonors.ToList()))
                {
                    requestsBinding.Add(result);
                }
                viewDonorsGrid.Visible = true;
                viewDonorsGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in viewDonorsGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                viewDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch { Close(); }

        }

        private void Delete_Anaylisis(object sender, EventArgs e)
        {
            _client.DeleteBloodBagAnalysis(SearchAnalysisGrid.SelectedCells[1].Value.ToString().Trim());
            if (SSNTextbox_SAn.Text != string.Empty)
            {
                var requestsBinding = new BindingSource();
                var results = _client.SearchForBloodBagsBySsn(SSNTextbox_SAn.Text).ToList();
                if (results.ToList().Count == 0)
                {
                    SearchAnalysisGrid.Visible = false;
                }
                else
                {
                    foreach (var result in results)
                    {
                        requestsBinding.Add(result);
                    }
                    SearchAnalysisGrid.Visible = true;
                    SearchAnalysisGrid.DataSource = requestsBinding;
                }
                foreach (DataGridViewRow row in SearchAnalysisGrid.Rows)
                {
                    row.Frozen = false;
                }
                try
                {
                    SearchAnalysisGrid.FirstDisplayedScrollingRowIndex = 0;
                }
                catch
                {
                }
            }
            else
            {
                var requestsBinding = new BindingSource();
                var results = _client.SearchForBloodBagByDateInterval(dateTimePicker1.Value, dateTimePicker2.Value).ToList();
                if (results.ToList().Count == 0)
                {
                    SearchAnalysisGrid.Visible = false;
                }
                else
                {
                    foreach (var result in results)
                    {
                        requestsBinding.Add(result);
                    }
                    SearchAnalysisGrid.Visible = true;
                    SearchAnalysisGrid.DataSource = requestsBinding;
                }
                foreach (DataGridViewRow row in SearchAnalysisGrid.Rows)
                {
                    row.Frozen = false;
                }
                try
                {
                    SearchAnalysisGrid.FirstDisplayedScrollingRowIndex = 0;
                }
                catch { }
            }
        }

        private void analysisGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("View more details", View_Analysis_Data));
                m.MenuItems.Add(new MenuItem("Update analysis", Update_Analysis_Data));
                m.MenuItems.Add(new MenuItem("Delete analysis", Delete_Anaylisis));

                var currentMouseOverRow = SearchAnalysisGrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    for (var i = 0; i < SearchAnalysisGrid.RowCount; i++)
                    {
                        SearchAnalysisGrid.Rows[i].Selected = false;
                    }
                    SearchAnalysisGrid.Rows[currentMouseOverRow].Selected = true;
                }
                currentDonorIndex = currentMouseOverRow;
                m.Show(SearchAnalysisGrid, new Point(e.X, e.Y));
            }
        }


        private void View_Analysis_Data(object sender, EventArgs e)
        {
            var moreData = new ViewAnalysisDetails(SearchAnalysisGrid.SelectedCells[0].Value.ToString().Trim(), SearchAnalysisGrid.SelectedCells[1].Value.ToString().Trim());
            moreData.Show();
        }

        private void doctorsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("View more details", View_more_data));
                m.MenuItems.Add(new MenuItem("Update donor", Update_donor));
                m.MenuItems.Add(new MenuItem("Delete donor", Delete_donor));

                var currentMouseOverRow = viewDonorsGrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    for (var i = 0; i < viewDonorsGrid.RowCount; i++)
                    {
                        viewDonorsGrid.Rows[i].Selected = false;
                    }
                    viewDonorsGrid.Rows[currentMouseOverRow].Selected = true;
                }
                currentDonorIndex = currentMouseOverRow;
                m.Show(viewDonorsGrid, new Point(e.X, e.Y));
            }
        }

        private void SearchDonorsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("View more details", ViewMoreDataForDonorFromSearch));
                m.MenuItems.Add(new MenuItem("Update donor", UpdateDonorFromSearch));
                m.MenuItems.Add(new MenuItem("Delete donor", DeleteDonorFromSearch));

                var currentMouseOverRow = SearchDonorsGrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    for (var i = 0; i < SearchDonorsGrid.RowCount; i++)
                    {
                        SearchDonorsGrid.Rows[i].Selected = false;
                    }
                    SearchDonorsGrid.Rows[currentMouseOverRow].Selected = true;
                }
                currentDonorIndex = currentMouseOverRow;
                m.Show(SearchDonorsGrid, new Point(e.X, e.Y));
            }
        }

        public void ViewMoreDataForDonorFromSearch(object sender, EventArgs e)
        {
            var moreData = new ViewDonorDetails(SearchDonorsGrid.SelectedCells[0].Value.ToString().Trim(), 2);
            moreData.Show();
        }

        public void DeleteDonorFromSearch(object sender, EventArgs e)
        {
            _client.DeleteDonor(SearchDonorsGrid.SelectedCells[0].Value.ToString().Trim(), "", "");
            var requestsBinding = new BindingSource();

            switch (SearchOption)
            {
                case 1:
                    ResultsSearchDonors = _client.GetDonorsByKeyword(textBox12.Text, 1, "", "").ToList();
                    break;
                case 2:
                    ResultsSearchDonors = _client.GetDonorsByKeyword(textBox10.Text, 2, "", "").ToList();
                    break;
                case 3:
                    ResultsSearchDonors = _client.GetDonorsByKeyword(textBox11.Text, 3, "", "").ToList();
                    break;
                case 4:
                    var toSend = new SearchFilterDetails
                    {
                        City = textBox16.Text != @"City..." ? textBox16.Text : string.Empty,
                        Country = textBox18.Text != @"Country..." ? textBox18.Text : string.Empty,
                        Phone = textBox17.Text != @"Phone..." ? textBox17.Text : string.Empty,
                        Ssn = textBox15.Text != @"SSN..." ? textBox15.Text : string.Empty,
                        LastName = textBox14.Text != @"Last name..." ? textBox14.Text : string.Empty,
                        FirstName = textBox13.Text != @"First name..." ? textBox13.Text : string.Empty
                    };
                    ResultsSearchDonors = _client.GetDonorsByDataFilter(toSend, "", "").ToList();
                    break;
                default:
                    ResultsSearchDonors = new List<DonorDetails>();
                    break;
            }


            if (ResultsSearchDonors.ToList().Count == 0)
            {
                SearchDonorsGrid.Visible = false;
            }
            else
            {
                foreach (var result in GetMinimumDetailsForDonors(ResultsSearchDonors.ToList()))
                {
                    requestsBinding.Add(result);
                }
                SearchDonorsGrid.Visible = true;
                SearchDonorsGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in SearchDonorsGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                SearchDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch { Close(); }
        }


        private void Update_Analysis_Data(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            updateAnalysisButton.Visible = true;
            label35.Text = @"Update Existing Analysis";

            var value = SearchAnalysisGrid.SelectedCells[1].Value.ToString().Trim();
            var analysis = _client.GetBloodBagById(value);

            BloodBagId_An.Text = value;
            RBCTextbox_An.Text = analysis.Rbc.ToString();
            HGBTextBox_An.Text = analysis.Hgb.ToString();
            HCTTextbox_An.Text = analysis.Hct.ToString();
            MCVTextbox_An.Text = analysis.Mcv.ToString();
            MCHCTextbox_An.Text = analysis.Mchc.ToString();
            WBCTextbox_An.Text = analysis.Wbc.ToString();
            PLTTextbox_An.Text = analysis.Plt.ToString();
            VSHTextbox_An.Text = analysis.Vsh.ToString();
            TGPTextbox_An.Text = analysis.Tgp.ToString();
            GroupCombobox_An.Text = analysis.Group;
            RHComboBox_An.Text = analysis.Rh;

            if (analysis.AnticorpsHiv)
                radioButton9.Checked = true;
            else radioButton10.Checked = true;

            if (analysis.AnticorpsHeC)
                radioButton11.Checked = true;
            else radioButton12.Checked = true;

            if (analysis.AnticoprsHeB)
                radioButton13.Checked = true;
            else radioButton14.Checked = true;

            if (analysis.AnticorpsLec)
                radioButton15.Checked = true;
            else radioButton16.Checked = true;

            if (analysis.AnticorpsSif)
                radioButton17.Checked = true;
            else radioButton18.Checked = true;

            checkBox1.Checked = analysis.IsGoodForUse;

            AddAnalysis_Button.Visible = false;
            InsertAnalysisPanel.Enabled = true;
            InsertAnalysisPanel.Visible = true;
            Controls.Add(InsertAnalysisPanel);
        }

        public void UpdateDonorFromSearch(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            updateDonorButton.Visible = true;
            titleLabel.Text = @"Update existing donor";

            var value = SearchDonorsGrid.SelectedCells[0].Value.ToString().Trim();
            var donor = new DonorDetails();
            foreach (var dd in ResultsSearchDonors)
            {
                if (dd.SocialSecurityNumber.Trim() == value)
                    donor = dd;
            }

            ssnTextBox_Add.Text = donor.SocialSecurityNumber.Trim();
            firstNameTextBox_Add.Text = donor.FirstName.Trim();
            lastNameTextbox_Add.Text = donor.LastName.Trim();
            phoneNumberTextbox_Add.Text = donor.PhoneNumber.Trim();
            cityTextbox_Add.Text = donor.City.Trim();
            countryTextbox_Add.Text = donor.Country.Trim();
            postcodeTextbox_Add.Text = donor.PostalCode.Trim();
            numericUpDown1.Text = donor.NumberOfDonations.ToString();
            occupationTextbox_Add.Text = donor.Occupation.Trim();
            industryTextbox_Add.Text = donor.Industry.Trim();

            numericUpDown2.Text = donor.BirthDay.Day.ToString();
            numericUpDown3.Text = donor.BirthDay.Month.ToString();
            numericUpDown4.Text = donor.BirthDay.Year.ToString();

            if (donor.Gender == Gender.M)
                radioButton1.Checked = true;
            else radioButton2.Checked = true;

            if (donor.IsEmergencyDonor)
                radioButton3.Checked = true;
            else radioButton4.Checked = true;

            if (donor.MedicalHistory != null)
            {
                if (string.IsNullOrEmpty(donor.MedicalHistory.DiseaseName))
                    radioButton6.Checked = true;
                else
                {
                    radioButton5.Checked = true;
                    diseaseNameTextbox_Add.Text = donor.MedicalHistory.DiseaseName;
                    if (donor.MedicalHistory.IsCured)
                        radioButton7.Checked = true;
                    else radioButton8.Checked = true;
                }
            }
            else
            {
                radioButton6.Checked = true;
            }

            comboBox1.SelectedItem = donor.BloodGroup.Trim();
            comboBox2.SelectedItem = donor.BloodRh.Trim();

            addDonorButton.Visible = false;
            addDonorPanel.Enabled = true;
            addDonorPanel.Visible = true;
            Controls.Add(addDonorPanel);
        }

        void searchDonor_Click(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            SearchDonorPanel.Enabled = true;
            SearchDonorPanel.Visible = true;
            Controls.Add(SearchDonorPanel);
        }

        void Update_donor(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            updateDonorButton.Visible = true;
            titleLabel.Text = @"Update existing donor";

            var value = viewDonorsGrid.SelectedCells[0].Value.ToString().Trim();
            var donor = new DonorDetails();
            foreach (var dd in MainForm.ResultsViewdonors)
            {
                if (dd.SocialSecurityNumber.Trim() == value)
                    donor = dd;
            }

            ssnTextBox_Add.Text = donor.SocialSecurityNumber.Trim();
            firstNameTextBox_Add.Text = donor.FirstName.Trim();
            lastNameTextbox_Add.Text = donor.LastName.Trim();
            phoneNumberTextbox_Add.Text = donor.PhoneNumber.Trim();
            cityTextbox_Add.Text = donor.City.Trim();
            countryTextbox_Add.Text = donor.Country.Trim();
            postcodeTextbox_Add.Text = donor.PostalCode.Trim();
            numericUpDown1.Text = donor.NumberOfDonations.ToString();
            occupationTextbox_Add.Text = donor.Occupation.Trim();
            industryTextbox_Add.Text = donor.Industry.Trim();

            numericUpDown2.Text = donor.BirthDay.Day.ToString();
            numericUpDown3.Text = donor.BirthDay.Month.ToString();
            numericUpDown4.Text = donor.BirthDay.Year.ToString();

            if (donor.Gender == Gender.M)
                radioButton1.Checked = true;
            else radioButton2.Checked = true;

            if (donor.IsEmergencyDonor)
                radioButton3.Checked = true;
            else radioButton4.Checked = true;

            if (donor.MedicalHistory != null)
            {
                if (string.IsNullOrEmpty(donor.MedicalHistory.DiseaseName))
                    radioButton6.Checked = true;
                else
                {
                    radioButton5.Checked = true;
                    diseaseNameTextbox_Add.Text = donor.MedicalHistory.DiseaseName;
                    if (donor.MedicalHistory.IsCured)
                        radioButton7.Checked = true;
                    else radioButton8.Checked = true;
                }
            }
            else
            {
                radioButton6.Checked = true;
            }

            comboBox1.SelectedItem = donor.BloodGroup.Trim();
            comboBox2.SelectedItem = donor.BloodRh.Trim();

            addDonorButton.Visible = false;
            addDonorPanel.Enabled = true;
            addDonorPanel.Visible = true;
            Controls.Add(addDonorPanel);
        }

        void newAnalysis_Click(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            InsertAnalysisPanel.Enabled = true;
            InsertAnalysisPanel.Visible = true;

            label35.Text = @"Insert new analysis";
            updateAnalysisButton.Visible = false;
            AddAnalysis_Button.Visible = true;
            ResetAnalysisDetails();
            RestoreAnalysisDataPanelsAndLabels();
            Controls.Add(InsertAnalysisPanel);
        }
        
        void searchAnalysis_Click(object sender, EventArgs e)
        {
            foreach (var pan in _listOfPanels)
            {
                pan.Visible = false;
            }
            SearchAnalysisPanel.Enabled = true;
            SearchAnalysisPanel.Visible = true;
            Controls.Add(SearchAnalysisPanel);
        }

        void viewA_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var isAllOk = IsAllDataValid();
            if (isAllOk)
            {
                var obj = CreatedDonorObject();
                _client.AddNewDonor(obj,"","");
                ResetDetails();
                RestorePanelsAndLabels();
            }
        }

        private bool IsAllDataValid()
        {
            if (!_isValidSsn) return false;
            if (!_isValidFirstName) return false;
            if (!_isValidLastName) return false;
            if (!_isValidCity) return false;
            if (!_isValidCountry) return false;
            if (!_isValidPhoneNr) return false;
            if (!_isValidOccupation) return false;
            if (!_isValidIndustry) return false;
            if (!_isValidGroup) return false;
            if (!_isValidRh) return false;
            return true;
        }

        private void ResetDetails()
        {
            RestorePanelsAndLabels();

            ssnTextBox_Add.Text = string.Empty;
            firstNameTextBox_Add.Text = string.Empty;
            lastNameTextbox_Add.Text = string.Empty;
            phoneNumberTextbox_Add.Text = string.Empty;
            cityTextbox_Add.Text = string.Empty;
            countryTextbox_Add.Text = string.Empty;
            postcodeTextbox_Add.Text = string.Empty;
            occupationTextbox_Add.Text = string.Empty;
            industryTextbox_Add.Text = string.Empty;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 1;
            numericUpDown4.Value = 1970;
            diseaseNameTextbox_Add.Text = string.Empty;
            radioButton7.Checked = true;
            radioButton6.Checked = true;
            comboBox1.SelectedItem = "";
            comboBox2.SelectedItem = "";
        }

        private DonorDetails CreatedDonorObject()
        {
            var toReturn = new DonorDetails
            {
                BankId = LoginForm.GetBankId(),
                SocialSecurityNumber = ssnTextBox_Add.Text,
                FirstName = firstNameTextBox_Add.Text,
                LastName = lastNameTextbox_Add.Text,
                PhoneNumber = phoneNumberTextbox_Add.Text,
                City = cityTextbox_Add.Text,
                Country = countryTextbox_Add.Text,
                PostalCode = postcodeTextbox_Add.Text,
                Occupation = occupationTextbox_Add.Text,
                Industry = industryTextbox_Add.Text,
                Gender = radioButton1.Checked ? Gender.M : Gender.F,
                IsEmergencyDonor = radioButton3.Checked,
                NumberOfDonations = (int)numericUpDown1.Value,
                BirthDay = new DateTime((int)numericUpDown4.Value,(int)numericUpDown3.Value, (int)numericUpDown2.Value),
                DoctorId = SelectDoctorForm.DoctorId,
                BloodGroup = comboBox1.SelectedItem.ToString(),
                BloodRh = comboBox2.SelectedItem.ToString()
            };
            var today = DateTime.Today;
            var age = today.Year - toReturn.BirthDay.Year;
            if (toReturn.BirthDay > today.AddYears(-age)) age--;
            toReturn.Age = age;

            toReturn.MedicalHistory = new DonorMedicalHistory
            {
                DiseaseName = diseaseNameTextbox_Add.Text,
                IsCured = radioButton7.Checked
            };

            return toReturn;
        }

        private void RestorePanelsAndLabels()
        {
            panel1.Visible = false;
            label15.Visible = false;
            panel2.Visible = false;
            label16.Visible = false;
            panel3.Visible = false;
            label17.Visible = false;
            panel4.Visible = false;
            label18.Visible = false;
            panel5.Visible = false;
            label20.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ssnTextBox_Add.Text))
            {
                panel1.Visible = true;
                label15.Text = @"Please enter a SSN";
                label15.Visible = true;
                _isValidSsn = false;
            }
            else
            {
                if (!ValidateSocialSecurityNumber(ssnTextBox_Add.Text))
                {
                    panel1.Visible = true;
                    label15.Text = @"Invalid SSN";
                    label15.Visible = true;
                    _isValidSsn = false;
                }
                else
                {
                    panel1.Visible = false;
                    _isValidSsn = true;
                }
            }
        }
        
        private void ssnTextBox_Add_Leave(object sender, EventArgs e)
        {
            if (_isValidSsn && !string.IsNullOrEmpty(ssnTextBox_Add.Text))
            {
                var exists = _client.CheckIfSsnExists(ssnTextBox_Add.Text);
                if (exists)
                {
                    var bbid = _client.InsertNewBloodBag(ssnTextBox_Add.Text);
                    foreach (var panel in _listOfPanels)
                    {
                        panel.Visible = false;
                    }
                    InsertAnalysisPanel.Visible = true;
                    BloodBagId_An.Text = bbid;
                    ResetAnalysisDetails();
                    RestoreAnalysisDataPanelsAndLabels();
                    newAnalysis_Click(null, null);
                }
            }
        }

        private bool ValidateSocialSecurityNumber(string ssn)
        {
            if (!ssn.StartsWith("1"))
                return false;
            if (ssn.Length != 13)
                return false;
            if (ssn.Any(char.IsLetter))
                return false;
            return true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNameTextBox_Add.Text))
            {
                panel2.Visible = true;
                label16.Text = @"Please enter the first name";
                label16.Visible = true;
                _isValidFirstName = false;
            }
            else
            {
                if (firstNameTextBox_Add.Text.Any(char.IsDigit))
                {
                    panel2.Visible = true;
                    label16.Text = @"Invalid name";
                    label16.Visible = true;
                    _isValidFirstName = false;
                }
                else
                {
                    panel2.Visible = false;
                    _isValidFirstName = true;
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lastNameTextbox_Add.Text))
            {
                panel3.Visible = true;
                label17.Text = @"Please enter the last name";
                label17.Visible = true;
                _isValidLastName = false;
            }
            else
            {
                if (lastNameTextbox_Add.Text.Any(char.IsDigit))
                {
                    panel3.Visible = true;
                    label17.Text = @"Invalid name";
                    label17.Visible = true;
                    _isValidLastName = false;
                }
                else
                {
                    panel3.Visible = false;
                    _isValidLastName = true;
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(phoneNumberTextbox_Add.Text))
            {
                panel4.Visible = true;
                label18.Text = @"Please enter the phone number";
                label18.Visible = true;
                _isValidPhoneNr = false;
            }
            else
            {
                if (phoneNumberTextbox_Add.Text.Any(char.IsLetter) || !phoneNumberTextbox_Add.Text.StartsWith("07"))
                {
                    panel4.Visible = true;
                    label18.Text = @"Invalid phone number";
                    label18.Visible = true;
                    _isValidPhoneNr = false;
                }
                else
                {
                    panel4.Visible = false;
                    _isValidPhoneNr = true;
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cityTextbox_Add.Text))
            {
                panel5.Visible = true;
                label20.Text = @"Please enter the city";
                label20.Visible = true;
                _isValidCity = false;
            }
            else
            {
                if (cityTextbox_Add.Text.Any(char.IsDigit))
                {
                    panel5.Visible = true;
                    label20.Text = @"Invalid city name";
                    label20.Visible = true;
                    _isValidCity = false;
                }
                else
                {
                    panel5.Visible = false;
                    _isValidCity = true;
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(countryTextbox_Add.Text))
            {
                panel6.Visible = true;
                label21.Text = @"Please enter the contry";
                label21.Visible = true;
                _isValidCountry = false;
            }
            else
            {
                if (countryTextbox_Add.Text.Any(char.IsDigit))
                {
                    panel6.Visible = true;
                    label21.Text = @"Invalid country name";
                    label21.Visible = true;
                    _isValidCountry = false;
                }
                else
                {
                    panel6.Visible = false;
                    _isValidCountry = true;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(postcodeTextbox_Add.Text))
            {
                panel7.Visible = true;
                label22.Text = @"Please enter the postcode";
                label22.Visible = true;
            }
            else
            {
                panel7.Visible = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(occupationTextbox_Add.Text))
            {
                panel8.Visible = true;
                label23.Text = @"Please enter the occupation";
                label23.Visible = true;
                _isValidOccupation = false;
            }
            else
            {
                if (occupationTextbox_Add.Text.Any(char.IsDigit))
                {
                    panel8.Visible = true;
                    label23.Text = @"Invalid occupation";
                    label23.Visible = true;
                    _isValidOccupation = false;
                }
                else
                {
                    panel8.Visible = false;
                    _isValidOccupation = true;
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(industryTextbox_Add.Text))
            {
                panel9.Visible = true;
                label24.Text = @"Please enter the industry";
                label24.Visible = true;
                _isValidIndustry = false;
            }
            else
            {
                if (industryTextbox_Add.Text.Any(char.IsDigit))
                {
                    panel9.Visible = true;
                    label24.Text = @"Invalid industry";
                    label24.Visible = true;
                    _isValidIndustry = false;
                }
                else
                {
                    panel9.Visible = false;
                    _isValidIndustry = true;
                }
            }
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            var logout = new LoginForm();
            Hide();
            logout.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != string.Empty)
            {
                SearchOption = 3;
                var requestsBinding = new BindingSource();
                ResultsSearchDonors = _client.GetDonorsByKeyword(textBox11.Text, 3, "", "").ToList();
                if (ResultsSearchDonors.ToList().Count == 0)
                {
                    SearchDonorsGrid.Visible = false;
                }
                else
                {
                    foreach (var result in GetMinimumDetailsForDonors(ResultsSearchDonors.ToList()))
                    {
                        requestsBinding.Add(result);
                    }
                    SearchDonorsGrid.Visible = true;
                    SearchDonorsGrid.DataSource = requestsBinding;
                }
                foreach (DataGridViewRow row in SearchDonorsGrid.Rows)
                {
                    row.Frozen = false;
                }
                try
                {
                    SearchDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
                }
                catch { Close(); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox10.Text != string.Empty)
            {
                SearchOption = 2;
                var requestsBinding = new BindingSource();
                ResultsSearchDonors = _client.GetDonorsByKeyword(textBox10.Text, 2, "", "").ToList();
                if (ResultsSearchDonors.ToList().Count == 0)
                {
                    SearchDonorsGrid.Visible = false;
                }
                else
                {
                    foreach (var result in GetMinimumDetailsForDonors(ResultsSearchDonors.ToList()))
                    {
                        requestsBinding.Add(result);
                    }
                    SearchDonorsGrid.Visible = true;
                    SearchDonorsGrid.DataSource = requestsBinding;
                }
                foreach (DataGridViewRow row in SearchDonorsGrid.Rows)
                {
                    row.Frozen = false;
                }
                try
                {
                    SearchDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
                }
                catch { Close(); }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox12.Text != string.Empty)
            {
                SearchOption = 1;
                var requestsBinding = new BindingSource();
                ResultsSearchDonors = _client.GetDonorsByKeyword(textBox12.Text, 1, "", "").ToList();
                if (ResultsSearchDonors.ToList().Count == 0)
                {
                    SearchDonorsGrid.Visible = false;
                }
                else
                {
                    foreach (var result in GetMinimumDetailsForDonors(ResultsSearchDonors.ToList()))
                    {
                        requestsBinding.Add(result);
                    }
                    SearchDonorsGrid.Visible = true;
                    SearchDonorsGrid.DataSource = requestsBinding;
                }
                foreach (DataGridViewRow row in SearchDonorsGrid.Rows)
                {
                    row.Frozen = false;
                }
                try
                {
                    SearchDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
                }
                catch { Close(); }
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            var toSend = new SearchFilterDetails
            {
                City = textBox16.Text != @"City..." ? textBox16.Text : string.Empty,
                Country = textBox18.Text != @"Country..." ? textBox18.Text : string.Empty,
                Phone = textBox17.Text != @"Phone..." ? textBox17.Text : string.Empty,
                Ssn = textBox15.Text != @"SSN..." ? textBox15.Text : string.Empty,
                LastName = textBox14.Text != @"Last name..." ? textBox14.Text : string.Empty,
                FirstName = textBox13.Text != @"First name..." ? textBox13.Text : string.Empty
            };
            SearchOption = 4;
            var requestsBinding = new BindingSource();
            ResultsSearchDonors = _client.GetDonorsByDataFilter(toSend, "", "").ToList();

            if (ResultsSearchDonors.ToList().Count == 0)
            {
                SearchDonorsGrid.Visible = false;
            }
            else
            {
                foreach (var result in GetMinimumDetailsForDonors(ResultsSearchDonors.ToList()))
                {
                    requestsBinding.Add(result);
                }
                SearchDonorsGrid.Visible = true;
                SearchDonorsGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in SearchDonorsGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                SearchDonorsGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch { Close(); }
        }

        private void updateDonorButton_Click(object sender, EventArgs e)
        {
            var result = IsAllDataValid();
            if (result)
            {
                var obj = CreatedDonorObject();
                _client.UpdateDonor(obj, "", "");
                ResetDetails();
                RestorePanelsAndLabels();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                label29.Visible = true;
                label30.Visible = true;
                diseaseNameTextbox_Add.Visible = true;
                groupBox3.Visible = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                label29.Visible = false;
                label30.Visible = false;
                diseaseNameTextbox_Add.Visible = false;
                groupBox3.Visible = false;
                diseaseNameTextbox_Add.Text = string.Empty;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "")
            {
                panel10.Visible = true;
                label33.Text = @"Invalid";
                label33.Visible = true;
                _isValidGroup = false;
            }
            else
            {
                panel10.Visible = false;
                _isValidGroup = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "")
            {
                panel11.Visible = true;
                label34.Text = @"Invalid";
                label34.Visible = true;
                _isValidRh = false;
            }
            else
            {
                panel11.Visible = false;
                _isValidRh = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var isAllOk = IsAllAnalysisDataValid();
            if (isAllOk)
            {
                var obj = CreateBloodBagAnalysisObject();
                var bbid = BloodBagId_An.Text == string.Empty ? string.Empty : BloodBagId_An.Text;
                _client.AddNewBloodBagAnalysis(obj, bbid);
                ResetAnalysisDetails();
                RestoreAnalysisDataPanelsAndLabels();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var isAllOk = IsAllAnalysisDataValid();
            if (isAllOk)
            {
                var obj = CreateBloodBagAnalysisObject();
                _client.UpdateBloodBagAnalysisByBloodBagId(obj, BloodBagId_An.Text.Trim());
                _client.UpdateBloodBagAnalysisByBloodBagId(obj, BloodBagId_An.Text.Trim());
                ResetAnalysisDetails();
                RestoreAnalysisDataPanelsAndLabels();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (SSNTextbox_SAn.Text != string.Empty)
            {
                var requestsBinding = new BindingSource();
                var results = _client.SearchForBloodBagsBySsn(SSNTextbox_SAn.Text).ToList();
                if (results.ToList().Count == 0)
                {
                    SearchAnalysisGrid.Visible = false;
                }
                else
                {
                    foreach (var result in results)
                    {
                        requestsBinding.Add(result);
                    }
                    SearchAnalysisGrid.Visible = true;
                    SearchAnalysisGrid.DataSource = requestsBinding;
                }
                foreach (DataGridViewRow row in SearchAnalysisGrid.Rows)
                {
                    row.Frozen = false;
                }
                try
                {
                    SearchAnalysisGrid.FirstDisplayedScrollingRowIndex = 0;
                }
                catch {  }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var requestsBinding = new BindingSource();
            var results = _client.SearchForBloodBagByDateInterval(dateTimePicker1.Value, dateTimePicker2.Value).ToList();
            if (results.ToList().Count == 0)
            {
                SearchAnalysisGrid.Visible = false;
            }
            else
            {
                foreach (var result in results)
                {
                    requestsBinding.Add(result);
                }
                SearchAnalysisGrid.Visible = true;
                SearchAnalysisGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in SearchAnalysisGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                SearchAnalysisGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch { }
        }
        
    }


    public class MinimumDonorDetails
    {
        public string SocialSecurityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
