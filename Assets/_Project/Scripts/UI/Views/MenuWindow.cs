﻿using UI.Buttons;
using UnityEngine;

namespace UI
{
    public sealed class MenuWindow : MonoBehaviour
    {
        [SerializeField] private SimpleButton _startButton;
        [SerializeField] private Canvas _canvas;
        public SimpleButton StartButton => _startButton;

        public void Show()
        {
            _startButton.SetAvailable(true);
            _canvas.enabled = true;
        }
        
        public void Hide()
        {
            _startButton.SetAvailable(false);
            _canvas.enabled = false;
        }
    }
}