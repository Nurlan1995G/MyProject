using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmAgentIdleState : FsmState
    {
        private NavMeshAgent _agent;

        public FsmAgentIdleState(FsmStateMashine fsmStateMashine, NavMeshAgent agent) : base(fsmStateMashine)
        {
            _agent = agent;
        }

        public override void Update()
        {
            Debug.Log("Idle - Update");
            _agent.isStopped = true;
        }
    }
}