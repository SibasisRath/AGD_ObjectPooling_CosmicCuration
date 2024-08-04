using CosmicCuration.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Bullets
{
    // 1. Create class of pooled bullet
    // 2. Create this pool via player service
    // 3. Create a constructor of pool
    // 4. Get a constructor from pool
    // 5. Return a constructor to pool
    public class BulletPool : GenericObjectPool<BulletController>
    {
        private BulletView bulletView;
        private BulletScriptableObject bulletScriptableObject;

        public BulletPool(BulletView bulletView, BulletScriptableObject bulletScriptableObject) 
        {
            this.bulletView = bulletView;
            this.bulletScriptableObject = bulletScriptableObject;
        }

        public BulletController GetBullet() => GetItem();

        protected override BulletController CreateItem() => new (this.bulletView, this.bulletScriptableObject);
    }

}
