using Models;
using TMPro;
using UnityEngine;

namespace SubViews
{
    public class HealthSubView : HudSubView<HealthModel>
    {
        [SerializeField] private TMP_Text _healthText;

        protected override void OnInitialized()
        {
            RefreshVisual();
        }

        protected override void RefreshVisual()
        {
            _healthText.text = $"Health: {Model.Health}/{Model.MaxHealth}";
        }
    }
}