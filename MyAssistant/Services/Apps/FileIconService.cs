using FileIconExtraction;
using System.Windows.Media;

namespace MyAssistant.Services
{
    public class FileIconService
    {
        #region Constructor

        private readonly FileIconExtractService fileIconExtractService;

        public FileIconService(FileIconExtractService fileIconExtractService)
        {
            this.fileIconExtractService = fileIconExtractService;
        }

        #endregion

        public ImageSource GetIcon(string filePath, int iconSize)
        {
            return fileIconExtractService.GetImage(filePath, iconSize);
        }
    }
}
