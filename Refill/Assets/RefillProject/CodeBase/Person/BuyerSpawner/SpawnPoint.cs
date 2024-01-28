using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Person.BuyerSpawner
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private float _delay = 5;
       
        public BuyerTypeId BuyerTypeId;
        private IGameFactory _gameFactory;

        public bool IsServiced;
        private float _time = 0;
        private int _countBuyers;

        public void Construct(IGameFactory gameFactory) =>
            _gameFactory = gameFactory;

        private void Update()
        {
            if (IsServiced)
                SpawnDelayd();
        }

        private void SpawnDelayd()
        {
            _time += Time.deltaTime;

            if (_time >= _delay && _countBuyers != 2)
            {
                    Spawn();
                    _time = 0;
                    _countBuyers++;
            }
        }

        public void LoadProgress(PlayerProgress progress) => 
            IsServiced = true;

        public void UpdateProgress(PlayerProgress progress)
        {
        }

        private void Spawn() =>
            _gameFactory.CreateBuyer(BuyerTypeId, transform);
    }
}
