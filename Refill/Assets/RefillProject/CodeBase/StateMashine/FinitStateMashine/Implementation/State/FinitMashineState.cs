using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using System;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.State
{
    public class FinitMashineState : IFinitMashineState, IChangerState
    {
        private IFinitState _firstState;
        private IFinitState _currentState;

        public void SetFirstState(IFinitState firstState)
        {
            _firstState = firstState ?? throw new ArgumentNullException(nameof(firstState));
            _currentState = _firstState;
        }

        public void Run() =>
            _currentState.Enter();

        public void Stop() =>
            _currentState.Exit();

        public void Update() =>
            _currentState.Update(this);

        public void Apply(IContext context) =>
            _currentState.Apply(this, context);

        public void ChangeState(IFinitState nextState)
        {
            Stop();
            _currentState = nextState;
            Run();
        }
    }
}
