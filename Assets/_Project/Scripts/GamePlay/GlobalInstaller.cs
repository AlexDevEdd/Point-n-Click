using App;
using Zenject;

namespace GamePlay
{
    public sealed class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            GameStateMachineInstaller.Install(Container);
            AssetProviderInstaller.Install(Container);
            UnityServicesInstaller.Install(Container);
            SceneLoaderInstaller.Install(Container);
        }
    }
}