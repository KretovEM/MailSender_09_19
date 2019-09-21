using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderWPFTest
{
    internal static class StaticData
    {
        public static string YandexSmptHost = "smtp.yandex.ru";
        public static int YandexSmtpPort_25 = 25;
        public static int YandexSmtpPort_587 = 587;

        public static string TestMessage = "Hello world!!! " + DateTime.Now;
        public static string TestSubject = "Заголовок письма от " + DateTime.Now;

        public static string MailAdressGandju = "gandjubas47@yandex.ru";
        public static string MailAdressKretov = "kretov.em@yandex.ru";

        public static string Success = "Успех!";
        public static string Error = "Ошибка!";
        public static string MailIsSend = "Почта успешно отправлена";
    }
}
