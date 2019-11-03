using Caliburn.Micro;
using MyAssistant.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyAssistant.ViewModels
{
    public class AppsViewModel : Screen
    {
        #region Constructor

        private readonly IAppsService appsService;

        public AppsViewModel(IAppsService appsService)
        {
            this.appsService = appsService;

            MyApps = new BindableCollection<AppViewModel>();
            OpenAppCmd = new RelayCommand(OpenApp);
        }

        #endregion

        #region Initializing

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            await Initialize();
        }

        public async Task Initialize()
        {
            var appVMs = await appsService.GetAll(IconSize);
            MyApps = new BindableCollection<AppViewModel>(appVMs);
        }

        #endregion

        #region Apps

        public int IconSize { get; set; } = 128;

        public int SelectedAppIndex { get; set; }

        /// <summary>
        /// Binding apps collection
        /// </summary>
        public BindableCollection<AppViewModel> MyApps { get; set; }

        public async Task AddNewApp()
        {
            await appsService.AddNew(MyApps);
        }

        public async Task EditAppName()
        {
            await appsService.EditName(MyApps, SelectedAppIndex);
        }

        public async Task RemoveApp()
        {
            await appsService.Remove(MyApps, SelectedAppIndex);
        }

        public ICommand OpenAppCmd { get; }

        private void OpenApp() => appsService.Open(MyApps[SelectedAppIndex]);

        #endregion
    }
}
