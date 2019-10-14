using MailSenderLib.Data.EF;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.EF
{
    public class DataContextProvider
    {
        public string ConnectionString { get; set; } = "name=MailSenderDB";

        public MailSenderDB CreateContext() => new MailSenderDB(ConnectionString);
    }
}
