using System;
using System.Windows;
using System.Windows.Threading;

namespace MyAssistant.Services
{
    public class ApplicationDispatcher : IApplicationDispatcher
    {
        public DispatcherOperation Invoke(DispatcherPriority priority, Action action)
        {
            return Application.Current.Dispatcher.BeginInvoke(priority, action);
        }
    }
}
