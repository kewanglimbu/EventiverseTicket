﻿using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace EventiverseTicket.Admin.Mobile.ViewModels
{
    public class EventDetailViewModel : INotifyPropertyChanged
    {
        private Guid _eventId;
        private string _name;
        public double _price;
        private string _imageUrl;
        private EventStatusEnum _status;
        private DateTime _date;
        private string _descriptions;
        private List<string> _artists = new();
        private CategoryViewModel _category = new();
        private bool _showLargeImage;

        public Guid EventId
        {
            get => _eventId;
            set
            {
                if (!Equals(_eventId, value))
                {
                    _eventId = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (!Equals(_name, value))
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (!Equals(_price, value))
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                if (!Equals(_imageUrl, value))
                {
                    _imageUrl = value;
                    OnPropertyChanged();
                }
            }
        }
        public EventStatusEnum Status
        {
            get => _status;
            set
            {
                if (!Equals(_status, value))
                {
                    _status = value;
                    OnPropertyChanged();
                    ((Command)CancelEventCommand).ChangeCanExecute();
                }
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                if (!Equals(_date, value))
                {
                    _date = value;
                    OnPropertyChanged();
                    ((Command)CancelEventCommand).ChangeCanExecute();
                }
            }
        }
        public string Descriptions
        {
            get => _descriptions;
            set
            {
                if (!Equals(_descriptions, value))
                {
                    _descriptions = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<string> Artists
        {
            get => _artists;
            set
            {
                if (!Equals(_artists, value))
                {
                    _artists = value;
                    OnPropertyChanged();
                }
            }
        }
        public CategoryViewModel Category
        {
            get => _category;
            set
            {
                if (!Equals(_category, value))
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool ShowLargeImage
        {
            get => _showLargeImage;
            set
            {
                if(!Equals(_showLargeImage, value))
                {
                    _showLargeImage = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ShowSmallImage));
                }
            }
        }

        public bool ShowSmallImage => !ShowLargeImage;
      
        public ICommand CancelEventCommand { get; }
        private void CancelEvent() => Status = EventStatusEnum.Cancelled;
        private bool CanCancelEvent() => Status != EventStatusEnum.Cancelled && Date.AddHours(-6) > DateTime.Now;

        public EventDetailViewModel()
        {
            CancelEventCommand = new Command(CancelEvent, CanCancelEvent);
            EventId = Guid.NewGuid();
            Name = "Sample Event";
            Price = 150;
            ImageUrl = "https://images.pexels.com/photos/1540406/pexels-photo-1540406.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1";
            Status = EventStatusEnum.OnSale;
            Date = DateTime.Now.AddMonths(1);
            Descriptions = "This is a sample description.";
            Artists = new List<string> { "Artist1", "Artist2" };
            Category = new CategoryViewModel()
            {
                Id = Guid.Parse("B0788D2F-8003-43C1-92A4-EDC76A7C5DDE"),
                Name = "Concert"
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        // automatically obtain the name of the property that call this method
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
