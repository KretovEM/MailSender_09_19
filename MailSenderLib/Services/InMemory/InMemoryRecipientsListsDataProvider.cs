﻿using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class InMemoryMemoryRecipientsListsDataProvider : InMemoryDataProvider<RecipientsList>, IRecipientsListsDataProvider
    {
        public override void Edit(int id, RecipientsList item)
        {
            var db_item = GetById(id);
            if (db_item is null) return;

            db_item.Name = item.Name;
            db_item.Recipients = item.Recipients;
        }
    }
}