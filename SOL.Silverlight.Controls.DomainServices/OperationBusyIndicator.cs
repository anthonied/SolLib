using System;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;


namespace SOL.Silverlight.Controls.Domain
{
    public class OperationBusyIndicator : BusyIndicator
    {
        #region Constructors

        public OperationBusyIndicator()
        {
            this.DefaultStyleKey = typeof(OperationBusyIndicator);
        }

        #endregion

        #region Properties

        public OperationBase Operation
        {
            get { return (OperationBase)GetValue(OperationProperty); }
            set { SetValue(OperationProperty, value); }
        }

        public static readonly DependencyProperty OperationProperty = DependencyProperty.Register("Operation", typeof(OperationBase), typeof(OperationBusyIndicator), new PropertyMetadata(OnOperationPropertyChanged));

        public string OperationMessage
        {
            get { return (string)GetValue(OperationMessageProperty); }
            set { SetValue(OperationMessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OperationMessage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OperationMessageProperty =
            DependencyProperty.Register("OperationMessage", typeof(string), typeof(OperationBusyIndicator), new PropertyMetadata(null));

        #endregion

        #region Static Members

        private static void OnOperationPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((OperationBusyIndicator)o).OnOperationPropertyChanged((OperationBase)e.OldValue, (OperationBase)e.NewValue);
        }

        #endregion

        #region Members

        private void OnOperationPropertyChanged(OperationBase oldOperation, OperationBase newOperation)
        {
            if (oldOperation != null)
            {
                oldOperation.Completed -= OnOperationCompleted;
                this.IsBusy = false;
            }

            if (newOperation != null)
            {
                newOperation.Completed += OnOperationCompleted;
                SetOperationMessage(newOperation.GetType());
                this.IsBusy = true;
            }
        }

        private void OnOperationCompleted(object sender, EventArgs e)
        {
            OperationBase operation = (OperationBase)sender;

            this.IsBusy = false;
            operation.Completed -= OnOperationCompleted;

            if (operation.HasError && (operation.IsErrorHandled == false))
            {
                ErrorWindow errorWin = new ErrorWindow(operation.Error);
                errorWin.Show();
                operation.MarkErrorAsHandled();
            }
        }

        private void SetOperationMessage(Type operationType)
        {
            if (String.IsNullOrEmpty(this.OperationMessage))
            {
                Type genericTypeDefinition = null;
                if (operationType.IsGenericType)
                    genericTypeDefinition = operationType.GetGenericTypeDefinition();

                if (operationType == typeof(LoadOperation) || genericTypeDefinition == typeof(LoadOperation<>))
                    this.BusyContent = Globals.Messages.LOADING_DATA;
                else if (operationType == typeof(SubmitOperation))
                    this.BusyContent = Globals.Messages.SAVING_CHANGES;
                else if (operationType == typeof(InvokeOperation) || genericTypeDefinition == typeof(InvokeOperation<>))
                    this.BusyContent = Globals.Messages.PROCESSING;
                else
                    this.BusyContent = Globals.Messages.PROCESSING;
            }
            else
            {
                this.BusyContent = this.OperationMessage;
            }
        }

        #endregion
    }
}
