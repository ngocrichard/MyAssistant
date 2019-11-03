using MyAssistant.Core.Services;
using MyAssistant.Models;
using MyAssistant.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Media;

namespace MyAssistant.Services
{
    public class AppService : IAppService
    {
        #region Constructor

        private readonly ISelectFileService selectFileService;
        private readonly FileIconService fileIconService;
        private readonly ProcessService processService;

        public AppService(ISelectFileService selectFileService,
            FileIconService fileIconService, ProcessService processService)
        {
            this.selectFileService = selectFileService;
            this.fileIconService = fileIconService;
            this.processService = processService;
        }

        #endregion

        public AppViewModel SelectNew(IEnumerable<AppViewModel> appVMs)
        {
            // Get selected file full path
            string path = selectFileService.SelectSingleFile();

            // If not any file selected, nothing we can do
            if (path == null)
                return null;

            // Check if path is exist
            if (appVMs.Where(appVM => appVM.Path == path).Count() > 0)
                throw new Exception("Path is already existed.");

            var name = Path.GetFileNameWithoutExtension(path);
            return new AppViewModel(new AppModel(0, name, path));
        }

        public void SetIcon(AppViewModel appVM, int iconSize)
        {
            appVM.Icon = fileIconService.GetIcon(appVM.Path, iconSize);
        }

        public void OpenWithDefaultProgram(AppViewModel appViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
