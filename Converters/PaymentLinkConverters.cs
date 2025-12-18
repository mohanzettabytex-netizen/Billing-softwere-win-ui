using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;

namespace App_3.Converters
{
    // ================= Status to Background Color =================
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string status = value as string;
            return status switch
            {
                "Paid" => new SolidColorBrush(Colors.LightGreen),
                "Pending" => new SolidColorBrush(Colors.LightGoldenrodYellow),
                "Expired" => new SolidColorBrush(Colors.IndianRed),
                _ => new SolidColorBrush(Colors.LightGray),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    // ================= Status to Foreground Color =================
    public class StatusToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string status = value as string;
            return status switch
            {
                "Paid" => new SolidColorBrush(Colors.DarkGreen),
                "Pending" => new SolidColorBrush(Colors.DarkGoldenrod),
                "Expired" => new SolidColorBrush(Colors.DarkRed),
                _ => new SolidColorBrush(Colors.Black),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }

    // ================= Empty State Visibility =================
    public class EmptyStateVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is int count && count == 0)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
