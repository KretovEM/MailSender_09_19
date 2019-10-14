using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MailSenderConsoleTest.Data
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
