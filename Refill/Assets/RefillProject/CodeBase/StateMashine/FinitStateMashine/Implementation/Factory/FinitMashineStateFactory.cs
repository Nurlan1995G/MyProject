using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Build;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using Assets.RefillProject.CodeBase.StateMashine.Game;
using Assets.RefillProject.CodeBase.StateMashine.Game.State;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Factory
{
    public class FinitMashineStateFactory
    {
        private FiniteMashineStateBuild _builder = new FiniteMashineStateBuild();

        public IFinitMashineState Create(IAgentMoving agent,BuyerView buyerView) =>
            _builder
                .AddState(new MoveState(agent, buyerView))
                .AddState(new FillingState(agent))
                .AddState(new FinalBuyerState(agent))
                .AddTransition<MoveState, FillingState, TransitionBuyer>(trans => trans.IsStoppingFilling)
                .SetFirstState<MoveState>()
                .Build();
    }
}
