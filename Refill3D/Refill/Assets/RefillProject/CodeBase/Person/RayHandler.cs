using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person
{
    public class RayHandler
    {
        private const string LayerBuyer = "Buyer";

        private float _maxDistance;
        private GameObject _pointRay;
        private AgentMoveToPetrol _agent;

        public RayHandler(GameObject pointRay, float maxDistance, AgentMoveToPetrol agent)
        {
            _pointRay = pointRay;
            _maxDistance = maxDistance;
            _agent = agent;
        }

        public void CreateRaycast()
        {
            Ray ray = new Ray(_pointRay.transform.position, _pointRay.transform.forward);
            Debug.DrawRay(_pointRay.transform.position, _pointRay.transform.forward * _maxDistance, Color.red);

            int layerMaskBuyer = LayerMask.GetMask(LayerBuyer);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance, layerMaskBuyer))
                _agent.ISBusy = true;
            else
                _agent.ISBusy = false;
        }
    }
}
