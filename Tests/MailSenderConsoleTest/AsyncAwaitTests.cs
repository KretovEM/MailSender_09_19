using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSenderConsoleTest
{
    internal static class AsyncAwaitTests
    {
        public static void Start()
        {
            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}").ToArray();

            var processingTasks = new List<Task>();
            foreach (var msg in messages)
            {
                processingTasks.Add(Task.Run(() => MessageProcessor(msg, $"{msg}.txt")));
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения");
            Task.WaitAll(processingTasks.ToArray());

            Console.WriteLine("Все задачи завершились.");
        }

        private static int MessageProcessor(string msg, string fileName)
        {
            Console.WriteLine("Готовлюсь к записи сообщения {0} в файл {1}", msg, fileName);
            Thread.Sleep(250);

            System.IO.File.WriteAllText(fileName, msg);

            Console.WriteLine("Сообщение {0} записано в файл {1}", msg, fileName);
            return msg.Length;
        }

        public static async void StartAsync()
        {
            var messages = Enumerable.Range(1, 100).Select(i => $"Message {i}").ToArray();

            var processingTasks = new List<Task>();
            foreach (var msg in messages)
            {
                //processing_tasks.Add(Task.Run(() => MessageProcessorAsync(msg, $"{msg}.txt"))); //асинхронно-параллельный 
                //processing_tasks.Add(MessageProcessorAsync(msg, $"{msg}.txt")); // асинхроннj-последовательныq вызов
            }

            Console.WriteLine("Все задачи сформированы. Ждём их завершения");
            //Task.WaitAll(processing_tasks.ToArray());
            var awaiting_all_task = Task.WhenAll(processingTasks);
            await awaiting_all_task;

            Console.WriteLine("Все задачи завершились.");
        }

        private static async Task<int> MessageProcessorAsync(string msg, string fileName)
        {
            Console.WriteLine("Готовлюсь к записи сообщения {0} в файл {1}", msg, fileName);
            Thread.Sleep(250);

            using (var writer = new StreamWriter(fileName))
                await writer.WriteAsync(msg).ConfigureAwait(false);

            Console.WriteLine("Сообщение {0} записано в файл {1}", msg, fileName);
            return msg.Length;
        }
    }
}
