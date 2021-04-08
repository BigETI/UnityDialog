using System;
using System.Collections.Generic;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// A structure that describes a dialog
    /// </summary>
    internal readonly struct Dialog : IDialog
    {
        /// <summary>
        /// Title
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Dialog type
        /// </summary>
        public EDialogType DialogType { get; }

        /// <summary>
        /// Dialog buttons
        /// </summary>
        public EDialogButtons DialogButtons { get; }

        /// <summary>
        /// Buttons
        /// </summary>
        public IReadOnlyList<string> Buttons { get; }

        /// <summary>
        /// Gets invoked when dialog has responded
        /// </summary>
        public DialogRespondedDelegate OnDialogResponded { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="message">Message</param>
        /// <param name="dialogType">Dialog tyoe</param>
        /// <param name="dialogButtons">Dialog buttons</param>
        /// <param name="buttons">Buttons</param>
        /// <param name="onDialogResponded">On dialog responded</param>
        internal Dialog(string title, string message, EDialogType dialogType, EDialogButtons dialogButtons, IReadOnlyList<string> buttons, DialogRespondedDelegate onDialogResponded)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Message = message ?? throw new ArgumentNullException(nameof(message));
            DialogType = dialogType;
            DialogButtons = dialogButtons;
            Buttons = DialogButtons switch
            {
                EDialogButtons.OKCancel => new string[] { Dialogs.OKString, Dialogs.CancelString },
                EDialogButtons.YesNo => new string[] { Dialogs.YesString, Dialogs.NoString },
                EDialogButtons.YesNoCancel => new string[] { Dialogs.YesString, Dialogs.NoString, Dialogs.CancelString },
                EDialogButtons.OK => new string[] { Dialogs.OKString },
                EDialogButtons.Custom => buttons ?? throw new ArgumentNullException(nameof(buttons)),
                _ => throw new NotImplementedException()
            };
            OnDialogResponded = onDialogResponded;
        }
    }
}
