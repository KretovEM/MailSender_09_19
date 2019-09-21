using System.Windows;
using System.Net.Mail;
using System.Net;
using System.Security;
using System;

namespace MailSenderWPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SendButtonClick(object sender, RoutedEventArgs e)
        {
            var host = "smtp.yandex.ru";
            var port = 587;

            var userName = tboxUserName.Text;
            var password = passboxPassword.SecurePassword;

            var msg = "Hello world!!! " + DateTime.Now;
            using (var client = new SmtpClient(host, port))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(userName, password);

                using (var message = new MailMessage())
                {
                    message.From = new MailAddress("gandjubas47@yandex.ru");
                    message.To.Add(new MailAddress("gandjubas47@yandex.ru"));
                    message.Subject = "Заголовок письма от " + DateTime.Now;
                    message.Body = msg;

                    try
                    {
                        client.Send(message);
                        MessageBox.Show("Почта успешно отправлена",
                            "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show(error.Message,
                            "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }    
            }
        }
    }
}
