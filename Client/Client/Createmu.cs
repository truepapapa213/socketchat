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
    public partial class Createmu : Form
    {
        public BinaryWriter Bw { set; get; }
        public Createmu()
        {
            InitializeComponent();
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            if (tb_muname.Text == "")
            {
                lb_state.Text = "群名不能为空";
                return;
            }
            Bw.Write("createmutual#" + tb_muname.Text + "#" + tb_musign.Text);
            this.Close();
        }
    }
}
