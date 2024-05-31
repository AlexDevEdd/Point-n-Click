using GamePlay;
using UI;
using UnityEngine;
using Zenject;

namespace App
{
    public sealed class MenuStateInstaller : MonoInstaller
    {
        [SerializeField] private MenuWindow _menuWindow;
        
        public override void InstallBindings()
        {
            BindMenuWindow();
            BindMenuController();
        }
        
        private void BindMenuWindow() 
            => Container.BindInterfacesAndSelfTo<MenuWindow>()
                .FromInstance(_menuWindow)
                .AsSingle()
                .NonLazy();
        
        private void BindMenuController() =>
            Container.BindInterfacesAndSelfTo<MenuController>()
                .AsSingle()
                .NonLazy();
    }
}