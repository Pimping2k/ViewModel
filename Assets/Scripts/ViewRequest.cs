using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ViewRequest : MonoBehaviour
    {
        [SerializeField] private ViewManager _viewManager;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
                _viewManager.ShowView<UIMainMenuView>();
        }
    }
}