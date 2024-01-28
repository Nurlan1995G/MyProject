using Assets.RefillProject.CodeBase.Person;
using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class StopToStation : MonoBehaviour
    {
        public event Action Stopped;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out AgentMove agent))
                agent.StopToBuyerTrigger();
        }
    }
}