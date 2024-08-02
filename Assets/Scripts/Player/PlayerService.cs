using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;
        private BulletPool bulletPool;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            bulletPool = new(bulletPrefab, bulletScriptableObject);
            playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPool);
            
        }

        public PlayerController GetPlayerController() => playerController;

        public void ReturnBulletToPool(BulletController bulletController)
        {
            bulletPool.ReturnBullet(bulletController);
        }

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();
        
    } 
}