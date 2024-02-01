using System;
using System.Collections.Generic;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmStateMashine
    {
        private Dictionary<Type,FsmState> _states = new Dictionary<Type,FsmState>();    

        public FsmState CurrentState { get; private set; }

        public void AddState(FsmState state) => 
            _states.Add(state.GetType(), state);

        public void SetState<T>() where T : FsmState
        {
            Type type = typeof(T);

            if (CurrentState != null && CurrentState.GetType() == type)
                return;

            if(_states.TryGetValue(type, out FsmState newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
        }

        public void Update() => 
            CurrentState?.Update();
    }
}