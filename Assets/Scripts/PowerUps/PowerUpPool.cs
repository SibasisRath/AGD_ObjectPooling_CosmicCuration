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
            return GetItem<T>();
        }

        protected override PowerUpController CreateItem<T>()
        {
            if (typeof(T) == typeof(Shield))
            {
                return new Shield(this.powerUpData);
            }

            else if (typeof(T) == typeof(DoubleTurret))
            {
                return new DoubleTurret(this.powerUpData);
            }

            else if (typeof(T) == typeof(RapidFire))
            {
                return new RapidFire(this.powerUpData);
            }
            else
            {
                throw new NotSupportedException("Power Up type is not supported.");
            }
           
        }
    }
}

