using System;
using System.Collections.Generic;

namespace UI
{
    public sealed class ButtonStateController
    {
        private readonly Dictionary<ButtonStateType, BaseButtonState> _buttonStatesMap = new();

        public void AddState(ButtonStateType buttonStateType, BaseButtonState state)
        {
            _buttonStatesMap.TryAdd(buttonStateType, state);
        }

        public void SetState(ButtonStateType buttonStateType)
        {
            if (_buttonStatesMap.TryGetValue(buttonStateType, out var state))
                state.SetState();
            else
                throw new Exception($"Undefined button state {buttonStateType}!");
        }
    }
}