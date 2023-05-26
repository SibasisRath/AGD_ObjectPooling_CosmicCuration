namespace CosmicCuration.PowerUps
{
    public class Shield : PowerUpController
    {
        public Shield(PowerUpView shieldPrefab, float activeDuration) : base(shieldPrefab, activeDuration) { }

        public override void Activate()
        {
            base.Activate();
            GameService.Instance.GetPlayerService().GetPlayerController().ToggleShield(true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            GameService.Instance.GetPlayerService().GetPlayerController().ToggleShield(false);
        }
    } 
}