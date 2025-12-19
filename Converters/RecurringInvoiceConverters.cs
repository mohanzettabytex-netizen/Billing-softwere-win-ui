using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

namespace App_3.Converters
{
    public class RecurringStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value?.ToString() switch
            {
                "Active" => new SolidColorBrush(Color.FromArgb(255, 220, 252, 220)),
                "Paused" => new SolidColorBrush(Color.FromArgb(255, 255, 245, 230)),
                "Completed" => new SolidColorBrush(Color.FromArgb(255, 229, 231, 235)),
                _ => new SolidColorBrush(Colors.LightGray),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }

    public class RecurringStatusToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return value?.ToString() switch
            {
                "Active" => new SolidColorBrush(Colors.Green),
                "Paused" => new SolidColorBrush(Colors.DarkOrange),
                "Completed" => new SolidColorBrush(Colors.Gray),
                _ => new SolidColorBrush(Colors.Black),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }
}
