using Assets.RefillProject.CodeBase.StateMashine.Game;
using System;
using System.Collections.Generic;

namespace Assets.RefillProject.CodeBase.Data
{
    [Serializable]
    public class KillData
    {
        public List<BuyerView> ClearedSpawners = new List<BuyerView>();
    }
}
