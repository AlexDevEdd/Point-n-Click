using JetBrains.Annotations;
using Zenject;

namespace App
{
    [UsedImplicitly]
    public sealed class GameStateMachineInstaller : Installer<GameStateMachineInstaller>
    {
        public override void InstallBindings()
        {
            BindStatesFactory();
            BindGameStateMachine();
        }

        private void BindStatesFactory()
        {
            Container.BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle()
                .NonLazy();
        }

        private void BindGameStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>()
                .AsSingle()
                .NonLazy();
        }
    }
}