using System.Windows;
using System.Net.Mail;
using System.Net;
using System.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;

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
            //var host = StaticData.YandexSmptHost;
            //var port = StaticData.YandexSmtpPort_587;

            //var userName = tboxUserName.Text;
            //var password = passboxPassword.SecurePassword;

            //var msg = StaticData.TestMessage;

            //using (var client = new SmtpClient(host, port))
            //{
            //    client.EnableSsl = true;
            //    client.Credentials = new NetworkCredential(userName, password);

            //    using (var message = new MailMessage())
            //    {
            //        message.From = new MailAddress(StaticData.MailAdressGandju);
            //        message.To.Add(new MailAddress(StaticData.MailAdressGandju));
            //        message.Subject = StaticData.TestSubject;
            //        message.Body = msg;

            //        try
            //        {
            //            client.Send(message);
            //            MessageBox.Show(StaticData.MailIsSend,
            //                StaticData.Success, MessageBoxButton.OK, MessageBoxImage.Information);
            //        }
            //        catch (Exception error)
            //        {
            //            MessageBox.Show(error.Message,
            //                StaticData.Error, MessageBoxButton.OK, MessageBoxImage.Error);
            //        }
            //    }    
            //}
            //try
            //{

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private CancellationTokenSource _ProcessCancellation;

        private async void BtnStart_OnClick(object sender, RoutedEventArgs e)
        {
            var cts = new CancellationTokenSource();

            Interlocked.Exchange(ref _ProcessCancellation, cts)?.Cancel();

            var cancel = cts.Token;

            var file_dialog = new OpenFileDialog
            {
                Title = "Файл данных",
                Filter = "zip-архивы (*.zip)|*.zip|Все файлы (*.*)|*.*",
                InitialDirectory = Environment.CurrentDirectory
            };

            if (file_dialog.ShowDialog() != true) return;

            var data_file_name = file_dialog.FileName;
            if (!File.Exists(data_file_name)) return;

            var tasks = new List<Task<int>>();
            int[] result;

            IProgress<double> progress = new Progress<double>(p => ProgressInformer.Value = p * 100);

            try
            {
                using (var zip = new ZipArchive(file_dialog.OpenFile()))
                {
                    //var total_length = zip.Entries.Sum(e => e.Length);

                    foreach (var zip_entry in zip.Entries.Where(x => x.Name.EndsWith(".txt")).Take(1))
                        tasks.Add(GetWordsCountAsync(zip_entry.Open(), zip_entry.Length, progress, cancel));

                    result = await Task.WhenAll(tasks);
                }

                ResultText.Text = $"Количество слов = {result.Sum()}";
            }
            catch (OperationCanceledException)
            {
                ResultText.Text = "Операция отменена";
            }

        }

        private static async Task<int> GetWordsCountAsync(Stream stream, long Length, IProgress<double> Progress, CancellationToken Cancel)
        {
            var reader = new StreamReader(stream);
            var words_count = 0;
            var seperators = new[] { ' ' };
            var position = 0L;
            while (!reader.EndOfStream)
            {
                Cancel.ThrowIfCancellationRequested();

                var line = await reader.ReadLineAsync().ConfigureAwait(true);
                position += line.Length;

                await Task.Delay(1, Cancel).ConfigureAwait(true);

                if (string.IsNullOrWhiteSpace(line)) continue;
                words_count += line
                    .Split(seperators, StringSplitOptions.RemoveEmptyEntries)
                    .Length;

                Progress?.Report((double)position / Length);
            }

            return words_count;
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            _ProcessCancellation?.Cancel();
        }
    }
}
