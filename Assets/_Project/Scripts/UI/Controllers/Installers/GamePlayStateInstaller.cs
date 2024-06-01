using UI.Views;
using UnityEngine;
using Zenject;

namespace UI.Controllers
{
    public sealed class GamePlayStateInstaller : MonoInstaller
    {
        [SerializeField] private ExitPanel _exitPanel;
        
        public override void InstallBindings()
        {
            BindExitPanel();
            BindExitController();
        }
        
        private void BindExitPanel() 
            => Container.BindInterfacesAndSelfTo<ExitPanel>()
                .FromInstance(_exitPanel)
                .AsSingle()
                .NonLazy();
        
        private void BindExitController() =>
            Container.BindInterfacesAndSelfTo<ExitController>()
                .AsSingle()
                .NonLazy();
    }
}