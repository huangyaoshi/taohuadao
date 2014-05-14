using System;

namespace ConsoleApplication1
{
    public class Base
    {
        static Base()
        {
            Console.WriteLine("Base static init");
        }
        public Base()
        {
            //Console.WriteLine("Base init");
        }
        protected virtual string GetName()
        {
            return "Base";
        }
        public string Call()
        {
            return GetName();
        }
        public static void Test()
        {
            Console.WriteLine("public static virtual void Test()");
        }
    }
}
