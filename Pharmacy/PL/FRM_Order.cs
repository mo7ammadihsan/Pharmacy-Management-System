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
    public partial class FRM_Order : MetroFramework.Forms.MetroForm
    {
        public FRM_Order()
        {
            InitializeComponent();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sales.Sales_Select_Search(txtSearch.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sales.Sales_Select_Search("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sales.Sales_Select_Date(dtpFirst.Value.ToShortDateString(), dtpSecound.Value.ToShortDateString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sales.Sales_Select_Today(DateTime.Now.ToShortDateString());
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            RPT.RPT_Order Report_Selected = new RPT.RPT_Order();
            Report_Selected.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report_Selected.Refresh();
            Report_Selected.SetParameterValue("@ID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //**************************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report_Selected;
            Report_View.crystalReportViewer1.Zoom(120);
            //**************************************
            Report_View.Show();


            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Print Selected Order Invoice");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new FRM_OrderLoan().Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FRM_Order_Add().Show();
        }
    }
}
