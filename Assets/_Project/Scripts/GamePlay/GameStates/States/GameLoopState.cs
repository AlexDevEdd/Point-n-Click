using App;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace GamePlay
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