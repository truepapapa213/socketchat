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
    public partial class Userstate : Form
    {
        public string UID { set; get; }
        public BinaryWriter Bw { get; set; }
        public string username { get; set; }
        public string sign { get; set; }
        public bool isself { get; set; }
        public Userstate()
        {
            InitializeComponent();
        }

        private void Userstate_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.Removeuserstate(UID);
        }

        private void Userstate_Load(object sender, EventArgs e)
        {
            lb_UID.Text = UID;
            tb_sign.Text = sign;
            tb_username.Text = username;
            if (isself != true)
            {
                tb_sign.ReadOnly = true;
                tb_username.ReadOnly = true;
                bt_change.Enabled = false;
            }

        }

        private void bt_change_Click(object sender, EventArgs e)
        {
            Bw.Write("userstate#" + tb_username.Text + "#" + tb_sign.Text);
        }
    }
}
