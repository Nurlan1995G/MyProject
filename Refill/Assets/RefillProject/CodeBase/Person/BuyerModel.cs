using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person
{
    public class BuyerModel : MonoBehaviour
    {
        [SerializeField] private float _maxDistance;
        [SerializeField] private PointRay _pointRay;

        private RayHandler _rayPoint;

        public int Money { get; set; }

        private void Awake()
        {
            _rayPoint = new RayHandler(_pointRay, _maxDistance);
            Money = Random.Range(40, 60);
        }

        private void Update()
        {
            if (_rayPoint != null)
                _rayPoint.CreateRaycast();
        }
    }
}
