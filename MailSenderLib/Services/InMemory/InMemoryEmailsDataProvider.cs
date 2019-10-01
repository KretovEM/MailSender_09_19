using System.Linq;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class InMemoryEmailsDataProvider : InDataProvider<Email>
    {
        public InMemoryEmailsDataProvider()
        {
            _Items.AddRange(Enumerable.Range(1, 20).Select(i => new Email { Id = i, Subject = $"Сообщение {i}", Body = $"Тело письма {i}" }));
        }

        public override void Edit(int id, Email item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }
    }
}