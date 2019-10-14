using MailSenderLib.Data.EF;
using MailSenderLib.Entityes.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MailSenderLib.Services.EF
{
    public abstract class EFDataProvider<T> : IDataProvider<T> where T : BaseEntity
    {
        private readonly MailSenderDB _db;
        private readonly DbSet<T> _Table;

        protected EFDataProvider(MailSenderDB db)
        {
            _db = db;
            _Table = db.Set<T>();
        }

        public IEnumerable<T> GetAll() => _Table.AsEnumerable();

        public T GetById(int id) => _Table.FirstOrDefault(r => r.Id == id);

        public int Create(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (_db.Recipients.Any(r => r.Id == item.Id))
                return item.Id;

            _Table.Add(item);
            SaveChanges();
            return item.Id;
        }

        public abstract void Edit(int id, T item);

        public bool Remove(int id)
        {
            var db_item = GetById(id);
            if (db_item is null) return false;
            _Table.Remove(db_item);
            SaveChanges();
            return true;
        }

        public void SaveChanges() => _db.SaveChanges();
    }
}
