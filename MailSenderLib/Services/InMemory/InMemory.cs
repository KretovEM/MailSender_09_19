using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Entityes;

namespace MailSenderLib.Services
{
    public class InMemoryRecipientsDataProvider: IRecipientsDataProvider
    {
        private readonly List<Recipient> _Recipients = new List<Recipient>();


        public int Create(Recipient recipient)
        {
            if (_Recipients.Contains(recipient)) return recipient.Id;
            recipient.Id = _Recipients.Count == 0 ? 1 : _Recipients.Max(r => r.Id) + 1;
            _Recipients.Add(recipient);
            return recipient.Id;
        }

        public void Edit(int id, Recipient item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Recipient> GetAll() => _Recipients;

        public Recipient GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            
        }
    }
}
