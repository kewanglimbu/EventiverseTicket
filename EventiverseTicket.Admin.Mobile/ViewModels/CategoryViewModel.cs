using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EventiverseTicket.Admin.Mobile.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private Guid _id;
        private string _name;

        public Guid Id
        {
            get => _id;
            set
            {
                if (!value.Equals(_id))
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (!value.Equals(_name))
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        // automatically obtain the name of the property that call this method
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
