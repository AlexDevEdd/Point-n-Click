using JetBrains.Annotations;
using Zenject;

namespace App
{
    [UsedImplicitly]
    public sealed class StatesFactory : IStateFactory
    {
        private readonly IInstantiator _instantiator;

        public StatesFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public TState Create<TState>() where TState : IExitableState => 
            _instantiator.Instantiate<TState>();
    }

    public interface IStateFactory
    {
        public TState Create<TState>() where TState : IExitableState;
    }
}