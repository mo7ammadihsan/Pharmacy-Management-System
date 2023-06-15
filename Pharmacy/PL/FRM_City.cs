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
    public partial class FRM_City : MetroFramework.Forms.MetroForm
    {
        public FRM_City()
        {
            InitializeComponent();
            DataLoad();
        }
        public void DataLoad()
        {
            dataGridView1.DataSource = City.Cities_Select_Search("");
            dataGridView1.Columns[0].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = City.Cities_Select_Search(txtSearch.Text);
        }

        public void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            cmbCountries.SelectedIndex = -1;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void FRM_City_Load(object sender, EventArgs e)
        {
            cmbCountries.DataSource = Countries.Countries_Select_Search("");
            cmbCountries.DisplayMember = "Name";
            cmbCountries.ValueMember = "ID";
            cmbCountries.SelectedIndex = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            City.Cities_Add(txtName.Text, int.Parse(cmbCountries.SelectedValue.ToString()));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add city: " + txtName.Text);
            DataLoad();
            clear();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            City.Cities_delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete city: " + txtName.Text);
            DataLoad();
            clear();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            City.Cities_Update(int.Parse(txtID.Text), txtName.Text, int.Parse(cmbCountries.SelectedValue.ToString()));
            DataLoad();
            clear();
            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit city ID: " + txtID.Text);
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
                    cmbCountries.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                }
            }
            catch { }
        }
    }
}
