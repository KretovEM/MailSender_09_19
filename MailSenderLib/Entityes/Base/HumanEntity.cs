using System.ComponentModel.DataAnnotations;

namespace MailSenderLib.Entityes.Base
{
    public abstract class HumanEntity : NamedEntity
    {
        [Required]
        public virtual string Address { get; set; }
    }
}
