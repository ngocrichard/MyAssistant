using Caliburn.Micro;
using MyAssistant.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace MyAssistant.ViewModels
{
    public class MainViewModel : Conductor<object>.Collection.AllActive
    {
        #region Constructor

        private readonly IMainService mainService;
        private readonly ITabsProvider tabsProvider;

        public MainViewModel(IMainService mainService, ITabsProvider tabsProvider)
        {
            this.mainService = mainService;
            this.tabsProvider = tabsProvider;
        }

        #endregion

        #region Initilize

        protected override async void OnInitialize()
        {
            base.OnInitialize();
            await Initialize();
        }

        public async Task Initialize()
        {
            // Set default tab
            tabViewModels = new List<Screen>(this.tabsProvider.GetTabViewModels());
            CurrentTab = tabViewModels[SelectedTabIndex];
            // Load asynchronous
            await Task.WhenAll(LoadTabsAsync());
        }

        private List<Task> LoadTabsAsync()
        {
            var tasks = new List<Task>();
            foreach (var tab in tabViewModels)
            {
                var cTab = tab;
                tasks.Add(Task.Run(() => ActivateItem(cTab)));
            }
            return tasks;
        }

        #endregion

        #region Window

        #region Loaded Handler

        /// <summary>
        /// Setup window from ViewModel
        /// </summary>
        public async Task SetupWindow()
        {
            await mainService.PerformStateChangedAnimation(this);
        }

        #endregion

        #region StateChanged Animation Handler

        /// <summary>
        /// Current window state, just for binding
        /// </summary>
        public WindowState WindowState { get; set; }

        /// <summary>
        /// Perform animation on restoring or minimizing
        /// </summary>
        /// <returns></returns>
        public async Task PerformStateChangedAnimation()
        {
            await mainService.PerformStateChangedAnimation(this);
        }

        #endregion

        #region Commands

        public async Task RestoreWindow()
        {
            await mainService.RestoreWindow(this);
        }

        public async Task MinimizeWindow()
        {
            await mainService.MinimizeWindow(this);
        }

        public void CloseWindow() => mainService.CloseWindow(this);

        #endregion

        #endregion

        #region Tab Menu

        private List<Screen> tabViewModels;

        /// <summary>
        /// Index of the selected tab, correspond to the binding ViewModel type in MenuTabs
        /// </summary>
        public int SelectedTabIndex { get; set; }

        /// <summary>
        /// ViewModel of current tab for binding
        /// </summary>
        public object CurrentTab { get; private set; }

        public void ChangeTab() => CurrentTab = tabViewModels[SelectedTabIndex];

        #endregion
    }
}
