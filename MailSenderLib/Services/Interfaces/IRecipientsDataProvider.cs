using MailSenderLib.Data.LinqToSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services
{
    public interface IRecipientsDataProvider
    {
        IEnumerable<Recipient> GetAll();

        int Create(Recipient recipient);

        void SaveChanges();
    }
}
