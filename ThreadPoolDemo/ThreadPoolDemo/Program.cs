using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void ShowMyText(object state)
        {
            string myText = (string)state;
            Console.WriteLine("Thread: {0} - {1}",Thread.CurrentThread.ManagedThreadId, myText);
        }

        static void Main(string[] args)
        {
            WaitCallback callback = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(callback, "Yo");
            ThreadPool.QueueUserWorkItem(callback, "Halo");
            ThreadPool.QueueUserWorkItem(callback, "Adios");
            ThreadPool.QueueUserWorkItem(callback, "Tsa");

            Console.Read();
        }
    }
}
