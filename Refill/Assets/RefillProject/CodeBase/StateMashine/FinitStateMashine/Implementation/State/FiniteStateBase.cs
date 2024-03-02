using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using System;
using System.Collections.Generic;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.State
{
    public abstract class FiniteStateBase : IFinitState
    {
        private List<ITransition> _transitions = new List<ITransition>();

        public virtual void Enter() { }

        public virtual void Exit() { }

        public void Apply(IChangerState changeState, IContext context)
        {
            if (TryGetNextState(context, out IFinitState nextState))
                changeState.ChangeState(nextState);
        }

        public void Update(IChangerState changeState)
        {
            if (TryGetNextState(null, out IFinitState nextState))
                changeState.ChangeState(nextState);

            OnUpdate();
        }

        public void AddTransition(ITransition transition)
        {
            if (transition == null)
                throw new ArgumentNullException(nameof(transition));

            _transitions.Add(transition);
        }

        protected virtual void OnUpdate() { }

        private bool TryGetNextState(IContext context, out IFinitState nextState)
        {
            nextState = null;

            foreach (ITransition transition in _transitions)
            {
                if (transition.CanTransit(context))
                {
                    nextState = transition.NextState;
                    break;
                }
            }

            return nextState != null;
        }
    }
}