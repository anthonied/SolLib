using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;

namespace SOL.Silverlight.Converters
{
    public class ValueParameterMatchBooleanConverter : IValueConverter
    {
        #region Properties

        public bool Inverse { get; set; }

        #endregion

        #region Members
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            object convertedParameter = null;
            Type valueType = value.GetType();
            if (valueType.IsEnum)
                convertedParameter = Enum.Parse(valueType, (string)parameter, false);
            else
                convertedParameter = System.Convert.ChangeType(parameter, value.GetType(), null);

            bool result = value.Equals(convertedParameter);
            if (this.Inverse)
                return !result;
            else
                return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
            //if (!(value is bool))
            //    throw new ArgumentException("value", "ValueParameterMatchBooleanConverter can only convert from Boolean");

            //if (targetType == typeof(bool))
            //{
            //    bool result = (bool)value;
            //    if (this.Inverse)
            //        return !result;
            //    else
            //        return result;
            //}
            //else
            //{
            //    throw new ArgumentException("targetType", "ValueParameterMatchBooleanConverter can only convert to Boolean");
            //}
        }

        #endregion
    }
}
