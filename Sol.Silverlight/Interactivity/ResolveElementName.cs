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
using System.Windows.Interactivity;
using System.Windows.Data;

namespace SOL.Silverlight.Interactivity
{
    public class ResolveElementName : TargetedTriggerAction<FrameworkElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            Target.Loaded += Target_Loaded;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            Target.Loaded -= Target_Loaded;
        }

        private void Target_Loaded(object sender, RoutedEventArgs e)
        {
            if (Target != null)
            {
                var fields = Target.GetType().GetFields(
                    System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.FlattenHierarchy |
                    System.Reflection.BindingFlags.Static);

                foreach (var field in fields)
                {
                    if (field.FieldType == typeof(DependencyProperty) &&
                        (field.Name == PropertyName ||
                        field.Name == string.Concat(PropertyName, "Property")))
                    {
                        DependencyProperty dp = field.GetValue(Target) as DependencyProperty;
                        var binding = Target.GetBindingExpression(dp);
                        string elementName = binding.ParentBinding.ElementName;
                        if (!string.IsNullOrEmpty(elementName))
                        {
                            DependencyObject boundToElement = GetElementBasedOnName(Target, elementName);
                            if (boundToElement != null)
                            {
                                Binding newBinding = new Binding();
                                Binding oldBinding = binding.ParentBinding;
                                newBinding.BindsDirectlyToSource = oldBinding.BindsDirectlyToSource;
                                newBinding.Converter = oldBinding.Converter;
                                newBinding.ConverterCulture = oldBinding.ConverterCulture;
                                newBinding.ConverterParameter = oldBinding.ConverterParameter;
                                newBinding.FallbackValue = oldBinding.FallbackValue;
                                newBinding.Mode = oldBinding.Mode;
                                newBinding.NotifyOnValidationError = oldBinding.NotifyOnValidationError;
                                newBinding.Path = oldBinding.Path;
                                newBinding.Source = boundToElement;
                                newBinding.StringFormat = oldBinding.StringFormat;
                                newBinding.TargetNullValue = oldBinding.TargetNullValue;
                                newBinding.UpdateSourceTrigger = oldBinding.UpdateSourceTrigger;
                                newBinding.ValidatesOnDataErrors = oldBinding.ValidatesOnDataErrors;
                                newBinding.ValidatesOnExceptions = oldBinding.ValidatesOnExceptions;
                                newBinding.ValidatesOnNotifyDataErrors = oldBinding.ValidatesOnNotifyDataErrors;
                                if (Target is ComboBox)
                                {
                                    ComboBox combo = Target as ComboBox;
                                    combo.SetBinding(dp, newBinding);
                                    combo.SetBinding(ComboBox.SelectedValueProperty, combo.GetBindingExpression(ComboBox.SelectedValueProperty).ParentBinding);
                                }
                                else
                                {
                                    Target.SetBinding(dp, newBinding);
                                }

                            }
                        }
                    }
                }
            }
        }

        private static DependencyObject GetElementBasedOnName(DependencyObject startPoint, string elementName)
        {
            DependencyObject returnValue = null;
            if (startPoint != null)
            {
                DependencyObject parent = VisualTreeHelper.GetParent(startPoint);
                if (parent != null)
                {
                    FrameworkElement fe = parent as FrameworkElement;
                    if (fe != null)
                    {
                        if (fe.Name == elementName)
                        {
                            returnValue = fe;
                        }
                        else
                        {
                            returnValue = GetElementBasedOnName(fe, elementName);
                        }
                    }
                    else
                    {
                        returnValue = GetElementBasedOnName(fe, elementName);
                    }
                }
            }
            return returnValue;
        }

        public string PropertyName
        {
            get { return (string)GetValue(PropertyNameProperty); }
            set { SetValue(PropertyNameProperty, value); }
        }

        public static readonly DependencyProperty PropertyNameProperty =
            DependencyProperty.Register("PropertyName", typeof(string), typeof(ResolveElementName), new PropertyMetadata(string.Empty));

        protected override void Invoke(object parameter)
        {
            // do nothing
        }
    }
}
