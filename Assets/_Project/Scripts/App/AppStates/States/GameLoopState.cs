using Cysharp.Threading.Tasks;
using GamePlay;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace App
{
    [UsedImplicitly]
    public sealed class GameLoopState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public GameLoopState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _sceneLoader.LoadAsync(AssetKeys.GAME_PLAY, LoadSceneMode.Single);
        }

        public UniTask Exit() 
            => default;
    }
}