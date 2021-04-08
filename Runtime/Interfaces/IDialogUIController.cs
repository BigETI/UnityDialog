using UnityEngine;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// An interface that represents a dialog UI controller
    /// </summary>
    public interface IDialogUIController
    {
        /// <summary>
        /// Dialog button asset
        /// </summary>
        GameObject DialogButtonAsset { get; set; }

        /// <summary>
        /// Dialog buttons panel rectangle transform
        /// </summary>
        RectTransform DialogButtonsPanelRectangleTransform { get; set; }

        /// <summary>
        /// Dialog
        /// </summary>
        IDialog Dialog { get; }

#if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// Is pressing escape key
        /// </summary>
        bool IsPressingEscapeKey { get; }
#endif

        /// <summary>
        /// Gets invoked when dialog title has been updated
        /// </summary>
        event DialogTitleUpdatedDelegate OnDialogTitleUpdated;

        /// <summary>
        /// Gets invoked when dialog message has been updated
        /// </summary>
        event DialogMessageUpdatedDelegate OnDialogMessageUpdated;

        /// <summary>
        /// Gets invoked when an information dialog has been shown
        /// </summary>
        event InformationDialogShownDelegate OnInformationDialogShown;

        /// <summary>
        /// Gets invoked when a warning dialog has been shown
        /// </summary>
        event WarningDialogShownDelegate OnWarningDialogShown;

        /// <summary>
        /// Gets invoked when an error dialog has been shown
        /// </summary>
        event ErrorDialogShownDelegate OnErrorDialogShown;

        /// <summary>
        /// Gets invoked when a dialog has responded
        /// </summary>
        event DialogRespondedDelegate OnDialogResponded;

        /// <summary>
        /// Fills values
        /// </summary>
        /// <param name="dialogData">Dialog data</param>
        void FillValues(IDialog dialogData);

        /// <summary>
        /// Dialog responds
        /// </summary>
        /// <param name="selectedButtonIndex">Selected button index</param>
        void Respond(int selectedButtonIndex);
    }
}
