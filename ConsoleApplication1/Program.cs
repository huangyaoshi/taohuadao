using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // 异步方式
            //AsyncMethod(0);

            System.Threading.Thread.Sleep(5000);
            Console.ReadKey();
        }
        // 异步操作
        private static async void AsyncMethod(int input)
        {
            Console.WriteLine("进入异步操作！");
            var resultTask = AsyncWork(input);
            Console.WriteLine("退出异步操作！");
            int i = await resultTask;
            Console.WriteLine("结果:" + i);
        }

        // 模拟耗时操作（异步方法）
        private static async Task<int> AsyncWork(int val)
        {
            for (int i = 0; i < 5; ++i)
            {
                Console.WriteLine("耗时操作{0}", i);
                await Task.Delay(1000);
                val++;
            }
            return val;
        }

        //static void Main(string[] args)
        //{
        //    //Rectangle rectangle = new Rectangle(0, 0, 10, 20);
        //    //Circle circle = new Circle(110, 110, 10);
        //    //bool isCross = Shape.IsCrossBetween(rectangle, circle);
        //    //Console.WriteLine(string.Format("isCross? {0}", isCross));
        //    //x += Add;
        //    //x += Multify;
        //    //Console.WriteLine(x.DynamicInvoke(1, 2));

        //    //var invocationList = x.GetInvocationList();
        //    //Console.WriteLine(invocationList[0].DynamicInvoke(1, 2));
        //    //Console.WriteLine(invocationList[1].DynamicInvoke(1, 2));
        //    //Console.ReadKey();

        //    //int[] s = new int[] { 2, 6, 4, 3, 7, 5, 8, 1, 9, 0 };
        //    //Console.WriteLine(string.Join(",", s));
        //    //Console.WriteLine(Environment.NewLine);
        //    //Sort.QuickSort(s, 0, s.Length - 1);
        //    //Console.WriteLine(string.Join(",", s));
        //    //Console.ReadKey();

        //    //MediaHelper.Play(@"E:\baiduyundownload\11.mp4");
        //    //Console.ReadLine();
        //}

        private static int Add(int a, int b)
        {
            return a + b;
        }
        private static int Multify(int a, int b)
        {
            return a * b;
        }
        private static void DBTriggerTest()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.For(0, 100, k =>
            {
                string connectionString = "Data Source=TAOHUADAO;Initial Catalog=Huangyaoshi;Persist Security Info=True;User ID=sa;Password=1234567@byd";
                string sql = "insert into Table_1 values ('{0}_{1}', 'name_{0}_{1}','{2}');";
                for (int i = 0; i < 100; i++)
                {
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(connectionString, System.Data.CommandType.Text, string.Format(sql, i, k, DateTime.Now));
                }
            });

            sw.Stop();
            Console.WriteLine("DBTriggerTest finished. cost:{0}s.", sw.ElapsedMilliseconds / 1000);
        }

        private static void DBTableControlTest()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Parallel.For(0, 100, k =>
            {
                string connectionString = "Data Source=TAOHUADAO;Initial Catalog=Huangyaoshi;Persist Security Info=True;User ID=sa;Password=1234567@byd";
                for (int i = 0; i < 100; i++)
                {
                    Microsoft.ApplicationBlocks.Data.SqlHelper.ExecuteNonQuery(connectionString, "Table_3Insert", string.Format("{0}_{1}", i, k), string.Format("name_{0}_{1}", i, k), DateTime.Now);
                }
            });

            sw.Stop();
            Console.WriteLine("DBTableControlTest finished. cost:{0}s.", sw.ElapsedMilliseconds / 1000);
        }

        private static IDictionary<int, object> lockObjectDictionary = new Dictionary<int, object> 
        {
            { 0, new object() },
            { 1, new object() }
        };

        private static void LockObjectTest(int i)
        {
            lock (lockObjectDictionary[i])
            {
                Console.WriteLine(string.Format("{0} started at: {1}", i, DateTime.Now));
                Thread.Sleep(2000);
                Console.WriteLine(string.Format("{0} finished at: {1}", i, DateTime.Now));
            }
        }

        private static void Test()
        {
            //Base b = new Hanxu();
            //Console.WriteLine(b.Call());
            //Console.WriteLine(Hanxu.GetI());
            //Func<string, string> g = s => s += "qq";

            //Hanxu h = new Hanxu();
            //Console.WriteLine(h.GetType().Namespace);
            //Console.WriteLine(h.GetType().Name);
            //Hanxu h1 = new Hanxu();
            //Console.WriteLine("h.GetI():" + h.GetI());
            //Console.WriteLine(S(null));
            //Console.WriteLine("h1.GetI():" + h1.GetI());
            //Console.WriteLine("Hanxu.StaticGetI()" + Hanxu.StaticGetI());

            //h.DisplayHtml("a");
            //Base.Test();
            //Hanxu.Test();
            //Console.WriteLine(h.GetIValue());
            //Class2 c2 = new Class2();

            //ABClass aa = new BClass();
            //Console.WriteLine(aa.GetTestType());
            //Console.ReadLine();

            //string a = "aaxlbbxlxlccxldd";
            //string f = "xl";
            //string r = "qq";
            //string[] aa = a.Split(new string[] { f }, StringSplitOptions.None);
            //for (int i = 0; i < aa.Length; i++)
            //{
            //    if (i < 3)
            //    {
            //        aa[i] += r;
            //    }
            //    else
            //    {
            //        aa[i] += f;
            //    }
            //}
            //Console.WriteLine(string.Join("", aa));
            //Console.ReadLine();

            //XElementTest();
            //Console.Beep();

            //Console.WriteLine(WebServiceTest());
            //Console.ReadLine();

            //int[] array = new int[1000000];
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = i;
            //}

            //Stopwatch sw = Stopwatch.StartNew();
            //IEnumerable<int> c1 = LambdaTest(array);
            //sw.Stop();
            //Console.WriteLine(string.Format("LambdaTest return:{0}, cost:{1}ms", c1.Count(), sw.ElapsedMilliseconds));//5ms

            //sw.Restart();
            //IEnumerable<int> c2 = ArrayTest(array);
            //sw.Stop();
            //Console.WriteLine(string.Format("ArrayTest return:{0}, cost:{1}ms", c2.Count(), sw.ElapsedMilliseconds));//16ms

            //Console.WriteLine(System.Environment.Version);
            //Console.WriteLine(System.Environment.WorkingSet / (1024 * 1024));

            //DictionaryTest d = new DictionaryTest();
            //d.Add(1, "a");

            //IEnumerable<int> list = RandomArrayTest1();
            //Console.WriteLine(string.Join(",", list));
            ////foreach (int i in list)
            ////{
            ////    TaskOrder(i);
            ////}

            //Console.ReadLine();

            //ParallelTry.GetBlog();

            // Get the list of the addresses associated with the requested server.

            //IPAddresses(Dns.GetHostName());

            //// Get additonal address information.

            //IPAddressAdditionalInfo();

            //Console.ReadLine();

            //EventTestMethod();

            //foreach (var item in ForEachTest())
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in ClosureTest())
            //{
            //    Console.WriteLine(item());
            //}

            //FileTest.Replace();
            //Stopwatch sw = Stopwatch.StartNew();
            //Parallel.For(0, 100, LockTest);
            //sw.Stop();
            //Console.WriteLine("sw:{0}ms", sw.ElapsedMilliseconds);

            //sw.Restart();
            //Parallel.For(0, 100, LockTest1);
            //sw.Stop();
            //Console.WriteLine("sw1:{0}ms", sw.ElapsedMilliseconds);

            //Mp3.SetTitleToName(@"E:\歌\钢琴");
        }

        private static object lockObj = new object();
        private static int i = 0;
        private static int i1 = 0;

        private static void LockTest(int x)
        {
            lock (lockObj)
            {
                i++;
            }
        }

        private static void LockTest1(int x)
        {
            Interlocked.Increment(ref i1);
            //Console.WriteLine(i1);
        }

        private static Func<int>[] ClosureTest()
        {
            Func<int>[] funcs = new Func<int>[] { null, null, null };

            Func<int, Func<int>> f = x => (() => x);

            for (int i = 0; i < funcs.Length; i++)
            {
                //funcs[i] = () => i;
                funcs[i] = f(i);
            }
            return funcs;
        }

        static IEnumerable<int> ForEachTest()
        {
            Console.WriteLine("ForEachTest");
            return Enumerable.Range(0, 3);
        }

        static void EventTestMethod()
        {
            EventTest et = new EventTest();
            et.getLengthEvent += s => s.Length;
            et.getLengthEvent += s => 2 * s.Length;
            et.PrintLength("a");
            Console.ReadLine();
        }

        // This program shows how to use the IPAddress class to obtain a server 

        // IP addressess and related information.
        /**
        * The IPAddresses method obtains the selected server IP address information.
        * It then displays the type of address family supported by the server and its 
        * IP address in standard and byte format.
        **/

        private static void IPAddresses(string server)
        {
            try
            {
                System.Text.ASCIIEncoding ASCII = new System.Text.ASCIIEncoding();

                // Get server related information.

                IPHostEntry heserver = Dns.GetHostEntry(server);

                // Loop on the AddressList

                foreach (IPAddress curAdd in heserver.AddressList)
                {


                    // Display the type of address family supported by the server. If the

                    // server is IPv6-enabled this value is: InternNetworkV6. If the server

                    // is also IPv4-enabled there will be an additional value of InterNetwork.

                    Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());

                    // Display the ScopeId property in case of IPV6 addresses.

                    if (curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                        Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());


                    // Display the server IP address in the standard format. In 

                    // IPv4 the format will be dotted-quad notation, in IPv6 it will be

                    // in in colon-hexadecimal notation.

                    Console.WriteLine("Address: " + curAdd.ToString());

                    // Display the server IP address in byte format.

                    Console.Write("AddressBytes: ");



                    Byte[] bytes = curAdd.GetAddressBytes();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        Console.Write(bytes[i]);
                    }

                    Console.WriteLine("\r\n");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("[DoResolve] Exception: " + e.ToString());
            }
        }

        // This IPAddressAdditionalInfo displays additional server address information.

        private static void IPAddressAdditionalInfo()
        {
            try
            {
                // Display the flags that show if the server supports IPv4 or IPv6

                // address schemas.

                Console.WriteLine("\r\nSupportsIPv4: " + Socket.SupportsIPv4);
                Console.WriteLine("SupportsIPv6: " + Socket.SupportsIPv6);

                if (Socket.SupportsIPv6)
                {
                    // Display the server Any address. This IP address indicates that the server 

                    // should listen for client activity on all network interfaces. 

                    Console.WriteLine("\r\nIPv6Any: " + IPAddress.IPv6Any.ToString());

                    // Display the server loopback address. 

                    Console.WriteLine("IPv6Loopback: " + IPAddress.IPv6Loopback.ToString());

                    // Used during autoconfiguration first phase.

                    Console.WriteLine("IPv6None: " + IPAddress.IPv6None.ToString());

                    Console.WriteLine("IsLoopback(IPv6Loopback): " + IPAddress.IsLoopback(IPAddress.IPv6Loopback));
                }
                Console.WriteLine("IsLoopback(Loopback): " + IPAddress.IsLoopback(IPAddress.Loopback));
            }
            catch (Exception e)
            {
                Console.WriteLine("[IPAddresses] Exception: " + e.ToString());
            }
        }


        private static void TaskOrder(int i)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(i * 5000);
                Console.WriteLine(i + ",");
            });
        }

        private static int?[] RandomArrayTest()
        {
            int?[] array = new int?[10];
            Random r = new Random();
            int? i = null;
            for (int j = 0; j < 10; j++)
            {
                while (!i.HasValue || array.Contains(i.Value))
                {
                    i = r.Next(10);
                }
                if (i.HasValue)
                {
                    array[j] = i.Value;
                }
            }
            return array;
        }

        /// <summary>
        /// yes! this is the best way i have found
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<int> RandomArrayTest1()
        {
            Random r = new Random();
            return Enumerable.Range(0, 10).OrderBy(i => r.Next(10));
        }

        private static IEnumerable<int> LambdaTest(int[] array)
        {
            return array.Where(i => i % 2 == 0);
        }

        private static void XElementTest()
        {
            XElement xel = XElement.Load(@"E:\Projects\ConsoleApplication1\xml\XMLFile.xml");
            XElement x = xel.XPathSelectElement("/book[price=30]");
            if (x != null)
            {
                Console.WriteLine(x.ToString());
            }
            else
            {
                Console.WriteLine("null");
            }
            Console.ReadLine();
        }

        private static IDictionary<int, int> results = null;

        public static string S(string s)
        {
            return s ?? "default";
        }

        private static int GetDG(int n)
        {
            int result = 0;
            if (results != null && results.ContainsKey(n))
            {
                result = results[n];
            }
            else
            {
                if (n <= 1)
                {
                    result = n;
                }
                else
                {
                    result = GetDG(n - 1) + GetDG(n - 2);
                }
                if (results != null && !results.ContainsKey(n))
                {
                    results.Add(n, result);
                }
            }
            return result;
        }

        private static string GetDGsBeforeN(int n)
        {
            StringBuilder sb = new StringBuilder();
            results = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                sb.AppendFormat("{0},", GetDG(i));
            }
            return sb.ToString();
        }
    }

    public abstract class StaticClass1
    {
        public string Foo(string foo)
        {
            return foo + "'s length is: " + foo.Length + AA();
        }

        public static string AA()
        {
            return "AA";
        }
    }

    public class Class2 : StaticClass1
    {

    }

    public class AClass
    {
        public int ID
        {
            get;
            set;
        }
        private string Name
        {
            get;
            set;
        }
    }

    public abstract class ABClass : AClass
    {
        public virtual string GetTestType()
        {
            return "ABClass";
        }
    }

    public class BClass : ABClass
    {
        public override string GetTestType()
        {
            return "ABClass";
        }
    }

    public static class LockObject
    {
        private static Dictionary<string, object> dic = new Dictionary<string, object>();

        public static object GetLockObjcet(string tenantId)
        {
            if (dic.ContainsKey(tenantId))
            {
                return dic[tenantId];
            }

            object obj = new object();
            dic.Add(tenantId, obj);
            return obj;
        }
    }
}