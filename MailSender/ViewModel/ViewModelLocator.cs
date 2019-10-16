using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSenderLib.Data.LinqToSql;
using MailSenderLib.Services;
using MailSenderLib.Data.EF;
using MailSenderLib.Services.EF;

namespace WpfTestMailSender.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator() 
        {
            var services = SimpleIoc.Default;
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            services.Register<MainWindowViewModel>();

            services
               .TryRegister<IRecipientsDataProvider, LinqToSqlRecipientsDataProvider>()
               .TryRegister(() => new MailSenderDBDataContext())
               .TryRegister<MemoryDataContext>()
               .TryRegister<DataContextProvider>();
            //.TryRegister(() => new MailSenderDB()); 

            //services
            //   .TryRegister<IRecipientsDataProvider, InMemoryMemoryRecipientsDataProvider>()
            //   .TryRegister<ISendersDataProvider, InMemoryMemorySendersDataProvider>()
            //   .TryRegister<IServersDataProvider, InMemoryMemoryServersDataProvider>();
        }

        public MainWindowViewModel MainWindowModel =>
                ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}