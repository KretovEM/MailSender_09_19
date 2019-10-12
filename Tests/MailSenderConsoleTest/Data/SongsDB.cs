using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderConsoleTest.Data
{
    public class SongsDB : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}
