using System;
using System.Diagnostics;
using System.Globalization;

namespace MyAssistant.Views
{
    public class StringToEnumConverter : BaseConverter<StringToEnumConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                return Enum.Parse(targetType, (string)value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw new InvalidOperationException("Invalid enum value or enum type.");
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException("Invalid enum value or enum type.");
        }
    }
}
