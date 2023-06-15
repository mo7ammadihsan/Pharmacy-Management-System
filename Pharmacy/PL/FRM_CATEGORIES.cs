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
    public partial class FRM_CATEGORIES : MetroFramework.Forms.MetroForm
    {
        public FRM_CATEGORIES()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = Categories.Categories_Select();
            dataGridView1.Columns[0].Visible = false;
        }
        public void Clear()
        {
            txtName.Clear();
            txtID.Clear();
            checkboxstatus.Checked = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Plese Enter Categorise", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Categories.Categories_Validate_Name(txtName.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This Categorise already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Categories.Categories_Add(txtName.Text, checkboxstatus.Checked);

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Categories: " + txtName.Text);
            LoadData();
            Clear();


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Plese Enter Categorise", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Categories.Categories_Update(txtName.Text, checkboxstatus.Checked, int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Categories ID: " + txtID.Text);
            LoadData();
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
                    checkboxstatus.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
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
                checkboxstatus.Text = "Acctive";
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Clear();
            txtName.Focus();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "0")
                return;

            Categories.Categories_delete(int.Parse(txtID.Text));
            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete Categories: " + txtName.Text);
            LoadData();
            Clear();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
                btndelete.Enabled = btnEdit.Enabled = false;
            else
                btndelete.Enabled = btnEdit.Enabled = true;
        }
    }
}
