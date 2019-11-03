using Caliburn.Micro;
using MyAssistant.ViewModels;
using Ninject;
using System;
using System.Windows;

namespace MyAssistant
{
    /// <summary>
    /// In this application, we use ViewModel-first approach
    /// </summary>
    public class Bootstrapper : BootstrapperBase
    {
        #region Ninject IoC Container Wrapper

        private IKernel container;
        private ContainerConfig containerConfig;

        protected override void Configure()
        {
            // Create container
            container = new StandardKernel();
            container.Bind<IWindowManager>().To<WindowManager>();

            // Configure container
            containerConfig = new ContainerConfig();
            containerConfig.Configure(container);

            // Share container
            IoC.GetInstance = GetInstance;
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.Get(service);
        }

        #endregion

        #region Constructor

        public Bootstrapper()
        {
            Initialize();
        }

        #endregion

        #region Handle Application Startup Event

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        #endregion

        #region Hangle Application Exit Event

        protected override void OnExit(object sender, EventArgs e)
        {
            container.Dispose();
        }

        #endregion
    }
}
