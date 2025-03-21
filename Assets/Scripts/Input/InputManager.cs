using UnityEngine;
#if UNITY_ANDROID || UNITY_IOS
#endif

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public InputType currentInputType { get; private set; } = InputType.Keyboard; // Default to Keyboard

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 

            // Determine default input type based on platform
#if UNITY_ANDROID || UNITY_IOS
            SetInputType(InputType.Touch);
            
#else
            SetInputType(InputType.Keyboard); // Default for other platforms
#endif
        }
        else
        {
            Destroy(gameObject);
        }

        Debug.Log("Initial input type: " + currentInputType); // Log the initial type
    }

    /// <summary>
    ///   Sets the current input type.
    /// </summary>
    /// <param name="inputType">The input type to set.</param>
    public void SetInputType(InputType inputType)
    {
        currentInputType = inputType;
        Debug.Log("Input type set to: " + currentInputType);
    }
}