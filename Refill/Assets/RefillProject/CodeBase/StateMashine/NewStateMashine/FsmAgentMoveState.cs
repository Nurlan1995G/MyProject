using Assets.RefillProject.CodeBase.Person;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmAgentMoveState : FsmState
    {
        private const string FinalPointTag = "Point";

        private NavMeshAgent _agent;
        private bool _isStopTrigger;

        public FsmAgentMoveState(FsmStateMashine fsmStateMashine, NavMeshAgent agent)
            : base(fsmStateMashine)
        {
            _agent = agent;
        }

        public override void Update()
        {
            GameObject finalTarget = GameObject.FindGameObjectWithTag(FinalPointTag);

            if (finalTarget)
                _agent.destination = finalTarget.transform.position;
            
            if (_isStopTrigger)
                FsmStateMashine.SetState<FsmAgentIdleState>();
            else
                FsmStateMashine.SetState<FsmAgentMoveState>();
        }

        public void StopTrigger() => 
            _isStopTrigger = true;
    }
}