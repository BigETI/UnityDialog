/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// Used to signal when an error dialog has been shown
    /// </summary>
    /// <param name="title">Dialog title</param>
    /// <param name="message">Dialog message</param>
    public delegate void ErrorDialogShownDelegate(string title, string message);
}
