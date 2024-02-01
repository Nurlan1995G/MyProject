using Assets.RefillProject.CodeBase.Person;
using UnityEngine;

namespace Assets.RefillProject.CodeBase
{
    public class FinalTarget : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BuyerModel model))
                Debug.Log("Final target");
        }
    }
}
