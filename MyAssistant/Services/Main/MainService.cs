using MyAssistant.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace MyAssistant.Services
{
    public class MainService : IMainService
    {
        #region Constructor

        private readonly IWindowAnimationPresenter windowAnimationPresenter;
        private readonly IMyWindowManager myWindowManager;

        public MainService(IWindowAnimationPresenter windowAnimationPresenter,
            IMyWindowManager myWindowManager)
        {
            this.windowAnimationPresenter = windowAnimationPresenter;
            this.myWindowManager = myWindowManager;
        }

        #endregion

        /// <summary>
        /// Perform animation when state of window changes
        /// </summary>
        /// <param name="window"></param>
        /// <param name="toThisState"></param>
        /// <returns></returns>
        public async Task PerformStateChangedAnimation(MainViewModel vm)
        {
            var window = myWindowManager.GetView(vm);
            await windowAnimationPresenter.PerformAnimation(window, window.WindowState);
        }

        /// <summary>
        /// Restore the main window of application
        /// </summary>
        public async Task RestoreWindow(MainViewModel vm)
        {
            var window = myWindowManager.GetView(vm);
            bool isNormalStateAlready = (window.WindowState == WindowState.Normal);
            // Restore window
            myWindowManager.RestoreWindow(window);
            // Perform animation
            if (!isNormalStateAlready)
                await windowAnimationPresenter.PerformAnimation(window, WindowState.Normal);
        }

        /// <summary>
        /// Minimze the window of this view model
        /// </summary>
        public async Task MinimizeWindow(MainViewModel vm)
        {
            var window = myWindowManager.GetView(vm);
            // Perform animation
            await windowAnimationPresenter.PerformAnimation(window, WindowState.Minimized);
            // Minimze window
            myWindowManager.MinimizeWindow(window);
        }

        /// <summary>
        /// Close the main window
        /// </summary>
        public void CloseWindow(MainViewModel vm)
        {
            var window = myWindowManager.GetView(vm);
            myWindowManager.CloseWindow(window);
        }
    }
}
