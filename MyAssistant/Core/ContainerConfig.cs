using MyAssistant.DAL;
using MyAssistant.Services;
using MyAssistant.ViewModels;
using MyAssistant.Views;
using Ninject;


namespace MyAssistant
{
    /// <summary>
    /// Config dependencies for interfaces of the applicatioin
    /// </summary>
    public class ContainerConfig
    {
        public void Configure(IKernel container)
        {
            // Config ViewModels
            container.Bind<MainViewModel>().ToSelf().InSingletonScope();
            container.Bind<HomeViewModel>().ToSelf().InSingletonScope();
            container.Bind<AppsViewModel>().ToSelf().InSingletonScope();
            container.Bind<YoutubeViewModel>().ToSelf().InSingletonScope();

            // Config services
            container.Bind<IWindowAnimationPresenter>().To<WindowAnimationPresenter>().InSingletonScope();
            container.Bind<IMyWindowManager>().To<MyWindowManager>().InSingletonScope();
            container.Bind<IMainService>().To<MainService>().InSingletonScope();
            container.Bind<ITabsProvider>().To<TabProvider>().InSingletonScope();
            container.Bind<IAppsService>().To<AppsService>().InSingletonScope();
            container.Bind<IAppService>().To<AppService>().InSingletonScope();
            container.Bind<ISelectFileService>().To<SelectFileService>().InSingletonScope();
            container.Bind<IApplicationDispatcher>().To<ApplicationDispatcher>().InSingletonScope();

            // Config repositories
            container.Bind<ISqliteDatabase>().To<SqliteDatabase>().InSingletonScope();
            container.Bind<IAppRepository>().To<AppRepository>().InSingletonScope();
        }
    }
}
