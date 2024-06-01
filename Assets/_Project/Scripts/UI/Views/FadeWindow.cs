using DG.Tweening;
using UnityEngine;

namespace UI.Views
{
    public sealed class FadeWindow : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private float _fadeDuration = 3f;

        private Tween _fadeTween;
        private void Awake()
        {
            Show();
            Hide();
        }

        private void Show()
        {
            _canvasGroup.alpha = 1;
            _canvas.enabled = true;
        }
        
        private void Hide()
        {
            _fadeTween = _canvasGroup.DOFade(0, _fadeDuration)
                .OnComplete(Disable);
        }

        private void Disable()
        {
            _canvas.enabled = false;
            _canvasGroup.alpha = 1;
        }

        private void OnDestroy()
        {
            _fadeTween?.Kill();
        }
    }
}