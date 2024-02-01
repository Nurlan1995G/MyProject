using Assets.RefillProject.CodeBase.StateMashine.NewStateMashine;
using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class StopToStation : MonoBehaviour
    {
        public event Action Stopped;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out FsmBuyer agent))
            {
                Debug.Log("OnTriggerEnter - agent.StopTrigger");
            }
        }
    }
}