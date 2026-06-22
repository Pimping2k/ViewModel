using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class UIMainMenuView : BaseView<UIMainMenuView>
    {
        [SerializeField] private Button _settingsView;
        [SerializeField] private Button _creditsView;
        [SerializeField] private Button _exitView;

        protected override void OnInitialized()
        {
            _settingsView.onClick.AddListener(OnSettingsClick);
            _creditsView.onClick.AddListener(OnCreditsClick);
            _exitView.onClick.AddListener(OnExitClick);
        }

        protected override void OnDisposed()
        {
            _settingsView.onClick.RemoveListener(OnSettingsClick);
            _creditsView.onClick.RemoveListener(OnCreditsClick);
            _exitView.onClick.RemoveListener(OnExitClick);
        }

        private void OnSettingsClick()
        {
            ViewManager.ShowView<UISettingsView>();
        }

        private void OnCreditsClick()
        {
            ViewManager.ShowView<UICreditsView>();
        }

        private void OnExitClick()
        {
            Application.Quit();
        }
    }
}