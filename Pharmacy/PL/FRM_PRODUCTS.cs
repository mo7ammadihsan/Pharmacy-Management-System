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
using CrystalDecisions.Shared;

namespace Pharmacy.PL
{
    public partial class FRM_PRODUCTS : MetroFramework.Forms.MetroForm
    {
        public FRM_PRODUCTS()
        {
            InitializeComponent();
        }

        private void FRM_PRODUCTS_Load(object sender, EventArgs e)
        {
            cmbScientificName.DataSource = Scientific_Name.Sc_Name_Search_ComboBox();
            cmbScientificName.ValueMember = "ID";
            cmbScientificName.DisplayMember = "Name";
            //***********************************************************
            cmbCategoris.DataSource = Categories.Categories_ComboBox();
            cmbCategoris.ValueMember = "ID";
            cmbCategoris.DisplayMember = "name";
            //************************************************************
            cmbProducerCompany.DataSource = Producer_Company.Producer_Company_ComboBox();
            cmbProducerCompany.ValueMember = "ID";
            cmbProducerCompany.DisplayMember = "name";
            DataLoad();
        }
        public void DataLoad()
        {
            dataGridView1.DataSource = Products.Producs_Select_Search("");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Products.Producs_Select_Search(txtSearch.Text);
        }

        public void clear(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    c.Text = "";
                }
                else
                {
                    clear(c);
                }

            }
            checkboxstatus.Checked = true;
            cmbCategoris.SelectedIndex = 0;
            cmbProducerCompany.SelectedIndex = 0;
            cmbScientificName.SelectedIndex = 0;
        }

        private void btnSceintificName_Click(object sender, EventArgs e)
        {
            new FRM_Sceintific_Name().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new FRM_CATEGORIES().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new FRM_Producer_Company().Show();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // || txtsellprice.Text == "" || txtbuyprice.Text == ""
            if (txtbarcode.Text == "" || txtname.Text == "" )
            {
                MetroFramework.MetroMessageBox.Show(this, "Plese Enter Requried Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (Products.Products_Validate_Barcode(txtbarcode.Text).Rows.Count > 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "This Barcode Already Existed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int fill;
            int.TryParse(txtfilling.Text, out fill);
            Products.products_add(txtname.Text, txtdescription.Text, txtbuyprice.Text, txtsellprice.Text, txtbarcode.Text, int.Parse(cmbCategoris.SelectedValue.ToString()),
                    int.Parse(cmbScientificName.SelectedValue.ToString()), int.Parse(cmbProducerCompany.SelectedValue.ToString()), fill, txtfillprice.Text, checkboxstatus.Checked);

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Add Product: " + txtname.Text);

            DataLoad();
            clear(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // || txtsellprice.Text == "" || txtbuyprice.Text == ""
            if (txtbarcode.Text == "" || txtname.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Plese Enter Requried Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int fill;
            int.TryParse(txtfilling.Text, out fill);
            Products.products_Update(txtname.Text, txtdescription.Text, txtbuyprice.Text, txtsellprice.Text,
                txtbarcode.Text, int.Parse(cmbCategoris.SelectedValue.ToString()), int.Parse(cmbScientificName.SelectedValue.ToString()),
                int.Parse(cmbProducerCompany.SelectedValue.ToString()), fill, txtfillprice.Text, int.Parse(txtID.Text), checkboxstatus.Checked);

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Edit Product ID:" + txtID.Text);

            DataLoad();
            clear(this);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                    txtname.Text = dataGridView1.CurrentRow.Cells["Name"].Value.ToString();
                    txtbarcode.Text = dataGridView1.CurrentRow.Cells["Barcode"].Value.ToString();
                    txtbuyprice.Text = dataGridView1.CurrentRow.Cells["Buy Price"].Value.ToString();
                    txtsellprice.Text = dataGridView1.CurrentRow.Cells["Sell Price"].Value.ToString();
                    txtfilling.Text = dataGridView1.CurrentRow.Cells["Fill"].Value.ToString();
                    txtfillprice.Text = dataGridView1.CurrentRow.Cells["Fill Price"].Value.ToString();
                    cmbCategoris.Text = dataGridView1.CurrentRow.Cells["Categories"].Value.ToString();
                    cmbScientificName.Text = dataGridView1.CurrentRow.Cells["Scientfic Name"].Value.ToString();
                    cmbProducerCompany.Text = dataGridView1.CurrentRow.Cells["Producer Company"].Value.ToString();
                    txtdescription.Text = dataGridView1.CurrentRow.Cells["Description"].Value.ToString();
                    checkboxstatus.Checked = bool.Parse(dataGridView1.CurrentRow.Cells["State"].Value.ToString());
                }
            }
            catch { }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Products.Products_Delete(int.Parse(txtID.Text));

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Delete Product: " + txtname.Text);

            DataLoad();
            clear(this);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            clear(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkboxstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxstatus.Checked == false)
            {
                checkboxstatus.BackColor = Color.Red;
                checkboxstatus.Text = "Passive";

            }
            else
            {
                checkboxstatus.BackColor = Color.Lime;
                checkboxstatus.Text = "Active";
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
                btndelete.Enabled = btnEdit.Enabled = false;
            else
                btndelete.Enabled = btnEdit.Enabled = true;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {  

            RPT.RPT_Products_All Report = new RPT.RPT_Products_All();
            Report.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);

            Report.Refresh();
            Report.SetParameterValue("@Search", "");
            //**************************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report;
            Report_View.crystalReportViewer1.Zoom(120);
            //**************************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Print All Products");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RPT.RPT_Products_Selected Report_Selected = new RPT.RPT_Products_Selected();
            Report_Selected.SetDatabaseLogon(Properties.Settings.Default.Name, Properties.Settings.Default.Pass, Properties.Settings.Default.Server, Properties.Settings.Default.Database);
            Report_Selected.Refresh();
            Report_Selected.SetParameterValue("@id", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            //**************************************
            RPT.Reports Report_View = new RPT.Reports();
            Report_View.crystalReportViewer1.ReportSource = Report_Selected;
            Report_View.crystalReportViewer1.Zoom(120);
            //**************************************
            Report_View.Show();

            Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Print Selected Products ID: " + dataGridView1.CurrentRow.Cells[0].Value.ToString());
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            FRM_PRODUCTS_Load(null, null);
        }
    }
}
