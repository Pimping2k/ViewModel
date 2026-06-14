using System;
using Models;
using UnityEngine;

namespace Gameplay
{
    public class ManaComponent : MonoBehaviour
    {
        [SerializeField] private float _maxValue;
        
        private float _currentValue;
        
        public ManaModel ManaModel { get; private set; }

        private void Awake()
        {
            _currentValue = _maxValue;
            ManaModel = new ManaModel(_currentValue, _maxValue);
        }
        
        public void ChangeMana(float value)
        {
            _currentValue += value;
            ManaModel.ChangeMana(value);
        }
    }
}