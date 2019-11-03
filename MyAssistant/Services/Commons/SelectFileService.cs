using Microsoft.Win32;

namespace MyAssistant.Services
{
    public class SelectFileService : ISelectFileService
    {
        #region Dialog
        private readonly OpenFileDialog Dialog;
        #endregion

        #region Constructor

        public SelectFileService()
        {
            Dialog = new OpenFileDialog();
        }

        #endregion

        public string SelectSingleFile()
        {
            // Set single selection
            Dialog.Multiselect = false;
            // Open dialog
            var dialogResult = Dialog.ShowDialog();
            // Return file path
            if (dialogResult.Value == true)
            {
                return Dialog.FileName;
            }
            // Return null if no file is selected
            return null;
        }

        public string[] SelectMultipleFiles()
        {
            // Set single selection
            Dialog.Multiselect = true;
            // Open dialog
            var dialogResult = Dialog.ShowDialog();
            // Return file path
            if (dialogResult.Value == true)
            {
                return Dialog.FileNames;
            }
            // Return null if no file is selected
            return null;
        }
    }
}
