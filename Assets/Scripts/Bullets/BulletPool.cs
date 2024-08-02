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

        private List<PooledBullet> pooledBullets = new List<PooledBullet>();


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

        public BulletController GetBullet()
        {
            if (pooledBullets.Count > 0)
            {
                PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
                if (pooledBullet != null) 
                {
                    pooledBullet.isUsed = true;
                    return pooledBullet.bullet;
                }                
            }
            return CreateNewPooledBullet();
        }

        private BulletController CreateNewPooledBullet()
        {
            PooledBullet pooledBullet = new ();
            pooledBullet.bullet = new (bulletView, bulletScriptableObject);
            pooledBullet.isUsed = true;
            return pooledBullet.bullet;
        }
    }

}
