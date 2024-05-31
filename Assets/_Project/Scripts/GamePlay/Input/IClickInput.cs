using UniRx;
using UnityEngine;

namespace GamePlay
{
    public interface IClickInput
    {
        public IReactiveCommand<Vector2> ClickCommand { get; }
    }
}