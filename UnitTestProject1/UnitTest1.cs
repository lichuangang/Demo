using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Dao.Demo;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                String url = "http://172.31.86.67:80/hsd//datainterface/yzClient/ifdCallback?taskid=443&result=true";

                // url = url;
                var httpRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                httpRequest.Timeout = 20000;
                httpRequest.Method = "GET";
                int count = 0;
                do
                {
                    var httpResponse = (System.Net.HttpWebResponse)httpRequest.GetResponse();
                    StreamReader sr = new StreamReader(httpResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("gb2312"));
                    string result = sr.ReadToEnd();
                    if (result.ToUpper() == "OK") break;
                    count++;

                    System.Threading.Thread.Sleep(5 * 1000);
                } while (count < 5);
            }
            catch { }

        }

        [TestMethod]
        public void TestDao()
        {
            ModuleDao dao = new ModuleDao();

            var list = dao.ToList();
            var list2 = dao.ToList(false);
            Assert.IsFalse(list.Count == 0);
        }
    }
}
