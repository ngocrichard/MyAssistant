using MyAssistant.ViewModels;
using System.Threading.Tasks;

namespace MyAssistant.Services
{
    public interface IMainService
    {
        Task PerformStateChangedAnimation(MainViewModel vm);
        Task RestoreWindow(MainViewModel vm);
        Task MinimizeWindow(MainViewModel vm);
        void CloseWindow(MainViewModel vm);
    }
}
