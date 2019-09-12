using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// Dialog button controller script abstract class
    /// </summary>
    public abstract class ADialogButtonControllerScript : MonoBehaviour
    {
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField]
        private Selectable button = default;

        /// <summary>
        /// Dialog UI controller
        /// </summary>
        private ADialogUIControllerScript dialogUIController;

        /// <summary>
        /// Button index
        /// </summary>
        private uint buttonIndex;

        /// <summary>
        /// Update text
        /// </summary>
        /// <param name="buttonText">Button Text</param>
        protected abstract void UpdateText(string buttonText);

        /// <summary>
        /// Fill values
        /// </summary>
        /// <param name="dialogUIController">Dialog UI controller</param>
        /// <param name="buttonIndex">Button index</param>
        /// <param name="text">Text</param>
        public void FillValues(ADialogUIControllerScript dialogUIController, uint buttonIndex, string text)
        {
            this.dialogUIController = dialogUIController;
            this.buttonIndex = buttonIndex;
            UpdateText((text == null) ? string.Empty : text);
        }

        /// <summary>
        /// Select
        /// </summary>
        public void Select()
        {
            if (button != null)
            {
                button.Select();
            }
        }

        /// <summary>
        /// Click
        /// </summary>
        public void Click()
        {
            if (dialogUIController != null)
            {
                dialogUIController.Respond((int)buttonIndex);
            }
        }
    }
}
