using JetBrains.Annotations;
using Zenject;

namespace App
{
    [UsedImplicitly]
    public sealed class UnityServicesInstaller : Installer<UnityServicesInstaller>
    {
        public override void InstallBindings()
        {
            BindAuthService();
        }

        private void BindAuthService()
        {
            Container.BindInterfacesAndSelfTo<AuthService>()
                .AsSingle()
                .NonLazy();
        }
    }
}