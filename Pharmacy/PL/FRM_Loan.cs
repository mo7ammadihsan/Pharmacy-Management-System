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
    public partial class FRM_Loan : MetroFramework.Forms.MetroForm
    {
        double TotalResidual = 0;
        public FRM_Loan()
        {
            InitializeComponent();
        }

        private void FRM_Loan_Load(object sender, EventArgs e)
        {
            try
            {
                cmbSupplier.DataSource = Suppliers.Suppliers_Select_Search("");
                cmbSupplier.DisplayMember = "Name";
                cmbSupplier.ValueMember = "ID";
                cmbSupplier.SelectedIndex = -1;
            }
            catch { }
        }

        void clearAllText(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = -1;
                }
                else
                {
                    clearAllText(c);
                }
            }
            txtPaidResidual.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Purchases.Purchases_Select_Loan();

            TotalResidual = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TotalResidual += double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }

                txtTotalResidual.Text = TotalResidual.ToString();
            }
            else
                txtTotalResidual.Text = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(cmbSupplier.SelectedIndex.ToString()) < 0)
                return;
            dataGridView1.DataSource = Purchases.Purchases_Select_Loan_With_Supplier(int.Parse(cmbSupplier.SelectedValue.ToString()));

            TotalResidual = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    TotalResidual += double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
                }

                txtTotalResidual.Text = TotalResidual.ToString();
            }
            else
                txtTotalResidual.Text = "0";
        }

        private void number_only(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPaidResidual_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                //if (Convert.ToDouble(txtPaidResidual.Text) > Convert.ToDouble(txtResidul.Text))
                //{
                //    MessageBox.Show("Please Shure residual Amount","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    txtPaidResidual.Text = "0";
                //}

                double PaidResidual;
                double.TryParse(txtPaidResidual.Text, out PaidResidual);

                txtResidul.Text = (Convert.ToDouble(txtAmount.Text) - (Convert.ToDouble(txtPaid.Text) + PaidResidual)).ToString();

                if (Convert.ToDouble(txtResidul.Text) == 0)
                    txtPaidResidual.ForeColor = Color.Green;
                else
                    txtPaidResidual.ForeColor = Color.Red;
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Purchases.Purchases_Loan_Update(int.Parse(txtID.Text), txtResidul.Text, (Convert.ToDouble(txtPaid.Text) + Convert.ToDouble(txtPaidResidual.Text)).ToString(), txtPurchaseNote.Text);
            button2_Click(null, null);
            txtPaidResidual.ForeColor = Color.DarkGray;
            clearAllText(this);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtSupplier.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPurchaseDate.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtPurchaseNote.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtPaid.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtResidul.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtAmount.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtPaidResidual.Text = "0";
            }
        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            RPT.RPT_Purchases_Loan_All Report = new RPT.RPT_Purchases_Loan_All();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            //***********************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //***********************************
            Report_View.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cmbSupplier.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RPT.RPT_Purchases_Loan_Supplier Report = new RPT.RPT_Purchases_Loan_Supplier();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report.Refresh();
            Report.SetParameterValue("@id", cmbSupplier.SelectedValue);
            //***********************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //***********************************
            Report_View.Show();
        }
    }
}
