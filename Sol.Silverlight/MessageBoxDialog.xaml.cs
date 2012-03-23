using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace SOL.Silverlight
{
    public partial class MessageBoxDialog : ChildWindow
    {
        #region Attributes

        private Action<DialogResult> _resultCallback;
        private DialogResult _result;

        #endregion

        #region Constructors

        private MessageBoxDialog(string title, string message, DialogButton buttons, DialogIcon icon, Action<DialogResult> resultCallback)
        {
            InitializeComponent();

            // Validate
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
            if (string.IsNullOrEmpty(message))
                throw new ArgumentNullException("message");

            // Set values
            this.Title = title;
            txtMessage.Text = message;
            this._resultCallback = resultCallback;

            // Set button states
            btnOk.Visibility = Visibility.Collapsed;
            btnYes.Visibility = Visibility.Collapsed;
            btnNo.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            switch (buttons)
            {
                case DialogButton.OK:
                    btnOk.Visibility = Visibility.Visible;
                    break;

                case DialogButton.OKCancel:
                    btnOk.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Visible;
                    break;

                case DialogButton.YesNo:
                    btnYes.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    break;

                case DialogButton.YesNoCancel:
                    btnYes.Visibility = Visibility.Visible;
                    btnNo.Visibility = Visibility.Visible;
                    btnCancel.Visibility = Visibility.Visible;
                    break;
            }

            // Set icon states
            imgSuccess.Visibility = Visibility.Collapsed;
            imgError.Visibility = Visibility.Collapsed;
            imgInfo.Visibility = Visibility.Collapsed;
            imgWarning.Visibility = Visibility.Collapsed;
            imgConfirm.Visibility = Visibility.Collapsed;
            switch (icon)
            {
                case DialogIcon.Success:
                    imgSuccess.Visibility = Visibility.Visible;
                    break;

                case DialogIcon.Error:
                    imgError.Visibility = Visibility.Visible;
                    break;

                case DialogIcon.Information:
                    imgInfo.Visibility = Visibility.Visible;
                    break;

                case DialogIcon.Warning:
                    imgWarning.Visibility = Visibility.Visible;
                    break;

                case DialogIcon.Confirm:
                    imgConfirm.Visibility = Visibility.Visible;
                    break;
            }

            // Hide detail items
            txtDetail.Visibility = System.Windows.Visibility.Collapsed;
            expandDetail.Visibility = System.Windows.Visibility.Collapsed;
        }

        private MessageBoxDialog(string title, string message, string detail, bool showDetailAsCollapsable, DialogButton buttons, DialogIcon icon, Action<DialogResult> resultCallback)
            : this(title, message, buttons, icon, resultCallback)
        {
            // Show detail message
            if (!String.IsNullOrEmpty(detail))
            {
                if (showDetailAsCollapsable)
                {
                    txtExpanderDetail.Text = detail;
                    expandDetail.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    txtDetail.Text = detail;
                    txtDetail.Visibility = Visibility.Visible;
                }
            }
        }

        #endregion

        #region Members

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.OK;
            this.Close();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.Yes;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.No;
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (this._resultCallback != null)
                this._resultCallback(this._result);
        }

        #endregion

        #region Static Members

        public static MessageBoxDialog Show(string title, string message, Action<DialogResult> resultCallback)
        {
            return Show(title, message, DialogButton.OK, resultCallback);
        }

        public static MessageBoxDialog Show(string title, string message, DialogButton buttons, Action<DialogResult> resultCallback)
        {
            return Show(title, message, buttons, DialogIcon.None, resultCallback);
        }

        public static MessageBoxDialog Show(string title, string message, DialogButton buttons, DialogIcon icon, Action<DialogResult> resultCallback)
        {
            MessageBoxDialog messageBoxDialog = new MessageBoxDialog(title, message, buttons, DialogIcon.None, resultCallback);
            messageBoxDialog.Show();
            return messageBoxDialog;
        }

        public static MessageBoxDialog Show(string title, string message, string detail, DialogButton buttons, Action<DialogResult> resultCallback)
        {
            return Show(title, message, detail, buttons, DialogIcon.None, resultCallback);
        }

        public static MessageBoxDialog Show(string title, string message, string detail, DialogButton buttons, DialogIcon icon, Action<DialogResult> resultCallback)
        {
            return Show(title, message, detail, false, buttons, icon, resultCallback);
        }

        public static MessageBoxDialog Show(string title, string message, string detail, bool showDetailAsCollapsable, DialogButton buttons, DialogIcon icon, Action<DialogResult> resultCallback)
        {
            MessageBoxDialog messageBoxDialog = new MessageBoxDialog(title, message, detail, showDetailAsCollapsable, buttons, icon, resultCallback);
            messageBoxDialog.Show();
            return messageBoxDialog;
        }

        #endregion
    }
}