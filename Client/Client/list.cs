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
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class list : Form
    {
        public string UID { get; set; }
        public string Username { get; set; }
        public string sign { get;set; }
        public string Users { get; set; }
        public int Port { get; set; }
        public BinaryReader Br { get; set; }
        public BinaryWriter Bw { get; set; }
        private TcpClient tc = null;
        private UdpClient uc = null;
        private Socket socketClient;
        private NetworkStream ns;
        //private BinaryReader Br;
        //private BinaryWriter Bw;
        public string ServerIP;
        public string ServerPort;

        public string IP { get; set; }

        public List<User> UserList = new List<User>();
        //聊天窗口List
        public static List<Talking> TalkList = new List<Talking>();
        public static List<mutualTalk> mutualTalkList = new List<mutualTalk>();
        //请求窗口List
        public static List<Friendreq> FriendreqList = new List<Friendreq>();
        public static List<Addfriend> addfmList = new List<Addfriend>();
        //好友菜单窗口List
        public static List<frdgroupcg> frdgrpcgList = new List<frdgroupcg>();
        public static List<Userstate> userstateList = new List<Userstate>();
        //群组菜单窗口List
        public static List<mugroupcg> mugrpcgList = new List<mugroupcg>();
        public static List<Createmu> crtmuList = new List<Createmu>();
        public static List<mustate> mustateList = new List<mustate>();
        //未读消息List
        public static List<noread> readList = new List<noread>();
        public static List<Groupnoread> grpreadList = new List<Groupnoread>();
        //锁List
        public static List<reqlock> lockList = new List<reqlock>();
        public static List<Grouplock> grplockList = new List<Grouplock>();
        //好友请求List
        public static List<User> frdreqList = new List<User>();
        public static List<User> putfrdreqList = new List<User>();
        //群组请求List
        public static List<Mureq> mureqList = new List<Mureq>();
        public static List<Mureq> putmureqList = new List<Mureq>();
        //好友分组List
        public static List<String> GroupList = new List<string>();
        public static List<String> muGroupList = new List<string>();
        

        bool iswork = false;
        public list()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        private void list_Load(object sender, EventArgs e)
        {
            this.Text = UID + ":" + Username;
            lb_UID.Text = UID;
            lb_Username.Text = Username;
            Start();
            //获取主界面列表
            Get_Friend();
            Get_Groups();
            Get_muGroups();
            Get_mutualchat();
            //获取请求
            Get_Friendreq();
            Get_Putreq();
            Get_Mureq();
            Get_Putmureq();
            //获取未读消息
            loadnoread();
            loadmunoread();
            lv_friends.Columns.Add("ID", 20, HorizontalAlignment.Left);
            lv_friends.Columns.Add("昵称", 40, HorizontalAlignment.Left);
            lv_friends.Columns.Add("分组", 60, HorizontalAlignment.Left);
            lv_friends.Columns.Add("在线状态", 60, HorizontalAlignment.Left);
            lv_group.Columns.Add("ID", 20, HorizontalAlignment.Left);
            lv_group.Columns.Add("群聊名称", 60, HorizontalAlignment.Left);
            lv_group.Columns.Add("分组", 60, HorizontalAlignment.Left);
        }

        private void Start()
        {
            iswork = true;
            //tcp消息监听
            Thread tcpth = new Thread(TcpListen);
            tcpth.IsBackground = true;
            tcpth.Start();
        }

        //监听服务器端发来的消息
        private void TcpListen()
        {
            while (iswork)
            {
                string receiveMsg = null;
                try
                {
                    receiveMsg = Br.ReadString();
                }
                catch (Exception)
                {
                }
                if (receiveMsg != null)
                {
                    string command = string.Empty;
                    string[] splitStrings = receiveMsg.Split('#');
                    command = splitStrings[0];
                    switch (command)
                    {
                        case "friends":
                            string[] frienditem = splitStrings[1].Split('/');
                            lockList.Clear();
                            foreach (string s in frienditem)
                            {
                                if (s != ".ed")
                                {
                                    string[] _index = s.Split(';');
                                    ListViewItem lvitem = new ListViewItem();
                                    lvitem.ImageIndex = 0;
                                    lvitem.Text = _index[0];
                                    lvitem.SubItems.Add(_index[1]);
                                    lvitem.SubItems.Add(_index[2]);
                                    lvitem.SubItems.Add(_index[4]);
                                    lvitem.Tag = _index[3];
                                    lv_friends.Items.Add(lvitem);
                                    reqlock n_lock = new reqlock(_index[0]);
                                    lockList.Add(n_lock);
                                }
                            }
                            break;
                        case "newmsg":
                            foreach (reqlock l in lockList)
                            {
                                if (l.UID == splitStrings[1])
                                {
                                    lock (l.newmsglock)
                                    {
                                        l.newmsg++;
                                        noread reader = new noread(splitStrings[1], splitStrings[2], splitStrings[3], splitStrings[4]);
                                        readList.Add(reader);
                                        remind(splitStrings[1]);
                                        Monitor.Pulse(l.newmsglock);
                                    }
                                }
                            }
                            break;
                        case "friendreq":
                            //格式：friendreq#UID1;username1/UID2;username2/.ed
                            string[] reqitem = splitStrings[1].Split('/');
                            frdreqList.Clear();
                            foreach (string s in reqitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] frdr = s.Split(';');
                                    User newusr = new User(frdr[0], frdr[1]);
                                    frdreqList.Add(newusr);
                                }

                            }
                            if (isHaveFrdrq() != null)
                            {
                                isHaveFrdrq().reloadreqitem();
                            }
                            break;
                        case "putreq":
                            //格式：friendreq#UID1;username1/UID2;username2/.ed
                            string[] putreqitem = splitStrings[1].Split('/');
                            putfrdreqList.Clear();
                            foreach (string s in putreqitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] pfrdr = s.Split(';');
                                    User pnewusr = new User(pfrdr[0], pfrdr[1]);
                                    putfrdreqList.Add(pnewusr);
                                }

                            }
                            if (isHaveFrdrq() != null)
                            {
                                isHaveFrdrq().reloadputreqitem();
                            }
                            break;
                        case "mureq":
                            //格式：mureq#GID1;groupname;UID1;username/GID2;groupname;UID2;username/.ed
                            string[] mureqitem = splitStrings[1].Split('/');
                            mureqList.Clear();
                            foreach (string s in mureqitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] pfrdr = s.Split(';');
                                    Mureq newmu = new Mureq(pfrdr[2], pfrdr[3], pfrdr[0], pfrdr[1]);
                                    mureqList.Add(newmu);
                                }

                            }
                            if (isHaveFrdrq() != null)
                            {
                                isHaveFrdrq().reloadmureqitem();
                            }
                            break;
                        case "putmureq":
                            //格式：putmureq#GID1;groupname1/GID2;groupname2/.ed
                            string[] putmureqitem = splitStrings[1].Split('/');
                            putmureqList.Clear();
                            foreach (string s in putmureqitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] pfrdr = s.Split(';');
                                    Mureq newmu = new Mureq("","",pfrdr[0], pfrdr[1]);
                                    putmureqList.Add(newmu);
                                }

                            }
                            if (isHaveFrdrq() != null)
                            {
                                isHaveFrdrq().reloadputmureqitem();
                            }
                            break;
                        case "groups":
                            string[] groupitem = splitStrings[1].Split(';');
                            foreach (string s in groupitem)
                            {
                                if (s != ".ed")
                                {
                                    GroupList.Add(s);
                                }
                            }
                            break;
                        case "mugroups":
                            string[] mugroupitem = splitStrings[1].Split(';');
                            foreach (string s in mugroupitem)
                            {
                                if (s != ".ed")
                                {
                                    muGroupList.Add(s);
                                }
                            }
                            break;
                        case "reloadlist":
                            lv_friends.Items.Clear();
                            lv_group.Items.Clear();
                            Get_Friend();
                            Get_mutualchat();
                            foreach(mutualTalk mt in mutualTalkList)
                            {
                                mt.get_member();
                            }
                            Get_Friendreq();
                            Get_Putreq();
                            Get_Mureq();
                            Get_Putmureq();
                            break;
                        case "addreturn":
                            switch (splitStrings[1])
                            {
                                case "msg":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(splitStrings[2]);
                                    }
                                    break;
                                case "true":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_true();
                                    }
                                    break;
                                case "mumsg":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_mumsg(splitStrings[2]);
                                    }
                                    break;
                                case "mutrue":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_mutrue();
                                    }
                                    break;
                                default:
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(receiveMsg);
                                    }
                                    break;
                            }
                            break;
                        case "addmureturn":
                            switch (splitStrings[1])
                            {
                                case "msg":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(splitStrings[2]);
                                    }
                                    break;
                                case "true":
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_true();
                                    }
                                    break;
                                default:
                                    if (isHaveAddfrd() != null)
                                    {
                                        isHaveAddfrd().get_msg(receiveMsg);
                                    }
                                    break;
                            }
                            break;
                        case "mutualname":
                            //格式:mutualname#GID1;Groupname1;权限;分组/GID2;Groupname;权限;分组/.ed
                            string[] mutualitem = splitStrings[1].Split('/');
                            grplockList.Clear();
                            foreach (string s in mutualitem)
                            {
                                if (s != ".ed")
                                {
                                    string[] _index = s.Split(';');
                                    ListViewItem lvitem = new ListViewItem();
                                    lvitem.ImageIndex = 0;
                                    lvitem.Text = _index[0];
                                    lvitem.SubItems.Add(_index[1]);
                                    lvitem.SubItems.Add(_index[3]);
                                    lvitem.Tag = _index[2];
                                    lvitem.SubItems.Add(_index[4]);
                                    lv_group.Items.Add(lvitem);
                                    Grouplock glock = new Grouplock(_index[0]);
                                    grplockList.Add(glock);
                                }
                            }
                            break;
                        case "member":
                            string[] mem = splitStrings[2].Split('/');
                            foreach (string s in mem)
                            {
                                mutualTalk mtk = isHavemutualTalk(splitStrings[1]);
                                if (mtk == null)
                                {
                                    break;
                                }
                                else
                                {
                                    if (s != ".ed")
                                    {
                                        string[] _index = s.Split(';');
                                        ListViewItem lvitem = new ListViewItem();
                                        lvitem.ImageIndex = 0;
                                        lvitem.Text = _index[0];
                                        lvitem.SubItems.Add(_index[1]);
                                        lvitem.SubItems.Add(_index[2]);
                                        lvitem.Tag = _index[2];
                                        mtk.addmemberitem(lvitem);
                                    }
                                }
                            }
                            break;
                        case "munewmsg":
                            foreach (Grouplock l in grplockList)
                            {
                                if (l.GID == splitStrings[1])
                                {
                                    lock (l.newmsglock)
                                    {
                                        l.newmsg++;
                                        Groupnoread reader = new Groupnoread(splitStrings[1], splitStrings[2], splitStrings[3], splitStrings[4], splitStrings[5]);
                                        grpreadList.Add(reader);
                                        muremind(splitStrings[1]);
                                        Monitor.Pulse(l.newmsglock);
                                    }
                                }
                            }
                            break;
                        case "userstate":
                            Username = splitStrings[1];
                            sign = splitStrings[2];
                            lb_Username.Text = Username;
                            break;
                        /*case "mustate":
                            mustate(splitStrings[1], splitStrings[2], splitStrings[3]);
                            break;*/
                        default:
                            MessageBox.Show(receiveMsg);
                            break;
                    }
                }
            }
        }

        //获取列表
        private void Get_Friend()
        {
            try
            {
                Bw.Write("getfriends");
            }
            catch
            {
                MessageBox.Show("获取好友列表失败");
            }
        }
        private void Get_Groups()
        {
            try
            {
                Bw.Write("getgroups");
            }
            catch
            {
                MessageBox.Show("获取好友分组失败");
            }
        }
        private void Get_muGroups()
        {
            try
            {
                Bw.Write("getmugroups");
            }
            catch
            {
                MessageBox.Show("获取群组分组失败");
            }
        }
        private void Get_mutualchat()
        {
            try
            {
                Bw.Write("getmutualchat");
            }
            catch
            {
                MessageBox.Show("获取群聊信息失败");
            }
        }

        //获取请求
        public void Get_Friendreq()
        {
            try
            {
                Bw.Write("getfriendreq");
            }
            catch
            {
                MessageBox.Show("获取好友列表失败");
            }
        }
        public void Get_Putreq()
        {
            try
            {
                Bw.Write("getputreq");
            }
            catch
            {
                MessageBox.Show("获取发送的好友列表失败");
            }
        }
        public void Get_Mureq()
        {
            try
            {
                Bw.Write("getmureq");
            }
            catch
            {
                MessageBox.Show("获取群组申请列表失败");
            }
        }
        public void Get_Putmureq()
        {
            try
            {
                Bw.Write("getputmureq");
            }
            catch
            {
                MessageBox.Show("获取发送的群组申请列表失败");
            }
        }

        private void loadnoread()
        {
            string sndmsg = "getnoread#";
            try
            {
                Bw.Write(sndmsg);
            }
            catch
            {
                MessageBox.Show("获取消息失败");
            }

        }
        private void loadmunoread()
        {
            string sndmsg = "getmunoread#";
            try
            {
                Bw.Write(sndmsg);
            }
            catch
            {
                MessageBox.Show("获取消息失败");
            }

        }
        private void remind(String UID)
        {
            foreach (ListViewItem item in this.lv_friends.Items)
            {
                if (isHaveTalk(UID) != null)
                {
                    break;
                }
                else
                {
                    if (item.Text == UID)
                    {
                        item.SubItems[0].BackColor = Color.Red;
                    }
                }
            }
        }
        private void muremind(String GID)
        {
            foreach (ListViewItem item in this.lv_group.Items)
            {
                if (isHavemutualTalk(GID) != null)
                {
                    break;
                }
                else
                {
                    if (item.Text == GID)
                    {
                        item.SubItems[0].BackColor = Color.Red;
                    }
                }
            }
        }
        //修改属性
        /*private void mustate(string GID,string groupname,string sign)
        {
            foreach (ListViewItem item in this.lv_group.Items)
            {
                if (item.Text == GID)
                {
                    item.SubItems[1].Text = groupname;
                    item.SubItems[4].Text = sign;
                }    
            }
        }
        private void state(string UID,string username,string sign)
        {

        }*/
        //关闭窗口
        private void list_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                string sendmsg = "logout#" + UID;
                Bw.Write(sendmsg);
                Bw.Flush();
                iswork = false;
                Br.Close();
                Bw.Close();
            }
            catch
            { }
            Application.Exit();
        }

        private void lv_friends_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_friends.SelectedItems[0];
                string toUID = lvitem.Text;
                string toname = lvitem.SubItems[1].Text;
                string toips = lvitem.Tag.ToString();
                Talking t = isHaveTalk(toUID);
                if (t != null)
                {
                    t.Focus();
                }
                else
                {
                    this.lv_friends.SelectedItems[0].SubItems[0].BackColor = Color.Transparent;
                    Talking talk = new Talking();
                    talk.UID = toUID;
                    talk.UserName = Username;
                    talk.ToName = toname;
                    talk.Br = Br;
                    talk.Bw = Bw;
                    TalkList.Add(talk);
                    talk.Show();
                }
            }
        }
        private Talking isHaveTalk(string toUID)
        {
            foreach (Talking tk in TalkList)
            {
                if (tk.UID == toUID)
                    return tk;
            }
            return null;
        }
        public static void RemoveTalking(Talking _talk)
        {
            foreach (Talking tk in TalkList)
            {
                if (tk.UID == _talk.UID)
                {
                    TalkList.Remove(_talk);
                    return;
                }
            }
        }

        private void frdreq_btn_Click(object sender, EventArgs e)
        {
            Friendreq f = isHaveFrdrq();
            if (f != null)
            {
                f.Focus();
            }
            else
            {
                Friendreq frq = new Friendreq();
                frq.iswork = true;
                frq.Bw = Bw;
                FriendreqList.Add(frq);
                frq.Show();
            }

        }
        private Friendreq isHaveFrdrq()
        {
            foreach (Friendreq frq in FriendreqList)
            {
                if (frq.iswork == true)
                    return frq;
            }
            return null;
        }
        public static void RemoveFriendreq()
        {
            foreach (Friendreq f in FriendreqList)
            {
                if (f.iswork == true)
                {
                    FriendreqList.Remove(f);
                    return;
                }
            }
        }

        private void addfrd_btn_Click(object sender, EventArgs e)
        {
            Addfriend f = isHaveAddfrd();
            if (f != null)
            {
                f.Focus();
            }
            else
            {
                Addfriend adf = new Addfriend();
                adf.iswork = true;
                adf.Bw = Bw;
                addfmList.Add(adf);
                adf.Show();
            }
        }
        private Addfriend isHaveAddfrd()
        {
            foreach (Addfriend adf in addfmList)
            {
                if (adf.iswork == true)
                    return adf;
            }
            return null;
        }
        public static void RemoveAddfrd()
        {
            foreach (Addfriend a in addfmList)
            {
                if (a.iswork == true)
                {
                    addfmList.Remove(a);
                    return;
                }
            }
        }

        private void lv_group_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lv_group.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_group.SelectedItems[0];
                string GID = lvitem.Text;
                string Groupname = lvitem.SubItems[1].Text;
                string auth = lvitem.Tag.ToString();
                mutualTalk mt = isHavemutualTalk(GID);
                if (mt != null)
                {
                    mt.Focus();
                }
                else
                {
                    this.lv_group.SelectedItems[0].SubItems[0].BackColor = Color.Transparent;
                    mutualTalk mtalk = new mutualTalk();
                    mtalk.UID = UID;
                    mtalk.GID = GID;
                    mtalk.GroupName = Groupname;
                    mtalk.UserName = Username;
                    mtalk.auth = auth;
                    mtalk.Br = Br;
                    mtalk.Bw = Bw;
                    mutualTalkList.Add(mtalk);
                    mtalk.Show();
                }
            }
        }
        private mutualTalk isHavemutualTalk(string GID)
        {
            foreach (mutualTalk mtk in mutualTalkList)
            {
                if (mtk.GID == GID)
                    return mtk;
            }
            return null;
        }
        public static void RemovemutualTalking(mutualTalk _mtalk)
        {
            foreach (mutualTalk mtk in mutualTalkList)
            {
                if (mtk.GID == _mtalk.GID)
                {
                    mutualTalkList.Remove(_mtalk);
                    return;
                }
            }

        }
        //弹出菜单
        private void lv_friends_MouseClick(object sender, MouseEventArgs e)
        {
            lv_friends.MultiSelect = false;
            if (e.Button == MouseButtons.Right)
            {
                string UID = lv_friends.SelectedItems[0].Text;
                Point p = new Point(e.X, e.Y);
                cm_frd.Show(lv_friends, p);
            }
        }
        private void lv_group_MouseClick(object sender, MouseEventArgs e)
        {
            lv_group.MultiSelect = false;
            if (e.Button == MouseButtons.Right)
            {
                string GID = lv_group.SelectedItems[0].Text;
                Point p = new Point(e.X, e.Y);
                if (lv_group.SelectedItems[0].Tag.ToString() != "0")
                {
                    delmuToolStripMenuItem.Visible = false;
                    exitmuToolStripMenuItem.Visible = true;
                }
                else
                {
                    delmuToolStripMenuItem.Visible = true;
                    exitmuToolStripMenuItem.Visible = false;
                }
                cm_grp.Show(lv_group, p);
            }
        }
        //删除好友
        private void frddelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_friends.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定删除好友吗？", "提示:",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("delfriends#" + lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
            //MessageBox.Show(lvitm.SubItems[1].Text);         
        }
        //修改好友分组
        private void frdgrpcgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_friends.SelectedItems[0];
                string UID = lvitem.Text;
                frdgroupcg f = isHavefrdgrpcg();
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    frdgroupcg fgcg = new frdgroupcg();
                    fgcg.iswork = true;
                    fgcg.UID = UID;
                    fgcg.Bw = Bw;
                    frdgrpcgList.Add(fgcg);
                    fgcg.Show();
                }
            }
        }
        private frdgroupcg isHavefrdgrpcg()
        {
            foreach (frdgroupcg frq in frdgrpcgList)
            {
                if (frq.iswork == true)
                    return frq;
            }
            return null;
        }
        public static void Removefrdgrpcg()
        {
            foreach (frdgroupcg frq in frdgrpcgList)
            {
                if (frq.iswork == true)
                {
                    frdgrpcgList.Remove(frq);
                    return;
                }
            }
        }
        //查看用户信息
        private void frdstateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_friends.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_friends.SelectedItems[0];
                string UID1 = lvitem.Text;
                Userstate us = isHaveuserstate(UID1);
                if (us != null)
                {
                    us.Focus();
                }
                else
                {
                    Userstate ust = new Userstate();
                    ust.UID = UID1;
                    if (UID1 == UID)
                    {
                        ust.isself = true;
                    }
                    else
                    {
                        ust.isself = false;
                    }
                    ust.Bw = Bw;
                    ust.username = lvitem.SubItems[1].Text;
                    ust.sign = lvitem.Tag.ToString();
                    userstateList.Add(ust);
                    ust.Show();
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Userstate us = isHaveuserstate(UID);
            if (us != null)
            {
                us.Focus();
            }
            else
            {
                Userstate ust = new Userstate();
                ust.UID = UID;
                ust.isself = true;
                ust.Bw = Bw;
                ust.username = Username;
                ust.sign = sign;
                userstateList.Add(ust);
                ust.Show();
            }
        }

        private Userstate isHaveuserstate(string UID)
        {
            foreach (Userstate ust in userstateList)
            {
                if (ust.UID == UID)
                    return ust;
            }
            return null;
        }
        public static void Removeuserstate(string UID)
        {
            foreach (Userstate ust in userstateList)
            {
                if (ust.UID == UID)
                {
                    userstateList.Remove(ust);
                    return;
                }
            }
        }
        //查看群组信息
        private void mustateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_group.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_group.SelectedItems[0];
                string GID1 = lvitem.Text;
                mustate us = isHavemustate(GID1);
                if (us != null)
                {
                    us.Focus();
                }
                else
                {
                    mustate ust = new mustate();
                    ust.auth = lvitem.Tag.ToString();
                    ust.GID = GID1;
                    ust.Bw = Bw;
                    ust.groupname = lvitem.SubItems[1].Text;
                    ust.sign = lvitem.SubItems[3].Text;
                    mustateList.Add(ust);
                    ust.Show();
                }
            }
        }
        private mustate isHavemustate(string GID)
        {
            foreach (mustate mst in mustateList)
            {
                if (mst.GID == GID)
                    return mst;
            }
            return null;
        }
        public static void Removemustate(string GID)
        {
            foreach (mustate mst in mustateList)
            {
                if (mst.GID == GID)
                {
                    mustateList.Remove(mst);
                    return;
                }
            }
        }
        //创建群组
        private void crtmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_group.SelectedItems.Count > 0)
            {
                Createmu c = new Createmu();
                c.Bw = Bw;
                c.Show();
            }
        }
        //修改群组分组
        private void cgmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_group.SelectedItems.Count > 0)
            {
                ListViewItem lvitem = this.lv_group.SelectedItems[0];
                string GID = lvitem.Text;
                mugroupcg f = isHavemugrpcg();
                if (f != null)
                {
                    f.Focus();
                }
                else
                {
                    mugroupcg mgcg = new mugroupcg();
                    mgcg.iswork = true;
                    mgcg.GID = GID;
                    mgcg.Bw = Bw;
                    mugrpcgList.Add(mgcg);
                    mgcg.Show();
                }
            }
        }
        private mugroupcg isHavemugrpcg()
        {
            foreach (mugroupcg frq in mugrpcgList)
            {
                if (frq.iswork == true)
                    return frq;
            }
            return null;
        }
        public static void Removemugrpcg()
        {
            foreach (mugroupcg frq in mugrpcgList)
            {
                if (frq.iswork == true)
                {
                    mugrpcgList.Remove(frq);
                    return;
                }
            }
        }
        //退出群聊
        private void exitmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_group.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_group.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定退出该群吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("exitmu#" + lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
        }

        private void delmuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lv_group.SelectedItems.Count == 0)
                return;
            ListViewItem lvitm = this.lv_group.SelectedItems[0];
            DialogResult result = MessageBox.Show("确定解散该群吗？", "提示:", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Bw.Write("delmu#" + lvitm.SubItems[0].Text);
            }
            else
            {
                return;
            }
        }

        
    }

    public class noread
    {

        public string UID { get; set; }
        public string user { get; set; }
        public string time { get; set; }
        public string words { get; set; }
        public noread(string userid, string u, string t, string w)
        {
            UID = userid;
            user = u;
            time = t;
            words = w;
        }


    }
    public class reqlock
    {
        public string UID { get; set; }
        public object newmsglock { get; set; }
        public int newmsg { get; set; }
        public reqlock(string userid)
        {
            UID = userid;
            newmsg = 0;
            newmsglock = new object();
        }
    }

    public class Groupnoread
    {
        public string GID { get; set; }
        public string UID { get; set; }
        public string user { get; set; }
        public string time { get; set; }
        public string words { get; set; }
        public Groupnoread(string grpid, string userid, string u, string t, string w)
        {
            GID = grpid;
            UID = userid;
            user = u;
            time = t;
            words = w;
        }
    }

    public class Grouplock
    {
        public string GID { get; set; }
        public object newmsglock { get; set; }
        public int newmsg { get; set; }
        public Grouplock(string grpid)
        {
            GID = grpid;
            newmsg = 0;
            newmsglock = new object();
        }

    }

    public class Mureq
    {
        private string uid;
        private string username;
        private string gid;
        private string groupname;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string UID
        {
            get { return uid; }
            set { uid = value; }
        }
        public string Groupname
        {
            get { return groupname; }
            set { groupname = value; }
        }
        public string GID
        {
            get { return gid; }
            set { gid = value; }
        }
        public Mureq(String UID,String Username,String GID,String Groupname)
        {
            uid = UID;
            username = Username;
            gid = GID;
            groupname = Groupname;
        }

    }
}



public class User
{
    private string uid;
    private string username;
    public string Username
    {
        get { return username; }
        set { username = value; }
    }
    public string UID
    {
        get { return uid; }
        set { uid = value; }
    }
    private string password;
    public string Password
    {
        get { return password; }
        set { password = value; }
    }
    private string ip;
    public string IP
    {
        get { return ip; }
        set { ip = value; }
    }
    private int port;
    public int Port
    {
        get { return port; }
        set { port = value; }
    }
    public User(string ID,string Usrname)
    {
        uid = ID;
        username = Usrname;
    }
    //private bool isOnline=false;
    //public bool IsOnline { get; set; }
}