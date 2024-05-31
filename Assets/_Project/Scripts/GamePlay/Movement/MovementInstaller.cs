using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GamePlay
{
    public sealed class MovementInstaller : MonoInstaller
    {
        [SerializeField] private NavMeshAgent _agent;

        public override void InstallBindings()
        {
            BindMovementController();
            BindClickValidator();
            BindAgentMovement();
            BindMovementPath();
        }

        private void BindMovementController()
        {
            Container.BindInterfacesAndSelfTo<MovementController>()
                .AsSingle()
                .NonLazy();
        }

        private void BindClickValidator()
        {
            Container.BindInterfacesAndSelfTo<ClickValidator>()
                .AsSingle()
                .NonLazy();
        }

        private void BindAgentMovement()
        {
            Container.BindInterfacesAndSelfTo<AgentMovement>()
                .AsSingle()
                .WithArguments(_agent)
                .NonLazy();
        }

        private void BindMovementPath()
        {
            Container.BindInterfacesAndSelfTo<MovementPath>()
                .AsSingle()
                .NonLazy();
        }
    }
}