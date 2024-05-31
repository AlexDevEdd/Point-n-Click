using Zenject;

namespace GamePlay
{
    public class InputInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<ClickInputReader>()
                .AsSingle()
                .NonLazy();
        }
    }
}