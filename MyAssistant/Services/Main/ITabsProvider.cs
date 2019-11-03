using Caliburn.Micro;
using System.Collections.Generic;

namespace MyAssistant.Services
{
    public interface ITabsProvider
    {
        IEnumerable<Screen> GetTabViewModels();
    }
}
