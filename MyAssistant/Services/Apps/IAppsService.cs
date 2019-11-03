using MyAssistant.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MyAssistant.Services
{
    public interface IAppsService
    {
        Task<List<AppViewModel>> GetAll(int iconSize);
        Task<bool> AddNew(ObservableCollection<AppViewModel> appVMs);
        Task<bool> Remove(ObservableCollection<AppViewModel> appVMs, int selectedIndex);
        Task<bool> EditName(ObservableCollection<AppViewModel> appVMs, int selectedIndex);
        void Open(AppViewModel appViewModel);
    }
}
