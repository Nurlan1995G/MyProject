using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmAgentMoveState : IFsmState
    {
        private const string FinalPointTag = "Point";

        private NavMeshAgent _agent;

        public FsmAgentMoveState(NavMeshAgent agent) => 
            _agent = agent;

        public void Enter()
        {
            Debug.Log("Enter - AgetnMoveState");
        }

        public void Exit()
        {
            Debug.Log("Exit - AgetnMoveState");
        }

        public void Update()
        {
            Debug.Log("AgentMoveState - Update");

            GameObject finalTarget = GameObject.FindGameObjectWithTag(FinalPointTag);

            if (finalTarget)
                _agent.destination = finalTarget.transform.position;
        }
    }
}