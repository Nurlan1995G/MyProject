using Assets.RefillProject.CodeBase.CameraLogic;
using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Logic;
using Assets.RefillProject.CodeBase.Person.BuyerSpawner;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.RefillProject.CodeBase.Infrastracture.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private const string InitialPointTag = "InitialPoint";
        private const string BuyerSpawnerTag = "BuyerSpawner";
        private const string PetrolPointTag = "PetrolPoint";

        private readonly GameStateMashine _gameStateMashine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _loadingCurtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMashine gameStateMashine, SceneLoader sceneLoader, LoadingCurtain loadingCurtain, IGameFactory gameFactory, IPersistentProgressService persistentProgress, IStaticDataService staticData)
        {
            _gameStateMashine = gameStateMashine;
            _sceneLoader = sceneLoader;
            _loadingCurtain = loadingCurtain;
            _gameFactory = gameFactory;
            _persistentProgress = persistentProgress;
            _staticData = staticData;
        }

        public void Enter(string sceneName)
        {
            _loadingCurtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _loadingCurtain.Hide();

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReader();

            _gameStateMashine.Enter<GameLoopState>();
        }

        private void InformProgressReader()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_persistentProgress.PlayerProgress);
        }

        private void InitGameWorld()
        {
            InitSpawners();

            GameObject refill = _gameFactory.CreateHero(at: GameObject.FindWithTag(InitialPointTag));

            _gameFactory.CreatePetrol(at: GameObject.FindWithTag(PetrolPointTag));
            _gameFactory.CreateHud();
            
            CameraFollow(refill);
        }

        private void InitSpawners()
        {
            string sceneKey = SceneManager.GetActiveScene().name;
            LevelStaticData levelData = _staticData.ForLevel(sceneKey);

            foreach (BuyerSpawnerData spawnerData in levelData.BuyerSpawners)
                _gameFactory.CreateSpawner(spawnerData.Position, spawnerData.Id, spawnerData.BuyerTypeId);
        }

        private static void CameraFollow(GameObject refill) => 
            Camera.main.GetComponent<CameraFollow>().Follow(refill);
    }
}