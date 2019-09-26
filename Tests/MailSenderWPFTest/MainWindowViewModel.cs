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

        private int _OffsetX = 10;

        public int OffserX
        {
            get => _OffsetX;
            set => Set(ref _OffsetX, value);
        }
        
        private int _OffsetY = 10;

        public int OffserY
        {
            get => _OffsetY;
            set => Set(ref _OffsetY, value);
        }
    }
}
