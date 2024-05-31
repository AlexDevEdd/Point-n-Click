using GamePlay;
using UnityEngine;
using Zenject;

namespace App
{
    [CreateAssetMenu(fileName = "ScriptableObjectInstaller", menuName = "Installers/ScriptableObjectInstaller")]
    public sealed class ScriptableObjectInstaller : ScriptableObjectInstaller<ScriptableObjectInstaller>
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