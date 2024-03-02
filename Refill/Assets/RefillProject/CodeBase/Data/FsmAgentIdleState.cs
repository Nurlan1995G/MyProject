using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmAgentIdleState : IFsmState
    {
        private NavMeshAgent _agent;

        public FsmAgentIdleState( NavMeshAgent agent)
        {
            _agent = agent;
        }

        public void Enter()
        {
            Debug.Log("Мы вошли в AgentIdleState");
        }

        public void Exit()
        {
            Debug.Log("Мы вышли в AgentIdleState");
        }

        public void Update()
        {
            Debug.Log("AgentIdleState - Update");
            _agent.isStopped = true;
        }
    }
}