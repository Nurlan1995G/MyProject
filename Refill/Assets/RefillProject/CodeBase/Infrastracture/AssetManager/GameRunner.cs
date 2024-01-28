using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.AssetManager
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _gameBootstrapper;

        private void Awake()
        {
            GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();   

            if (gameBootstrapper == null)
                Instantiate(_gameBootstrapper);
        }
    }
}