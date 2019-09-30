namespace MailSenderLib.Entityes.Base
{
    public abstract class NamedEntity : BaseEntity
    {
        public virtual string Name { get; set; }
    }
}
