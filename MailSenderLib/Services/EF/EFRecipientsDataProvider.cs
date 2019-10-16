using MailSenderLib.Data.EF;
using MailSenderLib.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailSenderLib.Services.EF
{
    public class EFRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly MailSenderDB _db;

        public EFRecipientsDataProvider(MailSenderDB db) { _db = db; }

        public IEnumerable<Recipient> GetAll() => _db.Recipients.AsEnumerable();

        public Recipient GetById(int id) => _db.Recipients.FirstOrDefault(r => r.Id == id);

        public int Create(Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (_db.Recipients.Any(r => r.Id == item.Id))
                return item.Id;

            _db.Recipients.Add(item);
            SaveChanges();
            return item.Id;
        }

        public void Edit(int id, Recipient item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();
        }

        public bool Remove(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;
            _db.Recipients.Remove(db_item);
            SaveChanges();
            return true;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
