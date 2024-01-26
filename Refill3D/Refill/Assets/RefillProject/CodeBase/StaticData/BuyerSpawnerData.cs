using System;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StaticData
{
    [Serializable]
    public class BuyerSpawnerData
    {
        public BuyerTypeId BuyerTypeId;
        public Vector3 Position;

        public BuyerSpawnerData(BuyerTypeId buyerTypeId, Vector3 position)
        {
            BuyerTypeId = buyerTypeId;
            Position = position;
        }
    }
}