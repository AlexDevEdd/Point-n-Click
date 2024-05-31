using App;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using JetBrains.Annotations;
using Zenject;

namespace UI
{
    [UsedImplicitly]
    public sealed class MenuController : IInitializable
    {
        private readonly IStateMachine _stateMachine;
        private readonly MenuWindow _window;
        
        
        private Tween _fillAmountTween;
        
        public MenuController(IStateMachine stateMachine, MenuWindow window)
        {
            _stateMachine = stateMachine;
            _window = window;
        }

        public void Initialize()
        {
            _window.Show();
            _window.StartButton.AddListener(OnStart);
        }
        
        private void OnStart()
        {
            _window.StartButton.RemoveListener(OnStart);
            _stateMachine.Enter<GameLoopState>().Forget();
        }
    }
}