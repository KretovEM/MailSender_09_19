using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSenderConsoleTest
{
    internal static class ThreadPoolTests
    {
        public static void Start()
        {
            var messages = Enumerable.Range(0, 100).Select(i => $"Message {i}").ToArray();

            //for (var i = 0; i < messages.Length; i++)
            //{
            //    var msg = messages[i];
            //    new Thread(() => ProcessMessage(msg)) { IsBackground = true }.Start();
            //}

            ThreadPool.SetMinThreads(5, 5);
            ThreadPool.SetMaxThreads(15, 15);
            foreach (var message in messages)
            {
                ThreadPool.QueueUserWorkItem(ProcessPoolMessage, message);
            }
        }

        private static readonly object _SyncRoot = new object();

        private static void ProcessPoolMessage(object parameter)
        {
            ProcessMessage((string)parameter);
        }

        private static void ProcessMessage(string message)
        {
            ThreadTests.CheckThread();

            for (var i = 0; i < 3; i++)
            {
                lock (_SyncRoot)
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg({0}):", i);
                    Console.WriteLine("\"{0}\"", message);
                }
                Thread.Sleep(1000);
            }
        }
    }
}