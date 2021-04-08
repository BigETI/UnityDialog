using System.Collections.Generic;
using UnityEngine;
using UnityTranslator.Objects;

/// <summary>
/// Unity dialog namespace
/// </summary>
namespace UnityDialog
{
    /// <summary>
    /// An interface that represents a dialog manager
    /// </summary>
    public interface IDialogManager
    {
        /// <summary>
        /// OK string translation
        /// </summary>
        StringTranslationObjectScript OKStringTranslation { get; set; }

        /// <summary>
        /// Cancel string translation
        /// </summary>
        StringTranslationObjectScript CancelStringTranslation { get; set; }

        /// <summary>
        /// Yes string translation
        /// </summary>
        StringTranslationObjectScript YesStringTranslation { get; set; }

        /// <summary>
        /// No string translation
        /// </summary>
        StringTranslationObjectScript NoStringTranslation { get; set; }

        /// <summary>
        /// Dialog stack
        /// </summary>
        IReadOnlyCollection<IDialog> DialogStack { get; }

        /// <summary>
        /// Rectangle transform
        /// </summary>
        RectTransform RectangleTransform { get; }

        /// <summary>
        /// Updates visuals
        /// </summary>
        void UpdateVisuals();

        /// <summary>
        /// Shows dialog
        /// </summary>
        /// <param name="dialog">Dialog</param>
        void Show(IDialog dialog);

        /// <summary>
        /// Pops last dialog
        /// </summary>
        void PopLastDialog();
    }
}
