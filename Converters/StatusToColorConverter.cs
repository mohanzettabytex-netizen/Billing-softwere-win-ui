using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using App_3.Models;
using System;

namespace App_3.Converters
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is LinkStatus status)
            {
                return status switch
                {
                    LinkStatus.Active => new SolidColorBrush(Colors.LightGreen),
                    LinkStatus.Inactive => new SolidColorBrush(Colors.LightGray),
                    LinkStatus.Expired => new SolidColorBrush(Colors.LightCoral),
                    _ => new SolidColorBrush(Colors.Transparent)
                };
            }
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
