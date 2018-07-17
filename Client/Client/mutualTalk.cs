using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class mutualTalk : Form
    {
        public string GID { get; set; }
        public string UID { get; set; }
        public string GroupName { get; set; }
        public string UserName { get; set; }
        public string auth { get; set; }
        public BinaryReader Br { get; set; }
        public BinaryWriter Bw { get; set; }

        bool iswork = false;
        public mutualTalk()
        {
            InitializeComponent();
        }
        private void mutualTalk_Load(object sender, EventArgs e)
        {
            this.Text = GID + ":" + GroupName;
            lv_members.Columns.Add("ID", 25, HorizontalAlignment.Left);
            lv_members.Columns.Add("权限", 60, HorizontalAlignment.Left);
            lv_members.Columns.Add("昵称", 60, HorizontalAlignment.Left);
            get_member();
            StartListen();

        }
        private Thread th = null;
        private void StartListen()
        {
            iswork = true;
            //tcp消息监听
            th = new Thread(get_noread);
            th.IsBackground = true;
            th.Start();
        }
        private void get_noread()
        {
            int locknum = 0;
            for (int i = 0; i < list.grplockList.Count; i++)
            {
                if (GID == list.grplockList[i].GID)
                {
                    locknum = i;
                }
            }
            while (true)
            {
                //MessageBox.Show(locknum.ToString());
                lock (list.grplockList[locknum].newmsglock)
                {
                    while (list.grplockList[locknum].newmsg == 0) { Monitor.Wait(list.grplockList[locknum].newmsglock); }
                    for (int i = 0; i < list.grpreadList.Count; i++)
                    {
                        if (GID == list.grpreadList[i].GID)
                        {
                            //MessageBox.Show(locknum.ToString());
                            AddMessage(list.grpreadList[i].user, list.grpreadList[i].words, true, list.grpreadList[i].time);
                            list.grpreadList.Remove(list.grpreadList[i]);
                            list.grplockList[locknum].newmsg--;
                        }
                    }
                    readed();
                    Monitor.Pulse(list.grplockList[locknum].newmsglock);
                }
            }
        }

        public void AddMessage(string username,string str, bool isuser, string time)
        {
            int startindex = this.rtb_ShowMsg.Text.Length;

            string message = string.Empty;

            if (isuser)
                message = "【" + username + "】  " + time + "\n" + str + "\n";
            else
                message = "【" + UserName + "】  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + str + "\n";
            this.rtb_ShowMsg.AppendText(message);
            this.rtb_ShowMsg.Select(startindex, message.Length);
            if (isuser)
            {
                this.rtb_ShowMsg.SelectionAlignment = HorizontalAlignment.Left;
            }
            else
            {
                this.rtb_ShowMsg.SelectionAlignment = HorizontalAlignment.Right;
            }
            this.rtb_ShowMsg.Select(this.rtb_ShowMsg.Text.Length, 0);
        }

        private void readed()
        {
            string sndmsg = "grpreaded#" + GID;
            try
            {
                Bw.Write(sndmsg);
            }
            catch
            {
                MessageBox.Show("发送失败");
            }
        }
        private void btn_send_Click(object sender, EventArgs e)
        {
            string temp = this.tb_SendMsg.Text; //保存TextBox文本
            //格式chat#ToName#words
            string sndmsg = "muchat#" + GID + "#" + UID + "#" + temp;
            try
            {
                Bw.Write(sndmsg);
            }
            catch
            {
                MessageBox.Show("发送失败");
            }
            AddMessage("",temp, false, null);
            this.tb_SendMsg.Clear();
        }
        public void get_member()
        {
            lv_members.Items.Clear();
            string sndmsg = "getmutualmember#" + GID;
            try
            {
                Bw.Write(sndmsg);
            }
            catch
            {
                MessageBox.Show("发送失败");
            }
        }
        public void addmemberitem(ListViewItem lvitem)
        {
            lv_members.Items.Add(lvitem);
        }
        private void mutualTalk_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.RemovemutualTalking(this);
            th.Abort();
        }



        private void lv_members_MouseClick(object sender, MouseEventArgs e)
        {
            lv_members.MultiSelect = false;
            if (e.Button == MouseButtons.Right)
            {
                string UID = lv_members.SelectedItems[0].Text;
                Point p = new Point(e.X, e.Y);
                string au = lv_members.SelectedItems[0].SubItems[1].Text;
                if (auth=="2")
                {
                    ts_auth.Visible = false;
                    ts_cg.Visible = false;
                    ts_rm.Visible = false;
                    ts_rmauth.Visible = false;
                }
                else
                {
                    if(auth == "1")
                    {
                        if (au == "群主" || au == "管理员")
                        {
                            ts_auth.Visible = false;
                            ts_cg.Visible = false;
                            ts_rm.Visible = false;
                            ts_rmauth.Visible = false;
                        }
                        else
                        {
                            ts_cg.Visible = false;
                            ts_auth.Visible = false;
                            ts_rmauth.Visible = false;
                            ts_rm.Visible = true;
                        }
                    }
                    else
                    {
                        
                        if (au == "群主")
                        {
                            ts_auth.Visible = false;
                            ts_cg.Visible = false;
                            ts_rm.Visible = false;
                            ts_rmauth.Visible = false;
                        }
                        else {
                            if (au == "管理员")
                            {
                                ts_auth.Visible = false;
                                ts_cg.Visible = true;
                                ts_rm.Visible = true;
                                ts_rmauth.Visible = true;
                            }
                            else
                            {
                                ts_auth.Visible = true;
                                ts_rmauth.Visible = false;
                                ts_cg.Visible = true;
                                ts_rm.Visible = true;
                            }
                        }
                       
                    }
                }
                

                cm_member.Show(lv_members, p);
            }
        }
        private void ts_rm_Click(object sender, EventArgs e)
        {
            if (this.lv_members.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_members.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定移出该群员吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("rmmember#" + GID + "#" + lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
        }

        private void ts_auth_Click(object sender, EventArgs e)
        {
            if (this.lv_members.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_members.SelectedItems[0];
            DialogResult result = MessageBox.Show("将其设置为管理员吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("aumember#" +GID+"#"+ lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
        }

        private void ts_cg_Click(object sender, EventArgs e)
        {
            if (this.lv_members.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_members.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定转让群主吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("cgmember#" + GID + "#" + lvitm.SubItems[0].Text);
                auth = "2";
            }
            else
            {
                return;
            }
        }

        private void ts_rmauth_Click(object sender, EventArgs e)
        {
            if (this.lv_members.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_members.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定移出该群员吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("rmauthmember#" + GID + "#" + lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
        }
    }
}
