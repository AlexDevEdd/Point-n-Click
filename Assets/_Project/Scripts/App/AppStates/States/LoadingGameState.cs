using Cysharp.Threading.Tasks;
using GamePlay;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace App
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