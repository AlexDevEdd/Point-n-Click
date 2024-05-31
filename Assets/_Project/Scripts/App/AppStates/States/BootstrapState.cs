using Cysharp.Threading.Tasks;
using GamePlay;
using JetBrains.Annotations;

namespace App
{
    [UsedImplicitly]
    public sealed class BootstrapState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public BootstrapState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _stateMachine.Enter<LoadingGameState>();
        }

        public UniTask Exit() 
            => default;
    }
}