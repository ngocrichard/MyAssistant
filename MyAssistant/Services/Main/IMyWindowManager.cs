using Caliburn.Micro;
using System.Windows;

namespace MyAssistant.Services
{
    public interface IMyWindowManager
    {
        Window GetView(Screen screen);

        void RestoreWindow(Window window);

        void MinimizeWindow(Window window);

        void CloseWindow(Window window);
    }
}
