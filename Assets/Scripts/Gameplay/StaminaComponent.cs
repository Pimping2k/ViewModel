using Models;
using UnityEngine;

namespace Gameplay
{
    public class StaminaComponent : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        
        private float _currentValue;
        
        public StaminaModel StaminaModel { get; private set; }

        private void Awake()
        {
            _currentValue = _maxValue;
            StaminaModel = new StaminaModel(_currentValue, _maxValue);
        }

        public void ChangeStamina(float value)
        {
            _currentValue += value;
            StaminaModel.ChangeStamina(value);
        }
    }
}