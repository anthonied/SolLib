using System;
using System.ComponentModel;
using System.Linq.Expressions;
using SOL.Reflection;


namespace SOL.Silverlight
{
    /// <remarks>
    /// - nRoute
    /// - ideas from http://michaelsync.net/2009/04/09/silverlightwpf-implementing-propertychanged-with-expression-tree
    /// </remarks>
    public static class PropertyChangedExtensions
    {
        //public static void Notify<T>(this Action<string> notifier, Expression<Func<T>> propertySelector)
        //{
        //    if (notifier != null)
        //        notifier(ReflectionHelper.GetPropertyName(propertySelector));
        //}

        public static void Notify<T>(this PropertyChangedEventHandler handler, Expression<Func<T>> propertySelector)
        {
            if (handler != null)
            {
                var memberExpression = ReflectionHelper.GetPropertyExpression(propertySelector);
                if (memberExpression != null)
                {
                    var sender = ((ConstantExpression)memberExpression.Expression).Value;
                    handler(sender, new PropertyChangedEventArgs(memberExpression.Member.Name));
                }
            }
        }
    }
}
