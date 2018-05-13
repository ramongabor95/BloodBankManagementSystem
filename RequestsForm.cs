using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBMS.BBWS;

namespace BBMS
{
    public partial class RequestsForm : Form
    {
        private readonly BloodBankWSSoapClient _client;
        public RequestsForm()
        {
            InitializeComponent();
            _client = new BloodBankWSSoapClient();
        }

        private async void RequestsForm_Load(object sender, EventArgs e)
        {
            requestsGrid.AutoGenerateColumns = true;
            badBloodGrid.AutoGenerateColumns = true;

            requestsGrid.RowsDefaultCellStyle.BackColor = Color.Bisque;
            requestsGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            requestsGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            

            requestsGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            requestsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            requestsGrid.AllowUserToResizeColumns = true;
            requestsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            

            badBloodGrid.RowsDefaultCellStyle.BackColor = Color.Bisque;
            badBloodGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.Beige;
            badBloodGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;


            badBloodGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            badBloodGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            badBloodGrid.AllowUserToResizeColumns = true;
            badBloodGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
            while (true)
            {
                CheckForRequests();
                CheckForBadBlood();
                await Task.Delay(3000);
            }

        }

        private void CheckForRequests()
        {
            var requestsBinding = new BindingSource();
            var results = _client.GetRequests("", "").ToList();
            if (results.Count == 0)
            {
                requestsGrid.Visible = false;
                reqButton.Visible = false;
            }
            else
            {
                foreach (var result in results)
                {
                    requestsBinding.Add(result);
                }
                requestsGrid.Visible = true;
                reqButton.Visible = true;
                requestsGrid.DataSource = requestsBinding;
            }
            foreach (DataGridViewRow row in requestsGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                requestsGrid.FirstDisplayedScrollingRowIndex = requestsGrid.Rows.Count - 1;
            }
            catch { }
        }

        private void CheckForBadBlood()
        {
            var badBloodBinding = new BindingSource();
            var results = _client.GetBadBlood("","").ToList();
            if (results.Count == 0)
            {
                badBloodGrid.Visible = false;
                thrButton.Visible = false;
            }
            else
            {
                foreach(var result in results)
                {
                    badBloodBinding.Add(result);
                }
                badBloodGrid.Visible = true;
                thrButton.Visible = true;
                badBloodGrid.DataSource = badBloodBinding;
            }
            foreach (DataGridViewRow row in badBloodGrid.Rows)
            {
                row.Frozen = false;
            }
            try
            {
                badBloodGrid.FirstDisplayedScrollingRowIndex = badBloodGrid.Rows.Count - 1;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var respond = new RespondToRequest();
            respond.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var tthrow = new ThrowBag();
            tthrow.Show();
        }

        private void requestsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var ceva = requestsGrid.SelectedRows;
        }
    }
}
