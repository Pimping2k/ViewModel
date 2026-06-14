using System;
using Additions;

namespace Models
{
    public class StaminaModel : IObservableData
    {
        public float Stamina { get; private set; }
        public float MaxStamina { get; private set; }
        
        public event Action Changed;

        public StaminaModel(float stamina, float maxStamina)
        {
            Stamina = stamina;
            MaxStamina = maxStamina;
        }

        public void ChangeStamina(float newValue)
        {
            Stamina = Math.Clamp(newValue, 0, MaxStamina);
            Changed?.Invoke();
        }
    }
}