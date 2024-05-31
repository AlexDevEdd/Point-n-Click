using UnityEngine;
using Zenject;

namespace GamePlay
{
    public sealed class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _container;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<LocationLoader>()
                .AsSingle()
                .WithArguments(_container)
                .NonLazy();
        }
    }
}