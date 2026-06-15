using Models;
using TMPro;
using UnityEngine;

namespace SubViews
{
    public class ManaSubView : BaseHudSubView<ManaModel>
    {
        [SerializeField] private TMP_Text _manaText;

        protected override void OnInitialized() => RefreshVisual();

        protected override void RefreshVisual()
        {
            _manaText.text = $"Mana: {Model.Mana}/{Model.MaxMana}";
        }
    }
}