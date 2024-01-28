using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class RandomService :  IRandomService
    {
        public int Next(int min, int max) =>
            Random.Range(min, max);
    }
}