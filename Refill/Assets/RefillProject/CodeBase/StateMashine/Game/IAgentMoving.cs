using UnityEngine;

namespace Assets.RefillProject.CodeBase.StateMashine.Game
{
    public interface IAgentMoving
    {
        void AgentStopping();
        void MoveAgentToTarget(Vector3 destination);
    }
}