using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using System;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Generic
{
    public class Transition<T> : ITransition where T : IContext
    {
        private readonly Func<T, bool> _condition;

        public Transition(IFinitState nextState, Func<T, bool> condition)
        {
            _condition = condition ?? throw new ArgumentNullException(nameof(condition));
            NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
        }

        public IFinitState NextState { get; }

        public bool CanTransit(IContext context) => 
            context is T concreateContext && _condition.Invoke(concreateContext);
    }
}
