using System;
using System.Windows;
using System.Windows.Controls;

namespace SOL.Silverlight
{
    public partial class DialogWindow : ChildWindow
    {
        #region Attributes

        private Func<DialogResult, bool> _closingHandler;
        private DialogResult _result;
        private bool _internalClose;

        #endregion

        #region Constructors

        public DialogWindow(string title, Control contentControl, DialogButton buttons, Func<DialogResult, bool> closingHandler = null)
        {
            InitializeComponent();

            // Validate
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
            if (contentControl == null)
                throw new ArgumentNullException("contentControl");

            // Set values
            this.Title = title;
            contentPlaceholder.Child = contentControl;
            this._closingHandler = closingHandler;

            // Set button states
            if (buttons == DialogButton.None)
            {
                spButtons.Visibility = Visibility.Collapsed;
            }
            else
            {
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
            }
        }

        #endregion

        #region Members

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.Cancel;
            CloseInternal();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.OK;
            CloseInternal();
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.Yes;
            CloseInternal();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            this._result = SOL.Silverlight.DialogResult.No;
            CloseInternal();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);

            if (this._internalClose)
            {
                if (this._closingHandler != null)
                    e.Cancel = !this._closingHandler(this._result);

                this._internalClose = false;
            }
        }

        private void CloseInternal()
        {
            this._internalClose = true;
            base.Close();
        }

        /// <summary>
        /// Closes the dialog.
        /// </summary>
        public new void Close()
        {
            this._internalClose = false;
            base.Close();
        }
                
        #endregion

        #region Static Members

        /// <summary>
        /// Displays a dialog window with the specified title, content and buttons.
        /// </summary>
        /// <param name="title">The title of the dialog.</param>
        /// <param name="contentControl">The content of the dialog.</param>
        /// <param name="buttons">The buttons to display.</param>
        /// <param name="closingHandler">The handler to call when the dialog is closing. The handler should return true if the dialog can be closed; otherwise false.</param>
        /// <returns>The dialog instance that is created and shown.</returns>
        public static DialogWindow Show(string title, Control contentControl, DialogButton buttons, Func<DialogResult, bool> closingHandler = null)
        {
            DialogWindow dialog = new DialogWindow(title, contentControl, buttons, closingHandler);
            dialog.Show();
            return dialog;
        }

        #endregion
    }
}
