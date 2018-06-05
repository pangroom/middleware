using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace 异步socket_wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“ISocketService”。
    [ServiceContract]
    public interface ISocketService
    {
        [OperationContract]
        string Hello();
        [OperationContract]
        string StartSocket();
        [OperationContract]
        string GetCount();
        [OperationContract]
        string Display();
        [OperationContract]
        string Send(string msg,int num);


    }
}
