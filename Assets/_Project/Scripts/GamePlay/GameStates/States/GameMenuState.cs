using App;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class GameMenuState : IState
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;
        
        public GameMenuState(IStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public async UniTask Enter()
        {
            await _sceneLoader.LoadAsync(AssetKeys.MENU, LoadSceneMode.Single);
        }
        
        public UniTask Exit() 
            => default;
    }
}