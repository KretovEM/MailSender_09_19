using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class InMemoryRecipientsDataProvider: InDataProvider<Recipient>
    {
        public override void Edit(int id, Recipient item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Address = item.Address;
        }

    }
}
