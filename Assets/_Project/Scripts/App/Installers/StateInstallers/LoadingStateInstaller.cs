using UI;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class LoadingStateInstaller : MonoInstaller
    {
        [SerializeField] private LoadingWindow _loadingWindow;
        
        public override void InstallBindings()
        {
            BindLoadingWindow();
            BindLoadingController();
        }
        
        private void BindLoadingWindow() 
            => Container.BindInterfacesAndSelfTo<LoadingWindow>()
                .FromInstance(_loadingWindow)
                .AsSingle()
                .NonLazy();
        
        private void BindLoadingController() =>
            Container.BindInterfacesAndSelfTo<LoadingController>()
                .AsSingle()
                .NonLazy();
    }
}