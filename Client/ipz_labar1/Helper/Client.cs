using System;
using System.ComponentModel;
using System.Net.Sockets;
using System.Threading;

namespace ipz_labar1.Helper
{
    public class Client
    {
        public static string Connect(String message)
        {
            start:
            try
            {
                Int32 port = Settings1.Default.Port;
                TcpClient client = new TcpClient(Settings1.Default.IPAddress, port);
           
                Byte[] data = System.Text.Encoding.Unicode.GetBytes(message);

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                
                data = new Byte[4096];

                string responseData = "";

                int bytes;
                while ((bytes = stream.Read(data, 0, data.Length)) != 0)
                {
                    responseData += System.Text.Encoding.Unicode.GetString(data, 0, bytes);
                }
                
                stream.Close();
                client.Close();
              
                return responseData;
            }
            catch (ArgumentNullException e)
            {
                return String.Format("ArgumentNullException: {0}", e.Message);
            }
            catch (SocketException e)
            {
                try
                {
                    isConnect = false;
                    msg = new MyMsgBox();
                    worker = new BackgroundWorker();
                    worker.WorkerSupportsCancellation = true;
                    worker.DoWork += WorkerOnDoWork;
                    worker.RunWorkerAsync();
                    msg.MyShowDialog("Server not found. Trying to reconnect...\t");
                    worker.CancelAsync();
                  
                    if (isConnect)
                    {
                        msg = null;
                        worker = null;
                        goto start;                        
                    }
                    else
                    {
                        return "";
                    }
                    

                }
                catch (Exception ex)
                {
                    worker.CancelAsync();
                    return "";
                }
            }
        }
        static MyMsgBox msg;
        static BackgroundWorker worker;
        private static bool isConnect;

        private static void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            int couner = 0;
            while (true)
            {
                if(worker != null && !worker.IsBusy)
                    break;
                try
                {
                    Thread.Sleep(1000);
                    switch (couner)
                    {
                        case 0:
                            msg.SetLabel("Server not found. Trying to reconnect\t");
                            break;
                        case 1:
                            msg.SetLabel("Server not found. Trying to reconnect.\t");
                            break;
                        case 2:
                            msg.SetLabel("Server not found. Trying to reconnect..\t");
                            break;
                        case 3:
                            msg.SetLabel("Server not found. Trying to reconnect...\t");
                            break;
                        default:
                            couner = -1;
                            break;

                    }
                    couner++;
                    Int32 port = Settings1.Default.Port;
                    TcpClient client = new TcpClient(Settings1.Default.IPAddress, port);
                    client.Close();
                    break;
                }
                catch (Exception ex)
                {

                }
            }
            isConnect = true;
            try
            {
                msg.CloseMsg();
            }
            catch (Exception e)
            {
            }
        }


    }
   
}
