using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyAssistant.Models
{
    public abstract class ObservableModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
