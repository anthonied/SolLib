using System;
using System.Windows;
using System.Windows.Data;
using System.ServiceModel.DomainServices.Client;
using System.Windows.Media;

namespace SOL.Silverlight.Converters
{
    public class EntityStateVisibilityConverter : IValueConverter
    {
        #region Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(Visibility))
                throw new ArgumentException("targetType", "EntityStateVisibilityConverter can only convert to Visibility");

            if (!(value is EntityState))
                throw new ArgumentException("value", "EntityStateVisibilityConverter can only convert from EntityState");

            if (parameter != null && !(parameter is EntityState))
                throw new ArgumentException("value", "EntityStateVisibilityConverter requires a parameter of type EntityState");

            EntityState entityState = (EntityState)value;
            if (parameter == null)
            {
                if (entityState == EntityState.New)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
            else
            {
                if (entityState == (EntityState)parameter)
                    return Visibility.Visible;
                else
                    return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
