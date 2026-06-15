using Models;
using TMPro;
using UnityEngine;

namespace SubViews
{
    public class ScoreSubView : BaseHudSubView<ScoreModel>
    {
        [SerializeField] private TMP_Text _scoreText;

        protected override void OnInitialized() => RefreshVisual();

        protected override void RefreshVisual()
        {
            _scoreText.text = $"Score: {Model.Score}";
        }
    }
}