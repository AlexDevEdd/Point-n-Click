using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

namespace GamePlay
{
    [UsedImplicitly]
    public sealed class AgentMovement
    {
        private readonly NavMeshAgent _agent;

        public Vector3 Position => _agent.transform.position;
        public Vector3 Rotation => _agent.transform.rotation.eulerAngles;
        public bool IsMoving => _agent.remainingDistance <= _agent.stoppingDistance;
        
        public AgentMovement(NavMeshAgent agent, GameBalance balance)
        {
            _agent = agent;
            _agent.speed = balance.PlayerConfig.MoveSpeed;
            _agent.angularSpeed = balance.PlayerConfig.RotationSpeed;
        }
        
        public async UniTask Move(Vector3 position, CancellationToken token)
        {
            _agent.SetDestination(position);

            await UniTask.WaitUntil(() => IsMoving, cancellationToken: token);
        }

        public void Warp(Vector3 position, Vector3 rotation)
        {
            _agent.enabled = true;
            _agent.Warp(position);
            _agent.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}