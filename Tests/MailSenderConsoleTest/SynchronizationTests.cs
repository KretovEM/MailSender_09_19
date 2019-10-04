using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace MailSenderConsoleTest
{
    internal static class SynchronizationTests
    {
        private static readonly List<string> _messages = new List<string>();

        public static void Start()
        {
            //var threads = new Thread[10];

            //for (var i = 0; i < threads.Length; i++)
            //{
            //    var x = i;
            //    threads[i] = new Thread(() => Printer($"Message {x}"));
            //}

            //Array.ForEach(threads, thread => thread.Start());

            //Mutex mutex = new Mutex(true, "Имя мютекса");
            ////mutex.WaitOne();
            //mutex.ReleaseMutex();

            //var semaphore = new Semaphore(0, 5, "Имя семафора");

            //semaphore.WaitOne();

            //// Критическая секция

            //semaphore.Release();

            //var manual_event = new ManualResetEvent(false);
            var auto_event = new AutoResetEvent(false);


            var test_threads = Enumerable
                .Range(0, 5)
                .Select(i => new Thread(() =>
                {
                    Console.WriteLine("Поток {0} ожидает запуска...", Thread.CurrentThread.ManagedThreadId);
                    auto_event.WaitOne();

                    Console.WriteLine($"Поток {i}");
                    Console.WriteLine("Поток {0} завершился", Thread.CurrentThread.ManagedThreadId);

                    auto_event.Reset();
                })).ToArray();

            foreach (var thread in test_threads)
                thread.Start();

            Console.WriteLine("Потоки ожидают запуска...");
            Console.ReadLine();

            auto_event.Set();

            Console.ReadLine();

            auto_event.Set();

            Console.ReadLine();

            auto_event.Set();
        }

        private static readonly object _SyncRoot = new object();

        private static void Printer(string message) 
        {
            ThreadTests.CheckThread();

            for (var i = 0; i < 20; i++)
            {
                lock (_SyncRoot)
                {
                    Console.Write("id:{0} ", Thread.CurrentThread.ManagedThreadId);
                    Console.Write(" - msg({0}):", i);
                    Console.WriteLine("\"{0}\"", message);
                    _messages.Add(message);
                }
                Thread.Sleep(100);

            }


            Console.WriteLine("Поток {0} завершён", Thread.CurrentThread.ManagedThreadId);
        }
    }

    [Synchronization]
    internal class Logger : ContextBoundObject
    {
        private string _filePath;

        public string FilePath
        {
            get => _filePath;
            set
            {
                if (!File.Exists(value))
                    throw new FileNotFoundException("Файл не существует", value);
                _filePath = value;
            }
        }

        public Logger(string filePath) => _filePath = filePath;

        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Log(string message)
        {
            //lock(this)
            File.AppendAllText(_filePath, message);
        }
    }
}
