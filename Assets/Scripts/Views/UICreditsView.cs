using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class UICreditsView : BaseView<UICreditsView>
    {
        [SerializeField] private RectTransform _creditsTextRect;
        [SerializeField] private float _scrollSpeed = 50f;
        [SerializeField] private float _startYPosition = -500f;

        private Coroutine _scrollCoroutine;

        protected override void OnShown()
        {
            if (_scrollCoroutine != null)
                StopCoroutine(_scrollCoroutine);

            _scrollCoroutine = StartCoroutine(ScrollCreditsRoutine());
        }

        protected override void OnHide()
        {
            if (_scrollCoroutine != null)
            {
                StopCoroutine(_scrollCoroutine);
                _scrollCoroutine = null;
            }
        }

        private IEnumerator ScrollCreditsRoutine()
        {
            Vector2 currentPos = _creditsTextRect.anchoredPosition;
            currentPos.y = _startYPosition;
            _creditsTextRect.anchoredPosition = currentPos;

            while (true)
            {
                currentPos.y += _scrollSpeed * Time.deltaTime;
                _creditsTextRect.anchoredPosition = currentPos;

                yield return null;
            }
        }
    }
}