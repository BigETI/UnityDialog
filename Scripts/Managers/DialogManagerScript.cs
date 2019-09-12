using System.Collections.Generic;
using UnityDialog.Data;
using UnityEngine;
using UnityTranslator.Objects;

/// <summary>
/// Unity dialog managers namespace
/// </summary>
namespace UnityDialog.Managers
{
    /// <summary>
    /// Dialog manager script class
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class DialogManagerScript : MonoBehaviour
    {
        /// <summary>
        /// OK translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript okTranslation = default;

        /// <summary>
        /// Cancel translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript cancelTranslation = default;

        /// <summary>
        /// Yes translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript yesTranslation = default;

        /// <summary>
        /// No translation
        /// </summary>
        [SerializeField]
        private TranslationObjectScript noTranslation = default;

        /// <summary>
        /// Dialog panel asset
        /// </summary>
        [SerializeField]
        private GameObject dialogPanelAsset = default;

        /// <summary>
        /// Rectangle transform
        /// </summary>
        private RectTransform rectTransform;

        /// <summary>
        /// Dialog stack
        /// </summary>
        private Stack<DialogData> dialogStack = new Stack<DialogData>();

        /// <summary>
        /// OK translation
        /// </summary>
        public TranslationObjectScript OKTranslation => okTranslation;

        /// <summary>
        /// Cancel translation
        /// </summary>
        public TranslationObjectScript CancelTranslation => cancelTranslation;

        /// <summary>
        /// Yes translation
        /// </summary>
        public TranslationObjectScript YesTranslation => yesTranslation;

        /// <summary>
        /// No translation
        /// </summary>
        public TranslationObjectScript NoTranslation => noTranslation;

        /// <summary>
        /// Instance
        /// </summary>
        public static DialogManagerScript Instance { get; private set; }

        /// <summary>
        /// Awake
        /// </summary>
        private void Awake()
        {
            if (Instance == null)
            {
                DontDestroyOnLoad(gameObject);
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
        }

        /// <summary>
        /// Current dialog panel object
        /// </summary>
        private GameObject currentDialogPanelObject;

        /// <summary>
        /// Update visuals
        /// </summary>
        public void UpdateVisuals()
        {
            if (currentDialogPanelObject != null)
            {
                Destroy(currentDialogPanelObject);
                currentDialogPanelObject = null;
            }
            if ((dialogPanelAsset != null) && (dialogStack.Count > 0))
            {
                DialogData dialog_data = dialogStack.Peek();
                GameObject go = Instantiate(dialogPanelAsset);
                if (go != null)
                {
                    RectTransform rect_transform = go.GetComponent<RectTransform>();
                    ADialogUIControllerScript dialog_ui_controller = go.GetComponent<ADialogUIControllerScript>();
                    if ((rect_transform != null) && (dialog_ui_controller != null))
                    {
                        dialog_ui_controller.FillValues(dialog_data);
                        rect_transform.SetParent(rectTransform, false);
                        currentDialogPanelObject = go;
                    }
                    else
                    {
                        Destroy(go);
                    }
                }
            }
        }

        /// <summary>
        /// Show dialog
        /// </summary>
        /// <param name="dialogData">Dialog data</param>
        public void Show(DialogData dialogData)
        {
            dialogStack.Push(dialogData);
            UpdateVisuals();
        }

        /// <summary>
        /// Pop last dialog
        /// </summary>
        public void PopLastDialog()
        {
            if (dialogStack.Count > 0)
            {
                dialogStack.Pop();
            }
            UpdateVisuals();
        }
    }
}
