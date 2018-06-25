using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WCFParallelTest.ServiceClient;

namespace WCFParallelTest
{
    class Program
    {
       private static ServiceContractClient client = new ServiceContractClient();
        static void Main(string[] args)
        {
            int t = 1;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            appleAcount user ;
            while (client.GetOrder()=="写入测试")
            {
                user = client.ParallelTest();
                Console.WriteLine("ID:" + user.ID + "\t");               
                user.cookies = DBNull.Value.ToString();
                int x=client.EditUserInfo(user);
                Console.Write("写入次数：" + t + "\t" + "写入时间间隔：" + sw.ElapsedMilliseconds+"\tID:"+x+"\r\n");
                t++;               
                sw.Restart();
            }
            Console.Read();
        }     
    }
}
