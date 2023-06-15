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
    public partial class FRM_Sceintific_Name : MetroFramework.Forms.MetroForm
    {
        public FRM_Sceintific_Name()
        {
            InitializeComponent();
            DataLoad();
        }

        public void DataLoad()
        {
            dataGridView1.DataSource = Scientific_Name.Sc_Name_Search_Select(string.Empty);
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Rows[1].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Scientific_Name.Sc_Name_Search_Select(txtSearch.Text);
        }
        public void Clear()
        {
            txtName.Clear();
            txtDescription.Clear();
            txtID.Clear();
            checkboxstatus.Checked = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Enter Sceintific Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Scientific_Name.Sc_Name_Validate_Name(txtName.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This Sceintific Name already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Scientific_Name.Sc_Name_Add(txtName.Text, txtDescription.Text, checkboxstatus.Checked);

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Sceintific Name: " + txtName.Text);
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
                    txtDescription.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    checkboxstatus.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[3].Value;
                }
            }
            catch { }

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

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            txtName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Enter Sceintific Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Scientific_Name.Sc_Name_Update(txtName.Text, txtDescription.Text, checkboxstatus.Checked, int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Sceintific Name ID: " + txtID.Text);

            DataLoad();
            Clear();
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "0")
                return;
            Scientific_Name.Sc_Name_delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete Sceintific Name: " + txtName.Text);

            DataLoad();
            Clear();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
                btndelete.Enabled = btnEdit.Enabled = false;
            else
                btndelete.Enabled = btnEdit.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RPT.RPT_Sceintific_Name Report = new RPT.RPT_Sceintific_Name();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@Search", "");
            //***********************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //***********************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Printed Sceintific Name");
        }
    }
}
