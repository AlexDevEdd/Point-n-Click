using Zenject;

namespace App
{
    public sealed class ProjectInstaller : MonoInstaller
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