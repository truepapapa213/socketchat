using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;

namespace Server
{
    class Program
    {
        public static List<User> userlist = new List<User>();
        private static TcpListener t1; //监听对象
        private static NetworkStream ns; //网络流
        private static string localAddress = GetAddressIP();
        static void Main(string[] args)
        {
            try
            {
                t1 = new TcpListener(9999);
                t1.Start();
                Console.WriteLine("服务器启动成功...");
                Thread th = new Thread(new ThreadStart(ListenClientConnect));
                th.IsBackground = true;
                th.Start();
                while (true)
                {
                    string index = Console.ReadLine();
                    if (index == "exit")
                    {
                        Console.WriteLine("开始停止服务，并依次使用户退出!");
                        foreach (User user in userlist)
                        {
                            user.br.Close();
                            user.bw.Close();
                            user.client.Close();
                        }
                        t1.Stop();
                        break;
                    }
                    else
                    {
                        SendToClient(userlist, "barchmsg#服务器#" + index);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("服务器启动失败..." + e.Message);
                throw;
            }
        }

        private static void ListenClientConnect()
        {
            Console.WriteLine("开始在{0}:{1}监听客户连接", localAddress, 9999);
            while (true)
            {
                TcpClient newClient = null;
                try
                {
                    //等待用户进入
                    newClient = t1.AcceptTcpClient();
                }
                catch
                {
                    break;
                }
                //每接受一个客户端连接，就创建一个线程循环接收该客户端发来的信息
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ReceiveData);
                Thread threadReceive = new Thread(pts);
                User user = new User(newClient);
                threadReceive.Start(user);
                //userlist.Add(user);
            }
        }


        private static void ReceiveData(object obj)
        {
            User user = (User)obj;
            TcpClient client = user.client;
            //是否正常退出接收线程
            bool normalExit = false;
            //用于控制是否退出循环
            bool exitWhile = false;
            //用于指向特定user
            String toName = null;
            String toUID = null;
            String GID = null;
            while (exitWhile == false)
            {
                string receiveString = null;
                try
                {
                    receiveString = user.br.ReadString();
                }
                catch
                {
                    Console.WriteLine("接受数据失败");
                }
                if (receiveString == null)
                {
                    if (normalExit == false)
                    {
                        if (client.Connected == true)
                        {
                            Console.WriteLine("与{0}]失去联系，已终止接收该用户信息", client.Client.RemoteEndPoint);
                        }
                    }
                    break;
                }
                Console.WriteLine("来自[{0}]：{1}", user.client.Client.RemoteEndPoint, receiveString);
                string[] splitString = receiveString.Split('#');
                string sendString = "";


                //SendToClient(userlist,receiveString);
                switch (splitString[0])
                {
                    case "login":
                        //格式：login#jack#12345
                        user.Account = splitString[1];
                        user.Password = splitString[2];
                        if (LoginCheck(user)!="false")
                        {
                            user.UID = LoginCheck(user);
                            user.Username = GetUsername(user.UID);
                            user.sign = GetUsersign(user.UID);
                            bool flag = false;
                            foreach (User u in userlist)
                            {
                                if (u.Username.Equals(user.Username))
                                    flag = true;
                            }
                            if (!flag)
                            {
                                user.IsLogin = true;
                                userlist.Add(user);
                                sendString = "user#";
                                sendString += user.UID;
                                sendString += "#";
                                sendString += user.Username;
                                sendString += "#";
                                sendString += user.sign;
                                //SendToClient(userlist, sendString);//发给所有用户

                            }
                            else
                            {
                                SendToClient(user, "already login");
                                break;
                            }
                            Console.WriteLine("[{0}]{1}({2})登录成功\t当前连接用户数{3}", user.UID,user.Username, user.client.Client.RemoteEndPoint, userlist.Count);

                        }
                        else
                        {
                            SendToClient(user, "login fail");
                            break;
                        }
                        SendToClient(user, sendString);//登陆消息反馈，只发给自己
                        MySqlDataReader ol = FriendsReader(user.UID);
                        while (ol.Read())
                        {
                            if (get_oluser(ol[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(ol[0].ToString()), "reloadlist");
                            }
                        }
                        ol.Close();
                        break;
                    case "signup":
                        //格式:signup#账号#密码#昵称
                        string temp = SignUp(splitString[1], splitString[2],splitString[3]);
                        SendToClient(user, temp);
                        break;
                    case "logout":
                        //格式：logout#jack
                        Console.WriteLine("{0}:{1}[{2}]退出", user.UID,user.Username, user.client.Client.RemoteEndPoint);
                        MySqlDataReader ofl = FriendsReader(user.UID);
                        while (ofl.Read())
                        {
                            if (get_oluser(ofl[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(ofl[0].ToString()), "reloadlist");
                            }
                        }
                        normalExit = true;
                        exitWhile = true;
                        user.IsLogin = false;
                        break;
                    case "getfriends":
                        try
                        {
                            //格式：friends#UID1;username1;group1;isonline/UID2;username2;group2;isonline/.ed
                            MySqlDataReader friends = FriendsReader(user.UID);
                            sendString = "friends#";
                            while (friends.Read())
                            {
                                sendString += friends[0].ToString();
                                sendString += ";";
                                sendString += friends[1].ToString();
                                sendString += ";";
                                sendString += friends[2].ToString();
                                sendString += ";";
                                sendString += friends[3].ToString();
                                sendString += ";";

                                //if (isol(friends[0].ToString()) == true)
                                if (get_oluser(friends[0].ToString()) != null)
                                {
                                    sendString += "在线";
                                }
                                else
                                {
                                    sendString += "离线";
                                }
                                sendString += "/";
                            }
                            sendString += ".ed";
                            SendToClient(user, sendString);

                        }
                        catch
                        {
                            Console.WriteLine("获取好友列表失败");
                        }

                        break;
                    case "chat":
                        toUID = splitString[1];
                        String chatwords = splitString[2];
                        try
                        {
                            sndchat(user.UID, toUID, chatwords);
                            Console.WriteLine("{0}向{1}发送\"{2}\"成功。", user.Username, toName, chatwords);
                        }
                        catch
                        {
                            Console.WriteLine("{0}向{1}发送的\"{2}\"失败了。", user.Username, toName, chatwords);
                        }
                        if (get_oluser(toUID) != null)
                        {
                            //格式：newmsg#UID#senduser#time#chatword
                            sendString = "newmsg#" + user.UID + "#" + user.Username + "#" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#" + chatwords;
                            Console.WriteLine(sendString);
                            SendToClient(get_oluser(toUID), sendString);
                        }
                        break;
                    case "readed":
                        toUID = splitString[1];
                        readed(toUID,user.UID);
                        break;
                    case "grpreaded":
                        GID = splitString[1];
                        mureaded(user.UID,GID);
                        break;
                    case "getnoread": //接受未读消息
                        toUID = splitString[1];
                        try
                        {
                            //格式：newmsg#UID#senduser#time#chatword
                            MySqlDataReader noread = getnoread(user.UID);
                            while (noread.Read())
                            {
                                sendString = "newmsg#" + noread[0].ToString() + "#" + noread[1].ToString() + "#" + noread[2].ToString() + "#" + noread[3].ToString();
                                SendToClient(user, sendString);
                            }
                            //readed(toUID, user.UID);
                        }
                        catch
                        {
                            Console.WriteLine("{0}获取未读消息失败。", user.Username);
                        }
                        break;
                    case "getmunoread":
                        MySqlDataReader munoread = getmunoread(user.UID);
                        while (munoread.Read())
                        {
                            //格式：munewmsg#GID#UID#Username#Sendtime#Sendwords
                            sendString = "munewmsg#" + munoread[0].ToString() + "#" + munoread[1].ToString() +"#"+GetUsername(munoread[1].ToString()) +"#" + munoread[2].ToString() + "#" + munoread[3].ToString();
                            SendToClient(user, sendString);
                        }
                        break;
                    case "addfriend": //发送好友请求
                        toUID = splitString[1];
                        String needGroup = splitString[2];
                        if (toUID == user.UID)
                        {
                            sendString = "addreturn#msg#不能添加自己为好友";
                        }
                        else
                        {
                            if (getuser(toUID) == true)
                            {
                                if (isHavereq(user.UID, toUID) == true)
                                {
                                    sendString = "addreturn#msg#已经发送过该请求";
                                }
                                else
                                {
                                    if (isHavefrd(user.UID, toUID) == true)
                                    {
                                        sendString = "addreturn#msg#你们已经是好友了";
                                    }
                                    else
                                    {
                                        putfriendreq(user.UID, toUID, needGroup);
                                        sendString = "addreturn#true";
                                        SendToClient(user, "reloadlist");
                                    }
                                }
                                
                            }
                            else
                            {
                                sendString = "addreturn#msg#用户不存在";
                                Console.WriteLine("{0}查找{1}用户失败。", user.Username, toName);
                            }
                        }
                        SendToClient(user, sendString);
                        if (get_oluser(toUID) != null)
                        {
                            SendToClient(get_oluser(toUID), "reloadlist");
                        }
                        break;
                    case "addgroup": //发送入群申请
                        GID = splitString[1];
                        String needmuGroup = splitString[2];
                        if (getmu(GID) == true)
                        {
                            if (isHavemureq(GID,user.UID) == true)
                            {
                                sendString = "addreturn#mumsg#已经发送过该请求";
                            }
                            else
                            {
                                if (isHavemember(GID, user.UID) == true)
                                {
                                    sendString= "addreturn#mumsg#你已在该群中";
                                }
                                else
                                {
                                    putmureq(GID, user.UID, needmuGroup);
                                    sendString = "addreturn#mutrue";
                                    SendToClient(user, "reloadlist");
                                }
                            }
                        }
                        else
                        {
                            sendString = "addreturn#msg#群组不存在";
                        }
                        SendToClient(user, sendString);
                        if (getmu(GID) == true)
                        {
                            MySqlDataReader auth = getauth(GID);
                            while (auth.Read())
                            {
                                if (get_oluser(auth[0].ToString()) != null)
                                {
                                    SendToClient(get_oluser(auth[0].ToString()), "reloadlist");
                                }
                            }
                            auth.Close();
                        }
                        break;
                    case "cancelfrdreq": //取消好友请求
                        toUID = splitString[1];
                        removefriendreq(user.UID, toUID);
                        SendToClient(user, "reloadlist");
                        if (get_oluser(toUID) != null)
                        {
                            SendToClient(get_oluser(toUID), "reloadlist");
                        }
                        break;
                    case "cancelmureq": //取消入群请求
                        GID = splitString[1];
                        removemureq(GID, user.UID);
                        SendToClient(user, "reloadlist");
                        MySqlDataReader oauth = getauth(GID);
                        while (oauth.Read())
                        {
                            if (get_oluser(oauth[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(oauth[0].ToString()), "reloadlist");
                            }
                        }
                        oauth.Close();
                        break;
                    case "delfriends": //删除好友
                        toUID = splitString[1];
                        removefriends(user.UID, toUID);
                        SendToClient(user, "reloadlist");
                        if (get_oluser(toUID) != null)
                        {
                            SendToClient(get_oluser(toUID), "reloadlist");
                        }
                        break;
                    case "exitmu": //退出群聊
                        GID = splitString[1];
                        removemu(user.UID, GID);
                        SendToClient(user, "reloadlist");
                        MySqlDataReader olme = getmember(GID);
                        while (olme.Read())
                        {
                            if (get_oluser(olme[0].ToString()) != null && olme[0].ToString() != user.UID)
                            {
                                SendToClient(get_oluser(olme[0].ToString()), "reloadlist");
                            }
                        }
                        olme.Close();
                        break;
                    case "delmu": //解散群聊
                        GID = splitString[1];
                        delmu(GID);
                        SendToClient(userlist, "reloadlist");
                        break;
                    case "cgfrdgroup":
                        toUID = splitString[1];
                        string exgroup = splitString[2];
                        changefrdgrp(user.UID, toUID, exgroup);
                        SendToClient(user, "reloadlist");
                        break;
                    case "cgmugroup":
                        GID = splitString[1];
                        string exmgroup = splitString[2];
                        changemugrp(user.UID, GID, exmgroup);
                        SendToClient(user, "reloadlist");
                        break;
                    case "getfriendreq": //获取好友请求列表
                        try
                        {
                            //格式：friendreq#UID1;username1/UID2;username2/.ed
                            sendString = "friendreq#";
                            MySqlDataReader frdreq = getfriendreq(user.UID);
                            while (frdreq.Read())
                            {
                                sendString += frdreq[0].ToString();
                                sendString += ";";
                                sendString += GetUsername(frdreq[0].ToString());
                                sendString += "/";
                            }
                            sendString += ".ed";
                            SendToClient(user, sendString);
                        }
                        catch
                        {
                            Console.WriteLine("{0}查找好友请求失败。", user.Username, toName);
                        }
                        break;
                    case "getputreq": //获取已发送好友请求列表
                        try
                        {
                            //格式：putreq#UID1;username1/UID2;username2/.ed
                            sendString = "putreq#";
                            MySqlDataReader putreq = getputreq(user.UID);
                            while (putreq.Read())
                            {
                                sendString += putreq[0].ToString();
                                sendString += ";";
                                sendString += GetUsername(putreq[0].ToString());
                                sendString += "/";
                            }
                            sendString += ".ed";
                            SendToClient(user, sendString);
                        }
                        catch
                        {
                            Console.WriteLine("{0}查找已发送的好友请求失败。", user.Username);
                        }
                        break;
                    case "createmutual":
                        string groupname = splitString[1];
                        string groupsign = splitString[2];
                        createmu(user.UID, groupname,groupsign);
                        SendToClient(user, "reloadlist");
                        break;
                    case "getmureq": //获取群组申请列表
                        try
                        {
                            //格式：mureq#GID1;groupname;UID1;username/GID2;groupname;UID2;username/.ed
                            sendString = "mureq#";
                            MySqlDataReader mureq = getmureq(user.UID);
                            while (mureq.Read())
                            {
                                sendString += mureq[0].ToString();
                                sendString += ";";
                                sendString += mureq[1].ToString();
                                sendString += ";";
                                sendString += mureq[2].ToString();
                                sendString += ";";
                                sendString += mureq[3].ToString();
                                sendString += "/";
                            }
                            sendString += ".ed";
                            SendToClient(user, sendString);
                        }
                        catch
                        {
                            Console.WriteLine("{0}查找群组请求失败。", user.Username);
                        }
                        break;
                    case "getputmureq":
                        try
                        {
                            //格式：putmureq#GID1;groupname1/GID2;groupname2/.ed
                            sendString = "putmureq#";
                            MySqlDataReader putmureq = getputmureq(user.UID);
                            while (putmureq.Read())
                            {
                                sendString += putmureq[0].ToString();
                                sendString += ";";
                                sendString += putmureq[1].ToString();
                                sendString += "/";
                            }
                            sendString += ".ed";
                            SendToClient(user, sendString);
                        }
                        catch
                        {
                            Console.WriteLine("{0}查找已发送的好友请求失败。", user.Username);
                        }
                        break;
                    case "getgroups": //获取分组信息
                        sendString = "groups#";
                        sendString += getgroups(user.UID);
                        sendString += ".ed";
                        SendToClient(user, sendString);
                        break;
                    case "getmugroups"://获取群分组信息
                        sendString = "mugroups#";
                        sendString += getmugroups(user.UID);
                        sendString += ".ed";
                        SendToClient(user, sendString);
                        break;
                    case "acceptreq"://同意好友申请
                        toUID = splitString[1];
                        String groups = splitString[2];
                        addnewfriends(toUID, user.UID, groups);
                        removefriendreq(toUID, user.UID);
                        removefriendreq(user.UID, toUID);
                        sendString = "reloadlist#";
                        SendToClient(user, sendString);
                        if (get_oluser(toUID) != null)
                        {
                            SendToClient(get_oluser(toUID), "reloadlist");
                        }
                        break;
                    case "refusereq"://拒绝好友申请
                        toUID = splitString[1];
                        removefriendreq(toUID, user.UID);
                        sendString = "reloadlist#";
                        SendToClient(user, sendString);
                        break;
                    case "acceptmureq": //同意入群申请
                        toUID = splitString[2];
                        GID = splitString[1];
                        joinmutual(GID,toUID);
                        removemureq(GID, toUID);
                        sendString = "reloadlist#";
                        SendToClient(user, sendString);
                        MySqlDataReader olmems= getmember(GID);
                        while (olmems.Read())
                        {
                            if (get_oluser(olmems[0].ToString()) != null && olmems[0].ToString() != user.UID)
                            {
                                SendToClient(get_oluser(olmems[0].ToString()), sendString);
                            }
                        }
                        olmems.Close();
                        break;
                    case "refusemureq"://拒绝入群申请
                        toUID = splitString[2];
                        GID = splitString[1];
                        removemureq(GID, toUID);
                        sendString = "reloadlist#";
                        SendToClient(user, sendString);
                        MySqlDataReader olauth = getauth(GID);
                        while (olauth.Read())
                        {
                            if (get_oluser(olauth[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(olauth[0].ToString()), "reloadlist");
                            }
                        }
                        olauth.Close();
                        break;
                    case "getmutualchat"://获取群聊名称
                        MySqlDataReader mutualname = getmutual(user.UID);
                        //格式:mutualname#GID1;Groupname1;权限;分组;简介/GID2;Groupname;权限;分组;简介/.ed
                        sendString = "mutualname#";
                        while (mutualname.Read())
                        {
                            sendString += mutualname[0].ToString();
                            sendString += ";";
                            sendString += mutualname[1].ToString();
                            sendString += ";";
                            sendString += mutualname[2].ToString();
                            sendString += ";";
                            sendString += mutualname[3].ToString();
                            sendString += ";";
                            sendString += mutualname[4].ToString();
                            sendString += "/";
                        }
                        sendString += ".ed";
                        SendToClient(user, sendString);
                        mutualname.Close();
                        break;
                    case "getmutualmember":
                        GID = splitString[1];
                        MySqlDataReader mem = getmember(GID);
                        //格式:member#GID#UID1;auth1;Username1/UID2;auth2;Username2/.ed
                        sendString = "member#" + GID + "#";
                        while (mem.Read())
                        {
                            sendString += mem[0].ToString();
                            sendString += ";";
                            switch (mem[1].ToString())
                            {
                                case "0":
                                    sendString += "群主";
                                    break;
                                case "1":
                                    sendString += "管理员";
                                    break;
                                case "":
                                    sendString += "群员";
                                    break;
                            }
                            sendString += ";";
                            sendString += mem[2].ToString();
                            sendString += "/";
                        }
                        sendString += ".ed";
                        SendToClient(user, sendString);
                        mem.Close();
                        break;
                    case "muchat":
                        GID = splitString[1];
                        String mutualchatwords = splitString[3];
                        try
                        {
                            sndmuchat(user.UID, GID, mutualchatwords);
                            Console.WriteLine("{0}向{1}发送\"{2}\"成功。", user.Username, GID, mutualchatwords);
                        }
                        catch
                        {
                            Console.WriteLine("{0}向{1}发送的\"{2}\"失败了。", user.Username, GID, mutualchatwords);
                        }
                        MySqlDataReader olmem = getmember(GID);
                        while (olmem.Read())
                        {
                            if (get_oluser(olmem[0].ToString())!=null && olmem[0].ToString()!=user.UID)
                            {
                                //格式：munewmsg#GID#UID#Username#Sendtime#Sendwords
                                sendString = "munewmsg#" + GID + "#" + user.UID + "#" +GetUsername(olmem[0].ToString()) +"#"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "#" + mutualchatwords;
                                Console.WriteLine(sendString);
                                SendToClient(get_oluser(olmem[0].ToString()), sendString);
                            }

                        }
                        break;
                    case "userstate":
                        string usrname = splitString[1];
                        string usrsign = splitString[2];
                        userstate(user.UID, usrname, usrsign);
                        SendToClient(user, "userstate#"+usrname+"#"+usrsign);
                        MySqlDataReader ol1 = FriendsReader(user.UID);
                        while (ol1.Read())
                        {
                            if (get_oluser(ol1[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(ol1[0].ToString()), "reloadlist");
                            }
                        }
                        break;
                    case "mustate":
                        GID = splitString[1];
                        string muname = splitString[2];
                        string musign = splitString[3];
                        mustate(GID, muname, musign);
                        MySqlDataReader omem = getmember(GID);
                        while (omem.Read())
                        {
                            if (get_oluser(omem[0].ToString()) != null )
                            {
                                SendToClient(get_oluser(omem[0].ToString()), "reloadlist");
                            }
                        }
                        break;
                    case "rmmember":
                        GID = splitString[1];
                        toUID = splitString[2];
                        removemember(GID, toUID);
                        MySqlDataReader o1 = getmember(GID);
                        while (o1.Read())
                        {
                            if (get_oluser(o1[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(o1[0].ToString()), "reloadlist");
                            }
                        }
                        break;
                    case "aumember":
                        GID = splitString[1];
                        toUID = splitString[2];
                        aumember(GID, toUID);
                        MySqlDataReader o2 = getmember(GID);
                        while (o2.Read())
                        {
                            if (get_oluser(o2[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(o2[0].ToString()), "reloadlist");
                            }
                        }
                        break;
                    case "cgmember":
                        GID = splitString[1];
                        toUID = splitString[2];
                        cgmember(GID, toUID);
                        MySqlDataReader o3 = getmember(GID);
                        while (o3.Read())
                        {
                            if (get_oluser(o3[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(o3[0].ToString()), "reloadlist");
                            }
                        }
                        break;
                    case "rmauthmember":
                        GID = splitString[1];
                        toUID = splitString[2];
                        rmaumember(GID, toUID);
                        MySqlDataReader o4 = getmember(GID);
                        while (o4.Read())
                        {
                            if (get_oluser(o4[0].ToString()) != null)
                            {
                                SendToClient(get_oluser(o4[0].ToString()), "reloadlist");
                            }
                        }
                        SendToClient(get_oluser(toUID), "reloadlist");
                        break;
                    default:
                        Console.WriteLine("未知指令：{0}", receiveString);
                        break;

                }
            }
            userlist.Remove(user);
            //SendToClient(userlist, "users#" + GetUsers());//发给其他用户
            client.Close();
            Console.WriteLine("当前连接用户数：{0}", userlist.Count);
        }

        private static void SendToClient(User user, string str)
        {
            try
            {
                //将字符串写入网络流，此方法会自动附加字符串长度前缀
                user.bw.Write(str);
                user.bw.Flush();
                Console.WriteLine("向[{0}({1})]发送：{2}", user.Username, user.client.Client.RemoteEndPoint, str);
            }
            catch
            {
                Console.WriteLine("向[{0}({1})]发送信息失败", user.Username, user.client.Client.RemoteEndPoint);
            }
        }
        //重载方法
        private static void SendToClient(IEnumerable<User> users, string str)
        {
            foreach (var user in users)
            {
                try
                {
                    //将字符串写入网络流，此方法会自动附加字符串长度前缀
                    user.bw.Write(str);
                    user.bw.Flush();
                }
                catch
                {
                    Console.WriteLine("向[{0}({1})]发送信息失败", user.Username, user.client.Client.RemoteEndPoint);
                }
            }
        }


        //根据UID返回一个在线的User
        private static User get_oluser(String UID)
        {
            User oluser = null;
            foreach (User u in userlist)
            {
                if (u.UID.Equals(UID))
                {
                    oluser = u;
                    break;
                }
            }
            return oluser;
        }

        static string GetAddressIP()
        {
            //获取本地的IP地址
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        static string LoginCheck(User user)
        {
            SQL_u get = new SQL_u();
            String UID = "";
            get.Initialize("localhost", "chatshow", "root", "ppp213");
            try { get.OpenConnection(); }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return "false";
            }
            String Com = "SELECT Password,UID FROM user WHERE Account=\"" + user.Account + "\";";
            try
            {
                MySqlDataReader read  = Reader(Com);
                if (read.HasRows == false)
                {
                    read.Close();
                    Console.WriteLine("账号不存在");
                    return "false";
                }
                else
                {
                    read.Read();
                    if (read[0].ToString() == user.Password)
                    {
                        UID = read[1].ToString();
                        read.Close();
                        return UID;
                    }
                    else
                    {
                        read.Close();
                        return "false";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询数据失败了！" + ex.Message);
                return "false";
            }
        }

        static string SignUp(string account, string password,string username)
        {
            SQL_u get = new SQL_u();
            get.Initialize("localhost", "chatshow", "root", "ppp213");
            try { get.OpenConnection(); }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return "无法连接到主机";
            }
            String Com = "SELECT Account FROM user WHERE Account=\"" + account + "\";";
            MySqlDataReader read = Reader(Com);

            if (read.HasRows == false)
            {
                read.Close();
                Com = "INSERT INTO user (Account,Password,Groups,G_groups,Username) VALUES (\"" + account + "\",\"" + password + "\",\"我的好友;家人;同学;同事;\",\"我的群;常用群聊;\",\""+username+"\");";
                try
                {
                    get.getInsert(Com);
                    get.CloseConnection();
                    return "注册成功";         
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return "无法注册";
                }
            }
            else
            {
                read.Close();
                return "用户名已存在";
            }

        }
        static string GetUsername(String UID)
        {
            String Username = "";
            string com = "SELECT Username FROM user WHERE UID=" + UID + ";";
            MySqlDataReader read = Reader(com);
            read.Read();
            Username = read[0].ToString();
            read.Close();
            return Username;
        }
        static string GetUsersign(String UID)
        {
            String Username = "";
            string com = "SELECT Sign FROM user WHERE UID=" + UID + ";";
            MySqlDataReader read = Reader(com);
            read.Read();
            Username = read[0].ToString();
            read.Close();
            return Username;
        }
        //获取好友列表
        private static MySqlDataReader FriendsReader(String UID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT UID2,Username,friends.groups,Sign FROM user,friends WHERE friends.UID2=user.UID AND friends.UID1=\"" + UID + "\"";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询数据失败了！" + ex.Message);
            }
            //friend.CloseConnection();
            return read;
        }
        //发送单人消息
        private static void sndchat(String UID, String toUID, String chatwords)
        {

            String Com = "INSERT INTO chathis (UID1,UID2,Sendtime,Sendwords,isread) VALUES (\"" + UID + "\",\"" + toUID + "\",\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"" + chatwords + "\",\"0\");";
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
        }
        //发送多人消息
        private static void sndmuchat(String UID,String GID, String chatwords)
        {
            String Com = "INSERT INTO groupchathis (GID,UID,Sendtime,Sendwords) VALUES (\"" + GID + "\",\"" + UID + "\",\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"" + chatwords + "\");";
            up(Com);
        }
        //获取未读信息
        private static MySqlDataReader getnoread(String toUID)
        {
            String Com = "SELECT chathis.UID1,user.Username,chathis.Sendtime,chathis.Sendwords FROM chathis,user WHERE chathis.UID1=user.UID AND chathis.isread=0 AND chathis.UID2=" + toUID + ";";
            MySqlDataReader read = null;
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;

        }
        //将未读消息全部标为已读
        private static void readed(string UID, String toUID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT * FROM chathis WHERE UID2=\"" + toUID + "\" AND isread=0;";
            read = Reader(Com);
            read.Read();
            if (read.HasRows == true)
            {
                read.Close();
                Com = "UPDATE chathis SET isread=1 WHERE UID2=" + toUID + " AND UID1=\"" + UID + "\" AND isread=0;";
                st(Com);
            }
            else
            {
                read.Close();
            }

        }
        //将群组未读消息标为已读
        private static void mureaded(string UID,string GID)
        {
            string Com = "UPDATE groupmembers SET closetime=\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\" WHERE GID="+GID+" AND UID="+UID+";";
            st(Com);
        }
        //获取群组未读消息
        private static MySqlDataReader getmunoread(string UID)
        {
            String Com = "SELECT closetime,GID FROM groupmembers WHERE UID="+UID+";";
            MySqlDataReader read = null;
            read = Reader(Com);
            if (read.HasRows == true)
            {
                read.Read();
                String closetime = read[0].ToString();
                read.Close();
                Com = "SELECT * FROM groupchathis WHERE DATE_FORMAT(Sendtime,'%Y-%m-%d %H:%i')>=DATE_FORMAT('" + closetime + "','%Y-%m-%d %H:%i');";
                read = Reader(Com);
            }       
            return read;
        }
        //获取指向Username的所有好友请求
        private static MySqlDataReader getfriendreq(String UID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT UID1 FROM frdreq WHERE UID2=\"" + UID + "\";";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        //获取Username指向toname的所有好友请求
        private static MySqlDataReader getfriendreq(String UID, String toUID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT * FROM frdreq WHERE UID1=\"" + UID + "\" AND UID2=\"" + toUID + "\";";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        //获取UID的所有发出的好友请求
        private static MySqlDataReader getputreq(String UID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT UID2 FROM frdreq WHERE UID1=\"" + UID + "\";";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        //获取指向UID的所有群组请求
        private static MySqlDataReader getmureq(string UID)
        {
            MySqlDataReader read = null;
            String Com = " SELECT groups.GID,groups.Groupname,user.UID,user.Username FROM user,groups,groupreq,groupmembers WHERE groups.GID=groupreq.GID AND user.UID=groupreq.UID AND groupmembers.GID=groups.GID AND groupmembers.UID="+UID+" AND groupmembers.auth<2;";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        private static MySqlDataReader getputmureq(string UID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT groups.GID,groups.Groupname FROM groups,groupreq WHERE groups.GID=groupreq.GID AND groupreq.UID="+UID+";";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        private static MySqlDataReader getmureq(string GID,string UID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT * FROM groupreq WHERE GID=" + GID + " AND UID=" + UID + ";";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        //查看是否存在好友请求
        private static bool isHavereq(String UID1,String UID2)
        {
            String Com = "SELECT * FROM frdreq WHERE UID1=" + UID1 + " AND UID2=" + UID2 + ";";
            MySqlDataReader read = null;
            read = Reader(Com);
            if (read.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //查看是否存在入群请求
        private static bool isHavemureq(string GID,string UID)
        {
            String Com = "SELECT * FROM groupreq WHERE GID=" + GID + " AND UID=" + UID + ";";
            MySqlDataReader read = null;
            read = Reader(Com);
            if (read.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //查看是否已经是好友
        private static bool isHavefrd(String UID1, String UID2)
        {
            String Com = "SELECT * FROM friends WHERE UID1=" + UID1 + " AND UID2=" + UID2 + ";";
            MySqlDataReader read = null;
            read = Reader(Com);
            if (read.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //查看是否已经入群
        private static bool isHavemember(String GID,String UID)
        {
            String Com = "SELECT * FROM groupmembers WHERE GID=" + GID + " AND UID=" + UID + ";";
            MySqlDataReader read = null;
            read = Reader(Com);
            if (read.HasRows == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //发送好友请求
        private static void putfriendreq(String UID, String toUID, string group)
        {
            String Com = "INSERT INTO frdreq (UID1,UID2,expgroup) VALUES (\"" + UID + "\",\"" + toUID + "\",\"" + group + "\");";
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
        }
        //发送入群请求
        private static void putmureq(string GID,string UID,string group)
        {
            String Com = "INSERT INTO groupreq (GID,UID,expgroup) VALUES (\"" + GID + "\",\"" + UID + "\",\"" + group + "\");";
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
        }
        //删除好友申请条目
        private static void removefriendreq(String UID, String toUID)
        {
            String Com = "DELETE FROM frdreq WHERE UID1=\"" + UID + "\" AND UID2=\"" + toUID + "\";";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        //删除好友条目
        private static void removefriends(string UID,string toUID)
        {
            String Com = "DELETE FROM friends WHERE UID1=\"" + UID + "\" AND UID2=\"" + toUID + "\";";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
            Com = "DELETE FROM friends WHERE UID2=\"" + UID + "\" AND UID1=\"" + toUID + "\";";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        //删除成员条目
        private static void removemu(string UID,string GID)
        {
            String Com = "DELETE FROM groupmembers WHERE UID=\"" + UID + "\" AND GID=\"" + GID + "\";";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        private static void delmu(string GID)
        {
            string Com = "DELETE FROM groups WHERE GID="+GID+";";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
            Com= "DELETE FROM groupmembers WHERE GID=" + GID + ";";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        //修改好友分组
        private static void changefrdgrp(string UID,string toUID,string exgroup)
        {
            String Com = "UPDATE friends SET groups=\""+exgroup+"\" WHERE UID1="+UID+" AND UID2= "+toUID+"";
            try
            {
                st(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        private static void changemugrp(string UID, string GID, string exgroup)
        {
            String Com = "UPDATE groupmembers SET G_group=\"" + exgroup + "\" WHERE UID=" + UID + " AND GID= " + GID + "";
            try
            {
                st(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        //创建群聊
        private static void createmu(string UID,string groupname,string groupsign)
        {
            String Com = "INSERT INTO groups (Groupname,CreatorUID,Groupsine) VALUES (\"" + groupname + "\","+UID+",\""+groupsign+"\");";
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
            Com = "SELECT GID FROM groups WHERE Groupname=\""+groupname+"\" AND CreatorUID="+UID+";";
            MySqlDataReader read = Reader(Com);
            read.Read();
            Com = "INSERT INTO groupmembers (GID,UID,auth,jointime,closetime,G_group) VALUES (" + read[0].ToString() + "," + UID + ",0,\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"我的群\");";
            read.Close();
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
        }
        //添加一对新好友
        private static void addnewfriends(String UID, String toUID, String usergroup)
        {
            String tonamegroup;
            MySqlDataReader frdreqreader = getfriendreq(UID, toUID);
            frdreqreader.Read();
            tonamegroup = frdreqreader[2].ToString();
            frdreqreader.Close();
            String Com = "INSERT INTO friends (UID1,UID2,groups) VALUES (\"" + UID + "\",\"" + toUID + "\",\"" + tonamegroup + "\");";
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！11111111" + ex.Message);
            }
            Com = "INSERT INTO friends (UID1,UID2,groups) VALUES (\"" + toUID + "\",\"" + UID + "\",\"" + usergroup + "\");";
            try
            {
                up(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！22222222" + ex.Message);
            }
        }
        //加入群组
        private static void joinmutual(String GID, String UID)
        {
            String mugroup;
            MySqlDataReader grpreqreader = getmureq(GID, UID);
            grpreqreader.Read();
            mugroup = grpreqreader[2].ToString();
            grpreqreader.Close();
            String Com = "INSERT INTO groupmembers (GID,UID,auth,jointime,closetime,G_group) VALUES (" + GID + "," + UID + ",2,\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\",\"" + mugroup + "\");";
            Console.WriteLine(Com);
            try
            {
                up(Com);
            }
            catch(Exception ex)
            {
                Console.WriteLine("插入数据失败了！22222222" + ex.Message);
            }
        }
        //删除入群申请条目
        private static void removemureq(string GID,string UID)
        {
            String Com = "DELETE FROM groupreq WHERE GID="+GID+" AND UID="+UID+"";
            try
            {
                rm(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
        }
        //获取管理员列表
        private static MySqlDataReader getauth(string GID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT UID FROM groupmembers WHERE GID=" + GID + " AND auth<2";
            try
            {
                read = Reader(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        //添加新分组
        private static void putnewgroups(String Username, String toName, String group)
        {
            SQL_u isrt = new SQL_u();
            isrt.Initialize("localhost", "chat", "root", "ppp213");
            if (isrt.OpenConnection())
            {
                Console.WriteLine("正在添加");
            }
            String Com = "INSERT INTO groups (Username, Friend, groups) VALUES(\"" + Username + "\", \"" + toName + "\", \"" + group + "\");";
            try
            {
                isrt.getInsert(Com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
            isrt.CloseConnection();
        }
        //用户是否存在
        private static bool getuser(String UID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT UID FROM user WHERE UID=\"" + UID + "\";";
            read = Reader(Com);
            if (read.HasRows == false)
            {
                read.Close();
                return false;
            }
            else
            {
                read.Close();
                return true;
            }
        }
        //群组是否存在
        private static bool getmu(string GID)
        {
            MySqlDataReader read = null;
            String Com = "SELECT GID FROM groups WHERE GID=\"" + GID + "\";";
            read = Reader(Com);
            if (read.HasRows == false)
            {
                read.Close();
                return false;
            }
            else
            {
                read.Close();
                return true;
            }
        }
        //获取用户分组信息
        private static String getgroups(String UID)
        {
            String Com = "SELECT Groups FROM user WHERE UID=\"" + UID + "\";";
            MySqlDataReader read = Reader(Com);
            read.Read();
            string grp = read[0].ToString();
            return grp;
        }
        private static string getmugroups(string UID)
        {
            String Com = "SELECT G_Groups FROM user WHERE UID=\"" + UID + "\";";
            MySqlDataReader read = Reader(Com);
            read.Read();
            string grp = read[0].ToString();
            return grp;
        }
        //获取用户的群组
        private static MySqlDataReader getmutual(string UID)
        {
            MySqlDataReader read = null;
            string com = " SELECT groups.GID,groups.Groupname,auth,G_group,groups.Groupsine FROM groups,groupmembers WHERE UID=" + UID + " AND groups.GID=groupmembers.GID;";
            read = Reader(com);
            return read;
        }
        private static MySqlDataReader getmember(string GID)
        {
            MySqlDataReader read = null;
            string com = " SELECT groupmembers.UID,auth,user.Username FROM groupmembers,user WHERE groupmembers.UID=user.UID AND GID=" + GID + ";";
            read = Reader(com);
            return read;
        }
        //修改信息类
        private static void userstate(string UID,String username,string sign)
        {
            string Com= "UPDATE user SET Username=\""+username+"\" WHERE UID=" + UID + ";";
            st(Com);
            Com = "UPDATE user SET Sign=\"" + sign + "\" WHERE UID=" + UID + ";";
            st(Com);
        }
        private static void mustate(string GID, String muname, string sign)
        {
            string Com = "UPDATE groups SET Groupname=\"" + muname + "\" WHERE GID=" + GID + ";";
            st(Com);
            Com = "UPDATE groups SET Groupsine=\"" + sign + "\" WHERE GID=" + GID + ";";
            st(Com);
        }
        //群成员管理类
        private static void removemember(string GID, string UID)
        {
            string Com= "DELETE FROM groupmembers WHERE GID=" + GID + " AND UID=" + UID + ";";
            rm(Com);
        }
        private static void aumember(string GID, string UID)
        {
            string Com = "UPDATE groupmembers SET auth=1 WHERE GID=" + GID + " AND UID=" + UID + ";";
            Console.WriteLine(Com);
            st(Com);
        }
        private static void cgmember(string GID, string UID)
        {
            string Com = "UPDATE groupmembers SET auth=2 WHERE GID=" + GID + " AND auth=0;";
            st(Com);
            Com = "UPDATE groupmembers SET auth=0 WHERE GID=" + GID + " AND UID=" + UID + ";";
            st(Com);
        }
        private static void rmaumember(string GID, string UID)
        {
            string Com = "UPDATE groupmembers SET auth=2 WHERE GID=" + GID + " AND UID=" + UID + ";";
            st(Com);
        }
        //数据库类
        private static MySqlDataReader Reader(String com)
        {
            SQL_u get = new SQL_u();
            MySqlDataReader read = null;
            get.Initialize("localhost", "chatshow", "root", "ppp213");
            if (get.OpenConnection())
            {
                Console.WriteLine("链接数据库成功");
            }
            else
            {
                Console.WriteLine("链接数据库失败");
            }
            try
            {
                read = get.GetReader(com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查找数据失败了！" + ex.Message);
            }
            return read;
        }
        private static void up(string com)
        {
            SQL_u isrt = new SQL_u();
            isrt.Initialize("localhost", "chatshow", "root", "ppp213");
            if (isrt.OpenConnection())
            {
                Console.WriteLine("链接数据库成功");
            }
            else
            {
                Console.WriteLine("链接数据库失败");
            }
            try
            {
                isrt.getInsert(com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入数据失败了！" + ex.Message);
            }
            isrt.CloseConnection();
        }
        private static void rm(string com)
        {
            SQL_u rmv = new SQL_u();
            rmv.Initialize("localhost", "chatshow", "root", "ppp213");
            if (rmv.OpenConnection())
            {
                Console.WriteLine("链接数据库成功");
            }
            else
            {
                Console.WriteLine("链接数据库失败");
            }
            try
            {
                rmv.getDel(com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除数据失败了！" + ex.Message);
            }
            rmv.CloseConnection();
        }
        private static void st(string com)
        {
            SQL_u st = new SQL_u();
            st.Initialize("localhost", "chatshow", "root", "ppp213");
            if (st.OpenConnection())
            {
                Console.WriteLine("链接数据库成功");
            }
            else
            {
                Console.WriteLine("链接数据库失败");
            }
            try
            {
                st.getUpdate(com);
            }
            catch (Exception ex)
            {
                Console.WriteLine("修改数据失败了！" + ex.Message);
            }
            st.CloseConnection();
        }
    }
}
