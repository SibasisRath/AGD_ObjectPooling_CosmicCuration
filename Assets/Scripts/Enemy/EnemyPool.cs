using CosmicCuration.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    public class EnemyPool
    {
        private EnemyScriptableObject scriptableObject;
        private EnemyView enemyView;

        private List<PooledEnemy> enemys = new();

        public EnemyPool(EnemyScriptableObject enemyScriptableObject, EnemyView enemyView) {
            this.scriptableObject = enemyScriptableObject;
            this.enemyView = enemyView;
        }

        public class PooledEnemy
        {
            public bool isUsed;
            public EnemyController enemyController;
        }

        public EnemyController GetEnemyController() 
        {
            if (enemys.Count > 0)
            {
                PooledEnemy enemy = enemys.Find(item => !item.isUsed);
                if (enemy != null) 
                {
                    enemy.isUsed = true;
                    return enemy.enemyController;
                }
            }
            return CreatePooledEnemy();
        }
        public void ReturnEnemyController(EnemyController enemyController)
        {
            PooledEnemy pooledEnemy = enemys.Find(item => item.enemyController == enemyController);
            pooledEnemy.isUsed = false;
        }

        private EnemyController CreatePooledEnemy()
        {
            PooledEnemy pooledEnemy = new PooledEnemy();
            pooledEnemy.enemyController = new EnemyController(enemyView, scriptableObject.enemyData);
            pooledEnemy.isUsed = true;
            enemys.Add(pooledEnemy);
            return pooledEnemy.enemyController;
        }
    }
}

