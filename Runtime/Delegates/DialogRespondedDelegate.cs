/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// Used to signal when a dialog has responded
    /// </summary>
    /// <param name="dialogResponse">Dialog response</param>
    /// <param name="selectedButtonIndex">Selected button index</param>
    public delegate void DialogRespondedDelegate(EDialogResponse dialogResponse, int selectedButtonIndex);
}
