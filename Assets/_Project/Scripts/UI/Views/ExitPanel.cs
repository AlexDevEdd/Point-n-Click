using UnityEngine;

namespace UI
{
    public sealed class ExitPanel : MonoBehaviour
    {
        [SerializeField] private SimpleButton _exitButton;
        [SerializeField] private Canvas _canvas;
        public SimpleButton ExitButton => _exitButton;

        public void Show()
        {
            _exitButton.SetAvailable(true);
            _canvas.enabled = true;
        }
        
        public void Hide()
        {
            _exitButton.SetAvailable(false);
            _canvas.enabled = false;
        }
    }
}