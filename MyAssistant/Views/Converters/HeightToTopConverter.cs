using System;
using System.Globalization;
using System.Windows;

namespace MyAssistant.Views
{
    /// <summary>
    /// This class convert width of window to the top of the bottom right position
    /// </summary>
    public class HeightToTopConverter : BaseConverter<HeightToTopConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Get the height of the window
            double height = (double)value;

            // Calculate the top of the window
            return SystemParameters.WorkArea.Bottom - height;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
