using Assets.RefillProject.CodeBase.Services;

namespace Assets.RefillProject.CodeBase.Logic
{
    public interface IRandomService : IService
    {
        int Next(int min, int max);
    }
}