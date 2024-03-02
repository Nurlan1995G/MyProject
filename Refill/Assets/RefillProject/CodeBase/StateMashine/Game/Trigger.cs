using UnityEngine;

namespace Assets.RefillProject.CodeBase.StateMashine.Game
{
    public class Trigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out BuyerView buyer))
            {
                buyer.SetTransition();  
            }
        }
    }
}
