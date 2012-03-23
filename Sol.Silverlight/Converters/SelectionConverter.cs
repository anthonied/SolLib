using System;
using System.Windows.Data;

namespace SOL.Silverlight.Converters
{
    public class SelectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                int selectedIndex = (int)value;
                if (selectedIndex >= 0)
                    return true;
            }
            else if (value is object)
            {
                if (value != null)
                    return true;
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
