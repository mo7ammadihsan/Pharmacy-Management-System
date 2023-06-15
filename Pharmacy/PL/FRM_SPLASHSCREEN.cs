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
    public partial class FRM_SPLASHSCREEN : MetroFramework.Forms.MetroForm
    {
        public FRM_SPLASHSCREEN()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                Prbar.Value += 5;
                if (Prbar.Value == 100)
                {
                    timer1.Enabled = false;
                    this.Hide();
                    FRM_LOGIN frm = new FRM_LOGIN();
                    frm.ShowDialog();
                }
            }
            catch
            {
                return;
            }
        }

        private void pbDBConfig_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            new PL.DBConfig().ShowDialog();
            timer1.Enabled = true;
        }
    }
}
