using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Factory;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Interface;
using System;
using Assets.RefillProject.CodeBase.BuyerCar;

namespace Assets.RefillProject.CodeBase.StateMashine.Game.Controller
{
    public class BuyerPresenter
    {
        private readonly IFinitMashineState _mashineState;
        private readonly RayHandler _rayHandler;
        private readonly BuyerView _buyerView;
        private readonly BuyerModel _model;

        public BuyerPresenter(FinitMashineStateFactory mashineStateFactory, BuyerView buyerView, BuyerModel model
            ,RayHandler rayHandler)
        {
            if(mashineStateFactory == null) throw new ArgumentNullException(nameof(mashineStateFactory));

            _model = model ?? throw new ArgumentNullException(nameof(model));
            _rayHandler = rayHandler ?? throw new ArgumentNullException(nameof(rayHandler));
            _buyerView = buyerView ?? throw new ArgumentNullException(nameof(buyerView));
            _mashineState = mashineStateFactory.Create(_buyerView.Agent, _buyerView);
        }

        public void Enable() => 
            _mashineState?.Run();

        public void Disable() => 
            _mashineState.Stop();
        
        public void Update()
        {
            _rayHandler.CreateRaycast<BuyerView>(_buyerView.CurrentPosition, _buyerView.Forward, _model.MaxDistance, _buyerView.LayerMask);

            _mashineState?.Update();
        }
    }
}
