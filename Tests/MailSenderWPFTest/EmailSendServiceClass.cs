using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSenderWPFTest
{
    class EmailSendServiceClass
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get; set; }
        public string Msg { get; set; }
        public string Subject { get; set; }
        public MailAddress From { get; set; }
        public List<MailAddress> To { get; set; }
        public EmailSendServiceClass(
            string host,
            int port,
            string userName,
            SecureString password,
            string msg,
            MailAddress addrfrom,
            List<MailAddress> addrto,
            string subject)
        {
            this.Host = host;
            this.UserName = userName;
            this.Password = password;
            this.Msg = msg;
            From = addrfrom;
            To.AddRange(addrto);
            Subject = subject;
        }

        public void SendMail()
        {
            using (var client = new SmtpClient(Host, Port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(UserName, Password);

                using (var message = new MailMessage())
                {
                    message.From = From;
                    foreach (var item in To)
                    {
                        message.To.Add(item);
                    }
                    message.Subject = Subject;
                    message.Body = Msg;

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception error)
                    {
                        throw error;
                    }
                }
            }
        }
    }
    
}
