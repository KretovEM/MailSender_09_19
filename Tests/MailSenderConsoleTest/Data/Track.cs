using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSenderConsoleTest.Data
{
    [Table("Track")]
    public class Track
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Length { get; set; }
    }
}
