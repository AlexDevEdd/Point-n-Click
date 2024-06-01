using App;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Zenject;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class GameStateMachine : StateMachine, IInitializable
    {
        private readonly IStateFactory _stateFactory;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }
        
        public void Initialize()
        {
            RegisterState(_stateFactory.Create<BootstrapState>());
            RegisterState(_stateFactory.Create<LoadingGameState>());
            RegisterState(_stateFactory.Create<GameMenuState>());
            RegisterState(_stateFactory.Create<GameLoopState>());
            
            Enter<BootstrapState>().Forget();
        }
    }
}