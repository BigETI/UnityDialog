using UnityEngine.UI;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// An interface that represents a base dialog button controller
    /// </summary>
    public interface IDialogButtonController
    {
        /// <summary>
        /// Button
        /// </summary>
        Button Button { get; set; }

        /// <summary>
        /// Button index
        /// </summary>
        uint ButtonIndex { get; }

        /// <summary>
        /// Dialog UI controller
        /// </summary>
        DialogUIControllerScript DialogUIController { get; }

        /// <summary>
        /// Gets invoked when text has been updated
        /// </summary>
        event DialogButtonTextUpdatedDelegate OnDialogButtonTextUpdated;

        /// <summary>
        /// Fill values
        /// </summary>
        /// <param name="dialogUIController">Dialog UI controller</param>
        /// <param name="buttonIndex">Button index</param>
        /// <param name="text">Text</param>
        void FillValues(DialogUIControllerScript dialogUIController, uint buttonIndex, string text);
    }
}
