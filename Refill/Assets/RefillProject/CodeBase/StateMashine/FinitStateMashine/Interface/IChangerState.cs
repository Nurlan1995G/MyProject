namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface
{
    public interface IChangerState
    {
        void ChangeState(IFinitState nextState);
    }
}