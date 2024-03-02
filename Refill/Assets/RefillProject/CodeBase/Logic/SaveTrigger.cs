using Assets.RefillProject.CodeBase.Services;
using Assets.RefillProject.CodeBase.Services.SaveLoad;
using UnityEngine;

namespace Assets.RefillProject.CodeBase.Logic
{
    public class SaveTrigger : MonoBehaviour
    {
        public BoxCollider Collider;

        private ISaveLoadService _saveLoadService;

        private void Awake() => 
            _saveLoadService = AllService.Container.Single<ISaveLoadService>();
            
        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (!Collider)
                return;

            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
        }
    }
}