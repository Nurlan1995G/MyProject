namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface
{
    public interface ITransition
    {
        IFinitState NextState { get; }
        bool CanTransit(IContext context);
    }
}