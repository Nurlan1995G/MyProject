using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.BuyerCar
{
    public class RayHandler
    {
        public T CreateRaycast<T>(Vector3 startPoint, Vector3 direction, float maxDistance, int layerMask)
           where T : class, IInteractable
        {
            Debug.DrawRay(startPoint, direction * maxDistance, Color.red);

            if (Physics.Raycast(startPoint, direction, out RaycastHit hitInfo, maxDistance, layerMask))
            {
                if (hitInfo.collider.TryGetComponent(out T interactable))
                    return interactable;
            }

            return null;
        }
    }
}
