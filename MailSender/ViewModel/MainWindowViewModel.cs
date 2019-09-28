using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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

        private ObservableCollection<Recipient> _Recipients  = new ObservableCollection<Recipient>();
        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }


        private Recipient _SelectedRecipient;
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }


        public ICommand RefreshDataCommand { get; }

        public ICommand SaveChangesCommand { get; }

        public MainWindowViewModel(RecipientsDataProvider recipientsDataProvider)
        {
            _recipientsDataProvider = recipientsDataProvider;

            RefreshDataCommand = new RelayCommand(OnRefreshDataCommandExecute,
                CanRefreshDataCommandExecute);
            SaveChangesCommand = new RelayCommand(OnSaveChangesCommand);
        }

        private void OnSaveChangesCommand()
        {
            _recipientsDataProvider.SaveChanges();
        }


        private bool CanRefreshDataCommandExecute() => true;
        private void OnRefreshDataCommandExecute()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = new ObservableCollection<Recipient>();
            foreach (var recipient in _recipientsDataProvider.GetAll())
            {
                recipients.Add(recipient);
            }
            Recipients = recipients;
        }
    }
}
