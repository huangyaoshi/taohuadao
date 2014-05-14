using System;

namespace ConsoleApplication1
{
    public class Hanxu : Base
    {
        private EventHandler ee;
        private static int i;
        private Func<string, string> GetHtml;
        static Hanxu()
        {
            Console.WriteLine("Hanxu static init");
        }
        public Hanxu()
        {
            //ee += EhDD;
            i += 1;
            Console.WriteLine("Hanxu init");
        }
        public Hanxu(Func<string, string> g)
        {
            this.GetHtml = g;
        }
        public int GetI()
        {
            return i;
        }
        public static int StaticGetI()
        {
            return i;
        }
        protected override string GetName()
        {
            //ee("fffff", null);
            return "Hanxu";
        }
        private void EhDD(object sender, EventArgs e)
        {
            string s = sender as string;
        }
        public int GetIValue()
        {
            Test();
            return GetI();
        }
        public static void Test()
        {
            Console.Write("public static override void Test()");
        }
        public void DisplayHtml(string a)
        {
            Console.Write(this.GetHtml(a));
        }
    }
}