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
    public partial class FRM_Countries : MetroFramework.Forms.MetroForm
    {
        public FRM_Countries()
        {
            InitializeComponent();
            DataLoad();
        }
        public void DataLoad()
        {
            dataGridView1.DataSource = Countries.Countries_Select_Search("");
            dataGridView1.Columns[0].Visible = false;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Countries.Countries_Select_Search(txtSearch.Text);
        }

        public void clear()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtSearch.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Countries.Countries_Add(txtName.Text);
            DataLoad();
            clear();

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Countries");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Countries.Countries_delete(int.Parse(txtID.Text));
            DataLoad();
            clear();

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete Countries");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Countries.Countries_Update(int.Parse(txtID.Text), txtName.Text);
            DataLoad();
            clear();

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Countries");
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
                if (dataGridView1.Rows.Count > 0 && dataGridView1.SelectedRows.Count > 0)
                {
                    txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                }
            }
            catch { }
        }
    }
}
