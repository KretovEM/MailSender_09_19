using System;
using System.ComponentModel.DataAnnotations;

namespace MailSenderConsoleTest.Data
{
    public class Artist
    {
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }
    }
}
