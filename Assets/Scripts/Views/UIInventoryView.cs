using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIInventoryView : BaseView<UIInventoryView>
    {
        [SerializeField] private Button _nextItemButton;
        [SerializeField] private Button _prevItemButton;
        [SerializeField] private Button _useItemButton;
        
        [SerializeField] private TMP_Text _itemDescriptionText;
        [SerializeField] private TMP_Text _coinsText;

        private readonly string[] ItemsNames = new[] { "Wooden Sword", "Health Potion", "Golden Shield" };
        private readonly string[] ItemsDescriptions = new[] { "Attack +5", "Restores 50 HP", "Defense +20" };

        private int _currentItemIndex;
        private int _playerCoins = 150;

        protected override void OnInitialized()
        {
            _nextItemButton.onClick.AddListener(OnNextItemClick);
            _prevItemButton.onClick.AddListener(OnPrevItemClick);
            _useItemButton.onClick.AddListener(OnUseItemClick);

            UpdateVisuals();
        }

        protected override void OnDisposed()
        {
            _nextItemButton.onClick.RemoveListener(OnNextItemClick);
            _prevItemButton.onClick.RemoveListener(OnPrevItemClick);
            _useItemButton.onClick.RemoveListener(OnUseItemClick);
        }

        private void OnNextItemClick()
        {
            _currentItemIndex = (_currentItemIndex + 1) % ItemsNames.Length;
            UpdateVisuals();
        }

        private void OnPrevItemClick()
        {
            _currentItemIndex = (_currentItemIndex - 1 + ItemsNames.Length) % ItemsNames.Length;
            UpdateVisuals();
        }

        private void OnUseItemClick()
        {
            if (_currentItemIndex == 1 && _playerCoins >= 20)
            {
                _playerCoins -= 20;
            }
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            _itemDescriptionText.text = $"{ItemsDescriptions[_currentItemIndex]}" +
                                        $"{ItemsNames[_currentItemIndex]}";
            
            _coinsText.text = $"{_playerCoins} GP";
        }
    }
}