using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace John.SocialClub.Desktop.Forms.Membership
{
    public partial class Rename : Form
    {
        public static Rename _intance;
        public static string newMaDK = "";

        Rename()
        {
            InitializeComponent();
        }

        public static Rename getInstance()
        {
            if (_intance == null || _intance.IsDisposed)
            {
                _intance = new Rename();
            }
            return _intance;
        }

        public void setMaDK(string oldMadk)
        {
            txtMa.Text = oldMadk.Substring(0, oldMadk.Length - 7);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Rename.newMaDK = txtMa.Text + txtNewMaDK.Text;
            this.Dispose();
        }
    }
}
