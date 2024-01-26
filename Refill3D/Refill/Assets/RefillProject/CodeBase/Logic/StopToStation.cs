using Assets.RefillProject.CodeBase.Person;
using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class StopToStation : MonoBehaviour
    {
        public BoxCollider Collider;

        public event Action Stoping;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Petrol model))
            {
                Debug.Log("OntriggerEnter - Stop");
                //Stoping?.Invoke();
            }
        }
    }
}