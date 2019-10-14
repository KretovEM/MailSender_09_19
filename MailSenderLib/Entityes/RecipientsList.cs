using MailSenderLib.Entityes.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSenderLib.Entityes
{
    public class RecipientsList : NamedEntity
    {
        [Required]
        public ICollection<Recipient> Recipients { get; set; }
    }
}
