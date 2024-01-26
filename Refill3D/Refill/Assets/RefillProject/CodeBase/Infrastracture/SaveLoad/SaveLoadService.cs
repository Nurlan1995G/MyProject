using Assets.RefillProject.CodeBase.Data;
using Assets.RefillProject.CodeBase.Infrastracture.Factory;
using Assets.RefillProject.CodeBase.Logic;
using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.PersistentProgress;
using System.IO;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Infrastracture.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string ProgressKey = "Progress";
        private readonly IPersistentProgressService _persistentProgress;
        private readonly IGameFactory _gameFactory;

        public SaveLoadService(IPersistentProgressService persistentProgress, IGameFactory gameFactory)
        {
            _persistentProgress = persistentProgress;
            _gameFactory = gameFactory;
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(ProgressKey)?.ToDeserialize<PlayerProgress>();

            /*if(!File.Exists(ProgressKey))
                return null;

            using FileStream fileStream = File.Open(ProgressKey, FileMode.Open);
            using StreamReader streamReader = new StreamReader(fileStream);
            PlayerProgress playerProgress = streamReader.ReadToEnd().FromJson<PlayerProgress>();

            return playerProgress;*/
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
                progressWriter.UpdateProgress(_persistentProgress.PlayerProgress);

            PlayerPrefs.SetString(ProgressKey, _persistentProgress.PlayerProgress.ToJson());
            


            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //binaryFormatter.Serialize(fileStream, _persistentProgress.PlayerProgress.ToJson());
            //fileStream.Close();

            /*using FileStream fileStream = File.Create("String Path");
            using StreamWriter streamWriter = new StreamWriter(fileStream);
            streamWriter.Write(_persistentProgress.PlayerProgress.ToJson());*/
        }
    }
}