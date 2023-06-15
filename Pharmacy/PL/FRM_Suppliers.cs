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
    public partial class FRM_Suppliers : MetroFramework.Forms.MetroForm
    {
        public FRM_Suppliers()
        {
            InitializeComponent();
            DataLoad();
        }
        private void FRM_Suppliers_Load(object sender, EventArgs e)
        {
            cmbCountries.DataSource = Countries.Countries_Select_Search("");
            dataGridView1.Columns[0].Visible = false;
            cmbCountries.DisplayMember = "Name";
            cmbCountries.ValueMember = "ID";
            cmbCountries.SelectedIndex = -1;
            cmbCity.SelectedIndex = -1;
        }
        private void cmbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbCity.DataSource = City.Cities_ComboBox(int.Parse(cmbCountries.SelectedValue.ToString()));
                cmbCity.DisplayMember = "City";
                cmbCity.ValueMember = "ID";
                
            }
            catch { }
        }
        public void DataLoad()
        {
            dataGridView1.DataSource = Suppliers.Suppliers_Select_Search("");
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Suppliers.Suppliers_Select_Search(txtSearch.Text);
        }
        public void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtSearch.Text = "";
            cmbCity.SelectedIndex = -1;
            cmbCountries.SelectedIndex = -1;
        }
        private void btnCountries_Click(object sender, EventArgs e)
        {
            new FRM_Countries().ShowDialog();
        }

        private void btnCity_Click(object sender, EventArgs e)
        {
            new FRM_City().ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cmbCountries.Text == "" || cmbCity.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter Required Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Suppliers.Suppliers_Validate(txtName.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This Supplier already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Suppliers.Suppliers_Add(txtName.Text, txtPhone.Text, int.Parse(cmbCity.SelectedValue.ToString()));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Supplier: " + txtName.Text);

            DataLoad();
            clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || cmbCountries.Text == "" || cmbCity.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter Required Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Suppliers.Suppliers_Update(int.Parse(txtID.Text), txtName.Text, txtPhone.Text, int.Parse(cmbCity.SelectedValue.ToString()));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Supplier ID: " + txtID.Text);

            DataLoad();
            clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Suppliers.Suppliers_Delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "delete Supplier: " + txtName.Text);

            DataLoad();
            clear();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                btndelete.Enabled = btnEdit.Enabled = false;
            else
                btndelete.Enabled = btnEdit.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    txtPhone.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    cmbCity.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    cmbCountries.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                }
            }
            catch { }
        }
        private void onlynumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RPT.RPT_Supplier Report = new RPT.RPT_Supplier();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@search", "");
            //*************************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //*************************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Print Supplier");
        }
    }
}
