using System;
using MailSenderLib.Data.EF;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services.EF
{
    public class EFSendersDataProvider : EFDataProvider<Sender>, ISendersDataProvider
    {
        public EFSendersDataProvider(MailSenderDB db) : base(db) { }

        public override void Edit(int id, Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            var db_item = GetById(id);

            db_item.Name = item.Name;
            db_item.Address = item.Address;
            SaveChanges();
        }
    }
}