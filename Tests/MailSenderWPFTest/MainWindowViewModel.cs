using MailSenderLib.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPFTest
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Заголовок окна";
        public string Title
        {
            get => _Title;
            set
            {
                if (Title == value) return;
                _Title = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TitleLength));
            }
        }

        public int TitleLength => Title?.Length ?? 0;


        private int _OffsetX = 10;

        public int OffsetX
        {
            get => _OffsetX;
            set => Set(ref _OffsetX, value);
        }
        

        private int _OffsetY = 10;

        public int OffsetY
        {
            get => _OffsetY;
            set => Set(ref _OffsetY, value);
        }
    }
}
