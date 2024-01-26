using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.RefillProject.CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "BuyerData", menuName = "StaticData/Buyer")]
    public class BuyerStaticData : ScriptableObject
    {
        public BuyerTypeId BuyerTypeId;

        public float MoveSpeed;

        public AssetReferenceGameObject PrefabReference;
    }
}