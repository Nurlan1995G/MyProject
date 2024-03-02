using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using Assets.RefillProject.CodeBase.StateMashine.Game.Controller;
using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StateMashine.Game
{
    public class BuyerView : MonoBehaviour, IInteractable
    {
       // создать паттерн декоратор для средств и заправки
        [field: SerializeField] public AgentMoving Agent { get; private set; }
        [SerializeField] public LayerMask _layerMask;

        private BuyerPresenter _buyerPresenter;

        public Vector3 CurrentPosition => transform.position;
        public Vector3 Forward => transform.forward;
        public int LayerMask => _layerMask.value;

        public event Action<TransitionBuyer> TriggerStopping;

        private void OnEnable() =>
            _buyerPresenter?.Enable();

        private void OnDisable() =>
            _buyerPresenter?.Disable();

        private void Update() =>
            _buyerPresenter?.Update();

        public void Construct(BuyerPresenter buyerPresenter) =>
            _buyerPresenter = buyerPresenter;

        public void SetTransition()
        {
            Debug.Log("BuyerView - SetTransition");
            TriggerStopping?.Invoke(new TransitionBuyer() { IsStoppingFilling = true });
        }
    }
}
