using JetBrains.Annotations;
using Zenject;

namespace App
{
    [UsedImplicitly]
    public sealed class AssetProviderInstaller : Installer<AssetProviderInstaller>
    {
        public override void InstallBindings()
        {
            BindAssetProvider();
        }

        private void BindAssetProvider()
        {
            Container.BindInterfacesAndSelfTo<AssetProvider>()
                .AsSingle()
                .NonLazy();
        }
    }
}