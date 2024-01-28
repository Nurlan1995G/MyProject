using Assets.RefillProject.CodeBase.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.Person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMove : MonoBehaviour
    {
        private const string PointTag = "Point";

        [SerializeField] private float _minDistance = 2f;

        private NavMeshAgent _agent;
        private Transform _petrol;

        private bool _isTrigger;

        public void Cunstruct(Transform petrol) =>
            _petrol = petrol;

        private void Awake() => 
            _agent = GetComponent<NavMeshAgent>();

        public void Update()
        {
            GameObject point = GameObject.FindGameObjectWithTag(PointTag);
            
            PointToMoving(point);

            if(_isTrigger)
                _agent.isStopped = true;
            else if(!_isTrigger)
                _agent.isStopped = false;
        }

        public void StopToBuyerTrigger() => 
            _isTrigger = true;

        private void PointToMoving(GameObject point)
        {
            if (_petrol && point)
                _agent.destination = point.transform.position;
        }

        private bool IsPetrolNotReached() => 
            _agent.transform.position.SqrMagnitudeTo(_petrol.position) >= _minDistance;
    }
}
