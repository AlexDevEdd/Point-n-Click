using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class ClickValidator : IInitializable, IDisposable
    {
        private readonly IClickInput _input;
        private readonly Camera _camera;
        
        private readonly ReactiveCommand<Vector3> _newPointCommand;
        private readonly CompositeDisposable _disposable;
        public IReactiveCommand<Vector3> NewPointCommand => _newPointCommand;

        public ClickValidator(IClickInput input)
        {
            _input = input;
            _camera = Camera.main;
            _disposable = new CompositeDisposable();
            _newPointCommand = new ReactiveCommand<Vector3>();
        }
        
        public void Initialize()
        {
            _input.ClickCommand.Subscribe(OnClickCommand).AddTo(_disposable);
        }

        private void OnClickCommand(Vector2 position)
        {
            if (IsClickUnderRectTransform(position)) return;

            var ray = _camera.ScreenPointToRay(position);
            
            if (Physics.Raycast(ray, out var hit, float.MaxValue))
            {
                if (hit.collider.gameObject.TryGetComponent<IClickable>(out var clickable))
                {
                    _newPointCommand.Execute(hit.point);
                }
            }
        }

        private bool IsClickUnderRectTransform(Vector2 position)
        {
            var cursor = new PointerEventData(EventSystem.current)
            {
                position = position
            };

            var objectsHit = new List<RaycastResult>();
            EventSystem.current.RaycastAll(cursor, objectsHit);

            return objectsHit.Any(rr => rr.gameObject.transform is RectTransform);
        }

        public void Dispose()
        {
            _disposable?.Dispose();
            _newPointCommand?.Dispose();
        }
    }
}