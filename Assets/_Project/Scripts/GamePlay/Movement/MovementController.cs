using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class MovementController : IInitializable, IDisposable
    {
        private readonly AgentMovement _agentMovement;
        private readonly MovementPath _movementPath;
        
        private CompositeDisposable _disposable;
        private CancellationTokenSource _token;

        public MovementController(AgentMovement agentMovement, MovementPath movementPath)
        {
            _agentMovement = agentMovement;
            _movementPath = movementPath;
        }

        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            _movementPath.PointAddedCommand
                .Subscribe(OnPointAddedCommand)
                .AddTo(_disposable);
        }

        private void OnPointAddedCommand(Unit _)
        {
            StartMove().Forget();
        }
        
        private async UniTaskVoid StartMove()
        {
            if (_agentMovement.IsMoving)
            {
                if (_movementPath.TryGetNextPoint(out var newPoint))
                {
                    await Move(newPoint);
                } 
            }
        }

        private async UniTask Move(Vector3 point)
        {
            _token = new CancellationTokenSource();
            await _agentMovement.Move(point, _token.Token);
            _movementPath.RemovePoint();

            if (_movementPath.TryGetNextPoint(out var newPoint))
            {
                await Move(newPoint); 
            }
        }

        public void Dispose()
        {
            _token?.Cancel();
            _token?.Dispose();
            _disposable?.Dispose();
        }
    }
}