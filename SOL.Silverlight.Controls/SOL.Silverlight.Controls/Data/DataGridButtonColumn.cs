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
using System.ComponentModel;
using System.Windows.Data;

namespace SOL.Silverlight.Controls.Data
{
    public class DataGridButtonColumn : DataGridColumn
    {
        #region Constructors

        public DataGridButtonColumn()
        {
            base.IsReadOnly = true;
        }

        #endregion

        #region Properties

        [Category("Common")]
        public Binding CommandBinding { get; set; }

        [Category("Common")]
        public Binding CommandParameterBinding { get; set; }

        [Category("Common")]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        [Category("Common")]
        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        [Category("Common")]
        public string ToolTip { get; set; }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(DataGridButtonColumn), new PropertyMetadata(String.Empty));

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(DataGridButtonColumn), new PropertyMetadata(null));

        #endregion

        #region Members

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            ImageButton button = new ImageButton();
            button.Content = this.Text;
            button.ImageSource = this.ImageSource;

            if (this.CommandBinding != null)
                button.SetBinding(Button.CommandProperty, this.CommandBinding);

            if (this.CommandParameterBinding != null)
                button.SetBinding(Button.CommandParameterProperty, this.CommandParameterBinding);

            if (!String.IsNullOrEmpty(this.ToolTip))
                ToolTipService.SetToolTip(button, this.ToolTip);

            return button;
        }

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            return null;
        }

        protected override object PrepareCellForEdit(FrameworkElement editingElement, RoutedEventArgs editingEventArgs)
        {
            return null;
        }

        #endregion

    }
}
