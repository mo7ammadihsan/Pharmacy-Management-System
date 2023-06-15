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
    public partial class FRM_Purchases_Add : MetroFramework.Forms.MetroForm
    {
        public FRM_Purchases_Add()
        {
            InitializeComponent();
        }

        private void FRM_Purchases_Add_Load(object sender, EventArgs e)
        {
            cmbSupplier.DataSource = Suppliers.Suppliers_Select_Search("");
            cmbSupplier.DisplayMember = "Name";
            cmbSupplier.ValueMember = "ID";
            cmbSupplier.SelectedIndex = -1;
            //************************************
            cmbBarcode.DataSource = Products.Producs_Select_Search("");
            cmbBarcode.DisplayMember = "Barcode";
            cmbBarcode.ValueMember = "ID";
            cmbBarcode.SelectedIndex = -1;
            //************************************
            cmbProductName.DataSource = Products.Producs_Select_Search("");
            cmbProductName.DisplayMember = "Name";
            cmbProductName.ValueMember = "ID";
            cmbProductName.SelectedIndex = -1;
        }

        private void cmbBarcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProductName.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Name"].ToString();
                txtProductId.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["ID"].ToString();
                txtBuyPrice.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Buy Price"].ToString();
                txtSalePrice.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Sell Price"].ToString();
                cmbBarcode.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Barcode"].ToString();
            }
            catch { }
        }
        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProductName.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Name"].ToString();
                txtProductId.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["ID"].ToString();
                txtBuyPrice.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Buy Price"].ToString();
                txtSalePrice.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Sell Price"].ToString();
                cmbBarcode.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Barcode"].ToString();
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
            txtProductDiscount.Text = txtProductCount.Text = "0";
            txtCount.Text = txtTotal.Text = txtdiscount.Text = txtAmount.Text = txtTotalPaid.Text = txtTotalResidul.Text = "0";
            dtpExpiredDate.Text = "";
        }
        private void txtCountDataDet_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                double buyTotal = double.Parse(txtBuyPrice.Text) * double.Parse(txtProductCount.Text);
                txtProductTotal.Text = buyTotal.ToString();
                //*****************************************
                double Discount;
                double.TryParse(txtProductDiscount.Text, out Discount);
                double buyDiscount = (double.Parse(txtProductTotal.Text) * Discount) / 100;
                double buyFinal = buyTotal - buyDiscount;
                txtProductAmount.Text = buyFinal.ToString();
            }
            catch { }
        }

        private void number_only(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtTotalPaid_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                txtTotalResidul.Text = (Convert.ToDouble(txtAmount.Text) - Convert.ToDouble(txtTotalPaid.Text)).ToString();
            }
            catch { }
        }
        void calculating()
        {
            txtCount.Text = dataGridView1.Rows.Count.ToString();
            //**************************************************
            double totalTotals = 0;
            double totalDiscount = 0;
            double totalFinals = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalTotals += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
                totalDiscount += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value) * Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value) / 100;
                totalFinals += Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
            }
            txtTotal.Text = totalTotals.ToString();
            txtdiscount.Text = totalDiscount.ToString();
            txtAmount.Text = totalFinals.ToString();
            txtTotalResidul.Text = totalFinals.ToString();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = true;
            btnAdd.Enabled = true;
            dataGridView1.Rows.Clear();
            clearAllText(this);
            txtUser.Text = Program.UserFullName;
            txtInvoiceNum.Text = Purchases.Max_ID().Rows[0][0].ToString();
        }

        private void btnAddDataDet_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Select product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtProductCount.Text == "0")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter product count", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtProductId.Text)
                    {
                        MetroFramework.MetroMessageBox.Show(this, "This product already existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                double discount;
                double.TryParse(txtProductDiscount.Text, out discount);

                dataGridView1.Rows.Add(txtProductId.Text, cmbProductName.Text, dtpExpiredDate.Text.ToString(), txtBuyPrice.Text, txtProductCount.Text,
                    txtProductTotal.Text, discount.ToString(), txtProductAmount.Text, txtProductNote.Text);
                //***********************************************
                txtProductId.Text = cmbProductName.Text = dtpExpiredDate.Text = cmbBarcode.Text =
                txtSalePrice.Text = txtBuyPrice.Text = txtProductTotal.Text = txtProductAmount.Text =
                txtProductNote.Text = "";
                txtProductDiscount.Text = txtProductCount.Text = "0";
                calculating();

            }
        }

        private void btndeleteDataDet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            calculating();
        }

        private void btnClearDataDet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
                dataGridView1.Rows.Clear();
            calculating();
        }



        private void btnEditDataDet_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                txtProductId.Text = dataGridView1.CurrentRow.Cells["Column1"].Value.ToString();
                cmbProductName.Text = dataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                txtBuyPrice.Text = dataGridView1.CurrentRow.Cells["Column3"].Value.ToString();
                txtProductCount.Text = dataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                txtProductTotal.Text = dataGridView1.CurrentRow.Cells["Column5"].Value.ToString();
                txtProductDiscount.Text = dataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
                txtProductAmount.Text = dataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
                txtProductNote.Text = dataGridView1.CurrentRow.Cells["Column8"].Value.ToString();
                dtpExpiredDate.Text = dataGridView1.CurrentRow.Cells["Column9"].Value.ToString();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                cmbProductName_SelectedIndexChanged(null, null);
                calculating();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbSupplier.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dataGridView1.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter some product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                Purchases.Purchases_Insert(DateTime.Now.ToString(), int.Parse(cmbSupplier.SelectedValue.ToString()), txtNote.Text, txtUser.Text, int.Parse(txtCount.Text),
                    int.Parse(txtdiscount.Text), txtTotalPaid.Text, txtTotalResidul.Text, txtAmount.Text, txtTotal.Text);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Purchases_Details.Purchases_Details_Insert(int.Parse(txtInvoiceNum.Text), int.Parse(dataGridView1.Rows[i].Cells["Column1"].Value.ToString()),
                        dataGridView1.Rows[i].Cells["Column3"].Value.ToString(), int.Parse(dataGridView1.Rows[i].Cells["Column4"].Value.ToString()),
                        dataGridView1.Rows[i].Cells["Column5"].Value.ToString(), dataGridView1.Rows[i].Cells["Column6"].Value.ToString(),
                        dataGridView1.Rows[i].Cells["Column8"].Value.ToString(), dataGridView1.Rows[i].Cells["Column9"].Value.ToString());

                    ExpAndQty.ExpAndQty_Add(dataGridView1.Rows[i].Cells["Column9"].Value.ToString() + " " + DateTime.Now.ToLongTimeString(),
                        int.Parse(dataGridView1.Rows[i].Cells["Column1"].Value.ToString()),
                        int.Parse(dataGridView1.Rows[i].Cells["Column4"].Value.ToString()), int.Parse(cmbSupplier.SelectedValue.ToString()));
                }

                groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = false;
                btnAdd.Enabled = false;
                dataGridView1.Rows.Clear();
                clearAllText(this);

                BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Purchases Invoice");
            }
        }

        private void btnProductEdit_Click(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
                return;

            new FRM_PRODUCTS_UPDATE(int.Parse(txtProductId.Text)).ShowDialog();

            txtBuyPrice.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Buy Price"].ToString();
            txtSalePrice.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Sell Price"].ToString();

        }


        private void txtProductId_TextChanged(object sender, EventArgs e)
        {
            if (txtProductId.Text == "")
                btnProductEdit.Enabled = false;
            else
                btnProductEdit.Enabled = true;
        }
    }
}
