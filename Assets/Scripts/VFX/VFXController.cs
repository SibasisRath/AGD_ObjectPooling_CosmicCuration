using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXController
    {
        private VFXView vfxView;

        public VFXController(VFXView vfxPrefab)
        {
            vfxView = Object.Instantiate(vfxPrefab);
            vfxView.SetController(this);
        }

        public void Configure(VFXType type, Vector2 spawnPosition)
        {
            //vfxView.gameObject.SetActive(true);
            vfxView.ConfigureAndPlay(type, spawnPosition);
        }
        public void OnParticleEffectCompleted()
        {
            //vfxView.gameObject.SetActive(false);
            GameService.Instance.GetVFXService().ReturnVFXToPool(this);
        }
    } 
}