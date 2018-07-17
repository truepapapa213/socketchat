using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;


//login界面传参数：username、IP、port、br、bw

namespace Client
{
    public partial class Form1 : Form
    {
        public string Username { get; set; }
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
        //public static List<Talking> TalkList = new List<Talking>();
        public List<User> UserList = new List<User>();
        bool iswork = false;
     
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartListen();
        }



        //开启监听服务
        private void StartListen()
        {
            iswork = true;
            tc = new TcpClient("127.0.0.1", 9999);
            ns = tc.GetStream();
            Br = new BinaryReader(ns);
            Bw = new BinaryWriter(ns);
            /*udp消息监听
            Thread th = new Thread(new ThreadStart(UdpListen));
            //设置为后台
            th.IsBackground = true;
            th.Start();*/
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
                    AddMessage(receiveMsg, true);
                    string command = string.Empty;
                    string[] splitStrings = receiveMsg.Split('#');
                    command = splitStrings[0];
                    switch (command)
                    {
                        case "barchmsg":
                            AddMessage(receiveMsg, true);
                            break;
                        case "users":
                            Users = receiveMsg.Replace("users#", "");
                            //LoadUser();
                            break;
                    }
                }
            }
        }

        //消息处理
        public void AddMessage(string text, bool isuser)
        {
            int startindex = this.rtb_ShowMsg.Text.Length;
            string[] infos = text.Split('#');
            //string command = infos[0];
            string fromuser = infos[1];
            string str = infos[2];
            string message = string.Empty;

            if (isuser)
                message = "【" + fromuser + "】  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + str + "\n";
            else
                message = "【" + this.Username + "】  " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + str + "\n";
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

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {//通过TCP协议向服务器发送群发消息
                string temp = this.tb_SendMsg.Text; //保存TextBox文本
                Bw.Write("barchmsg#" + Username + "#" + temp);
                Bw.Flush();
                AddMessage("barchmsg#" + Username + '#' + temp, false);
                this.tb_SendMsg.Clear();
            }
            catch
            { }
        }
    }


    
}
