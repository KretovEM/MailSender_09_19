using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.Interfaces
{
    public interface IPlugin
    {
        Task InitializeAsync();

        Task StartAsync();

        Task StopAsync();
    }
}
