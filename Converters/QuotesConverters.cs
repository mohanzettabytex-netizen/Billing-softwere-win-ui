using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI;
using System;

namespace App_3.Converters
{
    public class QuotesConverters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return ((string)value) switch
            {
                "Approved" => new SolidColorBrush(Colors.Green),
                "Draft" => new SolidColorBrush(Colors.Orange),
                "Sent" => new SolidColorBrush(Colors.Blue),
                "Rejected" => new SolidColorBrush(Colors.Red),
                _ => new SolidColorBrush(Colors.Gray)
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) =>
            throw new NotImplementedException();
    }
}
