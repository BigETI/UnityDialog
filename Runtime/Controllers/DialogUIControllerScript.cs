using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Unity dialog controllers namespace
/// </summary>
namespace UnityDialog.Controllers
{
    /// <summary>
    /// Dialog UI controller script
    /// </summary>
    public class DialogUIControllerScript : ADialogUIControllerScript
    {
        /// <summary>
        /// Title text
        /// </summary>
        [SerializeField]
        private Text titleText = default;

        /// <summary>
        /// Message text
        /// </summary>
        [SerializeField]
        private Text messageText = default;

        /// <summary>
        /// Update text
        /// </summary>
        /// <param name="titleText">Title text</param>
        /// <param name="titleTextColor">Title text color</param>
        /// <param name="messageText">Message text</param>
        protected override void UpdateText(string titleText, Color titleTextColor, string messageText)
        {
            if (this.titleText != null)
            {
                this.titleText.text = titleText;
                this.titleText.color = titleTextColor;
            }
            if (this.messageText != null)
            {
                this.messageText.text = messageText;
            }
        }
    }
}
