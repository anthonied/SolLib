using System;

namespace SOL.Silverlight
{
    #region DialogButton

    /// <summary>
    /// Indicates the combination of buttons a dialog should display.
    /// </summary>
    public enum DialogButton
    {
        /// <summary>
        /// Dialog should display no buttons.
        /// </summary>
        None,

        /// <summary>
        /// Dialog should display OK button.
        /// </summary>
        OK,

        /// <summary>
        /// Dialog should display OK and Cancel buttons.
        /// </summary>
        OKCancel,

        /// <summary>
        /// Dialog should display Yes, No and Cancel buttons.
        /// </summary>
        YesNoCancel,

        /// <summary>
        /// Dialog should display Yes and No buttons.
        /// </summary>
        YesNo
    }

    #endregion

    #region DialogIcon

    /// <summary>
    /// Indicates the icon a message box dialog should display.
    /// </summary>
    public enum DialogIcon
    {
        /// <summary>
        /// The message dialog should display no symbol.
        /// </summary>
        None = 0,

        /// <summary>
        /// The message dialog should display a success symbol.
        /// </summary>
        Success,

        /// <summary>
        /// The message dialog should display an error symbol.
        /// </summary>
        Error,

        /// <summary>
        /// The message dialog should display a warning symbol.
        /// </summary>
        Warning,

        /// <summary>
        /// The message dialog should display an information symbol.
        /// </summary>
        Information,

        /// <summary>
        /// The message dialog should display a confirm symbol.
        /// </summary>
        Confirm
    }

    #endregion

    #region DialogResult

    /// <summary>
    /// Represents a user's respone to a dialog.
    /// </summary>
    public enum DialogResult
    {
        /// <summary>
        /// This value is not currently used.
        /// </summary>
        None = 0,

        /// <summary>
        /// The dialog was closed with OK.
        /// </summary>
        OK,

        /// <summary>
        /// The dialog was canceled.
        /// </summary>
        Cancel,

        /// <summary>
        /// The dialog was closed with Yes.
        /// </summary>
        Yes,

        /// <summary>
        /// The dialog was closed with No.
        /// </summary>
        No,
    } 

    #endregion
}
