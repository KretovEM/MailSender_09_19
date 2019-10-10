using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSenderConsoleTest
{
    internal static class TPLTests
    {
        public static void Start()
        {
            //new Thread(() => Console.WriteLine("Асинхронный параллельный код")).Start();

            //Action<string> printer = str => Console.WriteLine(str);
            //printer("Hello World!");
            //printer.Invoke("Hello World2!!!");
            //printer.BeginInvoke("Hello World async...", result => Console.WriteLine("... completed!!!"), null);

            //Func<string, int> string_transform = str =>
            //{
            //    Thread.Sleep(400);
            //    return str.Length;
            //};
            //var data = "Hello World!";
            //string_transform.BeginInvoke(data, result =>
            //{
            //    var length = string_transform.EndInvoke(result);
            //    Console.WriteLine("Length of {0} = {1}", (string)result.AsyncState, length);
            //}, data);

            //Parallel.For(0, 100, i => Console.WriteLine("Iteration #{0}", i));

            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}").ToArray();

            //Parallel.For(0, messages.Length,
            //    new ParallelOptions { MaxDegreeOfParallelism = 8 },
            //    i =>
            //    {
            //        Thread.Sleep(250);
            //        Console.WriteLine("ThID:{0} - msg:{1}", Thread.CurrentThread.ManagedThreadId, messages[i]);
            //    });

            //var for_result = Parallel.For(0, messages.Length,
            //    new ParallelOptions { MaxDegreeOfParallelism = 8 },
            //    (i, state) =>
            //    {
            //        if(messages[i].EndsWith("15"))
            //            state.Break();
            //        Thread.Sleep(250);
            //        Console.WriteLine("ThID:{0} - msg:{1}", Thread.CurrentThread.ManagedThreadId, messages[i]);
            //    });

            //Console.WriteLine("Цикл прерван на итерации {0}",for_result.LowestBreakIteration);

            //Parallel.Invoke(/*new ParallelOptions { MaxDegreeOfParallelism = 2 },*/
            //    ParallelInvokeMethod, 
            //    ParallelInvokeMethod, 
            //    ParallelInvokeMethod,
            //    () => Console.WriteLine("Ещё одно параллельное действие!"));

            #region Посчитать суммарную длину всех сообщений параллельно

            //var messages_lengths = new List<int>(messages.Length);
            //Parallel.ForEach(messages, msg =>
            //{
            //    var length = MessageProcessor(msg);
            //    lock (messages_lengths)
            //        messages_lengths.Add(length);
            //});
            //var total_length = messages_lengths.Sum();

            //Console.WriteLine("Total messages length = {0}", total_length); 

            #endregion

            #region PLINQ

            //Console.WriteLine("Total messages length = {0}", messages
            //   .AsParallel()
            //   .WithDegreeOfParallelism(15)
            //    //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //   .Select(MessageProcessor)
            //    //.AsSequential()
            //   .Sum());

            var total_length = messages
                .AsParallel()
                .WithDegreeOfParallelism(15)
                //.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
                .Select(MessageProcessor)
                //.AsSequential()
                .Sum();

            Console.WriteLine("Total messages length = {0}", total_length);

            #endregion

        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine("ThID:{0} - started", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - ended", Thread.CurrentThread.ManagedThreadId);
        }

        private static int MessageProcessor(string msg)
        {
            Console.WriteLine("ThID:{0} - msg:{1} - started", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - msg:{1} - completed", Thread.CurrentThread.ManagedThreadId, msg);
            return msg.Length;
        }
    }
}
