using MyAssistant.DAL;
using MyAssistant.Models;
using MyAssistant.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MyAssistant.Services
{
    public class AppsService : IAppsService
    {
        #region Constructor

        private readonly IAppRepository appRepository;
        private readonly AppService appService;
        private readonly IApplicationDispatcher dispatcher;

        public AppsService(IAppRepository appRepository, AppService appService, IApplicationDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.appRepository = appRepository;
            this.appService = appService;
        }

        #endregion

        #region First Time Load Handler

        /// <summary>
        /// Get all apps
        /// </summary>
        /// <param name="appVMs"></param>
        public async Task<List<AppViewModel>> GetAll(int iconSize)
        {
            // Get apps from repositoriy
            var apps = appRepository.SelectAllApps().ToList();
            // If apps is null then nothing we can do
            if (apps == null)
                return null;
            // Update to ViewModel
            var appVMs = apps.Select(app => new AppViewModel(app)).ToList();
            // Load icon asynchronously
            await LoadAllIcons(appVMs, iconSize);
            return appVMs;
        }

        /// <summary>
        /// Load image asynchronously
        /// </summary>
        /// <param name="appVMs"></param>
        /// <param name="iconSize"></param>
        /// <returns></returns>
        public async Task LoadAllIcons(IEnumerable<AppViewModel> appVMs, int iconSize)
        {
            // Load icon asynchronously
            var tasks = new List<Task>();
            foreach (var appVM in appVMs)
            {
                // Call dispatcher to update UI
                var task = Task.Run(() => dispatcher.Invoke(DispatcherPriority.Render,
                    () => appService.SetIcon(appVM, iconSize)));
                tasks.Add(task);
            }
            await Task.WhenAll(tasks);
        }

        #endregion

        #region Add new App

        /// <summary>
        /// Open file dialog, select and add new app
        /// </summary>
        /// <returns></returns>
        public async Task<bool> AddNew(ObservableCollection<AppViewModel> appVMs)
        {
            // Get app
            var appVM = appService.SelectNew(appVMs);
            // If user did not select any file
            if (appVM == null)
                return true;

            // Update ViewModel
            var taskUpdate = Task.Run(() => appVMs.Add(appVM));
            // Insert to database and update id
            var taskInsert = Task.Run(() =>
            {
                var id = appRepository.InsertNewApp(appVM.Name, appVM.Path);
                appVM.Id = id.GetValueOrDefault();
                return id != null;
            });
            await Task.WhenAll(taskUpdate, taskInsert);
            return taskInsert.Result;
        }

        #endregion

        #region Modify App

        public async Task<bool> Remove(ObservableCollection<AppViewModel> appVMs, int selectedIndex)
        {
            // Get id
            long id = appVMs[selectedIndex].Id;
            // Update ViewModel
            var taskRemove = Task.Run(() => appVMs.RemoveAt(selectedIndex));
            // Insert to database and update id
            var taskInsert = Task.Run(() => appRepository.DeleteAppById(id));
            // Return status
            await Task.WhenAll(taskRemove, taskInsert);
            return taskInsert.Result;
        }

        public async Task<bool> EditName(ObservableCollection<AppViewModel> appVMs, int selectedIndex)
        {
            // Get current app
            var appVM = appVMs[selectedIndex];
            // Get id
            long id = appVM.Id;
            // Update database
            return await appRepository.UpdateAppById(id, appVM.Name, null);
        }

        public void Open(AppViewModel appViewModel)
        {
            appService.OpenWithDefaultProgram(appViewModel);
        }

        #endregion
    }
}
