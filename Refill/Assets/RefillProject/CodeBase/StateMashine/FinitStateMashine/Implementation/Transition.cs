using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using System;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation
{
    public sealed class Transition : ITransition
    {
        private readonly Func<IContext, bool> _condition;

        public Transition(IFinitState nextState, Func<IContext, bool> condition)
        {
            NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
        }

        public IFinitState NextState { get; }

        public bool CanTransit(IContext context) => 
            _condition.Invoke(context);
    }
}
