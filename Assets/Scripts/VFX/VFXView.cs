using System.Collections.Generic;
using System;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;

        [SerializeField] private List<VFXData> particleSystemMap;
        private ParticleSystem currentPlayingVFX;

        public void SetController(VFXController controllerToSet) => controller = controllerToSet;

        public void ConfigureAndPlay(VFXType type, Vector2 positionToSet)
        {
            this.gameObject.SetActive(true);
            this.gameObject.transform.position = positionToSet;

            foreach (VFXData item in particleSystemMap)
            {
                if (item.type == type)
                {
                    item.particleSystem.gameObject.SetActive(true);
                    currentPlayingVFX = item.particleSystem;
                }
                else
                    item.particleSystem.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (currentPlayingVFX != null)
            {
                if (currentPlayingVFX.isStopped)
                {
                    currentPlayingVFX.gameObject.SetActive(false);
                    currentPlayingVFX = null;
                    this.gameObject.SetActive(false);
                    controller.OnParticleEffectCompleted();
                   
                }
            }
        }

    }

    [Serializable]
    public struct VFXData
    {
        public VFXType type;
        public ParticleSystem particleSystem;
    }
}