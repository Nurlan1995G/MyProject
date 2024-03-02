using UnityEngine;

namespace Assets.RefillProject.CodeBase.BuyerCar
{
    public class EndlessRotation : MonoBehaviour
    {
        private float _speed = 1f;

        private void Update() =>
            transform.rotation *= Quaternion.Euler(0, _speed * Time.deltaTime, 0);
    }
}
