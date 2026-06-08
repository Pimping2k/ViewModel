using System;
using Models;
using UnityEngine;
using Views;

namespace Gameplay
{
    public class ViewRequester : MonoBehaviour
    {
        [SerializeField] private ViewManager _viewManager;
        [SerializeField] private Player _player;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _viewManager.ShowView<HealthView, HealthModel>(_player.HealthComponent.HealthModel);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                _player.HealthComponent.ChangeHealth(-5);
            }
        }
    }
}