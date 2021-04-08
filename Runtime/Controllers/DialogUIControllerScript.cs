using System;
using UnityDialog.Controllers;
using UnityDialog.Managers;
using UnityEngine;
using UnityEngine.Events;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// A class that describes a dialog UI controller script
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class DialogUIControllerScript : MonoBehaviour, IDialogUIController
    {
        /// <summary>
        /// Dialog button asset
        /// </summary>
        [SerializeField]
        private GameObject dialogButtonAsset = default;

        /// <summary>
        /// Dialog buttons panel rectangle transform
        /// </summary>
        [SerializeField]
        private RectTransform dialogButtonsPanelRectangleTransform = default;

        /// <summary>
        /// Gets invoked when dialog title has been updated
        /// </summary>
        [SerializeField]
        private UnityEvent<string> onDialogTitleUpdated = default;

        /// <summary>
        /// Gets invoked when dialog message has been updated
        /// </summary>
        [SerializeField]
        private UnityEvent<string> onDialogMessageUpdated = default;

        /// <summary>
        /// Gets invoked when an information dialog has been shown
        /// </summary>
        [SerializeField]
        private UnityEvent onInformationDialogShown = default;

        /// <summary>
        /// Gets invoked when a warning dialog has been shown
        /// </summary>
        [SerializeField]
        private UnityEvent onWarningDialogShown = default;

        /// <summary>
        /// Gets invoked when an error dialog has been shown
        /// </summary>
        [SerializeField]
        private UnityEvent onErrorDialogShown = default;

        /// <summary>
        /// Gets invoked when a dialog has responded
        /// </summary>
        [SerializeField]
        private UnityEvent onDialogResponded = default;

        /// <summary>
        /// Dialog button asset
        /// </summary>
        public GameObject DialogButtonAsset
        {
            get => dialogButtonAsset;
            set => dialogButtonAsset = value;
        }

        /// <summary>
        /// Dialog buttons panel rectangle transform
        /// </summary>
        public RectTransform DialogButtonsPanelRectangleTransform
        {
            get => dialogButtonsPanelRectangleTransform;
            set => dialogButtonsPanelRectangleTransform = value;
        }

        /// <summary>
        /// Dialog
        /// </summary>
        public IDialog Dialog { get; private set; }

#if ENABLE_INPUT_SYSTEM
        /// <summary>
        /// Is pressing escape key
        /// </summary>
        public bool IsPressingEscapeKey { get; private set; }
#endif

        /// <summary>
        /// Gets invoked when dialog title has been updated
        /// </summary>
        public event DialogTitleUpdatedDelegate OnDialogTitleUpdated;

        /// <summary>
        /// Gets invoked when dialog message has been updated
        /// </summary>
        public event DialogMessageUpdatedDelegate OnDialogMessageUpdated;

        /// <summary>
        /// Gets invoked when an information dialog has been shown
        /// </summary>
        public event InformationDialogShownDelegate OnInformationDialogShown;

        /// <summary>
        /// Gets invoked when a warning dialog has been shown
        /// </summary>
        public event WarningDialogShownDelegate OnWarningDialogShown;

        /// <summary>
        /// Gets invoked when an error dialog has been shown
        /// </summary>
        public event ErrorDialogShownDelegate OnErrorDialogShown;

        /// <summary>
        /// Gets invoked when a dialog has responded
        /// </summary>
        public event DialogRespondedDelegate OnDialogResponded;

        /// <summary>
        /// Fills values
        /// </summary>
        /// <param name="dialogData">Dialog data</param>
        public void FillValues(IDialog dialogData)
        {
            Dialog = dialogData ?? throw new ArgumentNullException(nameof(dialogData));
            if (onDialogTitleUpdated != null)
            {
                onDialogTitleUpdated.Invoke(dialogData.Title);
            }
            OnDialogTitleUpdated?.Invoke(dialogData.Title);
            if (onDialogMessageUpdated != null)
            {
                onDialogMessageUpdated.Invoke(dialogData.Message);
            }
            switch (dialogData.DialogType)
            {
                case EDialogType.Information:
                    if (onInformationDialogShown != null)
                    {
                        onInformationDialogShown.Invoke();
                    }
                    OnInformationDialogShown?.Invoke(dialogData.Title, dialogData.Message);
                    break;
                case EDialogType.Warning:
                    if (onWarningDialogShown != null)
                    {
                        onWarningDialogShown.Invoke();
                    }
                    OnWarningDialogShown?.Invoke(dialogData.Title, dialogData.Message);
                    break;
                case EDialogType.Error:
                    if (onErrorDialogShown != null)
                    {
                        onErrorDialogShown.Invoke();
                    }
                    OnErrorDialogShown?.Invoke(dialogData.Title, dialogData.Message);
                    break;
            }
            OnDialogMessageUpdated?.Invoke(dialogData.Message);
            if ((dialogButtonAsset != null) && (dialogButtonsPanelRectangleTransform != null))
            {
                for (int i = 0; i < dialogData.Buttons.Count; i++)
                {
                    string button = dialogData.Buttons[i];
                    GameObject dialog_button_game_object = Instantiate(dialogButtonAsset);
                    if (dialog_button_game_object != null)
                    {
                        if (dialog_button_game_object.TryGetComponent(out RectTransform dialog_button_rectangle_transform) && dialog_button_game_object.TryGetComponent(out DialogButtonControllerScript dialog_button_controller))
                        {
                            dialog_button_controller.FillValues(this, (uint)i, button);
                            dialog_button_rectangle_transform.SetParent(dialogButtonsPanelRectangleTransform, false);
                            if ((i == 0) && dialog_button_controller.Button)
                            {
                                dialog_button_controller.Button.Select();
                            }
                        }
                        else
                        {
                            Destroy(dialog_button_game_object);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Dialog responds
        /// </summary>
        /// <param name="selectedButtonIndex">Selected button index</param>
        public void Respond(int selectedButtonIndex)
        {
            DialogManagerScript dialog_manager = DialogManagerScript.Instance;
            if (dialog_manager != null)
            {
                dialog_manager.PopLastDialog();
            }
            else
            {
                Destroy(gameObject);
            }
            EDialogResponse dialog_response = EDialogResponse.None;
            switch (Dialog.DialogButtons)
            {
                case EDialogButtons.OK:
                    if (selectedButtonIndex == 0)
                    {
                        dialog_response = EDialogResponse.OK;
                    }
                    break;
                case EDialogButtons.OKCancel:
                    switch (selectedButtonIndex)
                    {
                        case 0:
                            dialog_response = EDialogResponse.OK;
                            break;
                        case 1:
                            dialog_response = EDialogResponse.Cancel;
                            break;
                    }
                    break;
                case EDialogButtons.YesNo:
                    switch (selectedButtonIndex)
                    {
                        case 0:
                            dialog_response = EDialogResponse.Yes;
                            break;
                        case 1:
                            dialog_response = EDialogResponse.No;
                            break;
                    }
                    break;
                case EDialogButtons.YesNoCancel:
                    switch (selectedButtonIndex)
                    {
                        case 0:
                            dialog_response = EDialogResponse.Yes;
                            break;
                        case 1:
                            dialog_response = EDialogResponse.No;
                            break;
                        case 2:
                            dialog_response = EDialogResponse.Cancel;
                            break;
                    }
                    break;
            }
            if (onDialogResponded != null)
            {
                onDialogResponded.Invoke();
            }
            OnDialogResponded?.Invoke(dialog_response, selectedButtonIndex);
            Dialog.OnDialogResponded?.Invoke(dialog_response, selectedButtonIndex);
        }

        /// <summary>
        /// Gets invoked when script has been validated
        /// </summary>
        protected virtual void OnValidate()
        {
            if (dialogButtonAsset && (!dialogButtonAsset.TryGetComponent(out DialogButtonControllerScript dialog_button_controller) || !dialog_button_controller.Button))
            {
                dialogButtonAsset = null;
            }
        }

        /// <summary>
        /// Gets invoked when script has been updated
        /// </summary>
        protected virtual void Update()
        {
#if ENABLE_INPUT_SYSTEM

            Keyboard keyboard = Keyboard.current;
            if ((keyboard != null) && keyboard.escapeKey.isPressed && IsPressingEscapeKey)
#else
            if (Input.GetKeyDown(KeyCode.Escape))
#endif
            {
                Respond(-1);
            }
#if ENABLE_INPUT_SYSTEM
            IsPressingEscapeKey = (keyboard != null) && keyboard.escapeKey.isPressed;
#endif
        }
    }
}
