using System;
using System.IO;
using System.Net;

namespace Update
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("获取下载地址");
            CheckUpdate checkUpdate = new CheckUpdate();
            checkUpdate.getJson();
            checkUpdate.getLastVersion();
            var version = checkUpdate.LastVersion;
            var url = "https://github.com/CmcnPro/NsuToolBox/releases/download/" + version + "/NsuToolBox.exe";
            Console.WriteLine(url);
            Console.WriteLine("开始尝试下载，若下载失败请手动复制上面的链接下载");

            try
            {
                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Proxy = WebRequest.GetSystemWebProxy();
                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                System.IO.Stream dataStream = httpResponse.GetResponseStream();
                byte[] buffer = new byte[8192];

                FileStream fs = new FileStream("NsuToolBox.exe",
                    FileMode.Create, FileAccess.Write);
                int size = 0;
                var MaxSiz = httpResponse.ContentLength;
                do
                {
                    size = dataStream.Read(buffer, 0, buffer.Length);
                    if (size > 0)
                    {
                        fs.Write(buffer, 0, size);
                        Console.Write(".");
                    }
                } while (size > 0);
                fs.Close();

                httpResponse.Close();

                Console.WriteLine('\n'+"Done at " + DateTime.Now.ToString("HH:mm:ss.fff"));
                Console.Read();
            }
            catch (Exception)
            {
                Console.WriteLine("下载失败，请稍后再试，或者前往官网下载");
                Console.Read();
            }



        }
    }
}
