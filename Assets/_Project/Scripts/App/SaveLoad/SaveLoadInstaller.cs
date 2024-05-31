using JetBrains.Annotations;
using Zenject;

namespace App
{
    [UsedImplicitly]
    public sealed class SaveLoadInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSaveSystem();
            BindGameRepository();
            BindPlayerSaveLoader();
            BindSaveLoadSerializerFactory();
            BindPlayerWayPointsSaveLoader();
        }

        private void BindSaveSystem()
        {
            Container.BindInterfacesAndSelfTo<SaveLoadSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameRepository()
        {
            Container.Bind<GameRepository>()
                .AsSingle()
                .NonLazy();
        }
        private void BindSaveLoadSerializerFactory()
        {
            Container.Bind<SaveLoadSerializerFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerSaveLoader()
        {
            Container.BindInterfacesAndSelfTo<PlayerSaveLoader>()
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerWayPointsSaveLoader()
        {
            Container.BindInterfacesAndSelfTo<PlayerWayPointsSaveLoader>()
                .AsSingle()
                .NonLazy();
        }
    }
}