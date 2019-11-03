using MyAssistant.Models;
using System.Windows.Media;

namespace MyAssistant.ViewModels
{
    public class AppViewModel : AppModel
    {
        public ImageSource Icon { get; set; }

        public AppViewModel(AppModel app) : base(app.Id, app.Name, app.Path) { }
    }
}
