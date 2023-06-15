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
    public partial class FRM_Stack : MetroFramework.Forms.MetroForm
    {
        public FRM_Stack()
        {
            InitializeComponent();
        }

        private void FRM_Stack_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt = Stack.Stack_Select("");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4].ToString(),
                       (int)Convert.ToDateTime(dt.Rows[i][4].ToString()).Subtract(DateTime.Now).Days / 30, dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7],
                       ((double.Parse(dt.Rows[i][7].ToString()) - (double.Parse(dt.Rows[i][6].ToString()))) / double.Parse(dt.Rows[i][6].ToString())) * 100 + " %", dt.Rows[i][8], dt.Rows[i][9], dt.Rows[i][10], dt.Rows[i][11], dt.Rows[i][12], dt.Rows[i][13], dt.Rows[i][14]);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                if ((int)Convert.ToDateTime(dt.Rows[i][4].ToString()).Subtract(DateTime.Now).TotalDays <= 30)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if(MetroFramework.MetroMessageBox.Show(this,"Are you sure!","Wrong",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk)==DialogResult.Yes)
                Stack.Stack_Delete(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()), dataGridView1.CurrentRow.Cells[4].Value.ToString());
                FRM_Stack_Load(null, null);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DataTable dt = Stack.Stack_Select(txtSearch.Text);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    dataGridView1.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4].ToString(),
                       (int)Convert.ToDateTime(dt.Rows[i][4].ToString()).Subtract(DateTime.Now).TotalDays, dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7],
                       ((double.Parse(dt.Rows[i][7].ToString()) - (double.Parse(dt.Rows[i][6].ToString()))) / double.Parse(dt.Rows[i][6].ToString())) * 100 + " %", dt.Rows[i][8], dt.Rows[i][9], dt.Rows[i][10], dt.Rows[i][11], dt.Rows[i][12], dt.Rows[i][13], dt.Rows[i][14]);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                if ((int)Convert.ToDateTime(dt.Rows[i][4].ToString()).Subtract(DateTime.Now).TotalDays <= 30)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            RPT.RPT_Stack_All Report = new RPT.RPT_Stack_All();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@Search", "");
            //*******************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //*******************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Printed All Stack");
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            RPT.RPT_Stack_Selected Report = new RPT.RPT_Stack_Selected();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@ID", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //*******************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //*******************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Printed Selected Stack ID: " + dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }
    }
}
