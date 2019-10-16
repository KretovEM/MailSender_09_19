using System.Collections.Generic;
using System.Linq;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class InMemoryEmailsDataProvider : IEmailsDataProvider
    {
        private readonly MemoryDataContext _db;

        public InMemoryEmailsDataProvider(MemoryDataContext db) => _db = db;

        public IEnumerable<Email> GetAll() => _db.Emails;

        public Email GetById(int id) => GetAll().FirstOrDefault(e => e.Id == id);

        public int Create(Email item)
        {
            var items = _db.Emails;
            if (items.Contains(item)) return item.Id;
            item.Id = items.Count == 0 ? 1 : items.Max(r => r.Id) + 1;
            items.Add(item);
            return item.Id;
        }

        public void Edit(int id, Email item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Subject = item.Subject;
            db_item.Body = item.Body;
        }

        public bool Remove(int id)
        {
            var db_item = GetById(id);
            return _db.Emails.Remove(db_item);
        }

        public void SaveChanges() { }

    }
}