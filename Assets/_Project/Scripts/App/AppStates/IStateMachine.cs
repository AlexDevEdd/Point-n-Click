using Cysharp.Threading.Tasks;

namespace App
{
    public interface IStateMachine
    {
        public UniTask Enter<TState>() where TState : class, IState;
        public UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>;
        public void RegisterState<TState>(TState state) where TState : IExitableState;
    }
}