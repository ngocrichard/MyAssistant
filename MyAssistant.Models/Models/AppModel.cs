namespace MyAssistant.Models
{
    public class AppModel : ObservableModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public AppModel(long id, string name, string path)
        {
            Id = id;
            Name = name;
            Path = path;
        }
    }
}
