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
    public partial class FRM_MAIN : MetroFramework.Forms.MetroForm
    {
        public FRM_MAIN()
        {
            InitializeComponent();
        }

        private void FRM_MAIN_Load(object sender, EventArgs e)
        {
            labeluser.Text += Program.UserFullName;

            if (Program.Permision != "1")
                btnStaff.Enabled = btnLogs.Enabled = btnBackup.Enabled = btnRestore.Enabled = btnCompany.Enabled = false;

            DataTable dt = Stack.Stack_Select("");
            bool expiry = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((int)Convert.ToDateTime(dt.Rows[i][4].ToString()).Subtract(DateTime.Now).TotalDays < 30)
                {
                    expiry = true;
                }
            }

            if (expiry)
                MetroFramework.MetroMessageBox.Show(this, "Check Stack for Expired Products", "Expired date", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if(fb.ShowDialog() == DialogResult.OK)
                {
                    string path = fb.SelectedPath.ToString() + "\\Pharmacy_DB" + " " + DateTime.Now.ToShortDateString().Replace('/', '_') + " "
                    + DateTime.Now.ToLongTimeString().Replace(':', '.') + ".bak";
                    Database.Backup(path);
                    MetroFramework.MetroMessageBox.Show(this, "Backup Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Title = "Restore";

                if (of.ShowDialog() == DialogResult.OK)
                {
                    Database.Restore(of.FileName);
                    MetroFramework.MetroMessageBox.Show(this, "Restore Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            new FRM_PRODUCTS().Show();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            new FRM_Suppliers().Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            new FRM_Customer().Show();
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            new FRM_Purchases().Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            new FRM_Order().Show();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            new FRM_Cashier().Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            new FRM_Staff().Show();
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            new FRM_Company().Show();
        }

        private void btnStack_Click(object sender, EventArgs e)
        {
            new FRM_Stack().Show();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            new FRM_Logs().Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

           if( MetroFramework.MetroMessageBox.Show(this, "Are You Sure,You Want Exit", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                System.Environment.Exit(0);
        }
    }
}
