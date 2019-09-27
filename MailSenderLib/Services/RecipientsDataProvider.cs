using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data.LinqToSql;

namespace MailSenderLib.Services
{
    public class RecipientsDataProvider
    {
        private readonly MailSenderDBDataContext _db;
        public RecipientsDataProvider(MailSenderDBDataContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipient> GetAll() => _db.Recipients.ToArray();
    }
}
