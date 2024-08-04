using CosmicCuration.Bullets;
using CosmicCuration.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool : GenericObjectPool<EnemyController>
    {
        private EnemyScriptableObject scriptableObject;
        private EnemyView enemyView;

        public EnemyPool(EnemyScriptableObject enemyScriptableObject, EnemyView enemyView) {
            this.scriptableObject = enemyScriptableObject;
            this.enemyView = enemyView;
        }

        public EnemyController GetEnemy() => GetItem<EnemyController>();

        protected override EnemyController CreateItem<T>() => new (enemyView, scriptableObject.enemyData);
    }
}

