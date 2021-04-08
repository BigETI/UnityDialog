using System;
using System.Collections.Generic;
using UnityDialog.Managers;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// A class that describes dialogs
    /// </summary>
    public static class Dialogs
    {
        /// <summary>
        /// OK string
        /// </summary>
        public static string OKString =>
            (DialogManagerScript.Instance && DialogManagerScript.Instance.OKStringTranslation) ? DialogManagerScript.Instance.OKStringTranslation.ToString() : "OK";

        /// <summary>
        /// Cancel string
        /// </summary>
        public static string CancelString =>
            (DialogManagerScript.Instance && DialogManagerScript.Instance.CancelStringTranslation) ? DialogManagerScript.Instance.CancelStringTranslation.ToString() : "Cancel";

        /// <summary>
        /// Yes string
        /// </summary>
        public static string YesString =>
            (DialogManagerScript.Instance && DialogManagerScript.Instance.YesStringTranslation) ? DialogManagerScript.Instance.YesStringTranslation.ToString() : "Yes";

        /// <summary>
        /// No string
        /// </summary>
        public static string NoString =>
            (DialogManagerScript.Instance && DialogManagerScript.Instance.NoStringTranslation) ? DialogManagerScript.Instance.NoStringTranslation.ToString() : "No";

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        /// <param name="onDialogResponse">On dialog response</param>
        public static void Show(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons, DialogRespondedDelegate onDialogResponse)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            DialogManagerScript dialog_manager = DialogManagerScript.Instance;
            if (dialog_manager != null)
            {
                dialog_manager.Show(new Dialog(title, message, dialogType, dialogButtons, null, onDialogResponse));
            }
        }

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        public static void Show(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons) =>
            Show(title, message, dialogType, dialogButtons, null);

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="onDialogResponse">On dialog response</param>
        public static void Show(string title, string message, EDialogType dialogType, IReadOnlyList<string> buttons, DialogRespondedDelegate onDialogResponse)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }
            if (buttons != null)
            {
                throw new ArgumentNullException(nameof(buttons));
            }
            DialogManagerScript dialog_manager = DialogManagerScript.Instance;
            if (dialog_manager != null)
            {
                dialog_manager.Show(new Dialog(title, message, dialogType, EDialogButtons.Custom, buttons, onDialogResponse));
            }
        }

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog type</param>
        /// <param name="buttons">Buttons</param>
        public static void Show(string title, string message, EDialogType dialogType, IReadOnlyList<string> buttons) =>
            Show(title, message, dialogType, buttons, null);
    }
}
