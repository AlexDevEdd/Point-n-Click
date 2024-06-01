using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace App
{
    public abstract class StateMachine : IStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _registeredStates = new ();
        private IExitableState _currentState;
        
        public async UniTask Enter<TState>() where TState : class, IState
        {
            var newState = await ChangeState<TState>();
            await newState.Enter();
        }

        public async UniTask Enter<TState, TPayload>(TPayload payload) where TState : class, IPaylodedState<TPayload>
        {
            var newState = await ChangeState<TState>();
            await newState.Enter(payload);
        }

        public void RegisterState<TState>(TState state) where TState : IExitableState =>
            _registeredStates.Add(typeof(TState), state);

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            if(_currentState != null)
                await _currentState.Exit();
      
            var state = GetState<TState>();
            _currentState = state;
      
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState => 
            _registeredStates[typeof(TState)] as TState;
    }
}