using System;
using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private StaminaComponent _staminaComponent;
        [SerializeField] private ScoreComponent _scoreComponent;
        [SerializeField] private ManaComponent _manaComponent;
        
        public HealthComponent HealthComponent => _healthComponent;
        public StaminaComponent StaminaComponent => _staminaComponent;
        public ScoreComponent ScoreComponent => _scoreComponent;
        public ManaComponent ManaComponent => _manaComponent;
    }
}