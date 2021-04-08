using System.Collections.Generic;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// An interface that represents a dialog
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Title
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Message
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Dialog type
        /// </summary>
        EDialogType DialogType { get; }

        /// <summary>
        /// Dialog buttons
        /// </summary>
        EDialogButtons DialogButtons { get; }

        /// <summary>
        /// Buttons
        /// </summary>
        IReadOnlyList<string> Buttons { get; }

        /// <summary>
        /// Gets invoked when dialog has responded
        /// </summary>
        DialogRespondedDelegate OnDialogResponded { get; }
    }
}
