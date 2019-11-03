using MyAssistant.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace MyAssistant.Services
{
    public interface IAppService
    {
        public AppViewModel SelectNew(IEnumerable<AppViewModel> appVMs);

        public void SetIcon(AppViewModel app, int iconSize);
    }
}
