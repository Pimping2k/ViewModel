using System;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth { get; private set; }
        public HealthModel HealthModel { get; private set; }

        private void Awake()
        {
            CurrentHealth = _maxHealth;
            HealthModel = new HealthModel(CurrentHealth, _maxHealth);
        }

        public void ChangeHealth(float amount)
        {
            CurrentHealth += amount;
            HealthModel.ChangeHealth(CurrentHealth);
        }
    }
}