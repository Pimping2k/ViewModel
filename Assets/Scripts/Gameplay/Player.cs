using UnityEngine;

namespace Gameplay
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        
        public HealthComponent HealthComponent => _healthComponent;
    }
}