using Assets.RefillProject.CodeBase.Data;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.Person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPetrol : MonoBehaviour
    {
        private const string PointTag = "Point";

        [SerializeField] private float _minDistance = 2f;
        [SerializeField] private NavMeshAgent _agent;

        public bool ISBusy;

        private Transform _petrol;

        public bool IsBusy { get; set; }

        public void Cunstruct(Transform petrol) =>
            _petrol = petrol;

        public void Update()
        {
            GameObject point = GameObject.FindGameObjectWithTag(PointTag);

            if (_petrol && point && !ISBusy)
                _agent.destination = point.transform.position;

            if (ISBusy)
                _agent.isStopped = true;
            else
                _agent.isStopped = false;
        }

        private bool IsPetrolNotReached() => 
            _agent.transform.position.SqrMagnitudeTo(_petrol.position) >= _minDistance;
    }
}
