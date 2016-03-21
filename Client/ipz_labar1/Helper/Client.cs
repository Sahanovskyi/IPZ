using System;
using System.Net.Sockets;

namespace ipz_labar1.Helper
{
    class Client
    {
        public static string Connect(String message)
        {
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
                return String.Format("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                return String.Format("SocketException: {0}", e);
            }


        }
    }
}
