using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace 异步socket_wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“SocketService”。
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SocketService : ISocketService
    {
        private static int count = 0;
        static byte[] buffer = new byte[1024];
        //使用字典来记录socket用来发送指令。
        static Dictionary<string, Socket> dic = new Dictionary<string, Socket>();
        
        public string Hello()
        {
            return "hello!";

        }
        public string StartSocket()
        {
            var socket=new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(IPAddress.Any, 7788));
            socket.Listen(10000);
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
            
            return "serer:ready";
        }
        
        public static void ClientAccepted(IAsyncResult ar)
        {
            count++;
            var socket = ar.AsyncState as Socket;
            var client = socket.EndAccept(ar);
            
            //keepalive用来监听在线的客户端，如果非正常断开的话就会自动释放socket
            byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
            {
                byte[] buffer = new byte[12];
                BitConverter.GetBytes(onOff).CopyTo(buffer, 0);
                BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4);
                BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);
                return buffer;
            }
            client.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 30000, 10000), null);
            IPEndPoint clientipe = (IPEndPoint)client.RemoteEndPoint;
            dic.Add(clientipe.ToString(),client);
            //WriteLine(clientipe + "is connected,total connects " + count, ConsoleColor.Yellow);
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), client);
            socket.BeginAccept(new AsyncCallback(ClientAccepted), socket);
        }
        public static void ReceiveMessage(IAsyncResult ar)
        {

            int length = 0;
            string message = "";
            var socket = ar.AsyncState as Socket;
            IPEndPoint clientipe = (IPEndPoint)socket.RemoteEndPoint;
            try
            {
                length = socket.EndReceive(ar);
                message = Encoding.Default.GetString(buffer, 0, length);
                //WriteLine(clientipe + ":" + message, ConsoleColor.White);
                
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), socket);
                Thread.Sleep(1000);
                socket.Send(Encoding.Default.GetBytes("server received data" + message+"/r/n"));
            }
            catch (Exception ex)
            {
                count--;
                dic.Remove(clientipe.ToString());
                //WriteLine(clientipe + "is disconnected,total connects " + (count), ConsoleColor.Red);

            }
        }
        public string GetCount()
        {
            return count.ToString();
        }
        public string Display()
        {
            string s = "";
            foreach(var key in dic)
            {
                s = s + key.Key+" ";
            }
            return s;
        }
        public string Send(string msg,int num)
        {
            List<string> list = new List<string>();
            foreach(var key in dic)
            {
                list.Add(key.Key);
            }
            byte[] arrSendMsg = Encoding.Default.GetBytes(msg);
            dic[list[num]].Send(arrSendMsg);
            return "ok";
        }
    }
}
