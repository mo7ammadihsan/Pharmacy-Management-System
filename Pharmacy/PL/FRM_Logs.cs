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
    public partial class FRM_Logs : MetroFramework.Forms.MetroForm
    {
        public FRM_Logs()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BL.Logs.Logs_Select_Today(DateTime.Now.ToShortDateString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BL.Logs.Logs_Select_Between(dtpFirst.Value.ToString(), dtpSecound.Value.ToString());
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                BL.Logs.Logs_Delete(long.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
                dataGridView1.DataSource = BL.Logs.Logs_Select_Today(DateTime.Now.ToShortDateString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BL.Logs.Logs_Select_Search(txtSearch.Text);
        }
    }
}
