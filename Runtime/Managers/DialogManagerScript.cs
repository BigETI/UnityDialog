using System;
using System.Collections.Generic;
using UnityEngine;
using UnityTranslator.Objects;

/// <summary>
/// Unity dialog managers namespace
/// </summary>
namespace UnityDialog.Managers
{
    /// <summary>
    /// A class that describes a dialog manager script
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class DialogManagerScript : MonoBehaviour, IDialogManager
    {
        /// <summary>
        /// OK translation
        /// </summary>
        [SerializeField]
        private StringTranslationObjectScript okStringTranslation = default;

        /// <summary>
        /// Cancel string translation
        /// </summary>
        [SerializeField]
        private StringTranslationObjectScript cancelStringTranslation = default;

        /// <summary>
        /// Yes string translation
        /// </summary>
        [SerializeField]
        private StringTranslationObjectScript yesStringTranslation = default;

        /// <summary>
        /// No string translation
        /// </summary>
        [SerializeField]
        private StringTranslationObjectScript noStringTranslation = default;

        /// <summary>
        /// Dialog panel asset
        /// </summary>
        [SerializeField]
        private GameObject dialogPanelAsset = default;

        /// <summary>
        /// Dialog stack
        /// </summary>
        private Stack<IDialog> dialogStack = new Stack<IDialog>();

        /// <summary>
        /// Current dialog panel object
        /// </summary>
        private GameObject currentDialogPanelObject;

        /// <summary>
        /// Instance
        /// </summary>
        public static DialogManagerScript Instance { get; private set; }

        /// <summary>
        /// OK string translation
        /// </summary>
        public StringTranslationObjectScript OKStringTranslation
        {
            get => okStringTranslation;
            set => okStringTranslation = value;
        }

        /// <summary>
        /// Cancel string translation
        /// </summary>
        public StringTranslationObjectScript CancelStringTranslation
        {
            get => cancelStringTranslation;
            set => cancelStringTranslation = value;
        }

        /// <summary>
        /// Yes string translation
        /// </summary>
        public StringTranslationObjectScript YesStringTranslation
        {
            get => yesStringTranslation;
            set => yesStringTranslation = value;
        }

        /// <summary>
        /// No string translation
        /// </summary>
        public StringTranslationObjectScript NoStringTranslation
        {
            get => noStringTranslation;
            set => noStringTranslation = value;
        }

        /// <summary>
        /// Dialog stack
        /// </summary>
        public IReadOnlyCollection<IDialog> DialogStack => dialogStack;

        /// <summary>
        /// Rectangle transform
        /// </summary>
        public RectTransform RectangleTransform { get; private set; }

        /// <summary>
        /// notifies if object is not available
        /// </summary>
        /// <param name="stringTranslation">String translation</param>
        /// <param name="name">Name</param>
        private void NotifyIfObjectIsNotAvailable(UnityEngine.Object obj, string name)
        {
            if (!obj)
            {
                Debug.LogError($"Please assign { name } to this component.", this);
            }
        }

        /// <summary>
        /// Updates visuals
        /// </summary>
        public void UpdateVisuals()
        {
            if (!RectangleTransform && TryGetComponent(out RectTransform rectangle_transform))
            {
                RectangleTransform = rectangle_transform;
            }
            if (currentDialogPanelObject != null)
            {
                Destroy(currentDialogPanelObject);
                currentDialogPanelObject = null;
            }
            if ((dialogPanelAsset != null) && (dialogStack.Count > 0))
            {
                IDialog dialog = dialogStack.Peek();
                GameObject dialog_panel_game_object = Instantiate(dialogPanelAsset);
                if (dialog_panel_game_object != null)
                {
                    if (dialog_panel_game_object.TryGetComponent(out RectTransform dialog_panel_rectangle_transform) && dialog_panel_game_object.TryGetComponent(out DialogUIControllerScript dialog_ui_controller))
                    {
                        dialog_ui_controller.FillValues(dialog);
                        dialog_panel_rectangle_transform.SetParent(RectangleTransform, false);
                        currentDialogPanelObject = dialog_panel_game_object;
                    }
                    else
                    {
                        Destroy(dialog_panel_game_object);
                    }
                }
            }
        }

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="dialog">Dialog</param>
        public void Show(IDialog dialog)
        {
            dialogStack.Push(dialog ?? throw new ArgumentNullException(nameof(dialog)));
            UpdateVisuals();
        }

        /// <summary>
        /// Pops last dialog
        /// </summary>
        public void PopLastDialog()
        {
            if (dialogStack.Count > 0)
            {
                dialogStack.Pop();
            }
            UpdateVisuals();
        }

        /// <summary>
        /// Gets invoked when script has been awaken
        /// </summary>
        protected virtual void Awake()
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
        /// Gets invoked when script has been started
        /// </summary>
        protected virtual void Start()
        {
            if (TryGetComponent(out RectTransform rectangle_transform))
            {
                RectangleTransform = rectangle_transform;
            }
            else
            {
                Debug.LogError($"Please assign a rectangle transform component to this game object.", this);
            }
            NotifyIfObjectIsNotAvailable(okStringTranslation, "an OK string translation");
            NotifyIfObjectIsNotAvailable(cancelStringTranslation, "a cancel string translation");
            NotifyIfObjectIsNotAvailable(yesStringTranslation, "a yes string translation");
            NotifyIfObjectIsNotAvailable(noStringTranslation, "a no string translation");
            NotifyIfObjectIsNotAvailable(dialogPanelAsset, "a dialog panel asset");
        }
    }
}
