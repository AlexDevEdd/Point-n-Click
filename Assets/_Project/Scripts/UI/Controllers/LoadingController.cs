using App;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GamePlay;
using JetBrains.Annotations;
using Zenject;

namespace UI
{
    [UsedImplicitly]
    public sealed class LoadingController : IInitializable
    {
        private const int FILL_PROGRESS_VALUE = 1;
        
        private readonly IStateMachine _stateMachine;
        private readonly LoadingWindow _window;
        private readonly LoadingConfig _config;
        
        private Tween _fillAmountTween;
        
        public LoadingController(IStateMachine stateMachine,
            GameBalance balance, LoadingWindow window)
        {
            _stateMachine = stateMachine;
            _config = balance.LoadingConfig;
            _window = window;
        }

        public void Initialize()
        {
             _window.UpdateTitle(_config.TitleText);
             _window.Show();
             StartProgress(FILL_PROGRESS_VALUE, _config.Duration);
        }
        
        private void StartProgress(float fillAmount, float duration)
        {
            _fillAmountTween = _window.FillImage
                .DOFillAmount(fillAmount, duration)
                .SetEase(Ease.Linear)
                .OnComplete(OnCompleteProgress);
            
            _fillAmountTween.OnUpdate(FillAmountCallback);
        }
        
        private void OnCompleteProgress()
        {
            _fillAmountTween?.Kill();
            _stateMachine.Enter<GameMenuState>().Forget();
        }
        
        private void FillAmountCallback()
        {
            var progress = _fillAmountTween.ElapsedPercentage();
            var convertedProgress = $"{progress * 100:0.}%";
            _window.UpdateProgress(convertedProgress);
        }
    }
}