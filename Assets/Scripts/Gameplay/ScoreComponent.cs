using Models;
using UnityEngine;

namespace Gameplay
{
    public class ScoreComponent : MonoBehaviour
    {
        private int _currentValue;
        
        public ScoreModel ScoreModel { get; private set; }

        private void Awake()
        {
            ScoreModel = new ScoreModel();
        }
        
        public void ChangeScore(int value)
        {
            _currentValue += value;
            ScoreModel.AddScore(value);
        }
    }
}