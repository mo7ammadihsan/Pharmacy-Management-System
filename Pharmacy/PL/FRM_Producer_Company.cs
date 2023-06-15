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
    public partial class FRM_Producer_Company : MetroFramework.Forms.MetroForm
    {
        public FRM_Producer_Company()
        {
            InitializeComponent();
            DataLoad();
        }
        public void DataLoad()
        {
            dataGridView1.DataSource = Producer_Company.Producer_Company_Select_Search(string.Empty);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Rows[1].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Producer_Company.Producer_Company_Select_Search(txtSearch.Text);
        }
        public void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtDescription.Clear();
            checkboxstatus.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Enter Producer Company Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Producer_Company.Producer_Company_Validate(txtName.Text, txtPhone.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This Producer Company already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Producer_Company.Producer_Company_Add(txtName.Text, txtAddress.Text, txtDescription.Text, txtPhone.Text, checkboxstatus.Checked);

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Producer Company: " + txtName.Text);

            DataLoad();
            Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Enter Producer Company Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Producer_Company.Producer_Company_Update(txtName.Text, txtAddress.Text, txtDescription.Text, txtPhone.Text, checkboxstatus.Checked, int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Producer Company ID: " + txtID.Text);

            DataLoad();
            Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.SelectedRows.Count > 0)
                {
                    txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtPhone.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    checkboxstatus.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                }
            }
            catch { }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            txtName.Focus();
        }

        private void checkboxstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxstatus.Checked == false)
            {
                checkboxstatus.BackColor = Color.Red;
                checkboxstatus.Text = "Passive";

            }
            else
            {
                checkboxstatus.BackColor = Color.Lime;
                checkboxstatus.Text = "Active";
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "0")
                return;
            Producer_Company.Producer_Company_Delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "delete Producer Company: " + txtName.Text);

            DataLoad();
            Clear();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty)
                btndelete.Enabled = btnEdit.Enabled = false;
            else
                btndelete.Enabled = btnEdit.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RPT.RPT_Producer_Company Report = new RPT.RPT_Producer_Company();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@Search", "");
            //**********************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //**********************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Printed Producer Company");
        }
    }
}
