using Assets.RefillProject.CodeBase.BuyerCar.BuyerSpawner;
using Assets.RefillProject.CodeBase.Infrastracture.AssetManagment;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StateMashine.FinitStateMashine.Factory;
using Assets.RefillProject.CodeBase.StateMashine.Game;
using Assets.RefillProject.CodeBase.StateMashine.Game.Controller;
using Assets.RefillProject.CodeBase.StaticData;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.RefillProject.CodeBase.Infrastracture.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
        
        private GameObject _petrolGameObject;

        public GameFactory(IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameObject CreateRefill(Vector3 at) => 
            InstanriateRegistered(AssetAddress.RefillPath, at);

        public BuyerView CreateBuyer(BuyerTypeId buyerTypeId, Transform parent)
        {
            BuyerStaticData buyerData = _staticData.ForBuyer(buyerTypeId);

            BuyerView buyerView = Object.Instantiate(buyerData.PrefabBuyerView, parent.position
                ,Quaternion.identity, parent);

            BuyerPresenter presenter = AllService.Container.Single<IBuyerPresenterFactory>()
                .Create(buyerView, new BuyerModel()); 

            buyerView.Construct(presenter);

            buyerView.GetComponent<NavMeshAgent>().speed = buyerData.MoveSpeed;

            return buyerView;
        }

        public GameObject CreatePetrol(Vector3 at) => 
            _petrolGameObject = InstanriateRegistered(AssetAddress.PetrolPath, at);

        public void CreateHud() =>
            InstanriateRegistered(AssetAddress.HudPath);
        
        public void CreateSpawner(Vector3 at, BuyerTypeId buyerTypeId)
        {
            SpawnPoint spawner = InstanriateRegistered(AssetAddress.Spawner, at).GetComponent<SpawnPoint>();

            spawner.Construct(this, buyerTypeId);
        }

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }

        private GameObject InstanriateRegistered(string gameObjectPath, Vector3 position)
        {
            GameObject gameObject = _assetProvider.Instantiate(gameObjectPath, position);
            RegisteresProgressWatchers(gameObject);

            return gameObject;
        }

        private GameObject InstanriateRegistered(string gameObjectPath)
        {
            GameObject gameObject = _assetProvider.Instantiate(gameObjectPath);
            RegisteresProgressWatchers(gameObject);

            return gameObject;
        }

        private void RegisteresProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
                Register(progressReader);
        }
    }
}
