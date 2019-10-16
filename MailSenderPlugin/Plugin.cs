using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MailSenderLib.Services.Interfaces;

namespace MailSenderPlugin
{
    public class Plugin : IPlugin
    {
        public async Task InitializeAsync()
        {
            await Task.Run(() => MessageBox.Show("Плагин проинициализирован"));
        }

        public async Task StartAsync()
        {
            await Task.Run(() => MessageBox.Show("Плагин запущен"));
        }

        public async Task StopAsync()
        {
            await Task.Run(() => MessageBox.Show("Плагин остановлен"));
        }
    }
}
