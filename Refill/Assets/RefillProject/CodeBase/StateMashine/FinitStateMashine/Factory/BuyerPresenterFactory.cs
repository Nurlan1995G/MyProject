using Assets.RefillProject.CodeBase.BuyerCar;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Implementation.Factory;
using Assets.RefillProject.CodeBase.StateMashine.Game;
using Assets.RefillProject.CodeBase.StateMashine.Game.Controller;
using System;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Factory
{
    public class BuyerPresenterFactory : IBuyerPresenterFactory
    {
        private readonly RayHandler _rayHandler;

        public BuyerPresenterFactory(RayHandler rayHandler) =>
            _rayHandler = rayHandler ?? throw new ArgumentNullException(nameof(rayHandler));

        public BuyerPresenter Create(BuyerView buyerView, BuyerModel buyerModel) => 
            new BuyerPresenter(new FinitMashineStateFactory(), buyerView, buyerModel, _rayHandler);
    }
}
