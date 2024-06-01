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
    public sealed class ExitController : IInitializable
    {
        private readonly IStateMachine _stateMachine;
        private readonly ISaveSystem _saveSystem;
        private readonly ExitPanel _exitPanel;
        
        private Tween _fillAmountTween;
        
        public ExitController(IStateMachine stateMachine, ISaveSystem saveSystem, ExitPanel exitPanel)
        {
            _stateMachine = stateMachine;
            _saveSystem = saveSystem;
            _exitPanel = exitPanel;
        }

        public void Initialize()
        {
            _exitPanel.Show();
            _exitPanel.ExitButton.AddListener(OnExit);
        }
        
        private void OnExit()
        {
            _exitPanel.Hide();
            _exitPanel.ExitButton.RemoveListener(OnExit);
            _saveSystem.Save();
            _stateMachine.Enter<GameMenuState>().Forget();
        }
    }
}