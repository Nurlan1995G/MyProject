using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Generic;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.State;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using System;
using System.Collections.Generic;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Build
{
    public class FiniteMashineStateBuild
    {
        private Dictionary<string, FiniteStateBase> _states = new Dictionary<string, FiniteStateBase>();
        private FinitMashineState _mashineState;

        public FiniteMashineStateBuild()
        {
            Clear();
        }

        public FiniteMashineStateBuild AddState<T>(T state) where T : FiniteStateBase
        {
            _states[state.GetType().Name] = state;
            return this;
        }

        public FiniteMashineStateBuild AddTransition<TFrom, TTo, TContext>(Func<TContext, bool> condition) 
            where TFrom : FiniteStateBase
            where TTo : FiniteStateBase
            where TContext : IContext
        {
            string from = typeof(TFrom).Name;
            string to = typeof(TTo).Name;

            if (_states.TryGetValue(from, out FiniteStateBase fromState) == false)
                throw new ArgumentNullException($"Состояние {from} не найдено");

            if(_states.TryGetValue(to, out FiniteStateBase toState) == false)
                throw new ArgumentNullException($"Состояние {to} не найдено");

            fromState.AddTransition(new Transition<TContext>(toState, condition));

            return this;
        }

        public FiniteMashineStateBuild SetFirstState<T>() where T : FiniteStateBase
        {
            string name = typeof(T).Name;

            if (_states.TryGetValue(name, out FiniteStateBase state) == false)
                throw new ArgumentNullException($"Состояние {name} не найдено");

            _mashineState.SetFirstState(state); 

            return this;
        }

        public FinitMashineState Build()
        {
            FinitMashineState mashineState = _mashineState;
            Clear();

            return mashineState;
        }

        private void Clear()
        {
            _states.Clear();
            _mashineState = new FinitMashineState();
        }
    }
}
