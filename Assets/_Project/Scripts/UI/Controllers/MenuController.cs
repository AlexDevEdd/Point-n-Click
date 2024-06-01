using App;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GamePlay;
using JetBrains.Annotations;
using UI.Views;
using Zenject;

namespace UI.Controllers
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