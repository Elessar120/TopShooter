using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// handle exit button in menu 
/// </summary>
public class GameExit : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            if (button == null)
                button = GetComponent<Button>();
            button.onClick.AddListener(CloseTheGame);
        }

        private void CloseTheGame()
        {
            Application.Quit();
        }
        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }