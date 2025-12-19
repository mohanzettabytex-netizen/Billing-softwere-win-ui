using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

namespace App_3.Converters
{
    public class PaymentStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value?.ToString() switch
            {
                "Paid" => new SolidColorBrush(Color.FromArgb(255, 220, 252, 220)),
                "Pending" => new SolidColorBrush(Color.FromArgb(255, 255, 245, 230)),
                "Failed" => new SolidColorBrush(Color.FromArgb(255, 254, 228, 228)),
                _ => new SolidColorBrush(Colors.LightGray),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }

    public class PaymentStatusToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value?.ToString() switch
            {
                "Paid" => new SolidColorBrush(Colors.Green),
                "Pending" => new SolidColorBrush(Colors.DarkOrange),
                "Failed" => new SolidColorBrush(Colors.Red),
                _ => new SolidColorBrush(Colors.Black),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }
}
