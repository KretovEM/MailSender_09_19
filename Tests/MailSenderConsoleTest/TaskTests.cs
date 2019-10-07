using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSenderConsoleTest
{
    internal static class TaskTests
    {
        public static void Start()
        {
            //var firstTask = new Task(TaskMethod/*, TaskCreationOptions.LongRunning*/);
            //firstTask.Start();
            //firstTask.Wait();

            var msg = "Hello World!";
            //var getLengthTask = new Task<int>(() => GetStrLength(msg));
            //getLengthTask.Start();
            //Console.WriteLine("Какие-то дополнительные действия в главном потоке после запуска задачи");

            //Console.ReadLine();
            
            //try
            //{
            //    //getLengthTask.Wait();
            //    Console.WriteLine("str {0} - length:{1}", msg, getLengthTask.Result);
            //}
            //catch (AggregateException error)
            //{
            //    Console.WriteLine("При выполнении задачи случилось страшное:");
            //    foreach (var innerError in error.InnerExceptions)
            //        Console.WriteLine("\t{0}", innerError.Message);
            //}

            var secondTask = Task.Factory.StartNew(TaskMethod);

            Console.WriteLine("\nКакие-то действия после запуска задачи");

            secondTask.Wait();
            Console.WriteLine("\nМы дождались завершения запущенной задачи");

            var secondValueTask = Task.Run(() => GetStrLength(msg)); // Рекомендуемый и чаще всего встречаемый

            //Console.WriteLine("str {0} - length:{1}", msg, second_value_task.Result);
            var secondValueTaskContinuation = secondValueTask.ContinueWith(
                completedTask => Console.WriteLine("str {0} - length:{1}", msg, completedTask.Result),
                TaskContinuationOptions.OnlyOnRanToCompletion);

            var secondValueTaskContinuationOnException = secondValueTask.ContinueWith(
                completedTask => Console.WriteLine("Exception {0}", completedTask.Exception),
                TaskContinuationOptions.OnlyOnFaulted);
            //secondValueTaskContinuation.ContinueWith()

        }

        private static void TaskMethod()
        {
            Console.WriteLine("ThID:{0} TaskID:{1} - started",
                Thread.CurrentThread.ManagedThreadId,
                Task.CurrentId);

            Thread.Sleep(1000);

            Console.WriteLine("ThID:{0} TaskID:{1} - ended",
                Thread.CurrentThread.ManagedThreadId,
                Task.CurrentId);
        }

        private static int GetStrLength(string msg)
        {
            Console.WriteLine("ThID:{0} - str:{1} - started", Thread.CurrentThread.ManagedThreadId, msg);
            Thread.Sleep(250);
            Console.WriteLine("ThID:{0} - str:{1} - completed", Thread.CurrentThread.ManagedThreadId, msg);

            //throw new InvalidOperationException("Страшная ошибка!");

            return msg.Length;
        }

    }
}
