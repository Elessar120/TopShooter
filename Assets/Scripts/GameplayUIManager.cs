using UnityEngine;
/// <summary>
/// handle win/lose canvas
/// </summary>
public class GameplayUIManager : Element
{
   public GameObject winCanvas;
   public GameObject loseCanvas;
   private PlayerHealth playerHealth;
   private void Awake()
   {
      playerHealth = FindFirstObjectByType<PlayerHealth>();
      playerHealth.OnDeath += ActiveLoseCanvas;
      TopShooterApplication.topShooterController.scoreController.OnWin += ActiveWinCanvas;
   }

   private void ActiveWinCanvas()
   {
      winCanvas.gameObject.SetActive(true);
   }

   private void ActiveLoseCanvas()
   {
      loseCanvas.gameObject.SetActive(true);
   }

   private void OnDestroy()
   {
    playerHealth.OnDeath -= ActiveWinCanvas;  
   }
}
