using MailSenderLib.Entityes.Base;
using System.Collections.Generic;

namespace MailSenderLib.Entityes
{
    public class RecipientsList : NamedEntity
    {
        public ICollection<Recipient> Recipients { get; set; }
    }
}
