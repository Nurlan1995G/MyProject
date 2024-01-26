using Assets.RefillProject.CodeBase.Logic;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person
{
    public class BuyerModel : MonoBehaviour
    {
        [SerializeField] private GameObject _pointRay;
        [SerializeField] private float _maxDistance = 3f;
       
        [SerializeField] private StopToStation _stopToStation;

        private AgentMoveToPetrol _agent;
        private RayHandler _rayPoint;

        public int Money { get; set; }

        private void Awake()
        {
            _agent = GetComponent<AgentMoveToPetrol>();
            _rayPoint = new RayHandler(_pointRay, _maxDistance, _agent);

            Money = Random.Range(40, 60);
        }

        private void OnEnable() => 
            _stopToStation.Stoping += OnStoping;

        private void Update()
        {
            if(_rayPoint != null)
                _rayPoint.CreateRaycast();
        }

        private void OnDisable() =>
            _stopToStation.Stoping -= OnStoping;

        private void OnStoping()
        {
            Debug.Log("Можно заправляться");
            _agent.ISBusy = true;
        }
    }
}
