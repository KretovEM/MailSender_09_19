using System.Windows;
using System.Net.Mail;
using System.Net;
using System.Security;
using System;

namespace MailSenderWPFTest
{
    /// <summary>
    /// Логика взаимодействия для MailSenderWpfTestWindow.xaml
    /// </summary>
    public partial class MailSenderWpfTestWindow : Window
    {
        public MailSenderWpfTestWindow()
        {
            InitializeComponent();
        }

        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            var host = StaticData.YandexSmptHost;
            var port = StaticData.YandexSmtpPort_587;

            var userName = tboxUserName.Text;
            var password = passboxPassword.SecurePassword;

            var msg = StaticData.TestMessage;

            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(userName, password);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress(StaticData.MailAdressGandju);
                    message.To.Add(new MailAddress(StaticData.MailAdressGandju));
                    message.Subject = StaticData.TestSubject;
                    message.Body = msg;

                    try
                    {
                        client.Send(message);
                        MessageBox.Show(StaticData.MailIsSend,
                            StaticData.Success, MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message,
                            StaticData.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }    
            }
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
