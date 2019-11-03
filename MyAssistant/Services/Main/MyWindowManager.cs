using Caliburn.Micro;
using System.Windows;

namespace MyAssistant.Services
{
    public class MyWindowManager : IMyWindowManager
    {
        public Window GetView(Screen screen)
        {
            return (Window)screen.GetView();
        }

        public void RestoreWindow(Window window)
        {
            SystemCommands.RestoreWindow(window);
            window.Activate();
        }

        public void MinimizeWindow(Window window)
        {
            SystemCommands.MinimizeWindow(window);
        }

        public void CloseWindow(Window window)
        {
            SystemCommands.CloseWindow(window);
        }
    }
}
