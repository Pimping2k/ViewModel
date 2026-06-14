using System;
using Additions;

namespace Models
{
    public class ManaModel : IObservableData
    {
        public float Mana { get; private set; }
        public float MaxMana { get; private set; }
        
        public event Action Changed;

        public ManaModel(float mana, float maxMana)
        {
            Mana = mana;
            MaxMana = maxMana;
        }

        public void ChangeMana(float newValue)
        {
            Mana = Math.Clamp(newValue, 0, MaxMana);
            Changed?.Invoke();
        }
    }
}