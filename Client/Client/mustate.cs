using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class mustate : Form
    {
        public string GID { set; get; }
        public BinaryWriter Bw { get; set; }
        public string groupname { get; set; }
        public string crtname { get; set; }
        public string sign { get; set; }
        public bool iscrt { get; set; }
        public string auth { get; set; }
        public mustate()
        {
            InitializeComponent();
        }

        private void mustate_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.Removemustate(GID);
        }

        private void mustate_Load(object sender, EventArgs e)
        {
            lb_GID.Text = GID;
            tb_grpname.Text = groupname;
            tb_grpsign.Text = sign;
            if (auth == "2")
            {
                tb_grpsign.ReadOnly = true;
                tb_grpname.ReadOnly = true;
                bt_send.Enabled = false;
            }
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            Bw.Write("mustate#" + GID + "#" + tb_grpname.Text+"#"+tb_grpsign.Text);
        }
    }
}
