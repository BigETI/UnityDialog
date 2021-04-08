using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Unity dialog controllers namespace
/// </summary>
namespace UnityDialog.Controllers
{
    /// <summary>
    /// A class that describes a dialog button controller script
    /// </summary>
    public class DialogButtonControllerScript : MonoBehaviour, IDialogButtonController
    {
        /// <summary>
        /// Button
        /// </summary>
        [SerializeField]
        private Button button = default;

        /// <summary>
        /// Gets invoked when dialog button text has been updated
        /// </summary>
        [SerializeField]
        private UnityEvent<string> onDialogButtonTextUpdated = default;

        /// <summary>
        /// Button
        /// </summary>
        public Button Button
        {
            get => button;
            set => button = value;
        }

        /// <summary>
        /// Button index
        /// </summary>
        public uint ButtonIndex { get; private set; }

        /// <summary>
        /// Dialog UI controller
        /// </summary>
        public DialogUIControllerScript DialogUIController { get; private set; }

        /// <summary>
        /// Gets invoked when dialog button text has been updated
        /// </summary>
        public event DialogButtonTextUpdatedDelegate OnDialogButtonTextUpdated;

        /// <summary>
        /// Gets invoked when user clicks on dialog button
        /// </summary>
        private void ClickEvent()
        {
            if (DialogUIController)
            {
                DialogUIController.Respond((int)ButtonIndex);
            }
        }

        /// <summary>
        /// Fills values
        /// </summary>
        /// <param name="dialogUIController">Dialog UI controller</param>
        /// <param name="buttonIndex">Button index</param>
        /// <param name="text">Text</param>
        public void FillValues(DialogUIControllerScript dialogUIController, uint buttonIndex, string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            DialogUIController = dialogUIController;
            ButtonIndex = buttonIndex;
            if (onDialogButtonTextUpdated != null)
            {
                onDialogButtonTextUpdated.Invoke(text);
            }
            OnDialogButtonTextUpdated?.Invoke(text);
        }

        /// <summary>
        /// Gets invoked when script gets enabled
        /// </summary>
        protected virtual void OnEnable()
        {
            if (button)
            {
                button.onClick.AddListener(ClickEvent);
            }
        }

        /// <summary>
        /// Gets invoked when script gets disabled
        /// </summary>
        protected virtual void OnDisable()
        {
            if (button)
            {
                button.onClick.RemoveListener(ClickEvent);
            }
        }

        /// <summary>
        /// Gets invoked when script has been started
        /// </summary>
        protected virtual void Start()
        {
            if (!button)
            {
                Debug.LogError("Please assign a button to this component.", this);
            }
        }
    }
}
