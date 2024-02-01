using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.Person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMove : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private bool _isTrigger;
        private GameObject _point;

        private void Awake() => 
            _agent = GetComponent<NavMeshAgent>();

        public void Update()
        {
            PointToMoving(_point);

            if(_isTrigger)
                _agent.isStopped = true;
            else if(!_isTrigger)
                _agent.isStopped = false;
        }

        public void StopToBuyerTrigger() => 
            _isTrigger = true;

        public void PointToMoving(GameObject point)
        {
            if (point)
                _agent.destination = point.transform.position;
        }
    }
}
