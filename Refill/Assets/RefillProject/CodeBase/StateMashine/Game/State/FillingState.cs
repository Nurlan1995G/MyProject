using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.State;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StateMashine.Game.State
{
    public class FillingState : FiniteStateBase
    {
        private readonly IAgentMoving _agentMoving;

        public FillingState(IAgentMoving agentMoving)
        {
            _agentMoving = agentMoving ?? throw new System.ArgumentNullException(nameof(agentMoving));
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("FillingState - Enter");
            _agentMoving.AgentStopping();
        }

        public override void Exit() 
        {
            base.Exit();

            Debug.Log("FillingState - Exit");
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            Debug.Log("FillingState - OnUpdate");
        }
    }
}
