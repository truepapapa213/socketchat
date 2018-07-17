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
    public partial class frdgroupcg : Form
    {
        public string UID { get; set; }
        public bool iswork { get; set; }
        public BinaryWriter Bw { get; set; }
        public frdgroupcg()
        {
            InitializeComponent();
        }

        private void frdgroupcg_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < list.GroupList.Count; i++)
            {
                cb_group.Items.Add(list.GroupList[i]);
            }
        }

        private void frdgroupcg_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.Removefrdgrpcg();
        }

        private void cb_send_Click(object sender, EventArgs e)
        {
            if (cb_group.Text == "")
            {
                lb_state.Text = "分组不能为空";
                return;
            }
            String sndmsg = "cgfrdgroup#";
            sndmsg += UID;
            sndmsg += "#";
            sndmsg += cb_group.Text;
            Bw.Write(sndmsg);
            this.Close();
        }

        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
