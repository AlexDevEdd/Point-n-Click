using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public class ClickInputReader : ClickMap.IGamePlayActions, IInitializable, IDisposable, IClickInput
    {
        private readonly ClickMap _input;
        private readonly ReactiveCommand<Vector2> _clickCommand;
        public IReactiveCommand<Vector2> ClickCommand => _clickCommand;
        
        public ClickInputReader()
        {
             _input = new ClickMap();
             _clickCommand = new ReactiveCommand<Vector2>();
        }

        public void Initialize()
        {
            _input.Enable();
            _input.GamePlay.SetCallbacks(this);
        }
        
        public void OnClickPosition(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var position = Pointer.current.position.value;
                ClickCommand?.Execute(position);
            }
        }

        public void Dispose()
        {
            _clickCommand?.Dispose();
            _input?.Dispose();
        }
    }
}