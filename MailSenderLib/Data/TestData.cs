using MailSenderLib.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Data
{
    public static class TestData
    {
        public static List<Server> Servers => new List<Server>
        {
            new Server { Id = 1, Name="Yandex", Host= "smtp.yandex.ru", Port = 587, UserName = "UserName", Password = "Pass" },
            new Server { Id = 2, Name="Mail.ru", Host="smtp.mail.ru", UserName = "UserName", Password = "Pass"},
            new Server { Id = 3, Name="Gmail", Host="smtp.gmail.ru", Port = 465, UserName = "UserName", Password = "Pass"},
        };

        public static List<Sender> Senders => new List<Sender>
        {
            new Sender {Id = 1, Name = "Иванов", Address = "ivanov@yandex.ru"},
            new Sender {Id = 2, Name = "Петров", Address = "petrov@yandex.ru"},
            new Sender {Id = 3, Name = "Сидоров", Address = "sidorov@gmail.ru"},
        };
    }
}
