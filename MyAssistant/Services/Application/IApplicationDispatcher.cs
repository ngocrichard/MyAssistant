using System;
using System.Windows.Threading;

namespace MyAssistant.Services
{
    public interface IApplicationDispatcher
    {
        DispatcherOperation Invoke(DispatcherPriority priority, Action action);
    }
}