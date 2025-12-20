using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Windows.UI; // Add this at the top
using System;

namespace App_3.Converters
{
    // Converter for Expense Status → Background Color
    public class ExpenseStatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string status = value?.ToString();

            return status switch
            {
                "Paid" => new SolidColorBrush(Color.FromArgb(255, 220, 252, 220)),    // light green
                "Unpaid" => new SolidColorBrush(Color.FromArgb(255, 255, 245, 230)),  // light orange
                "Pending" => new SolidColorBrush(Color.FromArgb(255, 254, 228, 228)), // light red
                _ => new SolidColorBrush(Colors.LightGray),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }

    // Converter for Expense Status → Foreground Color
    public class ExpenseStatusToForegroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string status = value?.ToString();

            return status switch
            {
                "Paid" => new SolidColorBrush(Colors.Green),
                "Unpaid" => new SolidColorBrush(Colors.DarkOrange),
                "Pending" => new SolidColorBrush(Colors.Red),
                _ => new SolidColorBrush(Colors.Black),
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }
}
