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
    public partial class FRM_Staff : MetroFramework.Forms.MetroForm
    {
        public FRM_Staff()
        {
            InitializeComponent();
            DataLoad();
        }
        private void FRM_Staff_Load(object sender, EventArgs e)
        {
            cmbPermission.DataSource = Users.Permissions_Select();
            dataGridView1.Columns[0].Visible = false;
            cmbPermission.DisplayMember = "Per_Name";
            cmbPermission.ValueMember = "Per_ID";
        }
        void DataLoad()
        {
            dataGridView1.DataSource = Users.Users_Select();
        }

        void clearall()
        {
            txtID.Text = txtFullName.Text = txtName.Text = txtPass.Text = "";
            cmbPermission.SelectedIndex = 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtFullName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtPass.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                cmbPermission.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                btndelete.Enabled = btnEdit.Enabled = false;
            else
                btndelete.Enabled = btnEdit.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtFullName.Text == "" || txtPass.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter required field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Users.Users_validate(txtName.Text, txtFullName.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This name or full name already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Users.Users_Add(txtName.Text, txtPass.Text, txtFullName.Text, int.Parse(cmbPermission.SelectedValue.ToString()));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Staff Member: " + txtFullName.Text);
            clearall();
            DataLoad();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtFullName.Text == "" || txtPass.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter required field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Users.Users_Update(int.Parse(txtID.Text), txtName.Text, txtPass.Text, txtFullName.Text, int.Parse(cmbPermission.SelectedValue.ToString()));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Staff Member ID: " + txtID.Text);
            clearall();
            DataLoad();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Users.Users_Delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete Staff Member: " + txtFullName.Text);
            clearall();
            DataLoad();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clearall();
        }
    }
}
