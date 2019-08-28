/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// Dialog response event arguments class
    /// </summary>
    public class DialogResponseEventArguments
    {
        /// <summary>
        /// Dialog response
        /// </summary>
        public EDialogResponse DialogResponse { get; private set; }

        /// <summary>
        /// Selected button index
        /// </summary>
        public int SelectedButtonIndex { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dialogResponse">Dialog response</param>
        /// <param name="selectedButtonIndex">Selected button index</param>
        public DialogResponseEventArguments(EDialogResponse dialogResponse, int selectedButtonIndex)
        {
            DialogResponse = dialogResponse;
            SelectedButtonIndex = selectedButtonIndex;
        }
    }
}
