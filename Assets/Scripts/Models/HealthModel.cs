using System;
using Additions;

namespace Models
{
    public class HealthModel : IObservableData
    {
        public float Health { get; private set; }
        public float MaxHealth { get; private set; }

        public event Action Changed;

        public void ChangeHealth(float newHealth)
        {
            Health = newHealth;
            Changed?.Invoke();
        }
        
        public HealthModel(float health, float maxHealth)
        {
            Health = health;
            MaxHealth = maxHealth;
        }
    }
}