using App;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class LoadingGameState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        
        public LoadingGameState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _sceneLoader.LoadAsync(AssetKeys.LOADING, LoadSceneMode.Single);
        }

        public UniTask Exit() 
            => default;
    }
}