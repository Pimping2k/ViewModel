using System;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HealthView : BaseView<HealthModel>
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private Button _damageButton;

        protected override void OnShown()
        {
            Model.HealthChanged += Refresh;
            _damageButton.onClick.AddListener(OnDamageClick);
        }

        protected override void OnHidden()
        {
            Model.HealthChanged -= Refresh;
            _damageButton.onClick.RemoveListener(OnDamageClick);
        }

        private void OnDamageClick()
        {
            Model.ChangeHealth(Mathf.Max(0, Model.Health - 10));
        }

        public override void Refresh()
        {
            _healthText.text = $"{Model.Health}/{Model.MaxHealth}";
        }
    }
}