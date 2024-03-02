using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;

namespace Assets.RefillProject.CodeBase.StateMashine.Game
{
    public class TransitionBuyer : IContext
    {
        public bool IsStoppingFilling { get; set; } = default;
    }
}
