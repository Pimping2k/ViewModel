using System;
using Additions;

namespace Models
{
    public class ScoreModel : IObservableData
    {
        public int Score { get; private set; }
        
        public event Action Changed;

        public ScoreModel(int initialScore = 0)
        {
            Score = initialScore;
        }

        public void AddScore(int amount)
        {
            Score += amount;
            Changed?.Invoke();
        }
    }
}