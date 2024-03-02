using UnityEngine;

namespace Assets.RefillProject.CodeBase.StateMashine.Game.State
{
    public class FinalTargetState : MonoBehaviour
    {
        private void Update()
        {

        }

        public void State()
        {
            Debug.Log($"State");
        }

        public void Final()
        {
            Debug.Log("Покупатель дошел до конечной остановки");
        }
    }
}
