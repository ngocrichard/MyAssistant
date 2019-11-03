using System;
using System.Globalization;
using System.Windows;

namespace MyAssistant.Views
{
    public class BooleanToVisibilityConverter : BaseConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Visibility.Visible : Visibility.Collapsed;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Visibility)value)
            {
                case Visibility.Visible:
                    return true;
                case Visibility.Hidden:
                    return false;
                case Visibility.Collapsed:
                    return false;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
