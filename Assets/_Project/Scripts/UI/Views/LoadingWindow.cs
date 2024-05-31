using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public sealed class LoadingWindow : MonoBehaviour
    {
        private const int START_PROGRESS_VALUE = 0;
        
        [SerializeField] private TMP_Text _progressTitle;
        [SerializeField] private TMP_Text _progressText;
        [SerializeField] private Image _fillImage;
        [SerializeField] private Canvas _canvas;
        
        public Image FillImage => _fillImage;
        
        public void Show()
        {
            ResetProgress();
            _canvas.enabled = true;
        }

        public void UpdateProgress(string progress)
        {
            _progressText.text = progress;
        }

        public void Hide()
        {
            _canvas.enabled = false;
        }

        public void UpdateTitle(string text)
        {
            _progressTitle.text = text;
        }

        private void ResetProgress()
        {
            _fillImage.fillAmount = START_PROGRESS_VALUE;
        }
    }
}