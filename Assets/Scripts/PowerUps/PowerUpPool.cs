using CosmicCuration.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.PowerUps
{
    public class PowerUpPool : GenericObjectPool<PowerUpController>
    {
        private PowerUpData powerUpData;

        public PowerUpController GetPowerUp<T>(PowerUpData powerUpData) where T: PowerUpController
        {
            this.powerUpData = powerUpData;
            return GetItem<PowerUpController>();
        }

        protected override PowerUpController CreateItem<T>()
        {
            if (typeof(T) == typeof(Shield))
            {
                return base.CreateItem<Shield>();
            }

            else if (typeof(T) == typeof(DoubleTurret))
            {
                return base.CreateItem<DoubleTurret>();
            }

            else if (typeof(T) == typeof(RapidFire))
            {
                return base.CreateItem<RapidFire>();
            }
            else
            {
                throw new NotSupportedException("Power Up type is not supported.");
            }
           
        }
    }
}

