using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using System;

namespace App_3.Converters
{
    public class ItemStockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool isLow && parameter is string param)
            {
                return (param == "Low" && isLow) || (param == "Available" && !isLow)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
