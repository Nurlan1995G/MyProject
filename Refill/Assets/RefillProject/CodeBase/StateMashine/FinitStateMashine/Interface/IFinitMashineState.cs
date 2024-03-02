namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface
{
    public interface IFinitMashineState : IUpdatable 
    {
        void Run();
        void Apply(IContext context);
        void Stop();
    }
}