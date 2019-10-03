using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class LinqToSqlRecipientsDataProvider : IRecipientsDataProvider
    {
        private readonly MailSenderLib.Data.LinqToSql.MailSenderDBDataContext _db;
        public LinqToSqlRecipientsDataProvider(Data.LinqToSql.MailSenderDBDataContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipient> GetAll() => _db.Recipients.ToArray().Select(r => new Recipient
        {
            Id = r.Id,
            Name = r.Name,
            Address = r.Address
        });

        public Recipient GetById(int id)
        {
            var db_item = _db.Recipients.FirstOrDefault(r => r.Id == id);
            return db_item is null
                ? null
                : new Recipient
                {
                    Id = db_item.Id,
                    Name = db_item.Name,
                    Address = db_item.Address
                };
        }

        public int Create(Recipient recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));
            if (recipient.Id != 0) return recipient.Id;

            var entity = new Data.LinqToSql.Recipient
            {
                Name = recipient.Name,
                Address = recipient.Address
            };
            _db.Recipients.InsertOnSubmit(entity);
            SaveChanges();
            return entity.Id;
        }

        public void Edit(int id, Recipient item)
        {
            var db_item = _db.Recipients.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;

            SaveChanges();
        }

        public bool Remove(int id)
        {
            var db_item = _db.Recipients.FirstOrDefault(r => r.Id == id);
            if (db_item is null) return false;

            _db.Recipients.DeleteOnSubmit(db_item);
            SaveChanges();
            return true;
        }

        public void SaveChanges() => _db.SubmitChanges();
    }
}
