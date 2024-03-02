using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.StateMashine.NewStateMashine
{
    public class FsmFillingState : IFsmState
    {
        private float _delay = 0;
        private NavMeshAgent _agent;
        private bool _isFilling;

        public FsmFillingState(NavMeshAgent agent) => 
            _agent = agent;

        public void Enter()
        {
            Debug.Log("Enter - FillingState");
        }

        public void Exit()
        {
            Debug.Log("Exit - FillingState");
        }

        public void Update()
        {
            Debug.Log("FillingState - Update");

            while (_isFilling == false)
            {
                _delay += Time.deltaTime;
                if (_delay <= 3)
                {
                    Debug.Log("Заправка закончена. Автомобиль уезжает!");
                    _delay = 0;
                    _isFilling = true;
                }
            }
        }
    }
}