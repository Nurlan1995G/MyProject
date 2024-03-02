using System;
using System.Collections.Generic;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmStateMashine
    {
        private Dictionary<Type,IFsmState> _states;
        
        private IFsmState _currentState { get; set; }

        public FsmStateMashine(NavMeshAgent agent)
        {
            _states = new Dictionary<Type, IFsmState> 
            {
                [typeof(FsmAgentIdleState)] = new FsmAgentIdleState(agent),
                [typeof(FsmAgentMoveState)] = new FsmAgentMoveState(agent),
                [typeof(FsmFillingState)] = new FsmFillingState(agent),
                [typeof(FsmFinalBuyerState)] = new FsmFinalBuyerState(),
            };
        }

        public void Update() =>
            _currentState?.Update();

        public void Enter<TState>() where TState : class, IFsmState
        {
            IFsmState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class,IFsmState
        {
            _currentState?.Exit();

            TState state = GetStated<TState>();
            _currentState = state;
            return state;
        }

        private TState GetStated<TState>() where TState : class,IFsmState =>
            _states[typeof(TState)] as TState;
    }
}