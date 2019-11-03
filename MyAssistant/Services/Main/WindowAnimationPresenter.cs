using MyAssistant.Views;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MyAssistant.Services
{
    public class WindowAnimationPresenter : IWindowAnimationPresenter
    {
        #region Constructor

        private WindowAnimations windowAnimations;

        public WindowAnimationPresenter(WindowAnimations windowAnimations)
        {
            this.windowAnimations = windowAnimations;
        }

        #endregion

        /// <summary>
        /// Perform animation. If restoring then slide from right, else if minizing
        /// then slide to right
        /// </summary>
        /// <param name="window"></param>
        /// <param name="toThisState"></param>
        /// <returns></returns>
        public async Task PerformAnimation(Window window, WindowState toThisState)
        {
            switch (toThisState)
            {
                case WindowState.Normal:
                    await windowAnimations.SlideFromRight(window);
                    break;
                case WindowState.Minimized:
                    await windowAnimations.SlideToRight(window);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
