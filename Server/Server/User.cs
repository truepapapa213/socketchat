using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class User
    {
        public string Account { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UID { get; set; }
        public string sign { get; set; }
        public bool IsLogin { get; set; }
        //private bool isOnline=false;
        //public bool IsOnline { get; set; }
        public TcpClient client;
        public BinaryReader br;
        public BinaryWriter bw;
        public User(TcpClient client)
        {
            this.client = client;
            NetworkStream networkStream = client.GetStream();
            br = new BinaryReader(networkStream);
            bw = new BinaryWriter(networkStream);
        }
    }
}
