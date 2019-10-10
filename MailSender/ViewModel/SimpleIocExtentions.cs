using System;
using GalaSoft.MvvmLight.Ioc;

namespace WpfTestMailSender.ViewModel
{
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

        public static SimpleIoc TryRegister<TService>(this SimpleIoc services, Func<TService> factory)
            where TService : class
        {
            if (services.IsRegistered<TService>()) 
                return services;
            services.Register(factory);
            return services;
        }

    }
}