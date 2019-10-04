using System;
using System.Collections.Generic;
using System.Threading;

namespace MailSenderConsoleTest
{
    internal static class SynchronizationTests
    {
        private static List<string> _Messages = new List<string>();

        public static void Start()
        {
            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                var x = i;
                threads[i] = new Thread(() => Printer($"Message {x}"));
            }

            Array.ForEach(threads, thread => thread.Start());
        }

        private static void Printer(string message) 
        {
            ThreadTests.CheckThread();

            for (var i = 0; i < 20; i++)
            {
                Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                Console.Write(" - msg({0}):", i);
                Console.WriteLine("\"{0}\"", message);
                Thread.Sleep(100);

                _Messages.Add(message);
            }

            Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
