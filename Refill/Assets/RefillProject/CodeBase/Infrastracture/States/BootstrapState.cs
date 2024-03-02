using Assets.RefillProject.CodeBase.BuyerCar;
using Assets.RefillProject.CodeBase.Infrastracture.AssetManagment;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.Input.Jostick;
using Assets.RefillProject.CodeBase.Services.SaveLoad;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Factory;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";

        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllService _services;

        public BootstrapState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, AllService services)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _services = services;

            RegisterServices();
        }

        public void Enter() => 
            _sceneLoader.Load(Initial, EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() =>
            _gameStateMashine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            RegisterStaticData();

            _services.RegisterSingle<IGameStateMashine>(_gameStateMashine);
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle(InputService());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()
                , _services.Single<IStaticDataService>()));

            RegisterBuyerPresentoryFactory();

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistentProgressService>()
                , _services.Single<IGameFactory>()));
        }

        private void RegisterBuyerPresentoryFactory()
        {
            IBuyerPresenterFactory buyerPresenterFactory = new BuyerPresenterFactory(new RayHandler()); 
            _services.RegisterSingle(buyerPresenterFactory);
        }

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadBuyers();
            _services.RegisterSingle(staticData);
        }

        private static IInputService InputService() =>
            Application.isEditor ? new StandoloneInputService() : new MobileInputService();
    }
}