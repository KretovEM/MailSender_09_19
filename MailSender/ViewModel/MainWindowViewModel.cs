using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MailSenderLib.Data.LinqToSql;
using MailSenderLib.Services;

namespace WpfTestMailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private RecipientsDataProvider _recipientsDataProvider;

        private string _WidowTitle = "Рассыльщик почты v0.1";

        public string WidowTitle
        {
            get => _WidowTitle;
            set => Set(ref _WidowTitle, value);
        }

        public ObservableCollection<Recipient> Recipients { get; } = new ObservableCollection<Recipient>();

        public MainWindowViewModel(RecipientsDataProvider recipientsDataProvider)
        {
            _recipientsDataProvider = recipientsDataProvider;

            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = Recipients;
            recipients.Clear();
            foreach (var recipient in _recipientsDataProvider.GetAll())
            {
                recipients.Add(recipient);
            }
        }
    }
}
