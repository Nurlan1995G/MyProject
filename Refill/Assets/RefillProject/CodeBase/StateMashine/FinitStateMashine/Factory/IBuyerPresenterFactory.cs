using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.StateMashine.Game;
using Assets.RefillProject.CodeBase.StateMashine.Game.Controller;

namespace Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Factory
{
    public interface IBuyerPresenterFactory : IService
    {
        BuyerPresenter Create(BuyerView buyerView, BuyerModel buyerModel);
    }
}