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
    public partial class FRM_LOGIN : MetroFramework.Forms.MetroForm
    {
        FRM_MAIN frm = new FRM_MAIN();
        FRM_Cashier Cashier = new FRM_Cashier();

        public FRM_LOGIN()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtName.Text == string.Empty)
            {
                txtName.Focus();
                return;
            }
            if (txtPass.Text == string.Empty)
            {
                txtPass.Focus();
                return;
            }

            DataTable dt = Login.login(txtName.Text, txtPass.Text);

            if (dt.Rows.Count > 0)
            {
                Program.UserFullName = dt.Rows[0]["U_Full_Name"].ToString();
                Program.Permision = dt.Rows[0]["Per_ID"].ToString();
                BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Login");

                this.Hide();
                if (dt.Rows[0]["Per_ID"].ToString() == "3")
                {
                    Cashier.Show();
                }
                else
                {
                    frm.ShowDialog();
                }
            }
            else
            {
                wrong.Text = "invalid password or name";
                txtName.Clear();
                txtPass.Clear();
                txtName.Focus();
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void txtPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider1.SetError(txtPass, "Please enter your name!");
                errorProvider1.SetIconPadding(txtPass, -20);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPass, null);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider1.SetError(txtName, "Please enter your name!");
                errorProvider1.SetIconPadding(txtName, -20);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtName, null);
            }
        }

    }
}
