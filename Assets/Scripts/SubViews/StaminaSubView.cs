using Models;
using TMPro;
using UnityEngine;

namespace SubViews
{
    public class StaminaSubView : BaseHudSubView<StaminaModel>
    {
        [SerializeField] private TMP_Text _staminaText;

        protected override void OnInitialized() => RefreshVisual();

        protected override void RefreshVisual()
        {
            _staminaText.text = $"Stamina: {Model.Stamina}/{Model.MaxStamina}";
        }
    }
}