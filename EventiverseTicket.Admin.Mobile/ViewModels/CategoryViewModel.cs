using System.ComponentModel;

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
                    OnPropertyChanged(nameof(Id));
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
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
