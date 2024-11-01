using EventiverseTicket.Admin.Mobile.ViewModels;
using System.Globalization;

namespace EventiverseTicket.Admin.Mobile.Converters
{
    class StatusEnumToTextConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if(value is not EventStatusEnum status)
            {
               return string.Empty;
            }

            return status switch
            {
                EventStatusEnum.OnSale => "On Sale",
                EventStatusEnum.AlmostSoldOut => "Ticket is Almost Sold out",
                EventStatusEnum.SalesClosed => "Ticket Sales is Closed",
                EventStatusEnum.Cancelled => "Cancelled",
                _ => string.Empty
            };
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
