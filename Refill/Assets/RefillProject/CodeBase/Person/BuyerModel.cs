using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person
{
    public class BuyerModel : MonoBehaviour
    {
        [SerializeField] private PointRay _pointRay;
        [SerializeField] private float _maxDistance = 3f;
        private AgentMove _agent;
        private RayHandler _rayPoint;
        

        public int Money { get; set; }

        private void Awake()
        {
            _agent = GetComponent<AgentMove>();
            _rayPoint = new RayHandler(_pointRay, _maxDistance);

            Money = Random.Range(40, 60);
        }

        private void Update()
        {
            if(_rayPoint != null)
                _rayPoint.CreateRaycast();
        }

        private void OnEnable()
        {
            _rayPoint.RayHadlerEvent += OnRayHadler;
        }

        private void OnDisable()
        {
            _rayPoint.RayHadlerEvent -= OnRayHadler;
        }

        private void OnRayHadler() =>
            _agent.StopToBuyerTrigger();
    }
}
