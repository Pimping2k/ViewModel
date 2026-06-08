using System;

namespace Models
{
    public class HealthModel
    {
        public float Health { get; private set; }
        public float MaxHealth { get; private set; }

        public event Action HealthChanged;

        public void ChangeHealth(float newHealth)
        {
            Health = newHealth;
            HealthChanged?.Invoke();
        }
        
        public HealthModel(float health, float maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;
        }
    }
}