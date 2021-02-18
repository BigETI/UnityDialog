using System;
using UnityEngine;

/// <summary>
/// Unity dialog data namespace
/// </summary>
namespace UnityDialog.Data
{
    /// <summary>
    /// Dialog data structure
    /// </summary>
    [Serializable]
    public struct DialogData
    {
        /// <summary>
        /// Title
        /// </summary>
        [SerializeField]
        private string title;

        /// <summary>
        /// Message
        /// </summary>
        [TextArea]
        [SerializeField]
        private string message;

        /// <summary>
        /// Buttons
        /// </summary>
        [SerializeField]
        private string[] buttons;

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get
            {
                if (title == null)
                {
                    title = string.Empty;
                }
                return title;
            }
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message
        {
            get
            {
                if (message == null)
                {
                    message = string.Empty;
                }
                return message;
            }
        }

        /// <summary>
        /// Dialog type
        /// </summary>
        public EDialogType DialogType { get; private set; }

        /// <summary>
        /// Dialog buttons
        /// </summary>
        public EDialogButtons DialogButtons { get; private set; }

        /// <summary>
        /// Buttons
        /// </summary>
        public string[] Buttons
        {
            get
            {
                if (buttons == null)
                {
                    switch (DialogButtons)
                    {
                        case EDialogButtons.OKCancel:
                            buttons = new string[] { Dialog.OKString, Dialog.CancelString };
                            break;
                        case EDialogButtons.YesNo:
                            buttons = new string[] { Dialog.YesString, Dialog.NoString };
                            break;
                        case EDialogButtons.YesNoCancel:
                            buttons = new string[] { Dialog.YesString, Dialog.NoString, Dialog.CancelString };
                            break;
                        default:
                            buttons = new string[] { Dialog.OKString };
                            break;
                    }
                }
                return buttons;
            }
        }

        /// <summary>
        /// On dialog response
        /// </summary>
        public DialogResponseDelegate OnDialogResponse { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog tyoe</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="onDialogResponse">On dialog response</param>
        public DialogData(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons, string[] buttons, DialogResponseDelegate onDialogResponse)
        {
            this.title = title;
            this.message = message;
            DialogType = dialogType;
            DialogButtons = dialogButtons;
            this.buttons = buttons;
            OnDialogResponse = onDialogResponse;
            if (dialogButtons != EDialogButtons.Custom)
            {
                this.buttons = null;
            }
        }
    }
}
