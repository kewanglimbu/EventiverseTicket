using EventiverseTicket.Admin.Mobile.Views;

namespace EventiverseTicket.Admin.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new EventDetailPage();
        }
    }
}
