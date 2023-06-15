using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Pharmacy.BL;

namespace Pharmacy.PL
{
    public partial class FRM_Cashier : MetroFramework.Forms.MetroForm
    {
        double QtyinStack = 0;
        public FRM_Cashier()
        {
            InitializeComponent();

            txtUser.Text = Program.UserFullName;
            InvoiceDate.Text = DateTime.Now.ToLongDateString();
            pbLogo.Image = Image.FromStream(new MemoryStream((byte[])Company.company_Info_select().Rows[0][3]));
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            PhName.Text = Company.company_Info_select().Rows[0][0].ToString();
            PhAddress.Text = Company.company_Info_select().Rows[0][2].ToString();
        }

        private void number_only(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FRM_Cashier_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Sales.Sales_Delete();
                ExpAndQty.Delete();

                if (Program.Permision == "3")
                    System.Environment.Exit(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FRM_Cashier_Load(object sender, EventArgs e)
        {
            cmbBarcode.DataSource = Products.Products_Select_Cashier();
            cmbBarcode.DisplayMember = "Barcode";
            cmbBarcode.ValueMember = "ID";
            cmbBarcode.SelectedIndex = -1;
            //*****************************
            cmbProductName.DataSource = Products.Products_Select_Cashier();
            cmbProductName.DisplayMember = "Name";
            cmbProductName.ValueMember = "ID";
            cmbProductName.SelectedIndex = -1;
            //*****************************

            txtInvoiceNum.Text = Sales.Max_ID().Rows[0][0].ToString();

            Sales.Sales_Insert(InvoiceDate.Text, 1, "", txtUser.Text, 0, 0, "0", "0", "0", "0");
        }

        private void cmbProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbBarcode.Text = Products.Products_Select_Id(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0]["Barcode"].ToString();
                txtPrice.Text = txtTotal.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Sell Price"].ToString();
                //txtCount_KeyUp(null, null);

                QtyinStack = (ExpAndQty.QtyInStack(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0][0] == DBNull.Value) ? 0 : double.Parse(ExpAndQty.QtyInStack(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0][0].ToString());
                errorProvider1.SetError(txtCount, null);
                txtCount.Text = "1";
                //txtCount.Focus();
            }
            catch { }
        }

        private void cmbBarcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbProductName.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Name"].ToString();
                txtPrice.Text = txtTotal.Text = Products.Products_Select_Id(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0]["Sell Price"].ToString();

                QtyinStack = (ExpAndQty.QtyInStack(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0][0] == DBNull.Value) ? 0 : double.Parse(ExpAndQty.QtyInStack(int.Parse(cmbBarcode.SelectedValue.ToString())).Rows[0][0].ToString());
                errorProvider1.SetError(txtCount, null);
                txtCount.Text = "1";
                //txtCount.Focus();
                //txtCount_KeyUp(null, null);
            }
            catch {}
        }

        private void txtCount_KeyUp(object sender, KeyEventArgs e)
        {
            try {
                if (double.Parse(txtCount.Text) > QtyinStack)
                {
                    errorProvider1.SetError(txtCount, string.Format("this County larger than in stack ({0})", QtyinStack));
                    errorProvider1.SetIconPadding(txtCount, -20);
                    txtCount.Focus();
                }
                else
                {
                    try
                    {

                        errorProvider1.SetError(txtCount, null);
                        double price, count;
                        double.TryParse(txtPrice.Text, out price);
                        double.TryParse(txtCount.Text, out count);
                        txtTotal.Text = (count * price).ToString();
                    } catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    if (e.KeyData == Keys.Enter)
                    {
                        button1_Click(null, null);
                    }
                }
            }catch
            {}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (cmbBarcode.Text == "" || cmbProductName.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please select product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtCount.Text == "0" || txtTotal.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Please enter count", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (QtyinStack == 0 || (int.Parse(txtCount.Text) > QtyinStack))
            {
                errorProvider1.SetError(txtCount, string.Format("this County larger than in stack ({0})", QtyinStack));
                errorProvider1.SetIconPadding(txtCount, -20);
                txtCount.Focus();
                return;
            }
            else
            {

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (cmbProductName.Text == dataGridView1.Rows[i].Cells["Column2"].Value.ToString())
                    {
                        if( QtyinStack >= (int.Parse(txtCount.Text) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())))
                        {
                            try
                            {
                                dataGridView1.Rows[i].Cells[2].Value = (int.Parse(txtCount.Text) + int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString())).ToString();
                                dataGridView1.Rows[i].Cells[3].Value = int.Parse(txtPrice.Text);
                                dataGridView1.Rows[i].Cells[4].Value = (int.Parse(txtTotal.Text) + int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString())).ToString();

                                calculate();
                                txtCount.Text = cmbProductName.Text = cmbBarcode.Text = txtPrice.Text = txtTotal.Text = "";
                                QtyinStack = 0;
                                errorProvider1.SetError(txtCount, null);
                                return;
                            }catch(Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                                return;
                            }
                            
                        }
                        else
                        {
                            errorProvider1.SetError(txtCount, string.Format("this County larger than in stack ({0})", QtyinStack));
                            errorProvider1.SetIconPadding(txtCount, -20);
                            txtCount.Focus();
                            return;
                        }
                        
                    }
                }

                calculate();
            }

            dataGridView1.Rows.Add(cmbProductName.SelectedValue, cmbProductName.Text, txtCount.Text, txtPrice.Text, txtTotal.Text);
            calculate();

            txtCount.Text = cmbProductName.Text = cmbBarcode.Text = txtPrice.Text = txtTotal.Text = "";
            QtyinStack = 0;
            cmbBarcode.Focus();
        }

        void calculate()
        {
            double total = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                try
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        total += Convert.ToDouble(dataGridView1.Rows[i].Cells["Column5"].Value);
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                txtInvoiceTotal.Text = total.ToString();
                txtInvoiceDiscount_KeyUp(null, null);
            }
        }

        private void txtInvoiceDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            double discount, total, dis, final;

            double.TryParse(txtInvoiceTotal.Text, out total);
            double.TryParse(txtInvoiceDiscount.Text, out dis);

            discount = (total * dis / 100);
            final = Convert.ToDouble(txtInvoiceTotal.Text) - discount;

            txtInvoiceAmount.Text = final.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Please Add Products", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    Sales_Details.Sales_Details_Insert(int.Parse(txtInvoiceNum.Text), int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()), dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()), dataGridView1.Rows[i].Cells[4].Value.ToString(), "0", "");
                }

                Sales.Sales_Update(int.Parse(txtInvoiceNum.Text), dataGridView1.Rows.Count, txtInvoiceTotal.Text, txtInvoiceTotal.Text, txtInvoiceTotal.Text);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            dataGridView1.Rows.Clear();
            txtInvoiceTotal.Text = txtInvoiceAmount.Text = "";
            txtInvoiceDiscount.Text = "0";
            ExpAndQty.Delete();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                calculate();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            txtInvoiceTotal.Text = txtInvoiceAmount.Text = "";
            txtInvoiceDiscount.Text = "0";

            cmbProductName.Text = cmbBarcode.Text = txtPrice.Text = txtTotal.Text = "";
            txtCount.Text = "";

            errorProvider1.SetError(txtCount, null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbProductName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            cmbProductName_SelectedIndexChanged(null, null);
            txtCount.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();

            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            //QtyinStack = (ExpAndQty.QtyInStack(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0][0] == DBNull.Value) ? 0 : double.Parse(ExpAndQty.QtyInStack(int.Parse(cmbProductName.SelectedValue.ToString())).Rows[0][0].ToString());
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbProductName.Text = cmbBarcode.Text = txtPrice.Text = txtTotal.Text = txtCount.Text = "";
        }
    }
}
