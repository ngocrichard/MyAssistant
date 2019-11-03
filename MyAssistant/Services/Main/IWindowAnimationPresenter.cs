using System.Threading.Tasks;
using System.Windows;

namespace MyAssistant.Services
{
    public interface IWindowAnimationPresenter
    {
        Task PerformAnimation(Window window, WindowState toThisState);
    }
}
