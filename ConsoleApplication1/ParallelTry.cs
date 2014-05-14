using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    static class ParallelTry
    {
        public static void GetBlog()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("begein...");

            string path = @"E:\文\韩寒\links.xml";
            XElement x = XElement.Load(path);
            Parallel.ForEach(x.Elements("a1"), LoadOne);

            sw.Stop();
            Console.WriteLine("end...");
            Console.WriteLine("cost is {0}s.", sw.ElapsedMilliseconds / 1000);
            Console.ReadLine();
        }

        static void LoadOne(XElement a)
        {
            string folder = @"E:\文\韩寒\";
            string name = a.Value;
            string url = a.Attribute("href").Value;

            try
            {
                using (WebClient wc = new WebClient())
                {
                    Console.WriteLine("start {0} @ {1}", name, DateTime.Now);
                    wc.DownloadFile(url, folder + name + ".html");
                    Console.WriteLine("end {0} @ {1}", name, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("error when {0}, msg: {1}", name, ex.Message);
            }
        }
    }
}
