using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class MemoryDataContext
    {
        public List<Recipient> Recipients { get; }
        public List<RecipientsList> RecipientsLists { get; }
        public List<Sender> Senders { get; }
        public List<Email> Emails { get; }
        public List<Server> Servers { get; }
        public List<SchedulerTask> SchedulerTasks { get; }

        public MemoryDataContext()
        {
            Recipients = Enumerable.Range(1, 10).Select(i => new Recipient
            {
                Id = i,
                Name = $"Получатель {i}",
                Address = $"recipient{i}@server.com"
            }).ToList();

            Senders = Enumerable.Range(1, 10).Select(i => new Sender
            {
                Id = i,
                Name = $"Отправитель {i}",
                Address = $"sender{i}@server.com"
            }).ToList();

            Emails = Enumerable.Range(1, 10).Select(i => new Email
            {
                Id = i,
                Subject = $"Письмо {i}",
                Body = $"Сообщение электронной почты {i}"
            }).ToList();

            Servers = Enumerable.Range(1, 10).Select(i => new Server
            {
                Id = i,
                Host = $"smtp.server{i}.com",
                UserName = $"user@server{i}.com",
                Password = $"user-{i}-password"
            }).ToList();

            var rnd = new Random();
            T GetRandom<T>(IList<T> items) => items[rnd.Next(0, items.Count)];
            IEnumerable<T> GetRandomItems<T>(IList<T> items, int count) =>
                Enumerable
                   .Range(0, count)
                   .Select(i => GetRandom(items));

            RecipientsLists = Enumerable.Range(1, 10).Select(i => new RecipientsList
            {
                Id = i,
                Name = $"Mail list {i}",
                Recipients = GetRandomItems(Recipients, rnd.Next(1, Recipients.Count)).ToList()
            }).ToList();

            SchedulerTasks = Enumerable.Range(1, 10).Select(i => new SchedulerTask
            {
                Id = i,
                Time = DateTime.Now.Add(TimeSpan.FromMinutes(rnd.Next(10, 120))),
                Server = GetRandom(Servers),
                Sender = GetRandom(Senders),
                Email = GetRandom(Emails),
                Recipients = GetRandom(RecipientsLists)
            }).ToList();
        }
    }
}