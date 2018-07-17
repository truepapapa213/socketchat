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
    public partial class Mutualreqitem : Form
    {
        public string UID { get; set; }
        public string GID { get; set; }
        public string toname { get; set; }
        public string groupname { get; set; }
        public BinaryWriter Bw { get; set; }
        public Mutualreqitem()
        {
            InitializeComponent();
        }

        private void Mutualreqitem_FormClosed(object sender, FormClosedEventArgs e)
        {
            Friendreq.removeMutualdreqitem(GID, UID);
        }

        private void Mutualreqitem_Load(object sender, EventArgs e)
        {
            tb_username.Text = toname;
            tb_mutualname.Text = groupname;
        }

        private void bt_accept_Click(object sender, EventArgs e)
        {
            String Com = "acceptmureq#";
            Com += GID;
            Com += "#";
            Com += UID;
            Bw.Write(Com);
            this.Close();
        }

        private void bt_refuse_Click(object sender, EventArgs e)
        {
            String Com = "refusemureq#";
            Com += GID;         
            Com += "#";
            Com += UID;
            Bw.Write(Com);
            this.Close();
        }
    }
}
