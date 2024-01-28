using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person
{
    public class RayHandler
    {
        private const string LayerBuyer = "Buyer";

        private PointRay _pointRay;
        private float _maxDistance;

        public event Action RayHadlerEvent;

        public RayHandler(PointRay pointRay, float maxDistance)
        {
            _pointRay = pointRay;
            _maxDistance = maxDistance;
        }

        public void CreateRaycast()
        {
            Ray ray = new Ray(_pointRay.transform.position, _pointRay.transform.forward);
            Debug.DrawRay(_pointRay.transform.position, _pointRay.transform.forward * _maxDistance, Color.red);

            int layerMaskBuyer = LayerMask.GetMask(LayerBuyer);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance, layerMaskBuyer))
                RayHadlerEvent?.Invoke();
        }
    }
}
