using UnityEngine.AI;
using UnityEngine;
using System;

namespace Assets.RefillProject.CodeBase.StateMashine.Game
{
    public class AgentMoving : MonoBehaviour, IAgentMoving
    {
        [SerializeField] private NavMeshAgent _agent;

        private void OnValidate()
        {
            if (_agent == null)
                throw new Exception(nameof(_agent));
        }
        public void MoveAgentToTarget(Vector3 destantion) =>
            _agent.destination = destantion;

        public void AgentStopping() => 
            _agent.isStopped = true;
    }
}
