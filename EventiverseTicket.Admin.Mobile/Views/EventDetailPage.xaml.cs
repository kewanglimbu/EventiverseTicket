using EventiverseTicket.Admin.Mobile.ViewModels;

namespace EventiverseTicket.Admin.Mobile.Views;

public partial class EventDetailPage : ContentPage
{
	public EventDetailPage()
	{
		InitializeComponent();
		BindingContext = new EventDetailViewModel();
	}
}