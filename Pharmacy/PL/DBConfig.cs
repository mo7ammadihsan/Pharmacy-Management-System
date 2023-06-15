using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy.PL
{
    public partial class DBConfig : MetroFramework.Forms.MetroForm
    {
        public DBConfig()
        {
            InitializeComponent();

            if (Properties.Settings.Default.Mode == true)
                rbWindows.Checked = true;
            else
                rdSQL.Checked = true;
               
            tbServer.Text=Properties.Settings.Default.Server;
            tbDb.Text= Properties.Settings.Default.Database;
            tbUser.Text = Properties.Settings.Default.Name;
            tbPass.Text = Properties.Settings.Default.Pass;
        }

        private void rbWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWindows.Checked == true)
                tbUser.Enabled = tbPass.Enabled = false;
            else
                tbUser.Enabled = tbPass.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Properties.Settings.Default.Mode = (rbWindows.Checked == true)? true: false;
            Properties.Settings.Default.Server = tbServer.Text;
            Properties.Settings.Default.Database = tbDb.Text;
            Properties.Settings.Default.Name = tbUser.Text;
            Properties.Settings.Default.Pass = tbPass.Text;
            Properties.Settings.Default.Save();

            MetroFramework.MetroMessageBox.Show(this, "", "Success", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }
    }
}
