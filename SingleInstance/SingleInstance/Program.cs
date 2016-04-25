using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutexVar = null;
            const string MutexName = "RUNMEONCE";

            try
            {
                mutexVar = Mutex.OpenExisting(MutexName);
            } catch(WaitHandleCannotBeOpenedException exception)
            {
                Console.WriteLine(exception.Message);
            }

            if(mutexVar == null)
            {
                mutexVar = new Mutex(true, MutexName);
            }
            else
            {
                mutexVar.Close();
                
            }
            Console.ReadLine();
        }
    }
}
