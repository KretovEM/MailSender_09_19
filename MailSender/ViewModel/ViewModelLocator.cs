/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfTestMailSender"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using MailSenderLib.Data.LinqToSql;
using MailSenderLib.Services;

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

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            services.Register<MainWindowViewModel>();

            services.Register<IRecipientsDataProvider,LinqToSqlRecipientsDataProvider>();
            //services.Register<IRecipientsDataProvider,InMemoryRecipientsDataProvider>();

            services.Register(() => new MailSenderDBDataContext());
        }

        public MainWindowViewModel MainWindowModel =>
                ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}