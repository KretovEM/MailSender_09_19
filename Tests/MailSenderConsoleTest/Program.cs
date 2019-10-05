using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace MailSenderConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTests.Start();
            //SynchronizationTests.Start();
            ThreadPoolTests.Start();
            Console.ReadLine();
        }
    }

    
}
