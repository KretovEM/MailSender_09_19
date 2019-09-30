using System.Collections.Generic;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public interface IRecipientsDataProvider
    {
        IEnumerable<Recipient> GetAll();

        Recipient GetById(int id);

        int Create(Recipient recipient);
        
        void Edit(int id, Recipient item);

        bool Remove(int id);

        void SaveChanges();

    }
}
