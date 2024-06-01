using System;
using System.Collections.Generic;
using Common;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class MovementPath: IInitializable, IDisposable
    {
        private readonly ClickValidator _clickValidator;

        private readonly int _maxCountQueue;

        private CompositeDisposable _disposable;
        public ReactiveCommand PointAddedCommand { get; }
        public Queue<Vector3> Path { get; }

        public MovementPath(ClickValidator clickValidator, GameBalance balance)
        {
            _clickValidator = clickValidator;
            _maxCountQueue = balance.PathConfig.MaxCountQueue;
            PointAddedCommand = new ReactiveCommand();
            Path = new Queue<Vector3>(_maxCountQueue);
        }

        void IInitializable.Initialize()
        {
            _disposable = new CompositeDisposable();
            
            _clickValidator.NewPointCommand
                .Subscribe(TryAddNewPoint)
                .AddTo(_disposable);
        }

        private void TryAddNewPoint(Vector3 point)
        {
            if (Path.Count > _maxCountQueue)
                Log.ColorLogDebugOnly($"Queue is fully");
            else
            {
                Path.Enqueue(point);
                    PointAddedCommand?.Execute();
            }
        }

        public bool TryGetNextPoint(out Vector3 point)
        {
            if (Path.Count == 0)
            {
                point = default;
                return false;
            }

            point = Path.Peek();
            return true;
        }

        public void RemovePoint()
        {
            Path.Dequeue();
        }

        public void Dispose()
        {
            _disposable?.Dispose();
            PointAddedCommand?.Dispose();
        }
    }
}