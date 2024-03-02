using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.State;

namespace Assets.RefillProject.CodeBase.StateMashine.Game.State
{
    public class FinalBuyerState : FiniteStateBase
    {
        private IAgentMoving agent;

        public FinalBuyerState(IAgentMoving agent)
        {
            this.agent = agent;
        }
    }
}
