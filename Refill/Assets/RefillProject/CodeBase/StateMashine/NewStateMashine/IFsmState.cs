namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public interface IFsmState
    {
        void Enter();
        void Exit();
        void Update();
    }
}