using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using Assets.RefillProject.CodeBase.StaticData;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.BuyerCar.BuyerSpawner
{
    public class SpawnPoint : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private float _delay = 3;
        [SerializeField] private BuyerTypeId _buyerTypeId;

        private IGameFactory _gameFactory;

        public bool IsServiced { get; private set; }
        private float _time = 0;
        private int _countBuyers;

        private void Update()
        {
            if (IsServiced)
                SpawnDelayd();
        }

        public void Construct(IGameFactory gameFactory, BuyerTypeId buyerTypeId)
        {
            _gameFactory = gameFactory;
            _buyerTypeId = buyerTypeId;
        }

        public void LoadProgress(PlayerProgress progress) =>
            IsServiced = true;

        public void UpdateProgress(PlayerProgress progress)
        {
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

        private void Spawn() =>
            _gameFactory.CreateBuyer(_buyerTypeId, transform);
    }
}
