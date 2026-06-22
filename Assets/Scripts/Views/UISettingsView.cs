using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UISettingsView : BaseView<UISettingsView>
    {
        [Header("Global Preset Buttons")]
        [SerializeField] private Button _globalSettingsLeftButton;
        [SerializeField] private Button _globalSettingsRightButton;
        [SerializeField] private TMP_Text _globalPresetText;

        [Header("Texture Buttons")]
        [SerializeField] private Button _textureLeftButton;
        [SerializeField] private Button _textureRightButton;
        [SerializeField] private TMP_Text _textureText;

        [Header("Resolution Buttons")]
        [SerializeField] private Button _resolutionsLeftButton;
        [SerializeField] private Button _resolutionsRightButton;
        [SerializeField] private TMP_Text _resolutionsText;

        [Header("Toggle Button")]
        [SerializeField] private Button _toggleButton;
        [SerializeField] private TMP_Text _toggleText;

        private readonly string[] GraphicsText = new[] { "Low", "Medium", "High" };
        private readonly string[] ResolutionsText = new[] { "720x360", "1360x768", "1920x1080" }; 

        private int _currentGraphics;
        private int _currentResolution;
        private int _currentSettingsPreset;
        private bool _isToggleOn;
        
        protected override void OnInitialized()
        {
            _textureLeftButton.onClick.AddListener(OnTextureLeftClick);
            _textureRightButton.onClick.AddListener(OnTextureRightClick);
            
            _resolutionsLeftButton.onClick.AddListener(OnResolutionLeftClick);
            _resolutionsRightButton.onClick.AddListener(OnResolutionRightClick);
            
            _globalSettingsLeftButton.onClick.AddListener(OnGlobalSettingsLeftClick);
            _globalSettingsRightButton.onClick.AddListener(OnGlobalSettingsRightClick);
            
            _toggleButton.onClick.AddListener(OnToggleClick);

            UpdateVisuals();
        }

        protected override void OnDisposed()
        {
            _textureLeftButton.onClick.RemoveListener(OnTextureLeftClick);
            _textureRightButton.onClick.RemoveListener(OnTextureRightClick);
            
            _resolutionsLeftButton.onClick.RemoveListener(OnResolutionLeftClick);
            _resolutionsRightButton.onClick.RemoveListener(OnResolutionRightClick);
            
            _globalSettingsLeftButton.onClick.RemoveListener(OnGlobalSettingsLeftClick);
            _globalSettingsRightButton.onClick.RemoveListener(OnGlobalSettingsRightClick);
            
            _toggleButton.onClick.RemoveListener(OnToggleClick);
        }

        private void OnGlobalSettingsLeftClick()
        {
            _currentSettingsPreset = (_currentSettingsPreset - 1 + GraphicsText.Length) % GraphicsText.Length;
            ApplyPreset();
        }

        private void OnGlobalSettingsRightClick()
        {
            _currentSettingsPreset = (_currentSettingsPreset + 1) % GraphicsText.Length;
            ApplyPreset();
        }

        private void ApplyPreset()
        {
            _currentGraphics = _currentSettingsPreset;
            _currentResolution = _currentSettingsPreset;
            UpdateVisuals();
        }

        private void OnTextureLeftClick()
        {
            _currentGraphics = (_currentGraphics - 1 + GraphicsText.Length) % GraphicsText.Length;
            UpdateVisuals();
        }

        private void OnTextureRightClick()
        {
            _currentGraphics = (_currentGraphics + 1) % GraphicsText.Length;
            UpdateVisuals();
        }

        private void OnResolutionLeftClick()
        {
            _currentResolution = (_currentResolution - 1 + ResolutionsText.Length) % ResolutionsText.Length;
            UpdateVisuals();
        }

        private void OnResolutionRightClick()
        {
            _currentResolution = (_currentResolution + 1) % ResolutionsText.Length;
            UpdateVisuals();
        }

        private void OnToggleClick()
        {
            _isToggleOn = !_isToggleOn;
            UpdateVisuals();
        }

        private void UpdateVisuals()
        {
            _textureText.text = GraphicsText[_currentGraphics];
            _resolutionsText.text = ResolutionsText[_currentResolution];
            _globalPresetText.text = GraphicsText[_currentSettingsPreset];
            _toggleText.text = "VSync is : " + (_isToggleOn ? "On" : "Off");
        }
    }
}