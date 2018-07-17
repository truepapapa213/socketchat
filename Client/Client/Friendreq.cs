using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Friendreq : Form
    {
        public bool iswork { get; set; }
        public BinaryWriter Bw { get; set; }
        public static List<Friendreqitem> frdformList = new List<Friendreqitem>();
        public static List<Mutualreqitem> muformList = new List<Mutualreqitem>();
        public Friendreq()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //好友申请
            lv_frdreq.Columns.Add("请求ID", 60, HorizontalAlignment.Left);
            lv_frdreq.Columns.Add("昵称", 60, HorizontalAlignment.Left);
            lv_frdreq.Columns.Add("请求状态", 60, HorizontalAlignment.Left);
            //发送的好友申请
            lv_frdputreq.Columns.Add("请求ID", 60, HorizontalAlignment.Left);
            lv_frdputreq.Columns.Add("昵称", 60, HorizontalAlignment.Left);
            lv_frdputreq.Columns.Add("请求状态", 60, HorizontalAlignment.Left);
            //群组申请
            lv_mureq.Columns.Add("UID", 45, HorizontalAlignment.Left);
            lv_mureq.Columns.Add("昵称", 60, HorizontalAlignment.Left);
            lv_mureq.Columns.Add("GID", 45, HorizontalAlignment.Left);
            lv_mureq.Columns.Add("群名", 60, HorizontalAlignment.Left);
            lv_mureq.Columns.Add("请求状态", 60, HorizontalAlignment.Left);
            //发送的群组申请
            lv_putmureq.Columns.Add("GID", 45, HorizontalAlignment.Left);
            lv_putmureq.Columns.Add("群名", 60, HorizontalAlignment.Left);
            lv_putmureq.Columns.Add("请求状态", 60, HorizontalAlignment.Left);
        }
        private void Friendreq_Load(object sender, EventArgs e)
        {
            addreqitem();
            addputreqitem();
            addmureqitem();
            addputmureqitem();
        }

        public void addreqitem()
        {
            for (int i = 0; i < list.frdreqList.Count; i++)
            {
                
                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageIndex = 0;
                lvitem.Text = list.frdreqList[i].UID;
                lvitem.SubItems.Add(list.frdreqList[i].Username);
                lvitem.SubItems.Add("未处理");
                lvitem.Tag = 0;
                lv_frdreq.Items.Add(lvitem);
            }
        }
        public void addputreqitem()
        {
            for (int i = 0; i < list.putfrdreqList.Count; i++)
            {

                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageIndex = 0;
                lvitem.Text = list.putfrdreqList[i].UID;
                lvitem.SubItems.Add(list.putfrdreqList[i].Username);
                lvitem.SubItems.Add("未处理");
                lvitem.Tag = 0;
                lv_frdputreq.Items.Add(lvitem);
            }
        }
        public void addmureqitem()
        {
            for (int i = 0; i < list.mureqList.Count; i++)
            {

                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageIndex = 0;
                lvitem.Text = list.mureqList[i].UID;
                lvitem.SubItems.Add(list.mureqList[i].Username);
                lvitem.SubItems.Add(list.mureqList[i].GID);
                lvitem.SubItems.Add(list.mureqList[i].Groupname);
                lvitem.SubItems.Add("未处理");
                lvitem.Tag = 0;
                lv_mureq.Items.Add(lvitem);
            }
        }
        public void addputmureqitem()
        {
            for (int i = 0; i < list.putmureqList.Count; i++)
            {

                ListViewItem lvitem = new ListViewItem();
                lvitem.ImageIndex = 0;
                lvitem.Text = list.putmureqList[i].GID;
                lvitem.SubItems.Add(list.putmureqList[i].Groupname);
                lvitem.SubItems.Add("未处理");
                lvitem.Tag = 0;
                lv_putmureq.Items.Add(lvitem);
            }
        }
        public void reloadreqitem()
        {
            //MessageBox.Show("trytoclear");
            lv_frdreq.Items.Clear();
            addreqitem();
        }
        public void reloadputreqitem()
        {
            //MessageBox.Show("trytoclear");
            lv_frdputreq.Items.Clear();
            addputreqitem();
        }
        public void reloadmureqitem()
        {
            //MessageBox.Show("trytoclear");
            lv_mureq.Items.Clear();
            addmureqitem();
        }
        public void reloadputmureqitem()
        {
            //MessageBox.Show("trytoclear");
            lv_putmureq.Items.Clear();
            addputmureqitem();
        }
        private void lv_frdreq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lv_frdreq.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_frdreq.SelectedItems[0];
                string toUID = lvitem.Text;
                //string toips = lvitem.Tag.ToString();
                Friendreqitem f = isHaveFriendreqitem(toUID);
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    Friendreqitem frditm = new Friendreqitem();
                    frditm.toUID = toUID;
                    frditm.toName = lvitem.SubItems[1].Text;
                    frditm.Bw = Bw;
                    frdformList.Add(frditm);
                    frditm.Show();
                }
            }
        }
        private void lv_mureq_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lv_mureq.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_mureq.SelectedItems[0];
                string UID = lvitem.Text;
                string GID = lvitem.SubItems[2].Text;
                //string toips = lvitem.Tag.ToString();
                Mutualreqitem f = isHavemureqitem(GID,UID);
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    Mutualreqitem muitm = new Mutualreqitem();
                    muitm.UID = UID;
                    muitm.GID = GID;
                    muitm.Bw = Bw;
                    muitm.toname = lvitem.SubItems[1].Text;
                    muitm.groupname = lvitem.SubItems[3].Text;
                    muformList.Add(muitm);
                    muitm.Show();
                }
            }
        }
        private void Friendreq_FormClosed(object sender, FormClosedEventArgs e)
        {
            list.RemoveFriendreq();
        }

        private Friendreqitem isHaveFriendreqitem(String toUID)
        {
            foreach (Friendreqitem frqitm in frdformList)
            {
                if (frqitm.toUID == toUID)
                    return frqitm;
            }
            return null;
        }
        private Mutualreqitem isHavemureqitem(String GID,String UID)
        {
            foreach (Mutualreqitem muitm in muformList)
            {
                if (muitm.UID == UID && muitm.GID==GID)
                    return muitm;
            }
            return null;
        }
        public static void removeFriendreqitem(String toUID)
        {
            foreach(Friendreqitem frq in frdformList)
            {
                if (frq.toUID == toUID)
                {
                    frdformList.Remove(frq);
                    return;
                }
            }
        }
        public static void removeMutualdreqitem(String GID,String UID)
        {
            foreach (Mutualreqitem muitm in muformList)
            {
                if (muitm.UID == UID && muitm.GID == GID)
                {
                    muformList.Remove(muitm);
                    return;
                }
            }
        }

        private void Friendreq_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*for (int i = 0; i < frdformList.Count; i++)
            {

            }*/
        }

        private void lv_frdputreq_MouseClick(object sender, MouseEventArgs e)
        {
            lv_frdputreq.MultiSelect = false;
            //鼠标右键  
            if (e.Button == MouseButtons.Right)
            {
                //filesList.ContextMenuStrip = contextMenuStrip1;  
                //选中列表中数据才显示 空白处不显示  
                string UID = lv_frdputreq.SelectedItems[0].Text;   
                Point p = new Point(e.X, e.Y);
                contextMenuStrip1.Show(lv_frdputreq, p);
            }
        }
        private void lv_putmureq_MouseClick(object sender, MouseEventArgs e)
        {
            lv_putmureq.MultiSelect = false;
            if (e.Button == MouseButtons.Right)
            {
                string GID = lv_putmureq.SelectedItems[0].Text;
                Point p = new Point(e.X, e.Y);
                contextMenuStrip2.Show(lv_putmureq, p);
            }
        }
        private void CancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_frdputreq.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_frdputreq.SelectedItems[0];
            //MessageBox.Show(lvitm.SubItems[1].Text);
            Bw.Write("cancelfrdreq#" + lvitm.SubItems[0].Text);
        }

        private void CancelmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_putmureq.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_putmureq.SelectedItems[0];
            Bw.Write("cancelmureq#" + lvitm.SubItems[0].Text);
        }

        
    }
}
