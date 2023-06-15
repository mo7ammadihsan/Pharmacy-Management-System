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
using System.IO;

namespace Pharmacy.PL
{
    public partial class FRM_Company : MetroFramework.Forms.MetroForm
    {
        public FRM_Company()
        {
            InitializeComponent();
        }
        private void FRM_Company_Load(object sender, EventArgs e)
        {
            try
            {
                txtName.Text = Company.company_Info_select().Rows[0][0].ToString();
                txtAddress.Text = Company.company_Info_select().Rows[0][1].ToString();
                txtPhone.Text = Company.company_Info_select().Rows[0][2].ToString();
                pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])Company.company_Info_select().Rows[0][3]));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch { }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtAddress.Enabled = txtName.Enabled = txtPhone.Enabled = pictureBox1.Enabled = btnSave.Enabled = true;
            btnEdit.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (pictureBox1.Image == null)
            {
                byte[] img = new byte[4];
                Company.company_Info_Update(txtName.Text, txtAddress.Text, txtPhone.Text, img);
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                byte[] img = ms.ToArray();
                Company.company_Info_Update(txtName.Text, txtAddress.Text, txtPhone.Text, img);
            }
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            txtAddress.Enabled = txtName.Enabled = txtPhone.Enabled = pictureBox1.Enabled = btnSave.Enabled = false;

            BL.Logs.Logs_Add(Program.UserFullName, DateTime.Now.ToString(), "Company Information Edit");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "choose image";
            ofd.Filter = "Image File | *.jpg;*.png;*.bmp;*.jpeg;*.gif";
            ofd.Multiselect = false;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
