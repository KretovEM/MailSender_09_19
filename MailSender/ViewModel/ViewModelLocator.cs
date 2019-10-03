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
using System;

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
               .TryRegister(() => new MailSenderDBDataContext());

            //services
            //   .TryRegister<IRecipientsDataProvider, InMemoryRecipientsDataProvider>()
            //   .TryRegister<ISendersDataProvider, InMemorySendersDataProvider>()
            //   .TryRegister<IServersDataProvider, InMemoryServersDataProvider>();
        }

        public MainWindowViewModel MainWindowModel =>
                ServiceLocator.Current.GetInstance<MainWindowViewModel>();
            
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }

    public static class SimpleIocExtentions
    {
        public static SimpleIoc TryRegister<TInterface, TService>(this SimpleIoc services)
            where TInterface : class
            where TService : class, TInterface
        {
            if (services.IsRegistered<TInterface>()) 
                return services;
            services.Register<TInterface, TService>();
            return services;
        }

        public static SimpleIoc TryRegister<TService>(this SimpleIoc services)
           where TService : class
        {
            if (services.IsRegistered<TService>()) 
                return services;
            services.Register<TService>();
            return services;
        }

        public static SimpleIoc TryRegister<TService>(this SimpleIoc services, Func<TService> Factory)
           where TService : class
        {
            if (services.IsRegistered<TService>()) 
                return services;
            services.Register(Factory);
            return services;
        }

    }
}