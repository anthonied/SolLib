using System;
using System.Linq.Expressions;
using System.Windows;
using System.ComponentModel;
using System.Reflection;

namespace SOL.Silverlight
{
    public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Members

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> propertySelector)
        {
            if (Deployment.Current.Dispatcher.CheckAccess())
                PropertyChanged.Notify<T>(propertySelector);
            else
                Deployment.Current.Dispatcher.BeginInvoke(() => PropertyChanged.Notify<T>(propertySelector));
        }

        protected void BeginInvoke(Action action)
        {
            if (Deployment.Current.Dispatcher.CheckAccess())
                action();
            else
                Deployment.Current.Dispatcher.BeginInvoke(action);
        }
        
        #endregion
    }
}
