using Assets.RefillProject.CodeBase.Data;

namespace Assets.RefillProject.CodeBase.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}