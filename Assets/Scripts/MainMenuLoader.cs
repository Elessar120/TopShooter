using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/// <summary>
/// load main menu from win/lose menu
/// </summary>
public class MainMenuLoader : MonoBehaviour
{
   [SerializeField] private Button button;

   private void Awake()
   {
      if (button == null)
         button = GetComponent<Button>();
      button.onClick.AddListener(LoadMainMenu);
   }

   private void LoadMainMenu()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
   }

   private void OnDestroy()
   {
      button.onClick.RemoveAllListeners();
   }
}
