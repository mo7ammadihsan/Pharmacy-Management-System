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
    public partial class FRM_PRODUCTS_UPDATE : MetroFramework.Forms.MetroForm
    {
        DataTable dt;
        public FRM_PRODUCTS_UPDATE(int ID)
        {
            InitializeComponent();

            dt = Products.Products_Select_Id(ID);
            txtID.Text = dt.Rows[0][0].ToString();
            txtbuyprice.Text= dt.Rows[0][3].ToString();
            txtsellprice.Text = dt.Rows[0][4].ToString();
            txtfilling.Text = dt.Rows[0][5].ToString();
            txtfillprice.Text = dt.Rows[0][6].ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtbuyprice.Text == "" || txtsellprice.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Plese Enter Requried Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int fill;
            int.TryParse(txtfilling.Text, out fill);

            Products.products_UpdatePrice(txtbuyprice.Text, txtsellprice.Text,fill, txtfillprice.Text, int.Parse(txtID.Text));
            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Product ID:" + txtID.Text);
            MetroFramework.MetroMessageBox.Show(this, "", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void onlynumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtfilling_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double fill_price = double.Parse(txtsellprice.Text) / double.Parse(txtfilling.Text);
                txtfillprice.Text = fill_price.ToString();
            }
            catch { }
        }

        private void txtfillprice_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double sell_price = double.Parse(txtfillprice.Text) * double.Parse(txtfilling.Text);
                txtsellprice.Text = sell_price.ToString();
            }
            catch { }
        }
    }
}
