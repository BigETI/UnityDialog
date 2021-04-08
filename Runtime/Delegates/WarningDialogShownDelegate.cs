/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// Used to signal when a warning dialog has been shown
    /// </summary>
    /// <param name="title">Dialog title</param>
    /// <param name="message">Dialog message</param>
    public delegate void WarningDialogShownDelegate(string title, string message);
}
