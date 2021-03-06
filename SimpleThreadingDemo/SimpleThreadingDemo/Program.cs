﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart starter = new ThreadStart(Counting);
            Thread first = new Thread(starter);
            Thread second = new Thread(starter);

            first.Start();
            second.Start();
            
            


            first.Join();
            second.Join();
            Console.ReadLine();

        }

        public static void Counting()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Count: {0} - Thread: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(100);
                try
                {
                   Thread.CurrentThread.Abort();
                }
                catch (ThreadAbortException tae)
                {
                    Console.WriteLine("OK " + tae.Message);
                }
            }
        }
    }
}
