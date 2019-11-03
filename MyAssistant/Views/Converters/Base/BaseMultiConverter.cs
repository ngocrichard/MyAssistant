using Caliburn.Micro;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace MyAssistant.Views.Converters
{
    public abstract class BaseMultiConverter<T> : MarkupExtension, IMultiValueConverter
    {
        #region Singleton instance

        private static T instance;

        /// <summary>
        /// Singleton instance of this class
        /// </summary>
        public static T Instance => instance ?? (instance = IoC.Get<T>());


        #endregion

        #region Provide instance for XAML

        /// <summary>
        /// This method provides instance of this class for XAML
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider) => Instance;

        #endregion

        #region Implement IMultiValueConverter

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

        #endregion
    }
}
