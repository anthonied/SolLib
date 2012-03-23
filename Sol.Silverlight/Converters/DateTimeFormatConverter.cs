using System;
using System.Windows.Data;

namespace SOL.Silverlight.Converters
{
    public sealed class DateTimeFormatConverter : IValueConverter
    {
        public const string FORMAT_DATE = "yyyy/MM/dd";
        public const string FORMAT_SHORT_TIME = "HH:mm";
        public const string FORMAT_TIME = "HH:mm:ss";
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                string format = String.Format("{0} {1}", FORMAT_DATE, FORMAT_TIME);
                if (parameter != null)
                {
                    string formatParam = (string)parameter;
                    if (formatParam.Equals("Date", StringComparison.InvariantCultureIgnoreCase))
                        format = FORMAT_DATE;
                    else if (formatParam.Equals("Time", StringComparison.InvariantCultureIgnoreCase))
                        format = FORMAT_TIME;
                    else if (formatParam.Equals("DateShortTime", StringComparison.InvariantCultureIgnoreCase))
                        format = String.Format("{0} {1}", FORMAT_DATE, FORMAT_SHORT_TIME);
                    else
                        format = (string)parameter;
                }

                if (value is DateTime)
                {
                    DateTime dt = (DateTime)value;
                    return dt.ToString(format);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime? result = value as DateTime?;

            if (result.HasValue)
            {
                return result.Value;
            }
            else
            {
                DateTime parseResult;
                if (DateTime.TryParse((string)value, out parseResult))
                    return parseResult;
            }

            return value;
        }
    }
}
