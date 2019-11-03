namespace MyAssistant.Services
{
    public interface ISelectFileService
    {
        string SelectSingleFile();

        string[] SelectMultipleFiles();
    }
}
