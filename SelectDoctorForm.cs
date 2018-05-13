using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class SelectDoctorForm : Form
    {
        private readonly BloodBankWSSoapClient _client;

        public static string DoctorFullName;
        public static string DoctorEmail;
        public static string DoctorStampId;
        public static string BankName;
        public static int DoctorId;

        private YourDetails _results;

        public SelectDoctorForm()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

        private void SelectDoctorForm_Load(object sender, EventArgs e)
        {
            doctorsGrid.AutoGenerateColumns = true;

            doctorsGrid.RowsDefaultCellStyle.BackColor = Color.Bisque;
            doctorsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            doctorsGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;


            doctorsGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            doctorsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            doctorsGrid.AllowUserToResizeColumns = true;
            doctorsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            GetDoctors();
        }

        private void GetDoctors()
        {
            var requestsBinding = new BindingSource();
            _results = _client.GetDetailsByBankId(LoginForm.GetBankId(), "", "");
            BankName = _results.BankName;
            if (_results.DoctorsList.ToList().Count == 0)
            {
                doctorsGrid.Visible = false;
            }
            else
            {
                foreach (var result in _results.DoctorsList.ToList())
                {
                    requestsBinding.Add(result);
                }
                doctorsGrid.Visible = true;
                doctorsGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in doctorsGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                doctorsGrid.FirstDisplayedScrollingRowIndex = 0;
            }
            catch { Close(); }
        }

        public void update_data(object sender, EventArgs e)
        {
            Close();
        }

        private void doctorsGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var m = new ContextMenu();
                m.MenuItems.Add(new MenuItem("Update", update_data));
                m.MenuItems.Add(new MenuItem("Delete"));

                var currentMouseOverRow = doctorsGrid.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    for (var i = 0; i < doctorsGrid.RowCount; i++)
                    {
                        doctorsGrid.Rows[i].Selected = false;
                    }
                    doctorsGrid.Rows[currentMouseOverRow].Selected = true;
                }
                m.Show(doctorsGrid, new Point(e.X, e.Y));
            }
            else
            {
                DoctorFullName = doctorsGrid.SelectedCells[1].Value.ToString().Trim() + @" " +
                                 doctorsGrid.SelectedCells[2].Value.ToString().Trim();
                DoctorEmail = doctorsGrid.SelectedCells[3].Value.ToString().Trim();
                DoctorStampId = doctorsGrid.SelectedCells[4].Value.ToString().Trim();
                DoctorId = GetDoctorIdByStampId(DoctorStampId);

                switch (MessageBox.Show(this, @"Are you sure you want to login as "
                                              + BankName.Trim() + @", Dr. "
                                              + DoctorFullName
                                              + @"?", @"Confirmation", MessageBoxButtons.YesNo))
                {
                    case DialogResult.Yes:
                        var mainform = new MainForm();
                        Hide();
                        mainform.Show();
                        break;
                    case DialogResult.No:
                        break;
                    default:
                        Application.Exit();
                        break;
                }
            }
        }

        private void doctorsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        //    if (e.)
        //    DoctorFullName = doctorsGrid.SelectedCells[1].Value.ToString().Trim() + @" " +
        //                     doctorsGrid.SelectedCells[2].Value.ToString().Trim();
        //    DoctorEmail = doctorsGrid.SelectedCells[3].Value.ToString().Trim();
        //    DoctorStampId = doctorsGrid.SelectedCells[4].Value.ToString().Trim();
        //    DoctorId = GetDoctorIdByStampId(DoctorStampId);

            //    switch (MessageBox.Show(this, @"Are you sure you want to login as " 
            //            + BankName.Trim() + @", Dr. " 
            //            + DoctorFullName
            //            + @"?", @"Confirmation", MessageBoxButtons.YesNo))
            //    {
            //        case DialogResult.Yes:
            //            var mainform = new MainForm();
            //            Hide();
            //            mainform.Show();
            //            break;
            //        case DialogResult.No:
            //            break;
            //        default:
            //            Application.Exit();
            //            break;
            //    }
            }

        public int GetDoctorIdByStampId(string sid)
        {
            return (from r in _results.DoctorsList where r.DoctorStampId == sid select r.DoctorId).FirstOrDefault();
        }
    }
}
