using Assets.RefillProject.CodeBase.StateMashine.Game;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "BuyerData", menuName = "StaticData/Buyer")]
    public class BuyerStaticData : ScriptableObject
    {
        public BuyerTypeId BuyerTypeId;
        public float MoveSpeed; //это относится к модельке
        public BuyerView PrefabBuyerView;
    }
}