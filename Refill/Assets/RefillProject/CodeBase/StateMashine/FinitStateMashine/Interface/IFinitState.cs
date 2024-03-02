namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface
{
    public interface IFinitState
    {
        void Enter();
        void Exit();
        void Apply(IChangerState changeState, IContext context);
        void Update(IChangerState changeState);
    }
}