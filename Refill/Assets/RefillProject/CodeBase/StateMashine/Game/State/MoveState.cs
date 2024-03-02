using UnityEngine;
using System;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.State;

namespace Assets.RefillProject.CodeBase.StateMashine.Game.State
{
    public class MoveState : FiniteStateBase
    {
        private const string FinalPointTag = "Point";
        private IAgentMoving _agentMoving;
        private readonly BuyerView _buyerView;

        public MoveState(IAgentMoving agentMoving, BuyerView buyerView)
        {
            _agentMoving = agentMoving ?? throw new ArgumentNullException(nameof(agentMoving));
            _buyerView = buyerView ?? throw new ArgumentNullException(nameof(buyerView));
        }

        public override void Enter()
        {
            Debug.Log("Enter - MoveState");
        }

        public override void Exit()
        {
            Debug.Log("Exit -MoveState");
        }

        protected override void OnUpdate()
        {
            Debug.Log("MoveState - OnUpdate");

            base.OnUpdate();

            GameObject finalTarget = GameObject.FindGameObjectWithTag(FinalPointTag);

            if (finalTarget != null)
                _agentMoving.MoveAgentToTarget(finalTarget.transform.position);
        }
    }
}
