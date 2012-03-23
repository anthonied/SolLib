using System;
using System.Windows.Data;

namespace SOL.Silverlight.Converters
{
    public class TimeSpanToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is TimeSpan))
                throw new ArgumentException("value", "TimeSpanToDateTimeConverter can only convert from TimeSpan");

            if (value != null)
            {
                TimeSpan timeValue = (TimeSpan)value;

                if (targetType == typeof(DateTime))
                    return new DateTime().Add(timeValue);
                else if (targetType == typeof(String))
                    return timeValue.ToString();
                else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    return new DateTime().Add(timeValue);
                else
                    throw new ArgumentException("targetType", "TimeSpanToDateTimeConverter can only convert to DateTime");
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(TimeSpan))
                throw new ArgumentException("targetType", "TimeSpanToDateTimeConverter can only convert to TimeSpan");

            if (!(value is DateTime))
                throw new ArgumentException("value", "TimeSpanToDateTimeConverter can only convert from DateTime");

            if (value != null)
                return ((DateTime)value).TimeOfDay;

            return value;
        }
    }
}
