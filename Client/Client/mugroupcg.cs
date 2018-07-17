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
    public partial class mugroupcg : Form
    {
        public string GID { get; set; }
        public BinaryWriter Bw { get; set; }
        public bool iswork { set; get; }
        public mugroupcg()
        {
            InitializeComponent();
        }

        private void mugroupcg_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.Removemugrpcg();
        }

        private void bt_send_Click(object sender, EventArgs e)
        {
            if (cb_group.Text == "")
            {
                lb_state.Text = "分组不能为空";
                return;
            }
            String sndmsg = "cgmugroup#";
            sndmsg += GID;
            sndmsg += "#";
            sndmsg += cb_group.Text;
            Bw.Write(sndmsg);
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mugroupcg_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < list.muGroupList.Count; i++)
            {
                cb_group.Items.Add(list.muGroupList[i]);
            }
        }
    }
}
