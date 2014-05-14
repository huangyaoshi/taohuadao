using System;

namespace ConsoleApplication1
{
    public delegate int GetLength(string str);

    public class EventTest
    {
        public event GetLength getLengthEvent;
        public void PrintLength(string str)
        {
            if (getLengthEvent != null)
                Console.WriteLine(getLengthEvent.GetInvocationList()[1].DynamicInvoke(new object[] { str }));
        }
    }
}
