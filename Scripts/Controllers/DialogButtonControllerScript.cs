using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Unity dialog controllers namespace
/// </summary>
namespace UnityDialog.Controllers
{
    /// <summary>
    /// Dialog button controller script class
    /// </summary>
    public class DialogButtonControllerScript : ADialogButtonControllerScript
    {
        /// <summary>
        /// Button text
        /// </summary>
        [SerializeField]
        private Text buttonText = default;

        /// <summary>
        /// Update text
        /// </summary>
        /// <param name="buttonText">Button text</param>
        protected override void UpdateText(string buttonText)
        {
            if (this.buttonText != null)
            {
                this.buttonText.text = buttonText;
            }
        }
    }
}
