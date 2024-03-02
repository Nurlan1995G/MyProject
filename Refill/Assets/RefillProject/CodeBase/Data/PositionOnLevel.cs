using System;

namespace Assets.RefillProject.CodeBase.Data
{
    [Serializable]
    public class PositionOnLevel
    {
        public string Level { get; private set; }
        public Vector3Data Position { get; private set; }

        public PositionOnLevel(string initialLevel) => 
            Level = initialLevel;

        public PositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }
    }
}