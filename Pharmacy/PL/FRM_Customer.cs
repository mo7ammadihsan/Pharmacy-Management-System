using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy.BL;

namespace Pharmacy.PL
{
    public partial class FRM_Customer : MetroFramework.Forms.MetroForm
    {
        public FRM_Customer()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            dataGridView1.DataSource = BL.Customer.Customer_Select_Search("");
            dataGridView1.Columns[0].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BL.Customer.Customer_Select_Search(txtSearch.Text);
        }

        public void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (BL.Customer.Customer_Validate(txtName.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This customer already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BL.Customer.Customer_Add(txtName.Text, txtAddress.Text, txtPhone.Text);
            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Customer: " + txtName.Text);

            DataLoad();
            clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BL.Customer.Customer_Update(int.Parse(txtID.Text), txtName.Text, txtAddress.Text, txtPhone.Text);

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Customer ID: " + txtID.Text);

            DataLoad();
            clear();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                btnEdit.Enabled = btndelete.Enabled = false;
            else
                btnEdit.Enabled = btndelete.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.SelectedRows.Count > 0)
                {
                    txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtAddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    txtPhone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch { }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            BL.Customer.Customer_Delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete Customer : " + txtName.Text);

            DataLoad();
            clear();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RPT.RPT_Customer Report = new RPT.RPT_Customer();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@search", "");
            //***********************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //***********************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Print Customer");
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
