using System;
using System.Windows;
using System.Windows.Data;

namespace SOL.Silverlight.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        #region Properties
        
        public bool Inverse { get; set; }

        #endregion

        #region Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new ArgumentException("targetType", "VisibilityConverter can only convert to Visibility");

            Visibility visibility = Visibility.Visible;
            if (value == null)
                visibility = Visibility.Collapsed;

            if (value is bool)
                visibility = (bool)value ? Visibility.Visible : Visibility.Collapsed;

            if (value is string)
                visibility = String.IsNullOrEmpty((string)value) ? Visibility.Collapsed : Visibility.Visible;

            if (this.Inverse)
                visibility = (visibility == Visibility.Visible) ? Visibility.Collapsed : Visibility.Visible;

            return visibility;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is Visibility))
                throw new ArgumentException("value", "VisibilityConverter can only convert from Visibility");

            if (targetType == typeof(bool))
                return ((Visibility)value == Visibility.Visible) ? true : false;
            else
                throw new ArgumentException("targetType", "VisibilityConverter can only convert to Boolean");
        }

        #endregion
    }
}
