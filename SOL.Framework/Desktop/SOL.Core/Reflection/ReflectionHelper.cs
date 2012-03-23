using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;

namespace SOL.Reflection
{
    /// <summary>
    /// Provides a set of static methods for manipulating objects using expressions.
    /// </summary>
    public static class ReflectionHelper
    {
        private const string SELECTOR_MUSTBEPROP = "PropertySelector must select a property type.";

        /// <summary>
        /// Gets the name of the property specified by the expression.
        /// </summary>
        /// <typeparam name="T">The type to find the property.</typeparam>
        /// <param name="propertySelector">The expression specifying the property.</param>
        /// <returns>The name of the property.</returns>
        public static string GetPropertyName<T>(Expression<Func<T>> propertySelector)
        {
            var memberExpression = GetPropertyExpression(propertySelector);
            if (memberExpression != null)
                return memberExpression.Member.Name;

            return null;
        }

        /// <summary>
        /// Gets the property <see cref="Expression"/> specified by the property selector.
        /// </summary>
        /// <typeparam name="T">The type of the object on which to get the property expression.</typeparam>
        /// <param name="propertySelector">The property selector expression.</param>
        /// <returns>The <see cref="MemberExpression"/> for the property specified by the selector if found; otherwise, null.</returns>
        public static MemberExpression GetPropertyExpression<T>(Expression<Func<T>> propertySelector)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = propertySelector.Body as UnaryExpression;
                if (unaryExpression != null)
                    memberExpression = unaryExpression.Operand as MemberExpression;
            }

            if (memberExpression != null)
            {
                if (memberExpression.Member.MemberType != MemberTypes.Property)
                    throw new ArgumentNullException(SELECTOR_MUSTBEPROP, "propertySelector");

                return memberExpression;
            }

            return null;
        }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> specified by the property selector.
        /// </summary>
        /// <typeparam name="T">The type of the object on which to get the property information.</typeparam>
        /// <param name="propertySelector">The property selector expression.</param>
        /// <returns>The <see cref="PropertyInfo"/> for the property specified by the selector if found; otherwise, null.</returns>
        public static PropertyInfo GetPropertyInfo<T>(Expression<Func<T, object>> propertySelector)
        {
            var memberExpression = propertySelector.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = propertySelector.Body as UnaryExpression;
                if (unaryExpression != null)
                    memberExpression = unaryExpression.Operand as MemberExpression;
            }

            if (memberExpression != null)
            {
                if (memberExpression.Member.MemberType != MemberTypes.Property)
                    throw new ArgumentNullException(SELECTOR_MUSTBEPROP, "propertySelector");

                return memberExpression.Member as PropertyInfo;
            }

            return null;
        }
    }
}
