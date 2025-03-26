using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// handle win/lose canvas
/// </summary>
public class GameplayUIController : Element
{
   public GameObject winCanvas;
   public GameObject loseCanvas;
   private PlayerHealth playerHealth;
   [SerializeField] private TextMeshProUGUI weapon1BulletText;
   [SerializeField] private TextMeshProUGUI weapon2BulletText;
   [SerializeField] private TextMeshProUGUI weapon3BulletText;
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

   public void UpdateWeaponAmmoUI(WeaponModel model)
   {
      if (model)
      {
         model.ammoText.text = "\u00d7 " + model.AmmoCount.ToString();
      }
      else
      {
         Debug.LogError("model is null");
      }
   }
}
