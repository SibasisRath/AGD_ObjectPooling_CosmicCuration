using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    // 1. Create class of pooled bullet
    // 2. Create this pool via player service
    // 3. Create a constructor of pool
    public class BulletPool
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;

        private List<PooledBullet> pool = new List<PooledBullet>();


        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject) 
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }
        public class PooledBullet
        {
            public bool isUsed;
            public BulletController bullet;
        }
    }

}
