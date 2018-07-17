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
    public partial class Friendreqitem : Form
    {
        public string toUID { get; set; }
        public String toName { get; set; }
        public BinaryWriter Bw { get; set; }
        public Friendreqitem()
        {
            InitializeComponent();
        }

        private void Friendreqitem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Friendreq.removeFriendreqitem(toUID);
        }

        private void Friendreqitem_Load(object sender, EventArgs e)
        {
            tb_username.Text = toName;
            for (int i = 0; i < list.GroupList.Count; i++)
            {
                cb_groups.Items.Add(list.GroupList[i]);
            }
            
        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            if (cb_groups.Text == "") 
            {
                lb_state.Text = "分组不能为空";
                return;
            }
            lb_state.Text = "";
            //格式：acceptreq#toname#group
            String Com = "acceptreq#";
            Com += toUID;
            Com += "#";
            Com += cb_groups.Text;
            Bw.Write(Com);
            this.Close();
        }

        private void bt_refuse_Click(object sender, EventArgs e)
        {
            String Com = "refusereq#";
            Com += toUID;
            Bw.Write(Com);
            this.Close();
        }
    }

}
