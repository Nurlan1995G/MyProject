using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmBuyer : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        
        private FsmStateMashine _mashine;

        private void Awake()
        {
            _mashine = new FsmStateMashine();

            _mashine.AddState(new FsmAgentMoveState(_mashine,_agent));
            _mashine.AddState(new FsmAgentIdleState(_mashine, _agent));

            _mashine.SetState<FsmAgentMoveState>();
        }

        private void Update() =>
            _mashine.Update();
    }
}