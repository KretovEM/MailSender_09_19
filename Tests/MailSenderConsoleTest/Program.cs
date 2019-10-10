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
            //TPLTests.Start();
            //TaskTests.Start();
            //AsyncAwaitTests.Start();
            AsyncAwaitTests.StartAsync();

            Console.WriteLine("Главный поток завершён!");
            Console.ReadLine();
            Console.WriteLine("Программа завершена...");
        }
    }

    
}
