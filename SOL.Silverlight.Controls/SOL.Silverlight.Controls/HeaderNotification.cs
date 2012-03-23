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

namespace SOL.Silverlight.Controls
{
    [TemplatePart(Name = "NotificationTextPart", Type = typeof(TextBlock))]
    public class HeaderNotification : Control
    {
        #region Attributes

        private TextBlock _textPart;

        #endregion

        #region Attributes

        public HeaderNotification()
        {
            this.DefaultStyleKey = typeof(HeaderNotification);
        }

        #endregion

        #region Properties

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(HeaderNotification), new PropertyMetadata("Pending changes exists! Some functionality might be disabled until changes have been saved."));

        #endregion

        #region Members

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this._textPart = GetTemplateChild("NotificationTextPart") as TextBlock;
        }

        #endregion
    }
}
