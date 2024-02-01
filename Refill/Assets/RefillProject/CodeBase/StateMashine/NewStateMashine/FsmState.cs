using UnityEngine;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public abstract class FsmState : IFsmState
    {
        protected readonly FsmStateMashine FsmStateMashine;

        public FsmState(FsmStateMashine fsmStateMashine) =>
            FsmStateMashine = fsmStateMashine;

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }
    }
}