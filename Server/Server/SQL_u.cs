using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace Server
{
    class SQL_u
    {
        private MySqlConnection Mysql_Con;
        private string server;
        private string database;
        private string uid;
        private string password;
        private string port;
        public MySqlConnection getInstance()
        {
            return Mysql_Con;
        }

        //初始化mysql链接
        public void Initialize(string server, string database, string uid, string password)
        {
            this.server = server;
            this.uid = uid;
            this.password = password;
            this.database = database;
            //string connectionString = "Data Source=" + server + ";" + "port=" + port + ";" + "Database=" + database + ";" + "User Id=" + uid + ";" + "Password=" + password + ";" + "CharSet = utf8"; ;  
            string connectionString = "server=" + server + ";user id=" + uid + ";password=" + password + ";database=" + database+ ";Charset=utf8";
            Mysql_Con = new MySqlConnection(connectionString);
        }

        //打开数据库链接
        public bool OpenConnection()
        {
            try
            {
                Mysql_Con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.  
                //The two most common error numbers when connecting are as follows:  
                //0: Cannot connect to server.  
                //1045: Invalid user name and/or password.  
                switch (ex.Number)
                {
                    case 0:
                        Console.Write("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.Write("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        //关闭数据库链接
        public bool CloseConnection()
        {
            try
            {
                Mysql_Con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        //返回MysqlDataAdapter
        //MysqlDataAdapter是C#的数据库适配器，需要通过它来查询数据库，查询后填充到dataset中
        public MySqlDataAdapter GetAdapter(string SQL)
        {
            MySqlDataAdapter Da = new MySqlDataAdapter(SQL, Mysql_Con);
            return Da;
        }

        //构建sql句柄
        public MySqlCommand CreateCmd(string SQL)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Mysql_Con);
            return Cmd;
        }

        //根据SQL创建DataTable
        public DataTable GetDataTable(string SQL, string Table_name)
        {
            MySqlDataAdapter Da = new MySqlDataAdapter(SQL, Mysql_Con);
            DataTable dt = new DataTable(Table_name);
            Da.Fill(dt);
            return dt;
        }

        //根据SQL语句返回MySqlDataReader对象
        public MySqlDataReader GetReader(string SQL)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Mysql_Con);
            MySqlDataReader Dr;
            try
            {
                Dr = Cmd.ExecuteReader(CommandBehavior.Default);
            }
            catch
            {
                throw new Exception(SQL);
            }
            return Dr;
        }

        //根据SQL语句返回DataSet对象
        //DataSet用于和datagridview绑定
        public DataSet Get_DataSet(string SQL, DataSet Ds, string tablename)
        {
            MySqlDataAdapter Da = new MySqlDataAdapter(SQL, Mysql_Con);
            try
            {
                Da.Fill(Ds, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Ds;
        }

        //根据SQL语句返回DataSet对象，将数据进行了分页
        public DataSet GetDataSet(string SQL, DataSet Ds, int StartIndex, int PageSize, string tablename)
        {
            MySqlDataAdapter Da = new MySqlDataAdapter(SQL, Mysql_Con);
            try
            {
                Da.Fill(Ds, StartIndex, PageSize, tablename);
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            return Ds;
        }

        //添加数据
        public void getInsert(String SQL)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Mysql_Con);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.WriteLine("插入数据失败了！" + message);
            }

        }
        

        //修改数据
        public void getUpdate(String SQL)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Mysql_Con);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                String message = ex.Message;
                Console.Write("修改数据失败了！" + message);
            }
        }

        //删除数据
        public void getDel(String SQL)
        {
            MySqlCommand Cmd = new MySqlCommand(SQL, Mysql_Con);
            try
            {
                Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                String message = ex.Message;
                Console.Write("删除数据失败了！" + message);
            }
        }
    }
}
