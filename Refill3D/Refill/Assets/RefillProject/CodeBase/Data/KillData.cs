using Assets.RefillProject.CodeBase.Person;
using System;
using System.Collections.Generic;

namespace Assets.RefillProject.CodeBase.Data
{
    [Serializable]
    public class KillData
    {
        public List<BuyerModel> ClearedSpawners = new List<BuyerModel>();
    }
}
