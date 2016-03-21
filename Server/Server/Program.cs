using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace TcpServer
{
    class Server
    {
        TcpListener Listener;

        public Server(int Port)
        {
            try
            {
                IPAddress ip = IPAddress.Any;
                Listener = new TcpListener(ip, Port);
                Listener.Start();
                int counter = 0;
                IPAddress[] address = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                foreach (IPAddress ipAddress in address)
                {
                    Console.WriteLine("IP Address: " + ipAddress);
                }
                Console.WriteLine("Port: " +Port);

                while (true)
                {
                    Console.Write("\nWaiting for a connection... ");
                    
                    TcpClient Client = Listener.AcceptTcpClient();
                    Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                    Console.Write("\nConnection №" + counter.ToString() + "!");
                    
                    Thread.Start(Client);
                    counter++;

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                Listener.Stop();
            }
        }

        static void ClientThread(Object StateInfo)
        {
            new Client((TcpClient) StateInfo);
        }


        static void Main(string[] args)
        {
            new Server(1024);
        }
    }

    class Client
    {
        private SqlConnection connection =
            new SqlConnection(
                @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True;Connect Timeout=30");

        private SqlConnection accountConnection =
            new SqlConnection(
                @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\AccountDatabase.mdf;Integrated Security=True;Connect Timeout=30");

        private TcpClient clnt;
        private byte[] output;

        public Client(TcpClient Client)
        {
            clnt = Client;
            string request = "";
            byte[] Buffer = new byte[4096];
            int count;
            NetworkStream stream = Client.GetStream();

            count = stream.Read(Buffer, 0, Buffer.Length);
            request = Encoding.Unicode.GetString(Buffer, 0, count);

            Console.WriteLine(request); 
            try
            {
                connection.Open();
                accountConnection.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Don't Connected");
                output = System.Text.Encoding.Unicode.GetBytes("-1\n");
                clnt.GetStream().Write(output, 0, output.Length);
                stream.Close();
                Client.Close();
                return;
            }
            //request = request.Substring(0, request.Length - 1);

            string[] arrayReauest = request.Split(':');
            switch (arrayReauest[0])
            {
                case "login":
                    Login(arrayReauest);
                    break;
                case "register":
                    Register(arrayReauest);
                    break;
                case "insert":
                    AddToTable(arrayReauest);
                    break;
                case "update":
                    UpdateTable(arrayReauest);
                    break;
                case "delete":
                    DeleteFromTable(arrayReauest);
                    break;
                case "show":
                    ShowTable(arrayReauest);
                    break;
            }

            
            accountConnection.Close();
            connection.Close();
            accountConnection.Dispose();
            connection.Dispose();
            stream.Close();
            Client.Close();
            
        }

     
        public void Login(string[] requestArr)
        {
            SqlCommand cmd = new SqlCommand("Select userTable From AccountTable where username = @username and pass = @pass", accountConnection);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@username";
            param.Value = requestArr[2];
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@pass";
            param.Value = requestArr[4];
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);
            string res = "";
            try
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        res = dr.GetValue(0).ToString().Trim();
                        output = System.Text.Encoding.Unicode.GetBytes("0\n"+res+"\n");
                        clnt.GetStream().Write(output, 0, output.Length);
                    }
                    else
                    {
                        Console.WriteLine("Incorrec username or password");
                        output = System.Text.Encoding.Unicode.GetBytes("208\n");
                        clnt.GetStream().Write(output, 0, output.Length);
                    }
                   
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                if (e.Number == 208)
                {    
                    output = System.Text.Encoding.Unicode.GetBytes("208\n");
                    clnt.GetStream().Write(output, 0, output.Length);
                }
                else
                {
                    output = System.Text.Encoding.Unicode.GetBytes("-1\n");
                    clnt.GetStream().Write(output, 0, output.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
        }//++++++++++

        public void Register(string[] requestArr)
        {
            int exitAddUser = AddUser(requestArr[6], requestArr[8], requestArr[12], requestArr[2], requestArr[4]);
            if (exitAddUser != 0)
            {
                output = Encoding.Unicode.GetBytes(exitAddUser.ToString() + "\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return;
            }

            if (requestArr[10].Equals("False"))
            {
                int exitAddWare = AddWarehouseAccount(requestArr[12], requestArr[14]);
                if (exitAddWare != 0)
                {
                    output = Encoding.Unicode.GetBytes(exitAddWare.ToString() + "\n");
                    clnt.GetStream().Write(output, 0, output.Length);
                    DeleteUser(requestArr[6]);
                    return;
                }
                int exitCreateTable = CreateNewTable(requestArr[12]);
                if (exitCreateTable != 0)
                {
                    output = Encoding.Unicode.GetBytes(exitCreateTable.ToString() + "\n");
                    clnt.GetStream().Write(output, 0, output.Length);
                    DeleteUser(requestArr[6]);
                    DeleteWarehouseAccount(requestArr[12]);
                    return;
                }
                output = Encoding.Unicode.GetBytes("0\n" + requestArr[12] + "\n");
                clnt.GetStream().Write(output, 0, output.Length);
            }
            else if(requestArr[10].Equals("True"))
            {
                SqlCommand cmd = new SqlCommand("Select WarehouseName From WarehouseTable where " +
                                                "WarehouseName = @WarehouseName and WarehousePass = @WarehousePass", accountConnection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@WarehouseName";
                param.Value = requestArr[12];
                param.SqlDbType = SqlDbType.NChar;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@WarehousePass";
                param.Value = requestArr[14];
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);
                string res = "";
                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (dr.Read())
                        {
                            res = dr.GetValue(0).ToString().Trim();
                            output = System.Text.Encoding.Unicode.GetBytes("0\n" + res + "\n");
                            clnt.GetStream().Write(output, 0, output.Length);
                        }
                        else
                        {
                            accountConnection.Close();
                            accountConnection.Open();
                            DeleteUser(requestArr[6]);                            
                            Console.WriteLine("Incorrec warehouse name or warehouse password");
                            output = System.Text.Encoding.Unicode.GetBytes("208\n");
                            clnt.GetStream().Write(output, 0, output.Length);
                            return;
                        }

                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    DeleteUser(requestArr[6]);
                    if (e.Number == 208)
                    {
                        output = System.Text.Encoding.Unicode.GetBytes("208\n");
                        clnt.GetStream().Write(output, 0, output.Length);
                    }
                    else
                    {
                        output = System.Text.Encoding.Unicode.GetBytes("-1\n");
                        clnt.GetStream().Write(output, 0, output.Length);
                    }
                }
                
            }
            else
            {
                DeleteUser(requestArr[6]);
                output = System.Text.Encoding.Unicode.GetBytes("-1\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return;
            }
            
            
        }

        public void ShowTable(string[] requestArr)
        {
            string res = "";
            try
            {
                SqlParameter param = new SqlParameter();
               // param.SqlDbType = SqlDbType.Char; ;

                SqlCommand cmd = new SqlCommand("Select * From " + requestArr[2], connection);
               // cmd.Parameters.Add(param);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    output = System.Text.Encoding.Unicode.GetBytes("0\n" + requestArr[2] + "\n");
                    clnt.GetStream().Write(output, 0, output.Length);
                    while (dr.Read())
                    {
                        res = "";
                        for (int i = 0; i < dr.FieldCount; i++)
                            res += String.Format("{0}\t", dr.GetValue(i).ToString().Trim());
                        res += "\n";

                        output = System.Text.Encoding.Unicode.GetBytes(res);
                        clnt.GetStream().Write(output, 0, output.Length); 
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                output = System.Text.Encoding.Unicode.GetBytes("-10\n");
                clnt.GetStream().Write(output, 0, output.Length);
            }
        }//++++++++++

        public int AddToTable(string[] requestArr)
        {
            NumberFormatInfo format = new NumberFormatInfo();
            format.NumberGroupSeparator = ",";
            format.NumberDecimalSeparator = ".";
            int id = Int32.Parse(requestArr[12]);
            float price = (float)Double.Parse(requestArr[6], format);
            int count = Int32.Parse(requestArr[10]);
            string name = requestArr[4];
            string tableName = requestArr[2];
            string type = requestArr[8];
            SqlCommand cmd = new SqlCommand("Insert into " + tableName +
                                            "(ID,Name,Price,Type,Count) Values (@ID,@Name,@Price,@Type,@Count)",
                connection);


            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = id;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = name;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Price";
            param.Value = price;
            param.SqlDbType = SqlDbType.Real;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Type";
            param.Value = type;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Count";
            param.Value = count;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);
            try
            {
                cmd.ExecuteNonQuery();
                output = System.Text.Encoding.Unicode.GetBytes("0\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                output = System.Text.Encoding.Unicode.GetBytes(e.Number + "\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return e.Number;
            }
        }

        public int CreateNewTable(string tableName)
        {
            SqlCommand cmdCreateTable2 = new SqlCommand("CREATE TABLE " + tableName +
                                                        " (ID int not null primary key, " +
                                                        "Name nchar(60) not null, " +
                                                        "Price real ," +
                                                        "Type nchar(60) , " +
                                                        "Count int)", connection);
            try
            {
                cmdCreateTable2.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                if (e.Number == 2714)
                {
                    return e.Number;
                }
                else
                {
                    return -4;
                }
            }
        }

        public int DeleteFromTable(string[] requestArr)
        {
            string tableName = requestArr[2];
            int id = Int32.Parse(requestArr[4]);
            SqlCommand cmd = new SqlCommand("Delete From " + tableName +
                                            " where ID = @ID", connection);
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = id;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
                output = System.Text.Encoding.Unicode.GetBytes("0\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                output = System.Text.Encoding.Unicode.GetBytes(e.Number + "\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return e.Number;
            }
           
        }

        public int DeleteAllFromTable(string tableName)
        {
            SqlCommand cmd = new SqlCommand("TRUNCATE TABLE " + tableName, connection);

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            return 0;
        }

        public int UpdateTable(string[] requestArr)
        {
            NumberFormatInfo format = new NumberFormatInfo();
            format.NumberGroupSeparator = ",";
            format.NumberDecimalSeparator = ".";
            int id = Int32.Parse(requestArr[12]);
            float price = (float)Double.Parse(requestArr[6], format);
            int count = Int32.Parse(requestArr[10]);
            string name = requestArr[4];
            string tableName = requestArr[2];
            string type = requestArr[8];

            SqlCommand cmd = new SqlCommand("Update " + tableName +
                                            " Set Name = @Name, " +
                                            "Price = @Price, " +
                                            "Type = @Type, " +
                                            "Count = @Count " +
                                            "Where ID = @ID", connection);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@ID";
            param.Value = id;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Name";
            param.Value = name;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Price";
            param.Value = price;
            param.SqlDbType = SqlDbType.Real;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Type";
            param.Value = type;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@Count";
            param.Value = count;
            param.SqlDbType = SqlDbType.Int;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
                output = System.Text.Encoding.Unicode.GetBytes("0\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                output = System.Text.Encoding.Unicode.GetBytes(e.Number + "\n");
                clnt.GetStream().Write(output, 0, output.Length);
                return e.Number;
            }
        }

        public int AddWarehouseAccount(string table, string tablePass)
        {

            SqlCommand tableCommand = new SqlCommand("Insert into WarehouseTable(WarehouseName,WarehousePass) " +
                                            "Values (@WarehouseName,@WarehousePass)", accountConnection);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@WarehouseName";
            param.Value = table;
            param.SqlDbType = SqlDbType.NChar;
            tableCommand.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@WarehousePass";
            param.Value = tablePass;
            param.SqlDbType = SqlDbType.NChar;
            tableCommand.Parameters.Add(param);

            try
            {
                tableCommand.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                if (e.Number == 2627)
                {
                    return 262722;
                }
                else
                {
                    return -3;
                }
            }
        }

        public int AddUser(string username, string password, string table, string firstName, string lastName)
        {
            SqlCommand cmd = new SqlCommand("Insert into AccountTable(username,pass,userTable,firstName,lastName) " +
                                            "Values (@username,@pass,@userTable,@firstName,@lastName)", accountConnection);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@username";
            param.Value = username;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@pass";
            param.Value = password;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@userTable";
            param.Value = table;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@firstName";
            param.Value = firstName;
            param.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            param = new SqlParameter();
            param.ParameterName = "@lastName";
            param.Value = lastName;
            param.SqlDbType = SqlDbType.NVarChar;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                if (e.Number == 2627)
                {
                    return 262711;
                }
                else
                {
                    return -2;
                }
            }
        }

        public int DeleteUser(string username)
        {
            SqlCommand cmd = new SqlCommand("Delete from AccountTable " +
                                            "where username = @username", accountConnection);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@username";
            param.Value = username;
            param.SqlDbType = SqlDbType.NChar;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
            
        }

        public int DeleteWarehouseAccount(string wareName)
        {
            SqlCommand cmd = new SqlCommand("Delete from WarehouseTable " +
                                            "where WarehouseName = @WarehouseName", accountConnection);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@WarehouseName";
            param.Value = wareName;
            param.SqlDbType = SqlDbType.Char;
            cmd.Parameters.Add(param);

            try
            {
                cmd.ExecuteNonQuery();
                return 0;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return -1;
            }
        }
    }
}


