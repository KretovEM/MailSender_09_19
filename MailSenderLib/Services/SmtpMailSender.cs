using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailSenderLib.Entityes;

namespace MailSender.lib.Services
{
    public class SmtpMailSender
    {
        private readonly string _host;
        private readonly int _port;
        private readonly bool _useSSL;
        private readonly string _login;
        private readonly string _password;

        public SmtpMailSender(string host, int port, bool useSSL, string login, string password)
        {
            _host = host;
            _port = port;
            _useSSL = useSSL;
            _login = login;
            _password = password;
        }

        public void Send(Email email, Sender from, Recipient to)
        {
            using (var client = new SmtpClient(_host, _port) { EnableSsl = _useSSL })
            {
                client.Credentials = new NetworkCredential
                {
                    UserName = _login,
                    Password = _password
                };

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(from.Address, from.Name);
                    message.To.Add(new MailAddress(to.Address, to.Name));
                    message.Subject = email.Subject;
                    message.Body = email.Body;

                    client.Send(message);
                }
            }
        }

        public void Send(Email email, Sender from, IEnumerable<Recipient> to)
        {
            foreach (var recipient in to)
                Send(email, from, recipient);
        }

        public void SendParallel(Email email, Sender from, IEnumerable<Recipient> to)
        {
            foreach (var recipient in to)
                ThreadPool.QueueUserWorkItem(_ => Send(email, from, recipient));
        }
    }
}
