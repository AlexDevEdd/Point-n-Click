using UnityEngine;
using Zenject;

namespace Common
{
    [CreateAssetMenu(fileName = "ScriptableConfigsInstaller", menuName = "Installers/ScriptableConfigsInstaller")]
    public sealed class ScriptableConfigsInstaller : ScriptableObjectInstaller<ScriptableConfigsInstaller>
    {
        [SerializeField, Space] private GameBalance _balance;

        public override void InstallBindings()
        {
            BindingBalance();
        }
        
        private void BindingBalance()
        {
            Container.BindInterfacesAndSelfTo<GameBalance>()
                .FromInstance(_balance)
                .AsSingle();
        }
    }
}